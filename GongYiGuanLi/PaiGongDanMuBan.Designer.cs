namespace GongYiGuanLi
{
    partial class PaiGongDanMuBan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaiGongDanMuBan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.commonDataGridView = new CommonControl.CommonDataGridView();
            this.commonFlowLayoutPanel1 = new CommonControl.CommonFlowLayoutPanel(this.components);
            this.commonPictureButton1 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton2 = new CommonControl.CommonPictureButton(this.components);
            this.commonPictureButton3 = new CommonControl.CommonPictureButton(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).BeginInit();
            this.commonFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(513, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(268, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "制作人:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模板名称:";
            // 
            // commonDataGridView
            // 
            this.commonDataGridView.AllowUserToAddRows = false;
            this.commonDataGridView.AllowUserToDeleteRows = false;
            this.commonDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.commonDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.commonDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.commonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.commonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column4,
            this.Column8,
            this.Column9,
            this.Column10});
            this.commonDataGridView.Location = new System.Drawing.Point(169, 173);
            this.commonDataGridView.MultiSelect = false;
            this.commonDataGridView.Name = "commonDataGridView";
            this.commonDataGridView.ReadOnly = true;
            this.commonDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.commonDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.commonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView.Size = new System.Drawing.Size(1133, 490);
            this.commonDataGridView.TabIndex = 6;
            this.commonDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView_CellContentClick);
            // 
            // commonFlowLayoutPanel1
            // 
            this.commonFlowLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("commonFlowLayoutPanel1.BackgroundImage")));
            this.commonFlowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton1);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton2);
            this.commonFlowLayoutPanel1.Controls.Add(this.commonPictureButton3);
            this.commonFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.commonFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.commonFlowLayoutPanel1.Name = "commonFlowLayoutPanel1";
            this.commonFlowLayoutPanel1.Size = new System.Drawing.Size(66, 680);
            this.commonFlowLayoutPanel1.TabIndex = 9;
            // 
            // commonPictureButton1
            // 
            this.commonPictureButton1.BackgroundImage = global::GongYiGuanLi.Properties.Resources.新建;
            this.commonPictureButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton1.Location = new System.Drawing.Point(0, 3);
            this.commonPictureButton1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton1.Name = "commonPictureButton1";
            this.commonPictureButton1.NonSelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.新建;
            this.commonPictureButton1.SelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.新建select;
            this.commonPictureButton1.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton1.TabIndex = 0;
            this.commonPictureButton1.TabStop = false;
            this.commonPictureButton1.ToolTipString = "新建";
            this.commonPictureButton1.Click += new System.EventHandler(this.commonPictureButton1_Click);
            // 
            // commonPictureButton2
            // 
            this.commonPictureButton2.BackgroundImage = global::GongYiGuanLi.Properties.Resources.打印;
            this.commonPictureButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton2.Location = new System.Drawing.Point(0, 67);
            this.commonPictureButton2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton2.Name = "commonPictureButton2";
            this.commonPictureButton2.NonSelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.打印;
            this.commonPictureButton2.SelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.打印select;
            this.commonPictureButton2.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton2.TabIndex = 1;
            this.commonPictureButton2.TabStop = false;
            this.commonPictureButton2.ToolTipString = "打印";
            // 
            // commonPictureButton3
            // 
            this.commonPictureButton3.BackgroundImage = global::GongYiGuanLi.Properties.Resources.导出;
            this.commonPictureButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commonPictureButton3.Location = new System.Drawing.Point(0, 131);
            this.commonPictureButton3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.commonPictureButton3.Name = "commonPictureButton3";
            this.commonPictureButton3.NonSelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.导出;
            this.commonPictureButton3.SelectBackGroundImage = global::GongYiGuanLi.Properties.Resources.导出select;
            this.commonPictureButton3.Size = new System.Drawing.Size(66, 61);
            this.commonPictureButton3.TabIndex = 2;
            this.commonPictureButton3.TabStop = false;
            this.commonPictureButton3.ToolTipString = "导出";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 72.58884F;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 102.7411F;
            this.Column2.HeaderText = "模板名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 270;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 102.7411F;
            this.Column7.HeaderText = "制作人";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 102.7411F;
            this.Column4.HeaderText = "最终修改人";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 102.7411F;
            this.Column8.HeaderText = "备注";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 400;
            // 
            // Column9
            // 
            this.Column9.HeaderText = " ";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = " ";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // PaiGongDanMuBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.commonFlowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.commonDataGridView);
            this.Name = "PaiGongDanMuBan";
            this.Load += new System.EventHandler(this.PaiGongDanMuBan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).EndInit();
            this.commonFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commonPictureButton3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private CommonControl.CommonDataGridView commonDataGridView;
        private CommonControl.CommonFlowLayoutPanel commonFlowLayoutPanel1;
        private CommonControl.CommonPictureButton commonPictureButton1;
        private CommonControl.CommonPictureButton commonPictureButton2;
        private CommonControl.CommonPictureButton commonPictureButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column9;
        private System.Windows.Forms.DataGridViewLinkColumn Column10;
    }
}
