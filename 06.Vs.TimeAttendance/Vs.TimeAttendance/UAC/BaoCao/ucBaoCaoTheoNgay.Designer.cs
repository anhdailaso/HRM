﻿namespace Vs.TimeAttendance
{
    partial class ucBaoCaoTheoNgay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBaoCaoTheoNgay));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.windowsUIButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.popupContainerControl2 = new DevExpress.XtraEditors.PopupContainerControl();
            this.calThang = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.grdThang = new DevExpress.XtraGrid.GridControl();
            this.grvThang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.LK_NgayXemBaoCao = new Commons.MPopupContainerEdit();
            this.rdo_DiTreVeSom = new DevExpress.XtraEditors.RadioGroup();
            this.rdo_ChonBaoCao = new DevExpress.XtraEditors.RadioGroup();
            this.lbNgayXemBaoCao = new DevExpress.XtraEditors.LabelControl();
            this.lbTo = new DevExpress.XtraEditors.LabelControl();
            this.lbXiNghiep = new DevExpress.XtraEditors.LabelControl();
            this.lbDonVi = new DevExpress.XtraEditors.LabelControl();
            this.lbNgay = new DevExpress.XtraEditors.LabelControl();
            this.lk_NgayIn = new DevExpress.XtraEditors.DateEdit();
            this.LK_XI_NGHIEP = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.LK_DON_VI = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.LK_TO = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).BeginInit();
            this.popupContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calThang.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LK_NgayXemBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DiTreVeSom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_XI_NGHIEP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DON_VI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_TO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButton
            // 
            windowsUIButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions1.Image")));
            this.windowsUIButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("In", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Print", -1, false)});
            this.windowsUIButton.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.windowsUIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsUIButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButton.Location = new System.Drawing.Point(0, 586);
            this.windowsUIButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.windowsUIButton.Name = "windowsUIButton";
            this.windowsUIButton.Padding = new System.Windows.Forms.Padding(5);
            this.windowsUIButton.Size = new System.Drawing.Size(1128, 72);
            this.windowsUIButton.TabIndex = 16;
            this.windowsUIButton.Text = "windowsUIButtonPanel1";
            this.windowsUIButton.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButton_ButtonClick);
            this.windowsUIButton.Click += new System.EventHandler(this.windowsUIButton_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.popupContainerControl2);
            this.layoutControl1.Controls.Add(this.popupContainerControl1);
            this.layoutControl1.Controls.Add(this.tablePanel1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1128, 586);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // popupContainerControl2
            // 
            this.popupContainerControl2.Controls.Add(this.calThang);
            this.popupContainerControl2.Location = new System.Drawing.Point(446, 329);
            this.popupContainerControl2.Name = "popupContainerControl2";
            this.popupContainerControl2.Size = new System.Drawing.Size(420, 257);
            this.popupContainerControl2.TabIndex = 26;
            // 
            // calThang
            // 
            this.calThang.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calThang.Location = new System.Drawing.Point(0, 0);
            this.calThang.Name = "calThang";
            this.calThang.Padding = new System.Windows.Forms.Padding(0);
            this.calThang.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Multiple;
            this.calThang.ShowClearButton = true;
            this.calThang.Size = new System.Drawing.Size(420, 257);
            this.calThang.TabIndex = 3;
            this.calThang.DateTimeCommit += new System.EventHandler(this.calThang_DateTimeCommit);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.grdThang);
            this.popupContainerControl1.Location = new System.Drawing.Point(147, 326);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(347, 252);
            this.popupContainerControl1.TabIndex = 25;
            // 
            // grdThang
            // 
            this.grdThang.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.grdThang.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdThang.Location = new System.Drawing.Point(0, 0);
            this.grdThang.MainView = this.grvThang;
            this.grdThang.Name = "grdThang";
            this.grdThang.Size = new System.Drawing.Size(347, 252);
            this.grdThang.TabIndex = 16;
            this.grdThang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvThang});
            // 
            // grvThang
            // 
            this.grvThang.DetailHeight = 349;
            this.grvThang.GridControl = this.grdThang;
            this.grvThang.Name = "grvThang";
            this.grvThang.OptionsView.ShowAutoFilterRow = true;
            this.grvThang.OptionsView.ShowGroupPanel = false;
            this.grvThang.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grvThang_RowCellClick);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F)});
            this.tablePanel1.Controls.Add(this.LK_NgayXemBaoCao);
            this.tablePanel1.Controls.Add(this.rdo_DiTreVeSom);
            this.tablePanel1.Controls.Add(this.rdo_ChonBaoCao);
            this.tablePanel1.Controls.Add(this.lbNgayXemBaoCao);
            this.tablePanel1.Controls.Add(this.lbTo);
            this.tablePanel1.Controls.Add(this.lbXiNghiep);
            this.tablePanel1.Controls.Add(this.lbDonVi);
            this.tablePanel1.Controls.Add(this.lbNgay);
            this.tablePanel1.Controls.Add(this.lk_NgayIn);
            this.tablePanel1.Controls.Add(this.LK_XI_NGHIEP);
            this.tablePanel1.Controls.Add(this.LK_DON_VI);
            this.tablePanel1.Controls.Add(this.LK_TO);
            this.tablePanel1.Location = new System.Drawing.Point(6, 6);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 197F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1116, 574);
            this.tablePanel1.TabIndex = 4;
            // 
            // LK_NgayXemBaoCao
            // 
            this.tablePanel1.SetColumn(this.LK_NgayXemBaoCao, 2);
            this.LK_NgayXemBaoCao.Location = new System.Drawing.Point(229, 139);
            this.LK_NgayXemBaoCao.Name = "LK_NgayXemBaoCao";
            this.LK_NgayXemBaoCao.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LK_NgayXemBaoCao.Properties.DefaultActionButtonIndex = 0;
            this.LK_NgayXemBaoCao.Properties.DefaultPopupControl = this.popupContainerControl1;
            this.LK_NgayXemBaoCao.Properties.DifferentActionButtonIndex = 1;
            this.LK_NgayXemBaoCao.Properties.DifferentPopupControl = this.popupContainerControl2;
            this.tablePanel1.SetRow(this.LK_NgayXemBaoCao, 4);
            this.LK_NgayXemBaoCao.Size = new System.Drawing.Size(160, 26);
            this.LK_NgayXemBaoCao.TabIndex = 25;
            // 
            // rdo_DiTreVeSom
            // 
            this.tablePanel1.SetColumn(this.rdo_DiTreVeSom, 5);
            this.tablePanel1.SetColumnSpan(this.rdo_DiTreVeSom, 2);
            this.rdo_DiTreVeSom.Location = new System.Drawing.Point(727, 251);
            this.rdo_DiTreVeSom.Name = "rdo_DiTreVeSom";
            this.rdo_DiTreVeSom.Properties.Columns = 3;
            this.rdo_DiTreVeSom.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Đi trễ", true, "rdo_DiTre"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Về sớm", true, "rdo_VeSom"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tất cả", true, "rdo_TatCa")});
            this.tablePanel1.SetRow(this.rdo_DiTreVeSom, 5);
            this.rdo_DiTreVeSom.Size = new System.Drawing.Size(326, 31);
            this.rdo_DiTreVeSom.TabIndex = 23;
            this.rdo_DiTreVeSom.SelectedIndexChanged += new System.EventHandler(this.rdo_DiTreVeSom_SelectedIndexChanged);
            // 
            // rdo_ChonBaoCao
            // 
            this.tablePanel1.SetColumn(this.rdo_ChonBaoCao, 2);
            this.tablePanel1.SetColumnSpan(this.rdo_ChonBaoCao, 3);
            this.rdo_ChonBaoCao.Location = new System.Drawing.Point(230, 171);
            this.rdo_ChonBaoCao.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.rdo_ChonBaoCao.Name = "rdo_ChonBaoCao";
            this.rdo_ChonBaoCao.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách vắng đầu giờ theo ngày và đơn vị", true, "rdo_DSVangDauGioTheoDV"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách công nhân vắng đầu giờ ngày", true, "rdo_DSVangDauGioTheoNgay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách nhân viên thiếu nhóm ca ngày", true, "rdo_DSThieuNhomCa"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách đi trễ về sớm ngày", true, "rdo_DSDiTreVeSomTheoNgay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách nhân viên trùng giờ ngày", true, "rdo_DSNVTrungGioNgay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách nhân viên có trên 2 cặp giờ chính ngày", true, "rdo_DSNVCoTren2CapGioChinhNgay"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Danh sách nhân viên vạch thẻ lỗi ngày", true, "rdo_DSNVLoiTheNgay")});
            this.tablePanel1.SetRow(this.rdo_ChonBaoCao, 5);
            this.rdo_ChonBaoCao.Size = new System.Drawing.Size(491, 191);
            this.rdo_ChonBaoCao.TabIndex = 22;
            this.rdo_ChonBaoCao.SelectedIndexChanged += new System.EventHandler(this.rdo_ChonBaoCao_SelectedIndexChanged);
            // 
            // lbNgayXemBaoCao
            // 
            this.lbNgayXemBaoCao.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.tablePanel1.SetColumn(this.lbNgayXemBaoCao, 1);
            this.lbNgayXemBaoCao.Location = new System.Drawing.Point(63, 142);
            this.lbNgayXemBaoCao.Name = "lbNgayXemBaoCao";
            this.tablePanel1.SetRow(this.lbNgayXemBaoCao, 4);
            this.lbNgayXemBaoCao.Size = new System.Drawing.Size(125, 20);
            this.lbNgayXemBaoCao.TabIndex = 21;
            this.lbNgayXemBaoCao.Text = "Ngày xem báo cáo";
            // 
            // lbTo
            // 
            this.tablePanel1.SetColumn(this.lbTo, 1);
            this.lbTo.Location = new System.Drawing.Point(63, 112);
            this.lbTo.Name = "lbTo";
            this.tablePanel1.SetRow(this.lbTo, 3);
            this.lbTo.Size = new System.Drawing.Size(17, 20);
            this.lbTo.TabIndex = 11;
            this.lbTo.Text = "Tổ";
            // 
            // lbXiNghiep
            // 
            this.tablePanel1.SetColumn(this.lbXiNghiep, 1);
            this.lbXiNghiep.Location = new System.Drawing.Point(63, 80);
            this.lbXiNghiep.Name = "lbXiNghiep";
            this.tablePanel1.SetRow(this.lbXiNghiep, 2);
            this.lbXiNghiep.Size = new System.Drawing.Size(63, 20);
            this.lbXiNghiep.TabIndex = 10;
            this.lbXiNghiep.Text = "Xí nghiệp";
            // 
            // lbDonVi
            // 
            this.tablePanel1.SetColumn(this.lbDonVi, 1);
            this.lbDonVi.Location = new System.Drawing.Point(63, 46);
            this.lbDonVi.Name = "lbDonVi";
            this.tablePanel1.SetRow(this.lbDonVi, 1);
            this.lbDonVi.Size = new System.Drawing.Size(43, 20);
            this.lbDonVi.TabIndex = 9;
            this.lbDonVi.Text = "Đơn vị";
            // 
            // lbNgay
            // 
            this.tablePanel1.SetColumn(this.lbNgay, 5);
            this.lbNgay.Location = new System.Drawing.Point(727, 144);
            this.lbNgay.Name = "lbNgay";
            this.tablePanel1.SetRow(this.lbNgay, 4);
            this.lbNgay.Size = new System.Drawing.Size(48, 20);
            this.lbNgay.TabIndex = 7;
            this.lbNgay.Text = "lbNgay";
            // 
            // lk_NgayIn
            // 
            this.tablePanel1.SetColumn(this.lk_NgayIn, 6);
            this.lk_NgayIn.EditValue = null;
            this.lk_NgayIn.Location = new System.Drawing.Point(894, 141);
            this.lk_NgayIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lk_NgayIn.Name = "lk_NgayIn";
            this.lk_NgayIn.Properties.Appearance.Options.UseTextOptions = true;
            this.lk_NgayIn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lk_NgayIn.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lk_NgayIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_NgayIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.lk_NgayIn, 4);
            this.lk_NgayIn.Size = new System.Drawing.Size(158, 26);
            this.lk_NgayIn.TabIndex = 5;
            // 
            // LK_XI_NGHIEP
            // 
            this.tablePanel1.SetColumn(this.LK_XI_NGHIEP, 2);
            this.tablePanel1.SetColumnSpan(this.LK_XI_NGHIEP, 5);
            this.LK_XI_NGHIEP.Location = new System.Drawing.Point(230, 77);
            this.LK_XI_NGHIEP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_XI_NGHIEP.Name = "LK_XI_NGHIEP";
            this.LK_XI_NGHIEP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_XI_NGHIEP, 2);
            this.LK_XI_NGHIEP.Size = new System.Drawing.Size(822, 26);
            this.LK_XI_NGHIEP.TabIndex = 3;
            this.LK_XI_NGHIEP.EditValueChanged += new System.EventHandler(this.LK_XI_NGHIEP_EditValueChanged);
            // 
            // LK_DON_VI
            // 
            this.tablePanel1.SetColumn(this.LK_DON_VI, 2);
            this.tablePanel1.SetColumnSpan(this.LK_DON_VI, 5);
            this.LK_DON_VI.Location = new System.Drawing.Point(230, 43);
            this.LK_DON_VI.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.LK_DON_VI.Name = "LK_DON_VI";
            this.LK_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_DON_VI, 1);
            this.LK_DON_VI.Size = new System.Drawing.Size(823, 26);
            this.LK_DON_VI.TabIndex = 1;
            this.LK_DON_VI.EditValueChanged += new System.EventHandler(this.LK_DON_VI_EditValueChanged);
            // 
            // LK_TO
            // 
            this.tablePanel1.SetColumn(this.LK_TO, 2);
            this.tablePanel1.SetColumnSpan(this.LK_TO, 5);
            this.LK_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LK_TO.Location = new System.Drawing.Point(230, 109);
            this.LK_TO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_TO.Name = "LK_TO";
            this.LK_TO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_TO, 3);
            this.LK_TO.Size = new System.Drawing.Size(822, 26);
            this.LK_TO.TabIndex = 3;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1128, 586);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tablePanel1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1118, 576);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 349;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 538;
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ucBaoCaoTheoNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucBaoCaoTheoNgay";
            this.Size = new System.Drawing.Size(1128, 658);
            this.Tag = "ucBaoCaoTheoNgay";
            this.Load += new System.EventHandler(this.ucBaoCaoTheoNgay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).EndInit();
            this.popupContainerControl2.ResumeLayout(false);
            this.popupContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calThang.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LK_NgayXemBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DiTreVeSom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_XI_NGHIEP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DON_VI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_TO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.DateEdit lk_NgayIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lbNgay;
        private DevExpress.XtraEditors.LabelControl lbTo;
        private DevExpress.XtraEditors.LabelControl lbXiNghiep;
        private DevExpress.XtraEditors.LabelControl lbDonVi;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_XI_NGHIEP;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_DON_VI;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_TO;
        private DevExpress.XtraEditors.LabelControl lbNgayXemBaoCao;
        private DevExpress.XtraEditors.RadioGroup rdo_DiTreVeSom;
        private DevExpress.XtraEditors.RadioGroup rdo_ChonBaoCao;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl2;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraGrid.GridControl grdThang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvThang;
        private DevExpress.XtraEditors.Controls.CalendarControl calThang;
        private Commons.MPopupContainerEdit LK_NgayXemBaoCao;
    }
}