﻿namespace Vs.HRM
{
    partial class ucBaoCaoDanhGianNV
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
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
            this.lbNoiDung = new DevExpress.XtraEditors.LabelControl();
            this.lbDiemTu = new DevExpress.XtraEditors.LabelControl();
            this.lbDen = new DevExpress.XtraEditors.LabelControl();
            this.txDiemTu = new DevExpress.XtraEditors.TextEdit();
            this.txDiemDen = new DevExpress.XtraEditors.TextEdit();
            this.LK_NOI_DUNG = new DevExpress.XtraEditors.SearchLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_XI_NGHIEP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DON_VI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_TO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDiemTu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDiemDen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_NOI_DUNG.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // windowsUIButton
            // 
            windowsUIButtonImageOptions1.Image = global::Vs.HRM.Properties.Resources.print;
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
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 389F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F)});
            this.tablePanel1.Controls.Add(this.txDiemDen);
            this.tablePanel1.Controls.Add(this.txDiemTu);
            this.tablePanel1.Controls.Add(this.lbTo);
            this.tablePanel1.Controls.Add(this.lbXiNghiep);
            this.tablePanel1.Controls.Add(this.lbDonVi);
            this.tablePanel1.Controls.Add(this.lbNgay);
            this.tablePanel1.Controls.Add(this.lk_NgayIn);
            this.tablePanel1.Controls.Add(this.LK_XI_NGHIEP);
            this.tablePanel1.Controls.Add(this.LK_DON_VI);
            this.tablePanel1.Controls.Add(this.LK_TO);
            this.tablePanel1.Controls.Add(this.lbNoiDung);
            this.tablePanel1.Controls.Add(this.lbDiemTu);
            this.tablePanel1.Controls.Add(this.lbDen);
            this.tablePanel1.Controls.Add(this.LK_NOI_DUNG);
            this.tablePanel1.Location = new System.Drawing.Point(6, 6);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 32F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 36F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1116, 574);
            this.tablePanel1.TabIndex = 4;
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
            this.tablePanel1.SetColumn(this.lbNgay, 4);
            this.lbNgay.Location = new System.Drawing.Point(513, 206);
            this.lbNgay.Name = "lbNgay";
            this.tablePanel1.SetRow(this.lbNgay, 6);
            this.lbNgay.Size = new System.Drawing.Size(51, 20);
            this.lbNgay.TabIndex = 7;
            this.lbNgay.Text = "Ngày in";
            // 
            // lk_NgayIn
            // 
            this.tablePanel1.SetColumn(this.lk_NgayIn, 5);
            this.lk_NgayIn.EditValue = null;
            this.lk_NgayIn.Location = new System.Drawing.Point(664, 203);
            this.lk_NgayIn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lk_NgayIn.Name = "lk_NgayIn";
            this.lk_NgayIn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lk_NgayIn.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.lk_NgayIn, 6);
            this.lk_NgayIn.Size = new System.Drawing.Size(381, 26);
            this.lk_NgayIn.TabIndex = 5;
            // 
            // LK_XI_NGHIEP
            // 
            this.tablePanel1.SetColumn(this.LK_XI_NGHIEP, 2);
            this.tablePanel1.SetColumnSpan(this.LK_XI_NGHIEP, 4);
            this.LK_XI_NGHIEP.Location = new System.Drawing.Point(214, 77);
            this.LK_XI_NGHIEP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_XI_NGHIEP.Name = "LK_XI_NGHIEP";
            this.LK_XI_NGHIEP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_XI_NGHIEP, 2);
            this.LK_XI_NGHIEP.Size = new System.Drawing.Size(831, 26);
            this.LK_XI_NGHIEP.TabIndex = 3;
            this.LK_XI_NGHIEP.EditValueChanged += new System.EventHandler(this.LK_XI_NGHIEP_EditValueChanged);
            // 
            // LK_DON_VI
            // 
            this.tablePanel1.SetColumn(this.LK_DON_VI, 2);
            this.tablePanel1.SetColumnSpan(this.LK_DON_VI, 4);
            this.LK_DON_VI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LK_DON_VI.Location = new System.Drawing.Point(213, 43);
            this.LK_DON_VI.Name = "LK_DON_VI";
            this.LK_DON_VI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_DON_VI, 1);
            this.LK_DON_VI.Size = new System.Drawing.Size(833, 26);
            this.LK_DON_VI.TabIndex = 1;
            this.LK_DON_VI.EditValueChanged += new System.EventHandler(this.LK_DON_VI_EditValueChanged);
            // 
            // LK_TO
            // 
            this.tablePanel1.SetColumn(this.LK_TO, 2);
            this.tablePanel1.SetColumnSpan(this.LK_TO, 4);
            this.LK_TO.Location = new System.Drawing.Point(214, 109);
            this.LK_TO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_TO.Name = "LK_TO";
            this.LK_TO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_TO, 3);
            this.LK_TO.Size = new System.Drawing.Size(831, 26);
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
            // lbNoiDung
            // 
            this.tablePanel1.SetColumn(this.lbNoiDung, 1);
            this.lbNoiDung.Location = new System.Drawing.Point(63, 144);
            this.lbNoiDung.Name = "lbNoiDung";
            this.tablePanel1.SetRow(this.lbNoiDung, 4);
            this.lbNoiDung.Size = new System.Drawing.Size(62, 20);
            this.lbNoiDung.TabIndex = 10;
            this.lbNoiDung.Text = "Nội dung";
            // 
            // lbDiemTu
            // 
            this.tablePanel1.SetColumn(this.lbDiemTu, 1);
            this.lbDiemTu.Location = new System.Drawing.Point(63, 178);
            this.lbDiemTu.Name = "lbDiemTu";
            this.tablePanel1.SetRow(this.lbDiemTu, 5);
            this.lbDiemTu.Size = new System.Drawing.Size(54, 20);
            this.lbDiemTu.TabIndex = 10;
            this.lbDiemTu.Text = "Điểm từ";
            // 
            // lbDen
            // 
            this.tablePanel1.SetColumn(this.lbDen, 3);
            this.lbDen.Location = new System.Drawing.Point(363, 178);
            this.lbDen.Name = "lbDen";
            this.tablePanel1.SetRow(this.lbDen, 5);
            this.lbDen.Size = new System.Drawing.Size(27, 20);
            this.lbDen.TabIndex = 10;
            this.lbDen.Text = "Đến";
            // 
            // txDiemTu
            // 
            this.tablePanel1.SetColumn(this.txDiemTu, 2);
            this.txDiemTu.Location = new System.Drawing.Point(213, 175);
            this.txDiemTu.Name = "txDiemTu";
            this.tablePanel1.SetRow(this.txDiemTu, 5);
            this.txDiemTu.Size = new System.Drawing.Size(144, 26);
            this.txDiemTu.TabIndex = 12;
            // 
            // txDiemDen
            // 
            this.tablePanel1.SetColumn(this.txDiemDen, 4);
            this.txDiemDen.Location = new System.Drawing.Point(513, 175);
            this.txDiemDen.Name = "txDiemDen";
            this.tablePanel1.SetRow(this.txDiemDen, 5);
            this.txDiemDen.Size = new System.Drawing.Size(144, 26);
            this.txDiemDen.TabIndex = 13;
            // 
            // LK_NOI_DUNG
            // 
            this.tablePanel1.SetColumn(this.LK_NOI_DUNG, 2);
            this.tablePanel1.SetColumnSpan(this.LK_NOI_DUNG, 4);
            this.LK_NOI_DUNG.Location = new System.Drawing.Point(214, 141);
            this.LK_NOI_DUNG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LK_NOI_DUNG.Name = "LK_NOI_DUNG";
            this.LK_NOI_DUNG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tablePanel1.SetRow(this.LK_NOI_DUNG, 4);
            this.LK_NOI_DUNG.Size = new System.Drawing.Size(831, 26);
            this.LK_NOI_DUNG.TabIndex = 3;
            // 
            // ucBaoCaoDanhGianNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.windowsUIButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucBaoCaoDanhGianNV";
            this.Size = new System.Drawing.Size(1128, 658);
            this.Load += new System.EventHandler(this.ucBaoCaoDanhGianNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lk_NgayIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_XI_NGHIEP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DON_VI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_TO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDiemTu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txDiemDen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_NOI_DUNG.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.DateEdit lk_NgayIn;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_XI_NGHIEP;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_DON_VI;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lbNgay;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_TO;
        private DevExpress.XtraEditors.LabelControl lbTo;
        private DevExpress.XtraEditors.LabelControl lbXiNghiep;
        private DevExpress.XtraEditors.LabelControl lbDonVi;
        private DevExpress.XtraEditors.TextEdit txDiemDen;
        private DevExpress.XtraEditors.TextEdit txDiemTu;
        private DevExpress.XtraEditors.LabelControl lbNoiDung;
        private DevExpress.XtraEditors.LabelControl lbDiemTu;
        private DevExpress.XtraEditors.LabelControl lbDen;
        private DevExpress.XtraEditors.SearchLookUpEdit LK_NOI_DUNG;
    }
}
