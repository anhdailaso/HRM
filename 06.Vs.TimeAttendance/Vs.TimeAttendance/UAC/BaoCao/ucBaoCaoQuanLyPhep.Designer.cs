namespace Vs.TimeAttendance
{
    partial class ucBaoCaoQuanLyPhep
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucBaoCaoQuanLyPhep));
            this.windowsUIButton = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.popupContainerControl2 = new DevExpress.XtraEditors.PopupContainerControl();
            this.calThang = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.nam = new DevExpress.Utils.Layout.TablePanel();
            this.lk_Nam = new Commons.MPopupContainerEdit();
            this.rdo_DiTreVeSom = new DevExpress.XtraEditors.RadioGroup();
            this.rdo_ChonBaoCao = new DevExpress.XtraEditors.RadioGroup();
            this.lbNam = new DevExpress.XtraEditors.LabelControl();
            this.lbTo = new DevExpress.XtraEditors.LabelControl();
            this.lbXiNghiep = new DevExpress.XtraEditors.LabelControl();
            this.lbDonVi = new DevExpress.XtraEditors.LabelControl();
            this.lbNgayIn = new DevExpress.XtraEditors.LabelControl();
            this.lk_DenNgay = new DevExpress.XtraEditors.DateEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.nam)).BeginInit();
            this.nam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Nam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DiTreVeSom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties)).BeginInit();
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
            windowsUIButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions2.Image")));
            this.windowsUIButton.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("In", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "Print", -1, false)});
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
            this.layoutControl1.Controls.Add(this.nam);
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
            this.calThang.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.calThang.DateTimeCommit += new System.EventHandler(this.calThang_DateTimeCommit);
            // 
            // nam
            // 
            this.nam.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25.14F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 37.53F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 9.35F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 28.62F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 44.61F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.02F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 27.18F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 29.55F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 72F)});
            this.nam.Controls.Add(this.lk_Nam);
            this.nam.Controls.Add(this.rdo_DiTreVeSom);
            this.nam.Controls.Add(this.rdo_ChonBaoCao);
            this.nam.Controls.Add(this.lbNam);
            this.nam.Controls.Add(this.lbTo);
            this.nam.Controls.Add(this.lbXiNghiep);
            this.nam.Controls.Add(this.lbDonVi);
            this.nam.Controls.Add(this.lbNgayIn);
            this.nam.Controls.Add(this.lk_DenNgay);
            this.nam.Controls.Add(this.LK_XI_NGHIEP);
            this.nam.Controls.Add(this.LK_DON_VI);
            this.nam.Controls.Add(this.LK_TO);
            this.nam.Location = new System.Drawing.Point(6, 6);
            this.nam.Name = "nam";
            this.nam.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 58F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 223F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.nam.Size = new System.Drawing.Size(1116, 574);
            this.nam.TabIndex = 4;
            // 
            // lk_Nam
            // 
            this.nam.SetColumn(this.lk_Nam, 2);
            this.lk_Nam.EditValue = "";
            this.lk_Nam.Location = new System.Drawing.Point(182, 139);
            this.lk_Nam.Name = "lk_Nam";
            this.lk_Nam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_Nam.Properties.DefaultActionButtonIndex = 0;
            this.lk_Nam.Properties.DefaultPopupControl = this.popupContainerControl2;
            this.lk_Nam.Properties.DifferentActionButtonIndex = 0;
            this.lk_Nam.Properties.DifferentPopupControl = null;
            this.nam.SetRow(this.lk_Nam, 4);
            this.lk_Nam.Size = new System.Drawing.Size(172, 26);
            this.lk_Nam.TabIndex = 28;
            // 
            // rdo_DiTreVeSom
            // 
            this.nam.SetColumn(this.rdo_DiTreVeSom, 4);
            this.nam.SetColumnSpan(this.rdo_DiTreVeSom, 2);
            this.rdo_DiTreVeSom.Location = new System.Drawing.Point(404, 139);
            this.rdo_DiTreVeSom.Name = "rdo_DiTreVeSom";
            this.rdo_DiTreVeSom.Properties.Columns = 3;
            this.rdo_DiTreVeSom.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Đi trễ", true, "rdo_DangLamViec"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Về sớm", true, "rdo_DaNghi"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tất cả", true, "rdo_TatCa")});
            this.nam.SetRow(this.rdo_DiTreVeSom, 4);
            this.rdo_DiTreVeSom.Size = new System.Drawing.Size(340, 26);
            this.rdo_DiTreVeSom.TabIndex = 23;
            this.rdo_DiTreVeSom.SelectedIndexChanged += new System.EventHandler(this.rdo_DiTreVeSom_SelectedIndexChanged);
            // 
            // rdo_ChonBaoCao
            // 
            this.nam.SetColumn(this.rdo_ChonBaoCao, 2);
            this.nam.SetColumnSpan(this.rdo_ChonBaoCao, 4);
            this.rdo_ChonBaoCao.Location = new System.Drawing.Point(183, 229);
            this.rdo_ChonBaoCao.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.rdo_ChonBaoCao.Name = "rdo_ChonBaoCao";
            this.rdo_ChonBaoCao.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Theo dõi phép năm thực tế", true, "rdo_TheoDoiPhepNamTucTe"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Thanh toán phép năm", true, "rdo_ThanhToanPhepNam"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Tổng hợp tiền phép", true, "rdo_TongHopTienPhep"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Phiếu tiền phép", true, "rdo_PhieuTienPhep")});
            this.nam.SetRow(this.rdo_ChonBaoCao, 6);
            this.rdo_ChonBaoCao.Size = new System.Drawing.Size(561, 217);
            this.rdo_ChonBaoCao.TabIndex = 22;
            this.rdo_ChonBaoCao.SelectedIndexChanged += new System.EventHandler(this.rdo_ChonBaoCao_SelectedIndexChanged);
            // 
            // lbNam
            // 
            this.lbNam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.nam.SetColumn(this.lbNam, 1);
            this.lbNam.Location = new System.Drawing.Point(63, 142);
            this.lbNam.Name = "lbNam";
            this.nam.SetRow(this.lbNam, 4);
            this.lbNam.Size = new System.Drawing.Size(32, 20);
            this.lbNam.TabIndex = 21;
            this.lbNam.Text = "Năm";
            // 
            // lbTo
            // 
            this.nam.SetColumn(this.lbTo, 1);
            this.lbTo.Location = new System.Drawing.Point(63, 112);
            this.lbTo.Name = "lbTo";
            this.nam.SetRow(this.lbTo, 3);
            this.lbTo.Size = new System.Drawing.Size(17, 20);
            this.lbTo.TabIndex = 11;
            this.lbTo.Text = "Tổ";
            // 
            // lbXiNghiep
            // 
            this.nam.SetColumn(this.lbXiNghiep, 1);
            this.lbXiNghiep.Location = new System.Drawing.Point(63, 80);
            this.lbXiNghiep.Name = "lbXiNghiep";
            this.nam.SetRow(this.lbXiNghiep, 2);
            this.lbXiNghiep.Size = new System.Drawing.Size(63, 20);
            this.lbXiNghiep.TabIndex = 10;
            this.lbXiNghiep.Text = "Xí nghiệp";
            // 
            // lbDonVi
            // 
            this.nam.SetColumn(this.lbDonVi, 1);
            this.lbDonVi.Location = new System.Drawing.Point(63, 46);
            this.lbDonVi.Name = "lbDonVi";
            this.nam.SetRow(this.lbDonVi, 1);
            this.lbDonVi.Size = new System.Drawing.Size(43, 20);
            this.lbDonVi.TabIndex = 9;
            this.lbDonVi.Text = "Đơn vị";
            // 
            // lbNgayIn
            // 
            this.nam.SetColumn(this.lbNgayIn, 7);
            this.lbNgayIn.Location = new System.Drawing.Point(779, 144);
            this.lbNgayIn.Name = "lbNgayIn";
            this.nam.SetRow(this.lbNgayIn, 4);
            this.lbNgayIn.Size = new System.Drawing.Size(51, 20);
            this.lbNgayIn.TabIndex = 7;
            this.lbNgayIn.Text = "Ngay In";
            // 
            // lk_DenNgay
            // 
            this.nam.SetColumn(this.lk_DenNgay, 8);
            this.lk_DenNgay.EditValue = null;
            this.lk_DenNgay.Location = new System.Drawing.Point(908, 141);
            this.lk_DenNgay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lk_DenNgay.Name = "lk_DenNgay";
            this.lk_DenNgay.Properties.Appearance.Options.UseTextOptions = true;
            this.lk_DenNgay.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lk_DenNgay.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lk_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nam.SetRow(this.lk_DenNgay, 4);
            this.lk_DenNgay.Size = new System.Drawing.Size(132, 26);
            this.lk_DenNgay.TabIndex = 5;
            // 
            // LK_XI_NGHIEP
            // 
            this.nam.SetColumn(this.LK_XI_NGHIEP, 2);
            this.nam.SetColumnSpan(this.LK_XI_NGHIEP, 7);
            this.LK_XI_NGHIEP.Location = new System.Drawing.Point(183, 77);
            this.LK_XI_NGHIEP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_XI_NGHIEP.Name = "LK_XI_NGHIEP";
            this.LK_XI_NGHIEP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nam.SetRow(this.LK_XI_NGHIEP, 2);
            this.LK_XI_NGHIEP.Size = new System.Drawing.Size(857, 26);
            this.LK_XI_NGHIEP.TabIndex = 3;
            this.LK_XI_NGHIEP.EditValueChanged += new System.EventHandler(this.LK_XI_NGHIEP_EditValueChanged);
            // 
            // LK_DON_VI
            // 
            this.nam.SetColumn(this.LK_DON_VI, 2);
            this.nam.SetColumnSpan(this.LK_DON_VI, 7);
            this.LK_DON_VI.Location = new System.Drawing.Point(183, 43);
            this.LK_DON_VI.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.LK_DON_VI.Name = "LK_DON_VI";
            this.LK_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nam.SetRow(this.LK_DON_VI, 1);
            this.LK_DON_VI.Size = new System.Drawing.Size(858, 26);
            this.LK_DON_VI.TabIndex = 1;
            this.LK_DON_VI.EditValueChanged += new System.EventHandler(this.LK_DON_VI_EditValueChanged);
            // 
            // LK_TO
            // 
            this.nam.SetColumn(this.LK_TO, 2);
            this.nam.SetColumnSpan(this.LK_TO, 7);
            this.LK_TO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LK_TO.Location = new System.Drawing.Point(183, 109);
            this.LK_TO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_TO.Name = "LK_TO";
            this.LK_TO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nam.SetRow(this.LK_TO, 3);
            this.LK_TO.Size = new System.Drawing.Size(857, 26);
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
            this.layoutControlItem1.Control = this.nam;
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
            // ucBaoCaoQuanLyPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucBaoCaoQuanLyPhep";
            this.Size = new System.Drawing.Size(1128, 658);
            this.Tag = "ucBaoCaoQuanLyPhep";
            this.Load += new System.EventHandler(this.ucBaoCaoQuanLyPhep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).EndInit();
            this.popupContainerControl2.ResumeLayout(false);
            this.popupContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calThang.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nam)).EndInit();
            this.nam.ResumeLayout(false);
            this.nam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_Nam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_DiTreVeSom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo_ChonBaoCao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_DenNgay.Properties)).EndInit();
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
        private DevExpress.Utils.Layout.TablePanel nam;
        private DevExpress.XtraEditors.DateEdit lk_DenNgay;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lbNgayIn;
        private DevExpress.XtraEditors.LabelControl lbTo;
        private DevExpress.XtraEditors.LabelControl lbXiNghiep;
        private DevExpress.XtraEditors.LabelControl lbDonVi;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_XI_NGHIEP;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_DON_VI;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_TO;
        private DevExpress.XtraEditors.LabelControl lbNam;
        private DevExpress.XtraEditors.RadioGroup rdo_DiTreVeSom;
        private DevExpress.XtraEditors.RadioGroup rdo_ChonBaoCao;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl2;
        private DevExpress.XtraEditors.Controls.CalendarControl calThang;
        private Commons.MPopupContainerEdit lk_Nam;
    }
}
