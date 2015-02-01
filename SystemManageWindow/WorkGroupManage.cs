using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EntityClassLibrary;

namespace SystemManageWindow
{
    public partial class WorkGroupManage : CommonControl.CommonTabPage
    {

        private long workgroupId;
        WorkingGroup workGroup ;
        public WorkGroupManage()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            Service.WorkGroupService OP_DP = new Service.WorkGroupService();
            IList wkgList = OP_DP.getAllWorkGroup();
            listView1.Items.Clear();

            if (wkgList != null && wkgList.Count > 0)
            {
                foreach (WorkingGroup w in wkgList)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = w;
                    item.Text = w.WorkingGroupName;
                    listView1.Items.Add(item);
                }
            }
            ListViewItem item1 = new ListViewItem();
            item1.Tag = null;
            item1.Text = "未分组";
            listView1.Items.Add(item1);
            
        }

        private void WorkGroupManage_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                Service.WorkGroupService OP_DP = new Service.WorkGroupService();
                workGroup = (WorkingGroup)listView1.SelectedItems[0].Tag;
               
                #region 选中未分组
                if (listView1.SelectedItems[0].Text == "未分组")
                {
                    IList user = OP_DP.getUserInfoWithWorkGroup();
                    workgroupId = -1;
                    commonDataGridView1.Rows.Clear();
                    if (user.Count != 0)
                    {
                        foreach (UserInfo uu in user)
                        {
                            if (uu != null)
                            {
                                commonDataGridView1.Rows.Add(uu.UserName, uu.Name, uu.Sex, uu.Age, uu.IdentifyCardNo, uu.Phone, "选择工作组","");
                                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = uu;
                            }
                        }
                    }

                    label1.Text = "未分组人员";
                    button1.Enabled = false;
                }
                #endregion
                #region 选中某分组
                else
                {
                    IList user = (IList)workGroup.UserInfo;
                    workgroupId = workGroup.Id;
                    commonDataGridView1.Rows.Clear();
                    if (user.Count != 0)
                    {
                       foreach (UserInfo uu in user)
                        {
                            if (uu != null)
                            {                       
                                commonDataGridView1.Rows.Add(uu.UserName, uu.Name, uu.Sex, uu.Age, uu.IdentifyCardNo, uu.Phone,"选择工作组","移除");
                                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = uu;
                            }
                        }
                    }
                    label1.Text = workGroup.WorkingGroupName + "    组长是：" + workGroup.WorkingGroupLeader.Name;
                    button1.Enabled = true;
                }
                #endregion
            }
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            AddWorkGroup addWorkGroup = new AddWorkGroup();
            addWorkGroup.ShowDialog();
            UpdateListView();
        }

        private void commonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 选择新工作组
            if (e.ColumnIndex == 6)
            {
                ChangeWorkGroup changeWorkGroup = new ChangeWorkGroup();
                changeWorkGroup.userInfo =(UserInfo) commonDataGridView1.SelectedRows[0].Tag;
                changeWorkGroup.ShowDialog();

                Service.WorkGroupService OP_DP = new Service.WorkGroupService();
                //
                //已有工作组中选择
                //
                if (workgroupId != -1)
                {
                    
                    IList user = OP_DP.getUserInfoByWorkGroupId(workgroupId);
                    commonDataGridView1.Rows.Clear();
                    if (user.Count != 0)
                    {
                        foreach (UserInfo uu in user)
                        {
                            if (uu != null)
                            {
                                commonDataGridView1.Rows.Add(uu.UserName, uu.Name, uu.Sex, uu.Age, uu.IdentifyCardNo, uu.Phone, "选择工作组","移除");
                                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = uu;
                            }
                        }
                    }
                    label1.Text = workGroup.WorkingGroupName + "    组长是：" + workGroup.WorkingGroupLeader.Name;
                    button1.Enabled = true;
                }
                //
                //未选择工作组人员
                //
                else
                {
                    IList user = OP_DP.getUserInfoWithWorkGroup();
                    commonDataGridView1.Rows.Clear();
                    if (user.Count != 0)
                    {
                        foreach (UserInfo uu in user)
                        {
                            if (uu != null)
                            {
                                commonDataGridView1.Rows.Add(uu.UserName, uu.Name, uu.Sex, uu.Age, uu.IdentifyCardNo, uu.Phone, "选择工作组");
                                commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = uu;
                            }
                        }
                    }
                    label1.Text = "未分组人员";
                }
            }
            #endregion
            #region 工作组中移除
            else if (e.ColumnIndex == 7 && commonDataGridView1.CurrentCell.Value == "移除")
            {
                Service.WorkGroupService workGroupService = new Service.WorkGroupService();
                if (workGroup.WorkingGroupLeader == (UserInfo)(commonDataGridView1.SelectedRows[0].Tag))
                {
                    MessageBox.Show("无法删除组长");
                }
                else
                {
                    workGroup.UserInfo.Remove((UserInfo)(commonDataGridView1.SelectedRows[0].Tag));
                    workGroupService.SaveOrUpdateEntity(workGroup);
                }

                //
                //刷新工作
                //
                IList user = (IList)workGroup.UserInfo;
                commonDataGridView1.Rows.Clear();
                if (user.Count != 0)
                {
                    foreach (UserInfo uu in user)
                    {
                        if (uu != null)
                        {
                            commonDataGridView1.Rows.Add(uu.UserName, uu.Name, uu.Sex, uu.Age, uu.IdentifyCardNo, uu.Phone, "选择工作组","移除");
                            commonDataGridView1.Rows[commonDataGridView1.Rows.Count - 1].Tag = uu;
                        }
                    }
                }
                label1.Text = workGroup.WorkingGroupName + "    组长是：" + workGroup.WorkingGroupLeader.Name;
                button1.Enabled = true;
            }
            #endregion
            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.commonDataGridView1.SelectedRows != null)
            {
                UserInfo leader = (UserInfo)commonDataGridView1.SelectedRows[0].Tag;
                if (MessageBox.Show("确定选择 "+leader.Name+"为本组组长？", "提交确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Service.WorkGroupService wks = new Service.WorkGroupService();
                    workGroup.WorkingGroupLeader = leader;
                    wks.SaveOrUpdateEntity(workGroup);
                    label1.Text = workGroup.WorkingGroupName + "    组长是：" + workGroup.WorkingGroupLeader.Name;                }
            }
            UpdateListView();
        }


    }
}
