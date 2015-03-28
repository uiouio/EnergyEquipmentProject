namespace CustomManageWindow
{
    partial class CustomServiceQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomServiceQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton2 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton3 = new CommonControl.CommonPictureButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.commonDataGridView1 = new CommonControl.CommonDataGridView();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车牌号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.车主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.联系电话 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出厂时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.回访次数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看回访记录 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.新建回访记录 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commonDataGridView2 = new CommonControl.CommonDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.致电时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.回访人 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.问题 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.处理意见 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查看 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // commonFlowLayoutPanel1
            // 
            this.commonFlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel1.BackgroundImage")));
            this.commonFlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton2);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton3);
            this.commonFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel1.Name = "commonFlowLayoutPanel1";
            this.commonFlowLayoutPanel1.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel1.TabIndex = 13;
            // 
            // commonPictureButton2
            // 
            this.commonPictureButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonPictureButton2.BackgroundImage")));
            this.commonPictureButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton2.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton2.Name = "commonPictureButton2";
            this.commonPictureButton2.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton2.NonSelectBackGroundImage")));
            this.commonPictureButton2.SelectBackGroundImage = global::CustomManageWindow.Properties.Resources.打印select;
            this.commonPictureButton2.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton2.TabIndex = 1;
            this.commonPictureButton2.TabStop = false;
            this.commonPictureButton2.ToolTipString = "打印";
            this.commonPictureButton2.Click += new System.EventHandler(this.commonPictureButton2_Click);
            // 
            // commonPictureButton3
            // 
            this.commonPictureButton3.BackgroundImage = global::CustomManageWindow.Properties.Resources.导出;
            this.commonPictureButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton3.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton3.Name = "commonPictureButton3";
            this.commonPictureButton3.NonSelectBackGroundImage = global::CustomManageWindow.Properties.Resources.导出;
            this.commonPictureButton3.SelectBackGroundImage = global::CustomManageWindow.Properties.Resources.导出select;
            this.commonPictureButton3.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton3.TabIndex = 2;
            this.commonPictureButton3.TabStop = false;
            this.commonPictureButton3.ToolTipString = "导出";
            this.commonPictureButton3.Click += new System.EventHandler(this.commonPictureButton3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.linkLabel5);
            this.groupBox1.Controls.Add(this.commonDataGridView1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.linkLabel4);
            this.groupBox1.Controls.Add(this.linkLabel3);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(73, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 245);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "车辆查询";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(346, 106);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(53, 12);
            this.linkLabel5.TabIndex = 17;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "所有车辆";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // commonDataGridView1
            // 
            this.commonDataGridView1.AllowUserToAddRows = false;
            this.commonDataGridView1.AllowUserToDeleteRows = false;
            this.commonDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.commonDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.commonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.车牌号,
            this.车型,
            this.车主,
            this.联系电话,
            this.出厂时间,
            this.回访次数,
            this.查看回访记录,
            this.新建回访记录});
            this.commonDataGridView1.Location = new System.Drawing.Point(6, 127);
            this.commonDataGridView1.MultiSelect = false;
            this.commonDataGridView1.Name = "commonDataGridView1";
            this.commonDataGridView1.RowHeadersVisible = false;
            this.commonDataGridView1.RowTemplate.Height = 23;
            this.commonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView1.Size = new System.Drawing.Size(790, 108);
            this.commonDataGridView1.TabIndex = 16;
            this.commonDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView1_CellContentClick);
            // 
            // 序号
            // 
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.Width = 60;
            // 
            // 车牌号
            // 
            this.车牌号.HeaderText = "车牌号";
            this.车牌号.Name = "车牌号";
            this.车牌号.Width = 80;
            // 
            // 车型
            // 
            this.车型.HeaderText = "车型";
            this.车型.Name = "车型";
            this.车型.Width = 80;
            // 
            // 车主
            // 
            this.车主.HeaderText = "车主";
            this.车主.Name = "车主";
            this.车主.Width = 80;
            // 
            // 联系电话
            // 
            this.联系电话.HeaderText = "电话";
            this.联系电话.Name = "联系电话";
            // 
            // 出厂时间
            // 
            this.出厂时间.HeaderText = "出厂时间";
            this.出厂时间.Name = "出厂时间";
            // 
            // 回访次数
            // 
            this.回访次数.HeaderText = "次数";
            this.回访次数.Name = "回访次数";
            this.回访次数.Width = 80;
            // 
            // 查看回访记录
            // 
            this.查看回访记录.HeaderText = "查看";
            this.查看回访记录.Name = "查看回访记录";
            this.查看回访记录.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.查看回访记录.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 新建回访记录
            // 
            this.新建回访记录.HeaderText = "新建回访记录";
            this.新建回访记录.Name = "新建回访记录";
            this.新建回访记录.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.新建回访记录.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(604, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "查询";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(246, 106);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(65, 12);
            this.linkLabel4.TabIndex = 14;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "出厂一年内";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(170, 106);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(65, 12);
            this.linkLabel3.TabIndex = 14;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "出厂一月内";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(88, 106);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(65, 12);
            this.linkLabel2.TabIndex = 13;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "出厂一周内";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(23, 106);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "出厂1天";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(316, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "至";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(348, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "出厂日期范围:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(424, 31);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "电话";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(261, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "车主";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "冀D";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "车牌号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.commonDataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(73, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(802, 334);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "回访记录";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(604, 13);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "查询";
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(68, 29);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(121, 21);
            this.textBox4.TabIndex = 19;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox4_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "回访人";
            // 
            // commonDataGridView2
            // 
            this.commonDataGridView2.AllowUserToAddRows = false;
            this.commonDataGridView2.AllowUserToDeleteRows = false;
            this.commonDataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.commonDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.commonDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.致电时间,
            this.回访人,
            this.问题,
            this.处理意见,
            this.备注,
            this.查看});
            this.commonDataGridView2.Location = new System.Drawing.Point(6, 68);
            this.commonDataGridView2.MultiSelect = false;
            this.commonDataGridView2.Name = "commonDataGridView2";
            this.commonDataGridView2.RowHeadersVisible = false;
            this.commonDataGridView2.RowTemplate.Height = 23;
            this.commonDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView2.Size = new System.Drawing.Size(790, 257);
            this.commonDataGridView2.TabIndex = 17;
            this.commonDataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView2_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "序号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "车牌号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // 致电时间
            // 
            this.致电时间.HeaderText = "致电时间";
            this.致电时间.Name = "致电时间";
            // 
            // 回访人
            // 
            this.回访人.HeaderText = "回访人";
            this.回访人.Name = "回访人";
            // 
            // 问题
            // 
            this.问题.HeaderText = "问题";
            this.问题.Name = "问题";
            // 
            // 处理意见
            // 
            this.处理意见.HeaderText = "处理意见";
            this.处理意见.Name = "处理意见";
            // 
            // 备注
            // 
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // 查看
            // 
            this.查看.HeaderText = "查看";
            this.查看.Name = "查看";
            this.查看.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.查看.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CustomServiceQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Name = "CustomServiceQuery";
            this.Load += new System.EventHandler(this.CustomServiceQuery_Load);
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton commonPictureButton2;
        private CommonControl.CommonPictureButton commonPictureButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CommonControl.CommonDataGridView commonDataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CommonControl.CommonDataGridView commonDataGridView2;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 致电时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 回访人;
        private System.Windows.Forms.DataGridViewTextBoxColumn 问题;
        private System.Windows.Forms.DataGridViewTextBoxColumn 处理意见;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewLinkColumn 查看;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车牌号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 车主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 联系电话;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出厂时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 回访次数;
        private System.Windows.Forms.DataGridViewLinkColumn 查看回访记录;
        private System.Windows.Forms.DataGridViewLinkColumn 新建回访记录;
    }
}