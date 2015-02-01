namespace KuGuanXiTong
{
    partial class UNDOWeiXiuTuiKu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UNDOWeiXiuTuiKu));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.commonDataGridView1 = new CommonControl.CommonDataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton1 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton2 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton5 = new CommonControl.CommonPictureButton(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).BeginInit();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(430, 132);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 21);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(211, 132);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 21);
            this.textBox1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "日期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "单据号:";
            // 
            // commonDataGridView1
            // 
            this.commonDataGridView1.AllowUserToAddRows = false;
            this.commonDataGridView1.AllowUserToDeleteRows = false;
            this.commonDataGridView1.AllowUserToResizeColumns = false;
            this.commonDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.commonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.commonDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.commonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commonDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column7});
            this.commonDataGridView1.Location = new System.Drawing.Point(160, 201);
            this.commonDataGridView1.MultiSelect = false;
            this.commonDataGridView1.Name = "commonDataGridView1";
            this.commonDataGridView1.ReadOnly = true;
            this.commonDataGridView1.RowHeadersVisible = false;
            this.commonDataGridView1.RowTemplate.Height = 23;
            this.commonDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView1.Size = new System.Drawing.Size(1100, 430);
            this.commonDataGridView1.TabIndex = 40;
            this.commonDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView1_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "维修单号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "物品编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "物品名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "规格型号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "单位";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "备注";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.HeaderText = "删除";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 54;
            // 
            // commonFlowLayoutPanel1
            // 
            this.commonFlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel1.BackgroundImage")));
            this.commonFlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton1);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton2);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton5);
            this.commonFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel1.Name = "commonFlowLayoutPanel1";
            this.commonFlowLayoutPanel1.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel1.TabIndex = 41;
            // 
            // commonPictureButton1
            // 
            this.commonPictureButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonPictureButton1.BackgroundImage")));
            this.commonPictureButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton1.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton1.Name = "commonPictureButton1";
            this.commonPictureButton1.NonSelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton1.NonSelectBackGroundImage")));
            this.commonPictureButton1.SelectBackGroundImage = ((System.Drawing.Bitmap)(resources.GetObject("commonPictureButton1.SelectBackGroundImage")));
            this.commonPictureButton1.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton1.TabIndex = 1;
            this.commonPictureButton1.TabStop = false;
            this.commonPictureButton1.ToolTipString = null;
            this.commonPictureButton1.Click += new System.EventHandler(this.commonPictureButton1_Click);
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
            this.commonPictureButton2.TabIndex = 10;
            this.commonPictureButton2.TabStop = false;
            this.commonPictureButton2.ToolTipString = null;
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
            this.commonPictureButton5.TabIndex = 11;
            this.commonPictureButton5.TabStop = false;
            this.commonPictureButton5.ToolTipString = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "--";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(581, 132);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(119, 21);
            this.dateTimePicker2.TabIndex = 43;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(741, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // WeiXiuTuiKu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Controls.Add(this.commonDataGridView1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "WeiXiuTuiKu";
            this.Load += new System.EventHandler(this.WeiXiuTuiKu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView1)).EndInit();
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CommonControl.CommonDataGridView commonDataGridView1;
        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton commonPictureButton1;
        private CommonControl.CommonPictureButton commonPictureButton5;
        private CommonControl.CommonPictureButton commonPictureButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button1;
    }
}