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
using CommonWindow.Service;
using KuGuanXiTong.Service;
using CommonMethod;

namespace KuGuanXiTong
{
    public partial class SunHuaiJianGuanLi : CommonControl.CommonTabPage
    {
       
        public SunHuaiJianGuanLi()
        {
            InitializeComponent();
        }

        private void commonPictureButton1_Click(object sender, EventArgs e)
        {
            SunHuaiJianGuanLi_New_dialog shouHou = new SunHuaiJianGuanLi_New_dialog();
            shouHou.User = this.User;
            shouHou.ShowDialog();
        }

        private void SunHuaiJianGuanLi_ShouHou_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categtory cca = new Categtory();
            ShowInGrid(cca.GetBrokenpart(this.textBox1.Text,
                this.textBox2.Text, this.textBox4.Text,
                this.comboBox1.SelectedIndex,
                this.dateTimePicker1.Value.Date.Ticks,
                this.dateTimePicker2.Value.Date.AddDays(1).Ticks));

        }

        public void ShowInGrid(IList i)
        {
            this.commonDataGridView1.Rows.Clear();
            if(i != null)
            {
                int num = 1;
                foreach(BrokenParts o in i)
                {
                    if(o.BrokenType == (long)BrokenParts.Broketype.richangsunhuai)
                    {

                     this.commonDataGridView1.Rows.Add(num,
                        o.GoodsBaseInfoId.GoodsClassCode,
                        o.GoodsBaseInfoId.GoodsName,
                        o.GoodsBaseInfoId.Specifications,
                        o.GoodsBaseInfoId.Material,
                        o.Quantity,
                        o.ReplyPersonId.Dept.DepartmentName,
                        o.ReplyPersonId.Name,
                        o.ResponPerson,
                        BrokenParts.BroketypeName[1],
                        o.IsBrokenInStock == 1 ? "库内损坏":"库外损坏",
                        (new DateTime(o.ReplyTime)).ToString("yyyy-MM-dd HH:mm")
                        );
                    }
                    else if(o.BrokenType == (long)BrokenParts.Broketype.zerensunhuai)
                    {
                        this.commonDataGridView1.Rows.Add(num,
                            o.GoodsBaseInfoId.GoodsClassCode,
                            o.GoodsBaseInfoId.GoodsName,
                            o.GoodsBaseInfoId.Specifications,
                            o.GoodsBaseInfoId.Material,
                            o.Quantity,
                            o.ReplyPersonId.Dept.DepartmentName,
                            o.ReplyPersonId.Name,
                            o.ResponPerson,
                            BrokenParts.BroketypeName[2],
                            o.IsBrokenInStock == 1 ? "库内损坏" : "库外损坏",
                            (new DateTime(o.ReplyTime)).ToString("yyyy-MM-dd HH:mm")
                            );
                    }
                    else if (o.BrokenType == (long)BrokenParts.Broketype.zhiliangsunhuai)
                    {
                        this.commonDataGridView1.Rows.Add(num,
                               o.GoodsBaseInfoId.GoodsClassCode,
                               o.GoodsBaseInfoId.GoodsName,
                               o.GoodsBaseInfoId.Specifications,
                               o.GoodsBaseInfoId.Material,
                               o.Quantity,
                               o.ReplyPersonId.Dept.DepartmentName,
                               o.ReplyPersonId.Name,
                               o.ResponPerson,
                               BrokenParts.BroketypeName[3],
                               o.IsBrokenInStock == 1 ? "库内损坏" : "库外损坏",
                               (new DateTime(o.ReplyTime)).ToString("yyyy-MM-dd HH:mm")
                               );
                    }
                   
                
                num++;
                }
            }
        
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton2_Click(object sender, EventArgs e)
        {
            DoExport.DoTheExport(this.commonDataGridView1);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commonPictureButton5_Click(object sender, EventArgs e)
        {
            PrintDataGridView.PrintTheDataGridView(commonDataGridView1);
        }

        
    }
}
