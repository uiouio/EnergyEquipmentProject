namespace CheRuKu
{
    partial class CheRuKu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheRuKu));
            this.CheRuKuDataGridView1 = new CommonControl.CommonDataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton2 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton3 = new CommonControl.CommonPictureButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CheRuKuDataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).BeginInit();
            this.SuspendLayout();
            // 
            // CheRuKuDataGridView1
            // 
            this.CheRuKuDataGridView1.AllowUserToAddRows = false;
            this.CheRuKuDataGridView1.AllowUserToDeleteRows = false;
            this.CheRuKuDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.CheRuKuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CheRuKuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CheRuKuDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.CheRuKuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CheRuKuDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheRuKuDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column5});
            this.CheRuKuDataGridView1.Location = new System.Drawing.Point(140, 185);
            this.CheRuKuDataGridView1.MultiSelect = false;
            this.CheRuKuDataGridView1.Name = "CheRuKuDataGridView1";
            this.CheRuKuDataGridView1.ReadOnly = true;
            this.CheRuKuDataGridView1.RowHeadersVisible = false;
            this.CheRuKuDataGridView1.RowTemplate.Height = 23;
            this.CheRuKuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CheRuKuDataGridView1.Size = new System.Drawing.Size(1100, 450);
            this.CheRuKuDataGridView1.TabIndex = 1;
            this.CheRuKuDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CheRuKuDataGridView1_CellContentClick);
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column9.HeaderText = " ";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 20;
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
            this.Column3.HeaderText = "合同编号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "派工单编号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "车牌号";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.HeaderText = "汽车类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.HeaderText = "缴费状态";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "入库日期";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 120;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.HeaderText = " ";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(280, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 80);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(610, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(461, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(126, 21);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "日期：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(294, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 21);
            this.textBox2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "派工单编号：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 21);
            this.textBox1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "合同编号：";
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(744, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.commonFlowLayoutPanel1.TabIndex = 9;
            // 
            // commonPictureButton2
            // 
            this.commonPictureButton2.BackgroundImage = global::CheRuKu.Properties.Resources.导出;
            this.commonPictureButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton2.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton2.Name = "commonPictureButton2";
            this.commonPictureButton2.NonSelectBackGroundImage = global::CheRuKu.Properties.Resources.导出;
            this.commonPictureButton2.SelectBackGroundImage = global::CheRuKu.Properties.Resources.导出select;
            this.commonPictureButton2.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton2.TabIndex = 1;
            this.commonPictureButton2.TabStop = false;
            this.commonPictureButton2.ToolTipString = "导出";
            this.commonPictureButton2.Click += new System.EventHandler(this.commonPictureButton2_Click);
            // 
            // commonPictureButton3
            // 
            this.commonPictureButton3.BackgroundImage = global::CheRuKu.Properties.Resources.打印;
            this.commonPictureButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton3.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton3.Name = "commonPictureButton3";
            this.commonPictureButton3.NonSelectBackGroundImage = global::CheRuKu.Properties.Resources.打印;
            this.commonPictureButton3.SelectBackGroundImage = global::CheRuKu.Properties.Resources.打印select;
            this.commonPictureButton3.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton3.TabIndex = 2;
            this.commonPictureButton3.TabStop = false;
            this.commonPictureButton3.ToolTipString = "打印";
            this.commonPictureButton3.Click += new System.EventHandler(this.commonPictureButton3_Click);
            // 
            // CheRuKu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CheRuKuDataGridView1);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.Name = "CheRuKu";
            this.Load += new System.EventHandler(this.CheRuKu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CheRuKuDataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonControl.CommonDataGridView CheRuKuDataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton commonPictureButton2;
        private CommonControl.CommonPictureButton commonPictureButton3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewLinkColumn Column5;
    }
}