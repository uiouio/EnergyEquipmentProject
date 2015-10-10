using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using CommonWindow;
using System.Collections;
using Iesi.Collections.Generic;
using Iesi.Collections;

namespace GongYiGuanLi
{
    public partial class PaiGongDan_add_Dialog : CommonControl.BaseForm
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
        private ISet currentGoods = new HashedSet<RefitWorkGoods>();
        private bool isNew;
        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }
        private RefitWork refitWork;
        public RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }
        public PaiGongDan_add_Dialog()
        {
            InitializeComponent();
        }

        private void PaiGongDan_add_Dialog_Load(object sender, EventArgs e)
        {
            if (isNew == false)
            {
                this.Text = "编辑派料单";
            }
            label_name.Text = refitWork.CarInfo.Cbi.Name;
            label_type.Text = CarBaseInfo.ModifyType[refitWork.CarInfo.ModidiedType];
            label_carType.Text = refitWork.CarInfo.VehicleType;
            label_carNum.Text = refitWork.CarInfo.PlateNumber;
            addItemToDataGridViewEntity(refitWork.RefitWorkGoodss);
        }

        private void addItemToDataGridViewEntity(ISet<RefitWorkGoods> goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
                foreach (RefitWorkGoods r in goodsList)
                {
                    i++;
                    commonDataGridView.Rows.Add(i.ToString(), r.GoodsBaseInfoId.GoodsName, r.GoodsBaseInfoId.Specifications,r.GoodsBaseInfoId.Unit, r.GoodsBaseInfoId.Material,r.Count, r.Remark, RefitWorkGoods.ReceiveTypeArray[r.ReceiveType],BaseEntity.YesOrNoArray[r.AddType], "删除");
                    currentGoods.Add(r);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = r;
                }
            }
        }

        private void addItemToDataGridViewObject(IList goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = this.commonDataGridView.Rows.Count;
                foreach (Object[] g in goodsList)
                {
                    #region 合并相同货物
                    if (commonDataGridView.Rows != null && commonDataGridView.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in commonDataGridView.Rows)
                        {
                            RefitWorkGoods refitWorkGoods = (RefitWorkGoods)row.Tag;
                            if (refitWorkGoods.GoodsBaseInfoId.Id == Convert.ToInt64(g[7]))
                            {
                                refitWorkGoods.Count += Convert.ToInt32(g[9]);
                                row.Cells[5].Value = refitWorkGoods.Count;
                                if (refitWork.DispatchState == (int)EntityClassLibrary.RefitWork.SaveDispatchingDispatchReceive.Save)
                                {
                                    refitWorkGoods.AddType = (int)RefitWorkGoods.IfAdd.NotAdd;
                                }
                                else
                                {
                                    refitWorkGoods.AddType = (int)RefitWorkGoods.IfAdd.Add;
                                }

                                return;
                            }
                        }
                    }
                    #endregion

                    i++;
                    //wp修改
                    commonDataGridView.Rows.Add(i.ToString(), g[1], g[2], g[4], g[3], g[9], "","未领料","否", "删除");
                    RefitWorkGoods rwg = new RefitWorkGoods();
                    if (refitWork.DispatchState == (int)EntityClassLibrary.RefitWork.SaveDispatchingDispatchReceive.Save)
                    {
                        rwg.AddType = (int)RefitWorkGoods.IfAdd.NotAdd;
                    }
                    else
                    {
                        rwg.AddType = (int)RefitWorkGoods.IfAdd.Add;
                    }
                    rwg.ReceiveType = (int)RefitWorkGoods.ReceiveTypeEnum.NotReceive;
                    rwg.Count = float.Parse(g[9].ToString());
                    GoodsBaseInfo gbi = new GoodsBaseInfo();
                    gbi.Id = Convert.ToInt64(g[7]);
                    rwg.GoodsBaseInfoId = gbi;
                    currentGoods.Add(rwg);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = rwg;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectGoods selectGoods = new SelectGoods();
            selectGoods.IsChooseAll = 1;
            if (selectGoods.ShowDialog() == DialogResult.OK)
            {
                addItemToDataGridViewObject(selectGoods.ReturnIlist);
            }
        }

        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefitWorkGoods rwg = (RefitWorkGoods)commonDataGridView.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 9)
            {
                if (rwg.ReceiveType == (int)RefitWorkGoods.ReceiveTypeEnum.Receive)
                {
                    MessageBox.Show("已领料，不可删除！");
                }
                currentGoods.Remove(rwg);
                commonDataGridView.Rows.RemoveAt(e.RowIndex);
                if (rwg.Id != 0)
                {
                    dispatchService.deleteEntity(rwg);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                refitWork.UserId = this.UserInfo;
                refitWork.FormulateDate = DateTime.Now.Ticks;
                DateTime now = DateTime.Now;
                refitWork.DispatchOrder = "GZ" + now.Year + (now.Month.ToString().Length == 1 ? ("0" + now.Month) : now.Month.ToString()) + (now.Day.ToString().Length == 1 ? ("0" + now.Day) : now.Day.ToString()) + DateTime.Now.ToLongTimeString().Replace(":", "");
                refitWork.DispatchState = (int)EntityClassLibrary.RefitWork.SaveDispatchingDispatchReceive.Save;
            }
            refitWork.FinalUserId = this.UserInfo;
            refitWork.RefitWorkGoodss = null;
            dispatchService.SaveOrUpdateEntity(refitWork);
            //refitWork.RefitWorkGoodss = (Iesi.Collections.Generic.ISet<RefitWorkGoods>)currentGoods;
            foreach (RefitWorkGoods rwg in currentGoods)
            {
                rwg.RefitWorkId = refitWork;
                //dispatchService.SaveOrUpdateEntity(rwg);
            }
            dispatchService.SaveOrUpdateEntity(currentGoods);
            //dispatchService.SaveOrUpdateEntity(refitWork);
            this.DialogResult = DialogResult.OK;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MuBanInfo_Input_Dialog mid = new MuBanInfo_Input_Dialog();
            if (mid.ShowDialog() == DialogResult.OK)
            {
                RefitWorkModel rwm = new RefitWorkModel();
                rwm.FinalUserId = this.UserInfo;
                rwm.UserId = this.UserInfo;
                rwm.Remarks = mid.ModelRemark;
                rwm.Name = mid.ModelName;
                dispatchService.SaveOrUpdateEntity(rwm);
                ISet<RefitWorkModelGoods> rwmgList = new HashedSet<RefitWorkModelGoods>();
                if (currentGoods != null && currentGoods.Count > 0)
                {
                    foreach (RefitWorkGoods g in currentGoods)
                    {
                        RefitWorkModelGoods rwmg = new RefitWorkModelGoods();
                        rwmg.Count = g.Count;
                        rwmg.GoodsBaseInfoId = g.GoodsBaseInfoId;
                        rwmg.Remark = g.Remark;
                        dispatchService.SaveOrUpdateEntity(rwmg);
                        rwmgList.Add(rwmg);
                    }
                }
                rwm.RefitWorkGoodss = rwmgList;
                dispatchService.SaveOrUpdateEntity(rwm);
            }
        }

        private void commonDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow r = commonDataGridView.Rows[e.RowIndex];
            RefitWorkGoods rwg = (RefitWorkGoods)r.Tag;
            if (e.ColumnIndex == 5)
            {
                if (rwg.ReceiveType == (int)RefitWorkGoods.ReceiveTypeEnum.Receive)
                {
                    MessageBox.Show("已领料，不可修改！");
                    r.Cells[5].Value = rwg.Count;
                    return;
                }
                if (refitWork.DispatchState != (int)EntityClassLibrary.RefitWork.SaveDispatchingDispatchReceive.Receive)
                {
                    r.Cells[8].Value = "是";
                    rwg.AddType = (int)RefitWorkGoods.IfAdd.Add;
                    rwg.Count =  Convert.ToInt32(r.Cells[5].Value);
                }
            }

            if (e.ColumnIndex == 6)
            {
                rwg.Remark = r.Cells[6].Value.ToString();
            }
        }
    }
}
