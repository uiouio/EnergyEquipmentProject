namespace CustomManageWindow
{
    partial class JiHuaGuanLi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JiHuaGuanLi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.add = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton2 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton5 = new CommonControl.CommonPictureButton(this.components);
            this.commonDataGridView1 = new CommonControl.CommonDataGridView();
            this.checks = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delCol = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gongHuoShangButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comapnyLabel = new System.Windows.Forms.Label();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonFlowLayoutPanel1
            // 
            this.commonFlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel1.BackgroundImage")));
            this.commonFlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel1.Controls.Add(this.add);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton2);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton5);
            this.commonFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel1.Name = "commonFlowLayoutPanel1";
            this.commonFlowLayoutPanel1.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel1.TabIndex = 1;
            // 
            // add
            // 
            this.add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("add.BackgroundImage")));
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.Location = new System.Drawing.Point(0, 3);
            this.add.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.add.Name = "add";
            this.add.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("add.NonSelectBackGroundImage")));
            this.add.SelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("add.SelectBackGroundImage")));
            this.add.Size = new System.Drawing.Size(66, 61);
            this.add.TabIndex = 15;
            this.add.TabStop = false;
            this.add.ToolTipString = null;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // commonPictureButton2
            // 
            this.commonPictureButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonPictureButton2.BackgroundImage")));
            this.commonPictureButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton2.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton2.Name = "commonPictureButton2";
            this.commonPictureButton2.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton2.NonSelectBackGroundImage")));
            this.commonPictureButton2.SelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton2.SelectBackGroundImage")));
            this.commonPictureButton2.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton2.TabIndex = 17;
            this.commonPictureButton2.TabStop = false;
            this.commonPictureButton2.ToolTipString = null;
            this.commonPictureButton2.Click += new System.EventHandler(this.commonPictureButton2_Click);
            // 
            // commonPictureButton5
            // 
            this.commonPictureButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonPictureButton5.BackgroundImage")));
            this.commonPictureButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton5.Location = new System.Drawing.Point(0, 131);
            this.commonPictureButton5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton5.Name = "commonPictureButton5";
            this.commonPictureButton5.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton5.NonSelectBackGroundImage")));
            this.commonPictureButton5.SelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton5.SelectBackGroundImage")));
            this.commonPictureButton5.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton5.TabIndex = 16;
            this.commonPictureButton5.TabStop = false;
            this.commonPictureButton5.ToolTipString = null;
            this.commonPictureButton5.Click += new System.EventHandler(this.commonPictureButton5_Click);
            // 
            // commonDataGridView1
            // 
            this.commonDataGridView1.AllowUserToAddRows = false;
            this.commonDataGridView1.AllowUserToDeleteRows = false;
            this.commonDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.commonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.commonDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.commonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checks,
            this.index,
            this.name,
            this.contact,
            this.phone,
            this.date,
            this.state,
            this.editCol,
            this.delCol});
            this.commonDataGridView1.Location = new System.Drawing.Point(314, 144);
            this.commonDataGridView1.MultiSelect = false;
            this.commonDataGridView1.Name = "commonDataGridView1";
            this.commonDataGridView1.RowHeadersVisible = false;
            this.commonDataGridView1.RowTemplate.Height = 23;
            this.commonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView1.Size = new System.Drawing.Size(803, 450);
            this.commonDataGridView1.TabIndex = 2;
            this.commonDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView1_CellContentClick);
            this.commonDataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView1_CellContentDoubleClick);
            // 
            // checks
            // 
            this.checks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.checks.HeaderText = " ";
            this.checks.Name = "checks";
            this.checks.Width = 20;
            // 
            // index
            // 
            this.index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.index.HeaderText = "序号";
            this.index.Name = "index";
            this.index.Width = 60;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.name.HeaderText = "加盟商名称";
            this.name.Name = "name";
            this.name.Width = 120;
            // 
            // contact
            // 
            this.contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.contact.HeaderText = "联系人";
            this.contact.Name = "contact";
            this.contact.Width = 120;
            // 
            // phone
            // 
            this.phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.phone.HeaderText = "联系方式";
            this.phone.Name = "phone";
            this.phone.Width = 120;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.date.HeaderText = "发货日期";
            this.date.Name = "date";
            this.date.Width = 120;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.state.HeaderText = "执行进度";
            this.state.Name = "state";
            this.state.Width = 120;
            // 
            // editCol
            // 
            this.editCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.editCol.HeaderText = " ";
            this.editCol.Name = "editCol";
            this.editCol.Width = 60;
            // 
            // delCol
            // 
            this.delCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.delCol.HeaderText = " ";
            this.delCol.Name = "delCol";
            this.delCol.Width = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gongHuoShangButton);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.comapnyLabel);
            this.groupBox1.Location = new System.Drawing.Point(244, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计划管理查询";
            // 
            // gongHuoShangButton
            // 
            this.gongHuoShangButton.Location = new System.Drawing.Point(754, 36);
            this.gongHuoShangButton.Name = "gongHuoShangButton";
            this.gongHuoShangButton.Size = new System.Drawing.Size(79, 23);
            this.gongHuoShangButton.TabIndex = 4;
            this.gongHuoShangButton.Text = "查询";
            this.gongHuoShangButton.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(476, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "联系人姓名：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(167, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 21);
            this.textBox1.TabIndex = 1;
            // 
            // comapnyLabel
            // 
            this.comapnyLabel.AutoSize = true;
            this.comapnyLabel.Location = new System.Drawing.Point(68, 39);
            this.comapnyLabel.Name = "comapnyLabel";
            this.comapnyLabel.Size = new System.Drawing.Size(77, 12);
            this.comapnyLabel.TabIndex = 0;
            this.comapnyLabel.Text = "加盟商名称：";
            // 
            // JiHuaGuanLi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.commonDataGridView1);
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Name = "JiHuaGuanLi";
            this.Load += new System.EventHandler(this.XuQiuGuanLi_Load);
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton add;
        private CommonControl.CommonPictureButton commonPictureButton2;
        private CommonControl.CommonPictureButton commonPictureButton5;
        private CommonControl.CommonDataGridView commonDataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button gongHuoShangButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label comapnyLabel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checks;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewLinkColumn editCol;
        private System.Windows.Forms.DataGridViewLinkColumn delCol;
    }
}