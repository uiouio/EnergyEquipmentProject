namespace KuGuanXiTong
{
    partial class ChuKu_addPaiGong_Dialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.commonDataGridView = new CommonControl.CommonDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.label_WorkGroup = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.领料状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否追加 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.Column3,
            this.Column8,
            this.Column7,
            this.付款类型,
            this.Column5,
            this.Column4,
            this.领料状态,
            this.是否追加,
            this.Column10,
            this.Column6});
            this.commonDataGridView.Location = new System.Drawing.Point(27, 108);
            this.commonDataGridView.MultiSelect = false;
            this.commonDataGridView.Name = "commonDataGridView";
            this.commonDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.commonDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.commonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView.Size = new System.Drawing.Size(1164, 636);
            this.commonDataGridView.TabIndex = 19;
            this.commonDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "派工单号：";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(485, 24);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(11, 12);
            this.label_name.TabIndex = 24;
            this.label_name.Text = " ";
            // 
            // label_WorkGroup
            // 
            this.label_WorkGroup.AutoSize = true;
            this.label_WorkGroup.Location = new System.Drawing.Point(685, 24);
            this.label_WorkGroup.Name = "label_WorkGroup";
            this.label_WorkGroup.Size = new System.Drawing.Size(11, 12);
            this.label_WorkGroup.TabIndex = 26;
            this.label_WorkGroup.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "工作组：";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Location = new System.Drawing.Point(852, 24);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(11, 12);
            this.label_UserName.TabIndex = 28;
            this.label_UserName.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(792, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "工作组长：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "扫码出库：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(526, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 21);
            this.textBox1.TabIndex = 30;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1107, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 72.58884F;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 71;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 102.7411F;
            this.Column2.HeaderText = "设备名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 102.7411F;
            this.Column3.HeaderText = "规格";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 101;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 102.7411F;
            this.Column8.HeaderText = "单位";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 102.7411F;
            this.Column7.HeaderText = "材质";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // 付款类型
            // 
            this.付款类型.HeaderText = "数量";
            this.付款类型.Name = "付款类型";
            this.付款类型.Width = 98;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "未出数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "备注";
            this.Column4.Name = "Column4";
            this.Column4.Width = 98;
            // 
            // 领料状态
            // 
            this.领料状态.HeaderText = "领料状态";
            this.领料状态.Name = "领料状态";
            this.领料状态.ReadOnly = true;
            this.领料状态.Width = 98;
            // 
            // 是否追加
            // 
            this.是否追加.HeaderText = "是否追加";
            this.是否追加.Name = "是否追加";
            this.是否追加.ReadOnly = true;
            this.是否追加.Width = 97;
            // 
            // Column10
            // 
            this.Column10.HeaderText = " ";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 98;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "当前单价";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // ChuKu_addPaiGong_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1216, 762);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_UserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_WorkGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commonDataGridView);
            this.Name = "ChuKu_addPaiGong_Dialog";
            this.Text = "派工出库";
            this.Load += new System.EventHandler(this.PaiGongDan_add_Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.CommonDataGridView commonDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_WorkGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 领料状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否追加;
        private System.Windows.Forms.DataGridViewLinkColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}