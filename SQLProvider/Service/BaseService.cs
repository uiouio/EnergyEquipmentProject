using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using EntityClassLibrary;
using System.Windows.Forms;
using NHibernate.Engine;
using System.Data;
using System.Data.SqlClient;
using CommonMethod;

namespace SQLProvider.Service
{
    public class BaseService
    {

        ISessionFactory factory ;//= Connection.Connection.getConfiguration().BuildSessionFactory();

        public BaseService()
        {

            factory = Connection.Connection.getConfiguration().BuildSessionFactory();
        
        }
        /// <summary>
        /// 不用了
        /// </summary>
        /// <param name="entity"></param>
        public void saveEntity(BaseEntity entity)
        {
            ISession session = null;
            ITransaction transaction = null;
            // Tell NHibernate that this object should be updated
            try
            {
                session = Connection.Connection.getSessionFactory().OpenSession();
                transaction = session.BeginTransaction();
                session.Save(session.Merge(entity));
                // commit all of the changes to the DB and close the ISession
                transaction.Commit();
            }
            catch(Exception e)
            {
                if (transaction != null && transaction.IsActive)
                {
                    transaction.Rollback();
                }
                throw e;
            }
            finally
            {
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }
        }
        public void deleteEntity(BaseEntity entity)
        {
            ISession session = null;
            ITransaction transaction = null;
            // Tell NHibernate that this object should be updated
            try
            {
                session = Connection.Connection.getSessionFactory().OpenSession();
                transaction = session.BeginTransaction();
                entity.State = (int)BaseEntity.stateEnum.Deleted;
                session.Update(entity);
                //session.Delete(session.Merge(entity));
                // commit all of the changes to the DB and close the ISession
                transaction.Commit();
            }
            catch (Exception e)
            {
                if (transaction != null && transaction.IsActive)
                {
                    transaction.Rollback();
                }
                throw e;
            }
            finally
            {
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }
        }
        /// <summary>
        /// saveOrUpate
        /// </summary>
        /// <param name="entity"></param>
        public BaseEntity SaveOrUpdateEntity(BaseEntity entity)
        {
            ISession session=null;
            ITransaction transaction =null;
            // Tell NHibernate that this object should be updated
            try
            {
                session = Connection.Connection.getSessionFactory().OpenSession();
                transaction = session.BeginTransaction();
                BaseEntity historyEntity = (BaseEntity)Activator.CreateInstance(entity.GetType());
                if (entity.Id != 0)
                {
                    session.Load(historyEntity, entity.Id);
                    //loadEntity(historyEntity, entity.Id);
                    //if (entity.Equals(historyEntity))
                    //{
                    //    return entity;
                    //}
                    historyEntity.Id = 0;
                    historyEntity.State = (int)BaseEntity.stateEnum.Deleted;
                    session.Save(historyEntity);
                }
                session.Clear();
                entity.State = (int)BaseEntity.stateEnum.Normal;
                entity.TimeStamp = DateTime.Now.Ticks;
                entity.HistoryId = historyEntity.Id;
                //BaseEntity mergeEntity = (BaseEntity)session.Merge(entity);
                session.SaveOrUpdate(entity);
                //entity.Id = mergeEntity.Id;
                // commit all of the changes to the DB and close the ISession
                session.Flush();
                transaction.Commit();
                return entity;
                //MessageBox.Show(entity.Id.ToString());
                //MessageBox.Show("保存成功");
            }
            catch (Exception e)
            {
                //if (transaction != null && transaction.IsActive)
                //{
                //    transaction.Rollback();
                //}
                throw e;
            }
            finally
             {
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }
        }

        /// <summary>
        /// saveOrUpate
        /// </summary>
        /// <param name="entity"></param>
        public void SaveOrUpdateEntity(Iesi.Collections.ISet entityList)
        {
            ISession session = null;
            ITransaction transaction = null;
            // Tell NHibernate that this object should be updated
            try
            {
                session = Connection.Connection.getSessionFactory().OpenSession();
                transaction = session.BeginTransaction();
                foreach (BaseEntity entity in entityList)
                {
                    if (entity.Id != 0)
                    {
                        if(this.ExecuteSQL(entity.CheckOldSQL()).Count>0)
                            continue;
                        IList oldIdList = this.ExecuteSQL(entity.SaveOldSQL());
                        if (oldIdList.Count == 1)
                        {
                            object[] o = (object[])oldIdList[0];
                            entity.HistoryId = Convert.ToInt64(o[0]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    session.Clear();
                    entity.State = (int)BaseEntity.stateEnum.Normal;
                    entity.TimeStamp = DateTime.Now.Ticks;
                    //BaseEntity mergeEntity = (BaseEntity)session.Merge(entity);
                    session.SaveOrUpdate(entity);
                    session.Flush();
                    //entity.Id = mergeEntity.Id;
                    // commit all of the changes to the DB and close the ISession
                }
               
                transaction.Commit();
                //MessageBox.Show(entity.Id.ToString());
                //MessageBox.Show("保存成功");
            }
            catch (Exception e)
            {
                //if (transaction != null && transaction.IsActive)
                //{
                //    transaction.Rollback();
                //}
                throw e;
            }
            finally
            {
                if (session != null && session.IsOpen)
                {
                    session.Close();
                }
            }
        }
        public BaseEntity loadEntity(BaseEntity entity, long id)
        {
            try
            {
                ISessionFactory factory = Connection.Connection.getConfiguration().BuildSessionFactory();
                ISession session = factory.OpenSession();
                ITransaction transaction = session.BeginTransaction();
                session.Load(entity, id);
                session.Close();
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 查询实体List
        /// </summary>
        /// <param name="entityNames">实体名称字符串数组</param>
        /// <param name="colAndValue">查询条件二维数组.0为实体名称，1为属性名称，2为属性类型是否为字符串，3为属性值.
        /// 例：new string[,]{{"Course","CourseName",CommonStaticParameter.IS_STRING,"aaa"}}</param>
        /// <returns>查询多个实体的时候返回Object[]的List,查询单个实体的时候返回实体对象数组</returns>
        public ArrayList loadEntityList(List<string> entityNames,string[,] colAndValue)
        {
            try
            {
                ISessionFactory factory = Connection.Connection.getConfiguration().BuildSessionFactory();
                ISession session = factory.OpenSession();
                ITransaction trans = session.BeginTransaction();
                if (entityNames.Count <= 0)
                {
                    return null;
                }
                StringBuilder sql = new StringBuilder("select ").Append("{").Append(entityNames[0]).Append(".*}");
                for (int i = 1; i < entityNames.Count; i++)
                {
                    sql.Append(",{").Append(entityNames[i]).Append(".*}");
                }
                sql.Append(" from ").Append(entityNames[0]);
                for (int i = 1; i < entityNames.Count; i++)
                {
                    sql.Append(",").Append(entityNames[i]);
                }
                if (colAndValue.Length >= 4)
                {
                    sql.Append(" where ");
                    if (!colAndValue[0, 0].Equals(""))
                    {
                        sql.Append(colAndValue[0, 0]).Append(".");
                    }
                    sql.Append(colAndValue[0, 1]).Append("=");
                    if (colAndValue[0, 2].Equals(CommonStaticParameter.IS_STRING))
                    {
                        sql.Append("'").Append(colAndValue[0, 3]).Append("'");
                    }
                    else if (colAndValue[0, 2].Equals(CommonStaticParameter.IS_NOT_STRING))
                    {
                        sql.Append(colAndValue[0, 3]);
                    }
                    for (int i = 1; i < (colAndValue.Length / 4); i++)
                    {
                        sql.Append(" and ");
                        if (!colAndValue[i, 0].Equals(""))
                        {
                            sql.Append(colAndValue[i, 0]).Append(".");
                        }
                        sql.Append(colAndValue[i, 1]).Append("=");
                        if (colAndValue[i, 2].Equals(CommonStaticParameter.IS_STRING))
                        {
                            sql.Append("'").Append(colAndValue[i, 3]).Append("'");
                        }
                        else if (colAndValue[i, 2].Equals(CommonStaticParameter.IS_NOT_STRING))
                        {
                            sql.Append(colAndValue[i, 3]);
                        }
                    }
                }
                ISQLQuery query = session.CreateSQLQuery(sql.ToString());
                for (int i = 0; i < entityNames.Count; i++)
                {
                    query.AddEntity("ClassLibrary." + entityNames[i]);
                }
                ArrayList list = (ArrayList)query.List();
                session.Close();
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ArrayList loadEntityList(List<string> entityNames,string sql)
        {
            try
            {
                ISessionFactory factory = Connection.Connection.getConfiguration().BuildSessionFactory();
                ISession session = factory.OpenSession();
                ITransaction trans = session.BeginTransaction();
                ISQLQuery query = session.CreateSQLQuery(sql);
                for (int i = 0; i < entityNames.Count; i++)
                {
                    query.AddEntity("ClassLibrary." + entityNames[i]);
                }
                ArrayList list = (ArrayList)query.List();
                session.Close();
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public IList loadEntityList(string sql)
        {
            
            ISession session = factory.OpenSession();
            try
            {
                ITransaction trans = session.BeginTransaction();
                IQuery query = session.CreateQuery(sql);
                IList result = query != null ? query.List() : null;
                session.Close();
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (session != null && session.IsOpen)
                {
                    session.Flush();
                    session.Clear();
                    session.Close();
                    //factory.
                    //factory.Close();
                    //factory.Dispose();
                    session.Dispose();
                }
            }

        }
        /// <summary>
        /// 执行sql语句，不是hql
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IList ExecuteSQL(string query)
        {
            IList result = new ArrayList();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = Connection.Connection.getSqlConnection();
                cmd = new SqlCommand(query, conn);

                SqlDataReader rs = cmd.ExecuteReader();
                while (rs.Read())
                {
                    int fieldCount = rs.FieldCount;
                    Object[] values = new Object[fieldCount];
                    for (int i = 0; i < fieldCount; i++)
                        values[i] = rs.GetValue(i);
                    result.Add(values);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        ///执行SQL语句返回DataSet 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet ExecuteSQLReturnDataSet(string query)
        {
            SqlConnection conn = null;
            try
            {
                DataSet datasetTable = new DataSet();
                conn = Connection.Connection.getSqlConnection();
                SqlDataAdapter sqldapter = new SqlDataAdapter(query, conn);
                sqldapter.Fill(datasetTable);
                return datasetTable;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 向表中增加删除修改数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int InsetReMoveUpdateSql(string query)
        {
            int res = 0;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = Connection.Connection.getSqlConnection();
                cmd = new SqlCommand(query, conn);
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }      
            return res;
        }


        /// <summary>
        /// 监测数据库数据更新情况
        /// </summary>
        /// <param name="changeMethod">dependency_OnChange(object sender, SqlNotificationEventArgs e)</param>
        /// <param name="sql">select ID,UserID,[Message] From [dbo].[Messages]</param>
        public static void autoUpdateForm(OnChangeEventHandler changeMethod,String sql)
        {
            try
            {
                using (SqlConnection connection = Connection.Connection.getSqlConnection())
                {
                    //依赖是基于某一张表的,而且查询语句只能是简单查询语句,不能带top或*,同时必须指定所有者,即类似[dbo].[]
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += changeMethod;
                        SqlDataReader objReader = command.ExecuteReader();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
