using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntityClassLibrary;
using System.Collections;

namespace GongYiGuanLi
{
    public partial class PaiGongDan : CommonControl.CommonTabPage
    {
        Service.DispatchService dispatchService = new Service.DispatchService();
        public PaiGongDan()
        {
            InitializeComponent();
        }
        public override void reFreshAllControl()
        {
            refreshDidGiView();
            refreshToDoGiView();
        }
        private void refreshDidGiView()
        {
            IList refitWorkList = dispatchService.getAllRefitWork("", "", "", 0, 999999999999999999); 
            initialDidGridView(refitWorkList);
        }
        private void refreshToDoGiView()
        {
            IList contractsList = dispatchService.getAllContractAndCarInfo("", 0, 999999999999999999);
            initialToDoGridView(contractsList);
        }
        private void initialToDoGridView(IList contracts)
        {
            commonDataGridView.Rows.Clear();
            if (contracts != null && contracts.Count > 0)
            {
                int i = 0;
                foreach (Object[] o in contracts)
                {
                    i++;
                    ModificationContract mc  = (ModificationContract)o[0];
                    CarBaseInfo ci = (CarBaseInfo)o[1];
                    commonDataGridView.Rows.Add(i, mc.ContractNo, CarBaseInfo.ModifyType[ci.ModidiedType], mc.PaymentMethod, ModificationContract.PaymentStateArray[mc.PaymentState], "查看", "派料");
                    commonDataGridView.Rows[commonDataGridView.Rows.Count - 1].Tag = o;
                }
            }
        }
        private void initialDidGridView(IList refitWork)
        {
            commonDataGridView1.Rows.Clear();
            if (refitWork != null && refitWork.Count > 0)
            {
                int i = 0;
                foreach (RefitWork rw in refitWork)
                {
                    i++;
                    DateTime date = new DateTime(rw.FormulateDate);
                    commonDataGridView1.Rows.Add(i,rw.ContractNo,rw.DispatchOrder,RefitWork.DispatchStateArray[rw.DispatchState],rw.WorkingGroupId==null?"":rw.WorkingGroupId.WorkingGroupName,rw.UserId.Name,rw.FinalUserId.Name,date.ToLongDateString(), "编辑", "删除");
                    commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = rw;
                }
            }
        }
        private void PaiGongDan_Load(object sender, EventArgs e)
        {
            reFreshAllControl();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            IList contractsList = dispatchService.getAllContractAndCarInfo(textBox1.Text, start_dateTimePicker.Value.Date.Ticks, end_dateTimePicker.Value.Date.Ticks+new DateTime(1,1,2).Date.Ticks);
            initialToDoGridView(contractsList);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            IList refitWorkList = dispatchService.getAllRefitWork(textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value.Date.Ticks, dateTimePicker2.Value.Date.Ticks + new DateTime(1, 1, 2).Date.Ticks);
            initialDidGridView(refitWorkList);
        }
        private void commonDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Object[] o = (Object[])commonDataGridView.Rows[e.RowIndex].Tag;
            ModificationContract mc = (ModificationContract)o[0];
            CarBaseInfo ci = (CarBaseInfo)o[1];
            if (e.ColumnIndex == 5)
            {
                PaiGongDan_view_Dialog pvd = new PaiGongDan_view_Dialog();
                pvd.CarInfo = ci;
                pvd.ShowDialog();
            }
            else if (e.ColumnIndex == 6)
            {
                PaiGongDan_select_Dialog pvd = new PaiGongDan_select_Dialog();
                pvd.UserInfo = this.User;
                RefitWork refitWork = new RefitWork();
                refitWork.CarInfo = ci;
                refitWork.ContractNo = mc.ContractNo;
                pvd.RefiWork = refitWork;
                if (pvd.ShowDialog() == DialogResult.OK)
                {
                    refreshDidGiView();
                    refreshToDoGiView();
                }
            }
        }
        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RefitWork rw = (RefitWork)commonDataGridView1.Rows[e.RowIndex].Tag;
            if (e.ColumnIndex == 8)
            {
                PaiGongDan_add_Dialog yvd = new PaiGongDan_add_Dialog();
                yvd.IsNew = false;
                yvd.RefitWork = rw;
                yvd.UserInfo = this.User;
                if (yvd.ShowDialog() == DialogResult.OK)
                {
                    refreshDidGiView();
                }
            }
            else if (e.ColumnIndex == 9)
            {
                if (rw.DispatchState > (int)RefitWork.SaveDispatchingDispatchReceive.Save)
                {
                    MessageBox.Show("已派工，不可删除！");
                    return;
                }
                if (MessageBox.Show("确定要删除？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        dispatchService.deleteEntity(rw);
                    }

                    catch (Exception exc)
                    {
                        SQLProvider.Service.CommonService.saveExceptionEntity(exc);
                    }
                    MessageBox.Show("删除成功！");
                    commonDataGridView1.Rows.RemoveAt(e.RowIndex);
                    refreshToDoGiView();
                }
            }
        }
    }
}
