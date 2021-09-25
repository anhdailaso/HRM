namespace Vs.TimeAttendance
{
    partial class frmDangKyKeHoachDiCa
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.windowsUIButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dttTu_ngay = new DevExpress.XtraEditors.DateEdit();
            this.dttDen_ngay = new DevExpress.XtraEditors.DateEdit();
            this.cboNhom = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboCA = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtghichu = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grouDanhSachCongNhan = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblNhom = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblCa = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTngay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lbldenngay = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblGhi_chu = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.windowsUIButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dttTu_ngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttTu_ngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttDen_ngay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttDen_ngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtghichu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grouDanhSachCongNhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldenngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGhi_chu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButton
            // 
            windowsUIButtonImageOptions1.Image = global::Vs.TimeAttendance.Properties.Resources.capnhat;
            windowsUIButtonImageOptions2.Image = global::Vs.TimeAttendance.Properties.Resources.iconExit;
            this.windowsUIButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Cập nhật", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "capnhat", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Thoát", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "thoat", -1, false)});
            this.windowsUIButton.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.windowsUIButton.Controls.Add(this.searchControl);
            this.windowsUIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.windowsUIButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButton.Location = new System.Drawing.Point(0, 644);
            this.windowsUIButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.windowsUIButton.Name = "windowsUIButton";
            this.windowsUIButton.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.windowsUIButton.Size = new System.Drawing.Size(1238, 81);
            this.windowsUIButton.TabIndex = 17;
            this.windowsUIButton.Text = "S";
            this.windowsUIButton.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButton_ButtonClick);
            // 
            // searchControl
            // 
            this.searchControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchControl.Client = this.grdData;
            this.searchControl.Location = new System.Drawing.Point(4, 40);
            this.searchControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.searchControl.Properties.Appearance.Options.UseFont = true;
            this.searchControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl.Properties.Client = this.grdData;
            this.searchControl.Properties.FindDelay = 100;
            this.searchControl.Size = new System.Drawing.Size(392, 36);
            this.searchControl.TabIndex = 10;
            // 
            // grdData
            // 
            this.grdData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.grdData.Location = new System.Drawing.Point(15, 190);
            this.grdData.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grdData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdData.MainView = this.grvData;
            this.grdData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1211, 419);
            this.grdData.TabIndex = 14;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.DetailHeight = 672;
            this.grvData.FixedLineWidth = 4;
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdData);
            this.layoutControl1.Controls.Add(this.dttTu_ngay);
            this.layoutControl1.Controls.Add(this.dttDen_ngay);
            this.layoutControl1.Controls.Add(this.cboNhom);
            this.layoutControl1.Controls.Add(this.cboCA);
            this.layoutControl1.Controls.Add(this.txtghichu);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1238, 644);
            this.layoutControl1.TabIndex = 18;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dttTu_ngay
            // 
            this.dttTu_ngay.EditValue = null;
            this.dttTu_ngay.Location = new System.Drawing.Point(726, 63);
            this.dttTu_ngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dttTu_ngay.Name = "dttTu_ngay";
            this.dttTu_ngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttTu_ngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttTu_ngay.Properties.DisplayFormat.FormatString = "";
            this.dttTu_ngay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dttTu_ngay.Properties.EditFormat.FormatString = "";
            this.dttTu_ngay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dttTu_ngay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dttTu_ngay.Size = new System.Drawing.Size(202, 32);
            this.dttTu_ngay.StyleController = this.layoutControl1;
            this.dttTu_ngay.TabIndex = 9;
            this.dttTu_ngay.EditValueChanged += new System.EventHandler(this.cboTo_EditValueChanged);
            // 
            // dttDen_ngay
            // 
            this.dttDen_ngay.EditValue = null;
            this.dttDen_ngay.Location = new System.Drawing.Point(1023, 63);
            this.dttDen_ngay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dttDen_ngay.Name = "dttDen_ngay";
            this.dttDen_ngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttDen_ngay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dttDen_ngay.Properties.DisplayFormat.FormatString = "";
            this.dttDen_ngay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dttDen_ngay.Properties.EditFormat.FormatString = "";
            this.dttDen_ngay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dttDen_ngay.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dttDen_ngay.Size = new System.Drawing.Size(176, 32);
            this.dttDen_ngay.StyleController = this.layoutControl1;
            this.dttDen_ngay.TabIndex = 15;
            // 
            // cboNhom
            // 
            this.cboNhom.Location = new System.Drawing.Point(135, 63);
            this.cboNhom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboNhom.Name = "cboNhom";
            this.cboNhom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhom.Properties.NullText = "";
            this.cboNhom.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboNhom.Size = new System.Drawing.Size(200, 32);
            this.cboNhom.StyleController = this.layoutControl1;
            this.cboNhom.TabIndex = 7;
            this.cboNhom.EditValueChanged += new System.EventHandler(this.cboDV_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.DetailHeight = 437;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // cboCA
            // 
            this.cboCA.Location = new System.Drawing.Point(430, 63);
            this.cboCA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCA.Name = "cboCA";
            this.cboCA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCA.Properties.NullText = "";
            this.cboCA.Properties.PopupView = this.gridView1;
            this.cboCA.Size = new System.Drawing.Size(201, 32);
            this.cboCA.StyleController = this.layoutControl1;
            this.cboCA.TabIndex = 8;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider1.SetValidationRule(this.cboCA, conditionValidationRule1);
            this.cboCA.EditValueChanged += new System.EventHandler(this.cboXN_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 437;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(135, 97);
            this.txtghichu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(497, 64);
            this.txtghichu.StyleController = this.layoutControl1;
            this.txtghichu.TabIndex = 16;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.grouDanhSachCongNhan});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1241, 623);
            this.Root.TextVisible = false;
            // 
            // grouDanhSachCongNhan
            // 
            this.grouDanhSachCongNhan.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblNhom,
            this.layoutControlItem1,
            this.lblCa,
            this.lblTngay,
            this.lbldenngay,
            this.emptySpaceItem2,
            this.lblGhi_chu,
            this.emptySpaceItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5});
            this.grouDanhSachCongNhan.Location = new System.Drawing.Point(0, 0);
            this.grouDanhSachCongNhan.Name = "grouDanhSachCongNhan";
            this.grouDanhSachCongNhan.Size = new System.Drawing.Size(1227, 611);
            // 
            // lblNhom
            // 
            this.lblNhom.Control = this.cboNhom;
            this.lblNhom.CustomizationFormText = "ItemForDON_VI";
            this.lblNhom.Location = new System.Drawing.Point(27, 25);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(295, 34);
            this.lblNhom.TextSize = new System.Drawing.Size(89, 25);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 152);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(140, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1213, 421);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lblCa
            // 
            this.lblCa.Control = this.cboCA;
            this.lblCa.CustomizationFormText = "ItemForXI_NGHIEP";
            this.lblCa.Location = new System.Drawing.Point(322, 25);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(296, 34);
            this.lblCa.TextSize = new System.Drawing.Size(89, 25);
            // 
            // lblTngay
            // 
            this.lblTngay.Control = this.dttTu_ngay;
            this.lblTngay.CustomizationFormText = "ItemForTO";
            this.lblTngay.Location = new System.Drawing.Point(618, 25);
            this.lblTngay.Name = "lblTngay";
            this.lblTngay.Size = new System.Drawing.Size(297, 34);
            this.lblTngay.Text = "lbltngay";
            this.lblTngay.TextSize = new System.Drawing.Size(89, 25);
            // 
            // lbldenngay
            // 
            this.lbldenngay.Control = this.dttDen_ngay;
            this.lbldenngay.Location = new System.Drawing.Point(915, 25);
            this.lbldenngay.Name = "lbldenngay";
            this.lbldenngay.Size = new System.Drawing.Size(271, 34);
            this.lbldenngay.Text = "lbldngay";
            this.lbldenngay.TextSize = new System.Drawing.Size(89, 25);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(27, 125);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(140, 27);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1159, 27);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblGhi_chu
            // 
            this.lblGhi_chu.Control = this.txtghichu;
            this.lblGhi_chu.Location = new System.Drawing.Point(27, 59);
            this.lblGhi_chu.Name = "lblGhi_chu";
            this.lblGhi_chu.Size = new System.Drawing.Size(592, 66);
            this.lblGhi_chu.TextSize = new System.Drawing.Size(89, 25);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(619, 59);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(567, 66);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 25);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(27, 127);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(27, 127);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(27, 127);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1186, 25);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(27, 127);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(27, 127);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(27, 127);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(1213, 25);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(1213, 25);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(1213, 25);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmDangKyKeHoachDiCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 725);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButton);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmDangKyKeHoachDiCa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKeHoachDiCa";
            this.Load += new System.EventHandler(this.frmDangKyKeHoachDiCa_Load);
            this.windowsUIButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dttTu_ngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttTu_ngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttDen_ngay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dttDen_ngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtghichu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grouDanhSachCongNhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldenngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGhi_chu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButton;
        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraLayout.LayoutControlGroup grouDanhSachCongNhan;
        private DevExpress.XtraLayout.LayoutControlItem lblNhom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lblCa;
        private DevExpress.XtraLayout.LayoutControlItem lblTngay;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lbldenngay;
        private DevExpress.XtraEditors.DateEdit dttTu_ngay;
        private DevExpress.XtraEditors.DateEdit dttDen_ngay;
        private DevExpress.XtraEditors.SearchLookUpEdit cboNhom;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboCA;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit txtghichu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lblGhi_chu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}