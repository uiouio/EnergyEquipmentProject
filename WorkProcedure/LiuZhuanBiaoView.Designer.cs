namespace WorkProcedure
{
    partial class LiuZhuanBiaoView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiuZhuanBiaoView));
            this.LiuZhuanBiaoDataGridView1 = new CommonControl.CommonDataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton3 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton1 = new CommonControl.CommonPictureButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LiuZhuanBiaoDataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // LiuZhuanBiaoDataGridView1
            // 
            this.LiuZhuanBiaoDataGridView1.AllowUserToAddRows = false;
            this.LiuZhuanBiaoDataGridView1.AllowUserToDeleteRows = false;
            this.LiuZhuanBiaoDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.LiuZhuanBiaoDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LiuZhuanBiaoDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LiuZhuanBiaoDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.LiuZhuanBiaoDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.LiuZhuanBiaoDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LiuZhuanBiaoDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column11});
            this.LiuZhuanBiaoDataGridView1.Location = new System.Drawing.Point(140, 185);
            this.LiuZhuanBiaoDataGridView1.MultiSelect = false;
            this.LiuZhuanBiaoDataGridView1.Name = "LiuZhuanBiaoDataGridView1";
            this.LiuZhuanBiaoDataGridView1.ReadOnly = true;
            this.LiuZhuanBiaoDataGridView1.RowHeadersVisible = false;
            this.LiuZhuanBiaoDataGridView1.RowTemplate.Height = 23;
            this.LiuZhuanBiaoDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LiuZhuanBiaoDataGridView1.Size = new System.Drawing.Size(1100, 450);
            this.LiuZhuanBiaoDataGridView1.TabIndex = 5;
            this.LiuZhuanBiaoDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column10.HeaderText = " ";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 20;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 54;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "派工单编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "车牌号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "汽车类型";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "工作组";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "派工日期";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "装车日期";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column11.HeaderText = " ";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(280, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 80);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(124, 21);
            this.textBox2.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "车牌号：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(460, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(609, 31);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "派工日期：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(749, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "派工单编号：";
            // 
            // commonFlowLayoutPanel1
            // 
            this.commonFlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel1.BackgroundImage")));
            this.commonFlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton3);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton1);
            this.commonFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel1.Name = "commonFlowLayoutPanel1";
            this.commonFlowLayoutPanel1.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel1.TabIndex = 12;
            // 
            // commonPictureButton3
            // 
            this.commonPictureButton3.BackgroundImage = global::WorkProcedure.Properties.Resources.导出;
            this.commonPictureButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton3.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton3.Name = "commonPictureButton3";
            this.commonPictureButton3.NonSelectBackGroundImage = global::WorkProcedure.Properties.Resources.导出;
            this.commonPictureButton3.SelectBackGroundImage = global::WorkProcedure.Properties.Resources.导出select;
            this.commonPictureButton3.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton3.TabIndex = 2;
            this.commonPictureButton3.TabStop = false;
            this.commonPictureButton3.ToolTipString = "导出";
            this.commonPictureButton3.Click += new System.EventHandler(this.commonPictureButton3_Click);
            // 
            // commonPictureButton1
            // 
            this.commonPictureButton1.BackgroundImage = global::WorkProcedure.Properties.Resources.打印;
            this.commonPictureButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton1.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton1.Name = "commonPictureButton1";
            this.commonPictureButton1.NonSelectBackGroundImage = global::WorkProcedure.Properties.Resources.打印;
            this.commonPictureButton1.SelectBackGroundImage = global::WorkProcedure.Properties.Resources.打印select;
            this.commonPictureButton1.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton1.TabIndex = 0;
            this.commonPictureButton1.TabStop = false;
            this.commonPictureButton1.ToolTipString = "打印";
            this.commonPictureButton1.Click += new System.EventHandler(this.commonPictureButton1_Click);
            // 
            // LiuZhuanBiaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LiuZhuanBiaoDataGridView1);
            this.Name = "LiuZhuanBiaoView";
            this.Load += new System.EventHandler(this.LiuZhuanBiaoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LiuZhuanBiaoDataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.CommonDataGridView LiuZhuanBiaoDataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton commonPictureButton1;
        private CommonControl.CommonPictureButton commonPictureButton3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;

    }
}
