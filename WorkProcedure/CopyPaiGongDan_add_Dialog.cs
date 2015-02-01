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


namespace WorkProcedure
{
    public partial class CopyPaiGongDan_add_Dialog : Form
    {
        private ISet currentGoods = new HashedSet<RefitWorkGoods>();
        private RefitWork refitWork;
        public RefitWork RefitWork
        {
            get { return refitWork; }
            set { refitWork = value; }
        }

        public CopyPaiGongDan_add_Dialog()
        {
            InitializeComponent();
        }


        private void CopyPaiGongDan_add_Dialog_Load(object sender, EventArgs e)
        {
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
                    commonDataGridView.Rows.Add(i.ToString(), r.GoodsBaseInfoId.GoodsName, r.GoodsBaseInfoId.Specifications, r.GoodsBaseInfoId.Unit, r.GoodsBaseInfoId.Material, r.Count, r.Remark, RefitWorkGoods.ReceiveTypeArray[r.ReceiveType], BaseEntity.YesOrNoArray[r.AddType]);
                    currentGoods.Add(r);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = r;
                }
            }
        }


        private void addItemToDataGridViewObject(IList goodsList)
        {
            if (goodsList != null && goodsList.Count > 0)
            {
                int i = 0;
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
                    commonDataGridView.Rows.Add(i.ToString(), g[1], g[2], g[3], g[4], g[9], "", "未领料", "否", "删除");
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
                    rwg.Count = Convert.ToInt32(g[9]);
                    GoodsBaseInfo gbi = new GoodsBaseInfo();
                    gbi.Id = Convert.ToInt64(g[7]);
                    rwg.GoodsBaseInfoId = gbi;
                    currentGoods.Add(rwg);
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = rwg;
                }
            }
        }
    }
}
