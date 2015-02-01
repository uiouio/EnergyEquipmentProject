namespace CustomManageWindow
{
    partial class CompanyCarManage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyCarManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.commonFlowLayoutPanel2 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton5 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton6 = new CommonControl.CommonPictureButton(this.components);
            this.commonDataGridView2 = new CommonControl.CommonDataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column34 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.commonFlowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonFlowLayoutPanel2
            // 
            this.commonFlowLayoutPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel2.BackgroundImage")));
            this.commonFlowLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel2.Controls.Add(this.commonPictureButton5);
            this.commonFlowLayoutPanel2.Controls.Add(this.commonPictureButton6);
            this.commonFlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel2.Name = "commonFlowLayoutPanel2";
            this.commonFlowLayoutPanel2.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel2.TabIndex = 12;
            // 
            // commonPictureButton5
            // 
            this.commonPictureButton5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonPictureButton5.BackgroundImage")));
            this.commonPictureButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton5.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton5.Name = "commonPictureButton5";
            this.commonPictureButton5.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton5.NonSelectBackGroundImage")));
            this.commonPictureButton5.SelectBackGroundImage = global::CustomManageWindow.Properties.Resources.打印select;
            this.commonPictureButton5.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton5.TabIndex = 1;
            this.commonPictureButton5.TabStop = false;
            this.commonPictureButton5.ToolTipString = "打印";
            // 
            // commonPictureButton6
            // 
            this.commonPictureButton6.BackgroundImage = global::CustomManageWindow.Properties.Resources.导出;
            this.commonPictureButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton6.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton6.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton6.Name = "commonPictureButton6";
            this.commonPictureButton6.NonSelectBackGroundImage = global::CustomManageWindow.Properties.Resources.导出;
            this.commonPictureButton6.SelectBackGroundImage = global::CustomManageWindow.Properties.Resources.导出select;
            this.commonPictureButton6.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton6.TabIndex = 2;
            this.commonPictureButton6.TabStop = false;
            this.commonPictureButton6.ToolTipString = "导出";
            // 
            // commonDataGridView2
            // 
            this.commonDataGridView2.AllowUserToAddRows = false;
            this.commonDataGridView2.AllowUserToDeleteRows = false;
            this.commonDataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.commonDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.commonDataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.commonDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column16,
            this.Column2,
            this.Column18,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column29,
            this.Column33,
            this.Column36,
            this.Column34,
            this.Column1,
            this.Column3});
            this.commonDataGridView2.Location = new System.Drawing.Point(126, 149);
            this.commonDataGridView2.MultiSelect = false;
            this.commonDataGridView2.Name = "commonDataGridView2";
            this.commonDataGridView2.ReadOnly = true;
            this.commonDataGridView2.RowHeadersVisible = false;
            this.commonDataGridView2.RowTemplate.Height = 23;
            this.commonDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView2.Size = new System.Drawing.Size(1224, 515);
            this.commonDataGridView2.TabIndex = 11;
            this.commonDataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView2_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox28);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.textBox27);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.textBox18);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.textBox23);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Location = new System.Drawing.Point(296, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(906, 69);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "企业车辆信息查询";
            // 
            // textBox28
            // 
            this.textBox28.Location = new System.Drawing.Point(669, 30);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(100, 21);
            this.textBox28.TabIndex = 14;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(608, 33);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 15;
            this.label30.Text = "发动机号：";
            // 
            // textBox27
            // 
            this.textBox27.Location = new System.Drawing.Point(488, 30);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(101, 21);
            this.textBox27.TabIndex = 13;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(415, 33);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 12);
            this.label29.TabIndex = 12;
            this.label29.Text = "车辆识别码：";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(291, 30);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 21);
            this.textBox18.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(231, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 12);
            this.label28.TabIndex = 10;
            this.label28.Text = "车 牌 号：";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(110, 30);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(100, 21);
            this.textBox23.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "公司名称：";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(804, 30);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(76, 22);
            this.button8.TabIndex = 0;
            this.button8.Text = "查询";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = " ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 20;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = "序号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 60;
            // 
            // Column16
            // 
            this.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column16.HeaderText = "公司名称";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 97;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "组织机构代码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column18
            // 
            this.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column18.HeaderText = "联系电话";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 97;
            // 
            // Column23
            // 
            this.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column23.HeaderText = "车牌号";
            this.Column23.Name = "Column23";
            this.Column23.ReadOnly = true;
            this.Column23.Width = 96;
            // 
            // Column24
            // 
            this.Column24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column24.HeaderText = "车型";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Width = 97;
            // 
            // Column25
            // 
            this.Column25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column25.HeaderText = "行驶里程";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 96;
            // 
            // Column26
            // 
            this.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column26.HeaderText = "百公里耗油";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 97;
            // 
            // Column29
            // 
            this.Column29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column29.HeaderText = "车辆识别码";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Width = 96;
            // 
            // Column33
            // 
            this.Column33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column33.HeaderText = "气瓶编号";
            this.Column33.Name = "Column33";
            this.Column33.ReadOnly = true;
            this.Column33.Width = 97;
            // 
            // Column36
            // 
            this.Column36.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column36.HeaderText = "气瓶容积";
            this.Column36.Name = "Column36";
            this.Column36.ReadOnly = true;
            this.Column36.Width = 96;
            // 
            // Column34
            // 
            this.Column34.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column34.HeaderText = "前检信息";
            this.Column34.Name = "Column34";
            this.Column34.ReadOnly = true;
            this.Column34.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column34.Width = 97;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = " ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.HeaderText = " ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 40;
            // 
            // CompanyCarManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.commonFlowLayoutPanel2);
            this.Controls.Add(this.commonDataGridView2);
            this.Controls.Add(this.groupBox3);
            this.Name = "CompanyCarManage";
            this.Load += new System.EventHandler(this.CompanyCarManage_Load);
            this.commonFlowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel2;
        private CommonControl.CommonPictureButton commonPictureButton5;
        private CommonControl.CommonPictureButton commonPictureButton6;
        private CommonControl.CommonDataGridView commonDataGridView2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column29;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column36;
        private System.Windows.Forms.DataGridViewLinkColumn Column34;
        private System.Windows.Forms.DataGridViewLinkColumn Column1;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;

    }
}
