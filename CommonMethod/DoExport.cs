using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Data;
using System.Windows.Forms;
namespace CommonMethod
{
    public  class DoExport
    {
        public static bool DoTheExport(DataGridView dgv)
        {

            if (dgv.Rows.Count > 0)
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                DataRow drr;
                //设置列表头 

                foreach (DataGridViewColumn headerCell in dgv.Columns)
                {
                    dt.Columns.Add(headerCell.HeaderText);
                }
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    drr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        drr[i] = item.Cells[i].Value == null?"":item.Cells[i].Value.ToString();
                    }
                    dt.Rows.Add(drr);
                }


                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (app == null)
                {
                    throw new Exception(" Excel无法启动 ");
                }
                app.Visible = true;
                Workbooks wbs = app.Workbooks;
                Workbook wb = wbs.Add(Missing.Value);
                Worksheet ws = (Worksheet)wb.Worksheets[1];

                int cnt = dt.Rows.Count;
                int columncnt = dt.Columns.Count;

                //  *****************获取数据******************** 
                object[,] objData = new Object[cnt + 1, columncnt];   //  创建缓存数据
                //  获取列标题 
                for (int i = 0; i < columncnt; i++)
                {
                    objData[0, i] = dt.Columns[i].ColumnName;
                }
                //  获取具体数据 
                for (int i = 0; i < cnt; i++)
                {
                    System.Data.DataRow dr = dt.Rows[i];
                    for (int j = 0; j < columncnt; j++)
                    {
                        objData[i + 1, j] = dr[j];
                    }
                }

                // ********************* 写入Excel****************** 
                Range r = ws.get_Range(app.Cells[1, 1], app.Cells[cnt + 1, columncnt]);
                r.NumberFormat = " @ ";
                // r = r.get_Resize(cnt+1, columncnt); 
                r.Value2 = objData;
                r.EntireColumn.AutoFit();

                app = null;
                return true;

            }
            else
            {
                MessageBox.Show("没有数据导出！");
                return false;
            
            }


           
        }


    }
}
