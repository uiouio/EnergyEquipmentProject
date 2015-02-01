namespace EnergyEquipmentProject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("个人客户");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("企业客户");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("客户管理", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("个人车辆");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("企业车辆");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("车辆管理", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("改装合同");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("维修合同");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("套件合同");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("合同模板");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("合同审批");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("合同管理", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("经销商信息");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("计划管理");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("经销商管理", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("销售管理", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode12,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("派工单管理");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("派工单模板");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("技术派工", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("分配派工单");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("前检CNG");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("前检柴油CNG");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("前检LNG");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("车辆前检", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("装车");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("调试");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("后检CNG");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("后检柴油CNG");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("后检LNG");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("装车后检验", new System.Windows.Forms.TreeNode[] {
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("车辆入库");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("车辆出库");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("生产管理", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode30,
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("监检通知单");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("监督检验", new System.Windows.Forms.TreeNode[] {
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("质量反馈单");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("维修管理", new System.Windows.Forms.TreeNode[] {
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("采购计划");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("采购申请");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("比价评审");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("采购合同");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("供货商管理");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("采购管理", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42});
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("入库");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("出库");
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("维修退库");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("入库记录");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("出库记录");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("概况统计");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("库存统计", new System.Windows.Forms.TreeNode[] {
            treeNode47,
            treeNode48,
            treeNode49});
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("类别管理");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("预警设置");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("参数设置", new System.Windows.Forms.TreeNode[] {
            treeNode51,
            treeNode52});
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("货物质量问题");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("责任损坏");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("日常损耗");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("坏件统计");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("坏件管理", new System.Windows.Forms.TreeNode[] {
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("库存管理", new System.Windows.Forms.TreeNode[] {
            treeNode44,
            treeNode45,
            treeNode46,
            treeNode50,
            treeNode53,
            treeNode58});
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("付款管理");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("双燃料管理系统", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode19,
            treeNode33,
            treeNode35,
            treeNode37,
            treeNode43,
            treeNode59,
            treeNode60});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.commonTabControl1 = new CommonControl.CommonTabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.首页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.采购ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人客户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "treeNode2.png");
            this.imageList1.Images.SetKeyName(1, "重工图标2.png");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::EnergyEquipmentProject.Properties.Resources.menuBG;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 720);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 30);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1138, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "河北工业大学信息技术研究所｜版本1.0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::EnergyEquipmentProject.Properties.Resources.titlePanel2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 69);
            this.panel2.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(1256, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "退出登录";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.commonTabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(234, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1136, 621);
            this.panel3.TabIndex = 35;
            // 
            // commonTabControl1
            // 
            this.commonTabControl1.BackColor = System.Drawing.Color.SkyBlue;
            this.commonTabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commonTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonTabControl1.Location = new System.Drawing.Point(0, 0);
            this.commonTabControl1.Name = "commonTabControl1";
            this.commonTabControl1.SelectedIndex = -1;
            this.commonTabControl1.Size = new System.Drawing.Size(1136, 621);
            this.commonTabControl1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(224, 99);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 621);
            this.splitter1.TabIndex = 34;
            this.splitter1.TabStop = false;
            this.splitter1.Click += new System.EventHandler(this.splitter1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeView2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 99);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(224, 621);
            this.panel4.TabIndex = 33;
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.Color.White;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.FullRowSelect = true;
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.ItemHeight = 25;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "节点1";
            treeNode1.Text = "个人客户";
            treeNode2.Name = "节点2";
            treeNode2.Text = "企业客户";
            treeNode3.Name = "节点5";
            treeNode3.Text = "客户管理";
            treeNode4.Name = "节点3";
            treeNode4.Text = "个人车辆";
            treeNode5.Name = "节点4";
            treeNode5.Text = "企业车辆";
            treeNode6.Name = "节点7";
            treeNode6.Text = "车辆管理";
            treeNode7.Name = "节点1";
            treeNode7.Text = "改装合同";
            treeNode8.Name = "节点9";
            treeNode8.Text = "维修合同";
            treeNode9.Name = "套件合同";
            treeNode9.Text = "套件合同";
            treeNode10.Name = "节点12";
            treeNode10.Text = "合同模板";
            treeNode11.Name = "节点0";
            treeNode11.Text = "合同审批";
            treeNode12.Name = "节点8";
            treeNode12.Text = "合同管理";
            treeNode13.Name = "节点0";
            treeNode13.Text = "经销商信息";
            treeNode14.Name = "节点1";
            treeNode14.Text = "计划管理";
            treeNode15.Name = "节点17";
            treeNode15.Text = "经销商管理";
            treeNode16.ImageIndex = 0;
            treeNode16.Name = "节点3";
            treeNode16.Text = "销售管理";
            treeNode17.Name = "节点14";
            treeNode17.Text = "派工单管理";
            treeNode18.Name = "节点15";
            treeNode18.Text = "派工单模板";
            treeNode19.Name = "节点4";
            treeNode19.Text = "技术派工";
            treeNode20.Name = "节点0";
            treeNode20.Text = "分配派工单";
            treeNode21.Name = "节点4";
            treeNode21.Text = "前检CNG";
            treeNode22.Name = "节点5";
            treeNode22.Text = "前检柴油CNG";
            treeNode23.Name = "节点6";
            treeNode23.Text = "前检LNG";
            treeNode24.Name = "节点3";
            treeNode24.Text = "车辆前检";
            treeNode25.Name = "节点7";
            treeNode25.Text = "装车";
            treeNode26.Name = "节点8";
            treeNode26.Text = "调试";
            treeNode27.Name = "节点12";
            treeNode27.Text = "后检CNG";
            treeNode28.Name = "节点13";
            treeNode28.Text = "后检柴油CNG";
            treeNode29.Name = "节点14";
            treeNode29.Text = "后检LNG";
            treeNode30.Name = "节点9";
            treeNode30.Text = "装车后检验";
            treeNode31.Name = "节点10";
            treeNode31.Text = "车辆入库";
            treeNode32.Name = "节点11";
            treeNode32.Text = "车辆出库";
            treeNode33.Name = "节点1";
            treeNode33.Text = "生产管理";
            treeNode34.Name = "节点17";
            treeNode34.Text = "监检通知单";
            treeNode35.Name = "节点15";
            treeNode35.Text = "监督检验";
            treeNode36.Name = "节点21";
            treeNode36.Text = "质量反馈单";
            treeNode37.Name = "节点16";
            treeNode37.Text = "维修管理";
            treeNode38.Name = "节点0";
            treeNode38.Text = "采购计划";
            treeNode39.Name = "节点28";
            treeNode39.Text = "采购申请";
            treeNode40.Name = "节点31";
            treeNode40.Text = "比价评审";
            treeNode41.Name = "节点59";
            treeNode41.Text = "采购合同";
            treeNode42.Name = "节点34";
            treeNode42.Text = "供货商管理";
            treeNode43.Name = "节点25";
            treeNode43.Text = "采购管理";
            treeNode44.Name = "节点53";
            treeNode44.Text = "入库";
            treeNode45.Name = "节点54";
            treeNode45.Text = "出库";
            treeNode46.Name = "节点56";
            treeNode46.Text = "维修退库";
            treeNode47.Name = "节点0";
            treeNode47.Text = "入库记录";
            treeNode48.Name = "节点1";
            treeNode48.Text = "出库记录";
            treeNode49.Name = "节点2";
            treeNode49.Text = "概况统计";
            treeNode50.Name = "节点57";
            treeNode50.Text = "库存统计";
            treeNode51.Name = "节点3";
            treeNode51.Text = "类别管理";
            treeNode52.Name = "节点4";
            treeNode52.Text = "预警设置";
            treeNode53.Name = "节点58";
            treeNode53.Text = "参数设置";
            treeNode54.Name = "节点1";
            treeNode54.Text = "货物质量问题";
            treeNode55.Name = "节点2";
            treeNode55.Text = "责任损坏";
            treeNode56.Name = "节点3";
            treeNode56.Text = "日常损耗";
            treeNode57.Name = "节点0";
            treeNode57.Text = "坏件统计";
            treeNode58.Name = "节点0";
            treeNode58.Text = "坏件管理";
            treeNode59.Name = "节点52";
            treeNode59.Text = "库存管理";
            treeNode60.Name = "节点13";
            treeNode60.Text = "付款管理";
            treeNode61.BackColor = System.Drawing.Color.White;
            treeNode61.Checked = true;
            treeNode61.ImageIndex = 1;
            treeNode61.Name = "节点0";
            treeNode61.SelectedImageKey = "重工图标2.png";
            treeNode61.Text = "双燃料管理系统";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode61});
            this.treeView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.ShowNodeToolTips = true;
            this.treeView2.Size = new System.Drawing.Size(224, 621);
            this.treeView2.TabIndex = 12;
            this.treeView2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImage = global::EnergyEquipmentProject.Properties.Resources.menuBG;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首页ToolStripMenuItem,
            this.采购ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 69);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 30);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 首页ToolStripMenuItem
            // 
            this.首页ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.首页ToolStripMenuItem.Name = "首页ToolStripMenuItem";
            this.首页ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.首页ToolStripMenuItem.Text = "首页";
            // 
            // 采购ToolStripMenuItem
            // 
            this.采购ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人客户ToolStripMenuItem});
            this.采购ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.采购ToolStripMenuItem.Name = "采购ToolStripMenuItem";
            this.采购ToolStripMenuItem.Size = new System.Drawing.Size(49, 26);
            this.采购ToolStripMenuItem.Text = "采购";
            // 
            // 个人客户ToolStripMenuItem
            // 
            this.个人客户ToolStripMenuItem.Name = "个人客户ToolStripMenuItem";
            this.个人客户ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.个人客户ToolStripMenuItem.Text = "个人客户";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::EnergyEquipmentProject.Properties.Resources.QQ图片20140709214426;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "MainForm";
            this.Text = "柴油-天然气双燃料重卡汽车业务信息管理系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonControl.CommonTabControl commonTabControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 首页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 采购ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 个人客户ToolStripMenuItem;
    }
}

