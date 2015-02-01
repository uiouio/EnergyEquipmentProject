namespace GongYiGuanLi
{
    partial class PaiGongDan_add_Dialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.commonDataGridView = new CommonControl.CommonDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.付款类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.领料状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否追加 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_carNum = new System.Windows.Forms.Label();
            this.label_type = new System.Windows.Forms.Label();
            this.label_carType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // commonDataGridView
            // 
            this.commonDataGridView.AllowUserToAddRows = false;
            this.commonDataGridView.AllowUserToDeleteRows = false;
            this.commonDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.commonDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.commonDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.commonDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.commonDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.commonDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.commonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.commonDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column7,
            this.付款类型,
            this.Column4,
            this.领料状态,
            this.是否追加,
            this.Column10});
            this.commonDataGridView.Location = new System.Drawing.Point(27, 79);
            this.commonDataGridView.MultiSelect = false;
            this.commonDataGridView.Name = "commonDataGridView";
            this.commonDataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.commonDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.commonDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.commonDataGridView.Size = new System.Drawing.Size(963, 345);
            this.commonDataGridView.TabIndex = 19;
            this.commonDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView_CellContentClick);
            this.commonDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.commonDataGridView_CellValueChanged);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 72.58884F;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
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
            // 
            // Column4
            // 
            this.Column4.HeaderText = "备注";
            this.Column4.Name = "Column4";
            // 
            // 领料状态
            // 
            this.领料状态.HeaderText = "领料状态";
            this.领料状态.Name = "领料状态";
            this.领料状态.ReadOnly = true;
            // 
            // 是否追加
            // 
            this.是否追加.HeaderText = "是否追加";
            this.是否追加.Name = "是否追加";
            this.是否追加.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "车牌号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "改装类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(671, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "车型：";
            // 
            // label_carNum
            // 
            this.label_carNum.AutoSize = true;
            this.label_carNum.Location = new System.Drawing.Point(592, 32);
            this.label_carNum.Name = "label_carNum";
            this.label_carNum.Size = new System.Drawing.Size(53, 12);
            this.label_carNum.TabIndex = 25;
            this.label_carNum.Text = "川AU066U";
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(463, 32);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(53, 12);
            this.label_type.TabIndex = 26;
            this.label_type.Text = "CNG-汽油";
            // 
            // label_carType
            // 
            this.label_carType.AutoSize = true;
            this.label_carType.Location = new System.Drawing.Point(707, 32);
            this.label_carType.Name = "label_carType";
            this.label_carType.Size = new System.Drawing.Size(47, 12);
            this.label_carType.TabIndex = 27;
            this.label_carType.Text = "奥迪A4L";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(905, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(370, 480);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 31;
            this.button3.Text = "提交";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(546, 480);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 32;
            this.button4.Text = "保存为模板";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "车主姓名：";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(329, 32);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(41, 12);
            this.label_name.TabIndex = 24;
            this.label_name.Text = "徐玉龙";
            // 
            // PaiGongDan_add_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1033, 749);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label_carType);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.label_carNum);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commonDataGridView);
            this.Name = "PaiGongDan_add_Dialog";
            this.Text = "新建派工单";
            this.Load += new System.EventHandler(this.PaiGongDan_add_Dialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.commonDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonControl.CommonDataGridView commonDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_carNum;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_carType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn 付款类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn 领料状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否追加;
        private System.Windows.Forms.DataGridViewLinkColumn Column10;
    }
}