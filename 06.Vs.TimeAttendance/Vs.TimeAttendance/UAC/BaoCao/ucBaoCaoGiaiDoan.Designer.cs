namespace Vs.HRM
{
    partial class ucBaoCaoGiaiDoan
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
            this.windowsUIButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.grdCN = new DevExpress.XtraGrid.GridControl();
            this.grvCN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lbDonVi = new DevExpress.Utils.Layout.TablePanel();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.lblLyDoNghi = new DevExpress.XtraEditors.LabelControl();
            this.chkInTheoCongNhan = new DevExpress.XtraEditors.CheckEdit();
            this.cboLydoVang = new Commons.MPopupContainerEdit();
            this.popListLyDo = new DevExpress.XtraEditors.PopupContainerControl();
            this.grdLydovang = new DevExpress.XtraGrid.GridControl();
            this.grvLydovang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lbDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.lbNgayIn = new DevExpress.XtraEditors.LabelControl();
            this.lk_NgayIn = new DevExpress.XtraEditors.DateEdit();
            this.lk_DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.rdo_ChonBaoCao = new DevExpress.XtraEditors.RadioGroup();
            this.lbTo = new DevExpress.XtraEditors.LabelControl();
            this.lbXiNghiep = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.lk_TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.LK_XI_NGHIEP = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.LK_DON_VI = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.LK_TO = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbDonVi)).BeginInit();
            this.lbDonVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInTheoCongNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLydoVang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popListLyDo)).BeginInit();
            this.popListLyDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLydovang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLydovang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_TuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_TuNgay.Properties)).BeginInit();
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
            windowsUIButtonImageOptions1.Image = global::Vs.TimeAttendance.Properties.Resources.print;
            this.windowsUIButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("In", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Print", -1, false)});
            this.windowsUIButton.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.windowsUIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsUIButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButton.Location = new System.Drawing.Point(0, 610);
            this.windowsUIButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.windowsUIButton.Name = "windowsUIButton";
            this.windowsUIButton.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.windowsUIButton.Size = new System.Drawing.Size(1484, 96);
            this.windowsUIButton.TabIndex = 10;
            this.windowsUIButton.Text = "windowsUIButtonPanel1";
            this.windowsUIButton.WrapButtons = true;
            this.windowsUIButton.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButton_ButtonClick);
            // 
            // grdCN
            // 
            this.lbDonVi.SetColumn(this.grdCN, 4);
            this.lbDonVi.SetColumnSpan(this.grdCN, 3);
            this.grdCN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCN.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdCN.Location = new System.Drawing.Point(719, 243);
            this.grdCN.MainView = this.grvCN;
            this.grdCN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdCN.Name = "grdCN";
            this.lbDonVi.SetRow(this.grdCN, 6);
            this.lbDonVi.SetRowSpan(this.grdCN, 3);
            this.grdCN.Size = new System.Drawing.Size(662, 457);
            this.grdCN.TabIndex = 27;
            this.grdCN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCN,
            this.gridView3});
            // 
            // grvCN
            // 
            this.grvCN.DetailHeight = 436;
            this.grvCN.GridControl = this.grdCN;
            this.grvCN.Name = "grvCN";
            // 
            // gridView3
            // 
            this.gridView3.DetailHeight = 436;
            this.gridView3.GridControl = this.grdCN;
            this.gridView3.Name = "gridView3";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lbDonVi);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(950, 307, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1484, 610);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lbDonVi
            // 
            this.lbDonVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDonVi.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 16.46F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 19.54F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F)});
            this.lbDonVi.Controls.Add(this.searchControl);
            this.lbDonVi.Controls.Add(this.lblLyDoNghi);
            this.lbDonVi.Controls.Add(this.grdCN);
            this.lbDonVi.Controls.Add(this.chkInTheoCongNhan);
            this.lbDonVi.Controls.Add(this.cboLydoVang);
            this.lbDonVi.Controls.Add(this.popListLyDo);
            this.lbDonVi.Controls.Add(this.lbDenNgay);
            this.lbDonVi.Controls.Add(this.lbNgayIn);
            this.lbDonVi.Controls.Add(this.lk_NgayIn);
            this.lbDonVi.Controls.Add(this.lk_DenNgay);
            this.lbDonVi.Controls.Add(this.rdo_ChonBaoCao);
            this.lbDonVi.Controls.Add(this.lbTo);
            this.lbDonVi.Controls.Add(this.lbXiNghiep);
            this.lbDonVi.Controls.Add(this.labelControl1);
            this.lbDonVi.Controls.Add(this.lbTuNgay);
            this.lbDonVi.Controls.Add(this.lk_TuNgay);
            this.lbDonVi.Controls.Add(this.LK_XI_NGHIEP);
            this.lbDonVi.Controls.Add(this.LK_DON_VI);
            this.lbDonVi.Controls.Add(this.LK_TO);
            this.lbDonVi.Location = new System.Drawing.Point(8, 7);
            this.lbDonVi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDonVi.Name = "lbDonVi";
            this.lbDonVi.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 36F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 170F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 170F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 31F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 22F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.lbDonVi.Size = new System.Drawing.Size(1468, 596);
            this.lbDonVi.TabIndex = 4;
            // 
            // searchControl
            // 
            this.searchControl.Client = this.grdCN;
            this.lbDonVi.SetColumn(this.searchControl, 4);
            this.lbDonVi.SetColumnSpan(this.searchControl, 3);
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchControl.Location = new System.Drawing.Point(1265, 623);
            this.searchControl.Margin = new System.Windows.Forms.Padding(550, 6, 6, 6);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.searchControl.Properties.Appearance.Options.UseFont = true;
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.grdCN;
            this.searchControl.Properties.FindDelay = 100;
            this.lbDonVi.SetRow(this.searchControl, 7);
            this.searchControl.Size = new System.Drawing.Size(114, 36);
            this.searchControl.TabIndex = 32;
            // 
            // lblLyDoNghi
            // 
            this.lbDonVi.SetColumn(this.lblLyDoNghi, 2);
            this.lblLyDoNghi.Location = new System.Drawing.Point(395, 163);
            this.lblLyDoNghi.Margin = new System.Windows.Forms.Padding(95, 4, 4, 4);
            this.lblLyDoNghi.Name = "lblLyDoNghi";
            this.lbDonVi.SetRow(this.lblLyDoNghi, 4);
            this.lblLyDoNghi.Size = new System.Drawing.Size(104, 25);
            this.lblLyDoNghi.TabIndex = 31;
            this.lblLyDoNghi.Text = "lblLyDoNghi";
            // 
            // chkInTheoCongNhan
            // 
            this.lbDonVi.SetColumn(this.chkInTheoCongNhan, 4);
            this.chkInTheoCongNhan.Location = new System.Drawing.Point(719, 204);
            this.chkInTheoCongNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkInTheoCongNhan.Name = "chkInTheoCongNhan";
            this.chkInTheoCongNhan.Properties.Caption = "In theo CN";
            this.lbDonVi.SetRow(this.chkInTheoCongNhan, 5);
            this.chkInTheoCongNhan.Size = new System.Drawing.Size(228, 29);
            this.chkInTheoCongNhan.TabIndex = 26;
            // 
            // cboLydoVang
            // 
            this.lbDonVi.SetColumn(this.cboLydoVang, 4);
            this.lbDonVi.SetColumnSpan(this.cboLydoVang, 2);
            this.cboLydoVang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLydoVang.Location = new System.Drawing.Point(719, 158);
            this.cboLydoVang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLydoVang.Name = "cboLydoVang";
            this.cboLydoVang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLydoVang.Properties.DefaultActionButtonIndex = 0;
            this.cboLydoVang.Properties.DefaultPopupControl = this.popListLyDo;
            this.cboLydoVang.Properties.DifferentActionButtonIndex = 0;
            this.cboLydoVang.Properties.DifferentPopupControl = null;
            this.lbDonVi.SetRow(this.cboLydoVang, 4);
            this.cboLydoVang.Size = new System.Drawing.Size(445, 32);
            this.cboLydoVang.TabIndex = 25;
            // 
            // popListLyDo
            // 
            this.popListLyDo.AutoSize = true;
            this.lbDonVi.SetColumn(this.popListLyDo, 6);
            this.lbDonVi.SetColumnSpan(this.popListLyDo, 3);
            this.popListLyDo.Controls.Add(this.grdLydovang);
            this.popListLyDo.Location = new System.Drawing.Point(1172, 202);
            this.popListLyDo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.popListLyDo.MinimumSize = new System.Drawing.Size(550, 250);
            this.popListLyDo.Name = "popListLyDo";
            this.lbDonVi.SetRow(this.popListLyDo, 5);
            this.popListLyDo.Size = new System.Drawing.Size(550, 250);
            this.popListLyDo.TabIndex = 24;
            // 
            // grdLydovang
            // 
            this.grdLydovang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLydovang.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdLydovang.Location = new System.Drawing.Point(0, 0);
            this.grdLydovang.MainView = this.grvLydovang;
            this.grdLydovang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdLydovang.Name = "grdLydovang";
            this.grdLydovang.Size = new System.Drawing.Size(550, 250);
            this.grdLydovang.TabIndex = 15;
            this.grdLydovang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLydovang,
            this.gridView2});
            // 
            // grvLydovang
            // 
            this.grvLydovang.DetailHeight = 436;
            this.grvLydovang.GridControl = this.grdLydovang;
            this.grvLydovang.Name = "grvLydovang";
            this.grvLydovang.OptionsView.ShowGroupPanel = false;
            this.grvLydovang.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvLydovang_FocusedRowChanged);
            this.grvLydovang.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvLydovang_ValidatingEditor);
            // 
            // gridView2
            // 
            this.gridView2.DetailHeight = 436;
            this.gridView2.GridControl = this.grdLydovang;
            this.gridView2.Name = "gridView2";
            // 
            // lbDenNgay
            // 
            this.lbDonVi.SetColumn(this.lbDenNgay, 3);
            this.lbDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDenNgay.Location = new System.Drawing.Point(521, 113);
            this.lbDenNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbDenNgay.Name = "lbDenNgay";
            this.lbDonVi.SetRow(this.lbDenNgay, 3);
            this.lbDenNgay.Size = new System.Drawing.Size(191, 37);
            this.lbDenNgay.TabIndex = 20;
            this.lbDenNgay.Text = "Đến ngày";
            // 
            // lbNgayIn
            // 
            this.lbNgayIn.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbDonVi.SetColumn(this.lbNgayIn, 5);
            this.lbNgayIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNgayIn.Location = new System.Drawing.Point(955, 113);
            this.lbNgayIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbNgayIn.Name = "lbNgayIn";
            this.lbDonVi.SetRow(this.lbNgayIn, 3);
            this.lbNgayIn.Size = new System.Drawing.Size(209, 37);
            this.lbNgayIn.TabIndex = 21;
            this.lbNgayIn.Text = "Ngày in";
            // 
            // lk_NgayIn
            // 
            this.lbDonVi.SetColumn(this.lk_NgayIn, 6);
            this.lk_NgayIn.EditValue = null;
            this.lk_NgayIn.Location = new System.Drawing.Point(1174, 115);
            this.lk_NgayIn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lk_NgayIn.Name = "lk_NgayIn";
            this.lk_NgayIn.Properties.Appearance.Options.UseTextOptions = true;
            this.lk_NgayIn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lk_NgayIn.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lk_NgayIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_NgayIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lbDonVi.SetRow(this.lk_NgayIn, 3);
            this.lk_NgayIn.Size = new System.Drawing.Size(205, 32);
            this.lk_NgayIn.TabIndex = 18;
            // 
            // lk_DenNgay
            // 
            this.lbDonVi.SetColumn(this.lk_DenNgay, 4);
            this.lk_DenNgay.EditValue = null;
            this.lk_DenNgay.Location = new System.Drawing.Point(721, 115);
            this.lk_DenNgay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lk_DenNgay.Name = "lk_DenNgay";
            this.lk_DenNgay.Properties.Appearance.Options.UseTextOptions = true;
            this.lk_DenNgay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lk_DenNgay.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lk_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_DenNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.lbDonVi.SetRow(this.lk_DenNgay, 3);
            this.lk_DenNgay.Size = new System.Drawing.Size(224, 32);
            this.lk_DenNgay.TabIndex = 19;
            // 
            // rdo_ChonBaoCao
            // 
            this.lbDonVi.SetColumn(this.rdo_ChonBaoCao, 1);
            this.lbDonVi.SetColumnSpan(this.rdo_ChonBaoCao, 3);
            this.rdo_ChonBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_ChonBaoCao.Location = new System.Drawing.Point(111, 264);
            this.rdo_ChonBaoCao.Margin = new System.Windows.Forms.Padding(28, 25, 28, 25);
            this.rdo_ChonBaoCao.Name = "rdo_ChonBaoCao";
            this.rdo_ChonBaoCao.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "DSNV đi trễ về sớm giai đoạn", true, "rdo_ditrevesomgiaidoan"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "DS vắng đầu giờ giai đoạn", true, "rdo_vangdaugiogiaidoan"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "DS chấm vắng giai đoạn", true, "rdo_chamvanggiaidoan"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "DS chấm công vắng lũy kế", true, "rdo_chamcongvangluyke"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Xác nhận quẹt thẻ", true, "rdo_xacnhanquetthe"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Chấm công chi tiết công nhân giai đoạn", true, "rdo_congnhangiaidoan")});
            this.lbDonVi.SetRow(this.rdo_ChonBaoCao, 6);
            this.lbDonVi.SetRowSpan(this.rdo_ChonBaoCao, 2);
            this.rdo_ChonBaoCao.Size = new System.Drawing.Size(577, 376);
            this.rdo_ChonBaoCao.TabIndex = 17;
            // 
            // lbTo
            // 
            this.lbDonVi.SetColumn(this.lbTo, 1);
            this.lbTo.Location = new System.Drawing.Point(87, 80);
            this.lbTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbTo.Name = "lbTo";
            this.lbDonVi.SetRow(this.lbTo, 2);
            this.lbTo.Size = new System.Drawing.Size(114, 25);
            this.lbTo.TabIndex = 11;
            this.lbTo.Text = "labelControl3";
            // 
            // lbXiNghiep
            // 
            this.lbDonVi.SetColumn(this.lbXiNghiep, 1);
            this.lbXiNghiep.Location = new System.Drawing.Point(87, 42);
            this.lbXiNghiep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbXiNghiep.Name = "lbXiNghiep";
            this.lbDonVi.SetRow(this.lbXiNghiep, 1);
            this.lbXiNghiep.Size = new System.Drawing.Size(114, 25);
            this.lbXiNghiep.TabIndex = 10;
            this.lbXiNghiep.Text = "labelControl2";
            // 
            // labelControl1
            // 
            this.lbDonVi.SetColumn(this.labelControl1, 1);
            this.labelControl1.Location = new System.Drawing.Point(87, 7);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl1.Name = "labelControl1";
            this.lbDonVi.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(114, 25);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "labelControl1";
            // 
            // lbTuNgay
            // 
            this.lbDonVi.SetColumn(this.lbTuNgay, 1);
            this.lbTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTuNgay.Location = new System.Drawing.Point(87, 113);
            this.lbTuNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbTuNgay.Name = "lbTuNgay";
            this.lbDonVi.SetRow(this.lbTuNgay, 3);
            this.lbTuNgay.Size = new System.Drawing.Size(209, 37);
            this.lbTuNgay.TabIndex = 7;
            this.lbTuNgay.Text = "Từ ngày";
            // 
            // lk_TuNgay
            // 
            this.lbDonVi.SetColumn(this.lk_TuNgay, 2);
            this.lk_TuNgay.EditValue = null;
            this.lk_TuNgay.Location = new System.Drawing.Point(306, 115);
            this.lk_TuNgay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lk_TuNgay.Name = "lk_TuNgay";
            this.lk_TuNgay.Properties.Appearance.Options.UseTextOptions = true;
            this.lk_TuNgay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lk_TuNgay.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lk_TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_TuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_TuNgay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.lbDonVi.SetRow(this.lk_TuNgay, 3);
            this.lk_TuNgay.Size = new System.Drawing.Size(205, 32);
            this.lk_TuNgay.TabIndex = 5;
            // 
            // LK_XI_NGHIEP
            // 
            this.lbDonVi.SetColumn(this.LK_XI_NGHIEP, 2);
            this.lbDonVi.SetColumnSpan(this.LK_XI_NGHIEP, 5);
            this.LK_XI_NGHIEP.Location = new System.Drawing.Point(306, 39);
            this.LK_XI_NGHIEP.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LK_XI_NGHIEP.Name = "LK_XI_NGHIEP";
            this.LK_XI_NGHIEP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lbDonVi.SetRow(this.LK_XI_NGHIEP, 1);
            this.LK_XI_NGHIEP.Size = new System.Drawing.Size(1073, 32);
            this.LK_XI_NGHIEP.TabIndex = 3;
            this.LK_XI_NGHIEP.EditValueChanged += new System.EventHandler(this.LK_XI_NGHIEP_EditValueChanged);
            // 
            // LK_DON_VI
            // 
            this.lbDonVi.SetColumn(this.LK_DON_VI, 2);
            this.lbDonVi.SetColumnSpan(this.LK_DON_VI, 5);
            this.LK_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LK_DON_VI.Location = new System.Drawing.Point(304, 4);
            this.LK_DON_VI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LK_DON_VI.Name = "LK_DON_VI";
            this.LK_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lbDonVi.SetRow(this.LK_DON_VI, 0);
            this.LK_DON_VI.Size = new System.Drawing.Size(1077, 32);
            this.LK_DON_VI.TabIndex = 1;
            this.LK_DON_VI.EditValueChanged += new System.EventHandler(this.LK_DON_VI_EditValueChanged);
            // 
            // LK_TO
            // 
            this.lbDonVi.SetColumn(this.LK_TO, 2);
            this.lbDonVi.SetColumnSpan(this.LK_TO, 5);
            this.LK_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LK_TO.Location = new System.Drawing.Point(306, 77);
            this.LK_TO.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.LK_TO.Name = "LK_TO";
            this.LK_TO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lbDonVi.SetRow(this.LK_TO, 2);
            this.LK_TO.Size = new System.Drawing.Size(1073, 32);
            this.LK_TO.TabIndex = 3;
            this.LK_TO.EditValueChanged += new System.EventHandler(this.LK_TO_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1484, 610);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lbDonVi;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1470, 598);
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
            // ucBaoCaoGiaiDoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ucBaoCaoGiaiDoan";
            this.Size = new System.Drawing.Size(1484, 706);
            this.Load += new System.EventHandler(this.ucBaoCaoGiaiDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbDonVi)).EndInit();
            this.lbDonVi.ResumeLayout(false);
            this.lbDonVi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkInTheoCongNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLydoVang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popListLyDo)).EndInit();
            this.popListLyDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLydovang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLydovang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_TuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_TuNgay.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Layout.TablePanel lbDonVi;
        private DevExpress.XtraGrid.GridControl grdCN;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCN;
        private DevExpress.XtraEditors.CheckEdit chkInTheoCongNhan;
        private Commons.MPopupContainerEdit cboLydoVang;
        private DevExpress.XtraEditors.PopupContainerControl popListLyDo;
        private DevExpress.XtraGrid.GridControl grdLydovang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLydovang;
        private DevExpress.XtraEditors.LabelControl lbDenNgay;
        private DevExpress.XtraEditors.LabelControl lbNgayIn;
        private DevExpress.XtraEditors.DateEdit lk_NgayIn;
        private DevExpress.XtraEditors.DateEdit lk_DenNgay;
        private DevExpress.XtraEditors.RadioGroup rdo_ChonBaoCao;
        private DevExpress.XtraEditors.LabelControl lbTo;
        private DevExpress.XtraEditors.LabelControl lbXiNghiep;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbTuNgay;
        private DevExpress.XtraEditors.DateEdit lk_TuNgay;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_XI_NGHIEP;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_DON_VI;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_TO;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.LabelControl lblLyDoNghi;
        private DevExpress.XtraEditors.SearchControl searchControl;
    }
}
