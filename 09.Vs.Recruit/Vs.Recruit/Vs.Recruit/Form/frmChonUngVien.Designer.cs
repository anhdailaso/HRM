
namespace Vs.Recruit
{
    partial class frmChonUngVien
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
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonUngVien));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions2 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions3 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.grdChonUV = new DevExpress.XtraGrid.GridControl();
            this.grvChonUV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboID_BC = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit4View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboID_KNLV = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit3View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboID_TDVH = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cboCHUYEN_MON = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblCHUYEN_MON = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_TDVH = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_KNLV = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblID_BC = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnALL = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChonUV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChonUV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_BC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit4View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_KNLV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_TDVH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCHUYEN_MON.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHUYEN_MON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_TDVH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_KNLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_BC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 10F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 10F)});
            this.tablePanel1.Controls.Add(this.dataLayoutControl1);
            this.tablePanel1.Controls.Add(this.btnALL);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 8F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 90F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 46F)});
            this.tablePanel1.Size = new System.Drawing.Size(669, 370);
            this.tablePanel1.TabIndex = 0;
            // 
            // dataLayoutControl1
            // 
            this.tablePanel1.SetColumn(this.dataLayoutControl1, 1);
            this.dataLayoutControl1.Controls.Add(this.grdChonUV);
            this.dataLayoutControl1.Controls.Add(this.cboID_BC);
            this.dataLayoutControl1.Controls.Add(this.cboID_KNLV);
            this.dataLayoutControl1.Controls.Add(this.cboID_TDVH);
            this.dataLayoutControl1.Controls.Add(this.cboCHUYEN_MON);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(13, 11);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.tablePanel1.SetRow(this.dataLayoutControl1, 1);
            this.dataLayoutControl1.Size = new System.Drawing.Size(643, 310);
            this.dataLayoutControl1.TabIndex = 13;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // grdChonUV
            // 
            this.grdChonUV.Location = new System.Drawing.Point(12, 60);
            this.grdChonUV.MainView = this.grvChonUV;
            this.grdChonUV.Name = "grdChonUV";
            this.grdChonUV.Size = new System.Drawing.Size(619, 238);
            this.grdChonUV.TabIndex = 5;
            this.grdChonUV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChonUV});
            // 
            // grvChonUV
            // 
            this.grvChonUV.ColumnPanelRowHeight = 0;
            this.grvChonUV.FixedLineWidth = 1;
            this.grvChonUV.FooterPanelHeight = 0;
            this.grvChonUV.GridControl = this.grdChonUV;
            this.grvChonUV.GroupRowHeight = 0;
            this.grvChonUV.Name = "grvChonUV";
            this.grvChonUV.OptionsSelection.MultiSelect = true;
            this.grvChonUV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.grvChonUV.OptionsView.ShowGroupPanel = false;
            this.grvChonUV.RowHeight = 0;
            this.grvChonUV.ViewCaptionHeight = 0;
            this.grvChonUV.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grvChonUV_PopupMenuShowing);
            this.grvChonUV.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.grvChonUV_MouseWheel);
            // 
            // cboID_BC
            // 
            this.cboID_BC.Location = new System.Drawing.Point(405, 36);
            this.cboID_BC.Name = "cboID_BC";
            this.cboID_BC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_BC.Properties.NullText = "";
            this.cboID_BC.Properties.PopupView = this.searchLookUpEdit4View;
            this.cboID_BC.Size = new System.Drawing.Size(226, 20);
            this.cboID_BC.StyleController = this.dataLayoutControl1;
            this.cboID_BC.TabIndex = 4;
            this.cboID_BC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboID_BC_KeyDown);
            // 
            // searchLookUpEdit4View
            // 
            this.searchLookUpEdit4View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit4View.Name = "searchLookUpEdit4View";
            this.searchLookUpEdit4View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit4View.OptionsView.ShowGroupPanel = false;
            // 
            // cboID_KNLV
            // 
            this.cboID_KNLV.Location = new System.Drawing.Point(94, 36);
            this.cboID_KNLV.Name = "cboID_KNLV";
            this.cboID_KNLV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_KNLV.Properties.NullText = "";
            this.cboID_KNLV.Properties.PopupView = this.searchLookUpEdit3View;
            this.cboID_KNLV.Size = new System.Drawing.Size(225, 20);
            this.cboID_KNLV.StyleController = this.dataLayoutControl1;
            this.cboID_KNLV.TabIndex = 3;
            this.cboID_KNLV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboID_KNLV_KeyDown);
            // 
            // searchLookUpEdit3View
            // 
            this.searchLookUpEdit3View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit3View.Name = "searchLookUpEdit3View";
            this.searchLookUpEdit3View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit3View.OptionsView.ShowGroupPanel = false;
            // 
            // cboID_TDVH
            // 
            this.cboID_TDVH.Location = new System.Drawing.Point(405, 12);
            this.cboID_TDVH.Name = "cboID_TDVH";
            this.cboID_TDVH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboID_TDVH.Properties.NullText = "";
            this.cboID_TDVH.Properties.PopupView = this.searchLookUpEdit2View;
            this.cboID_TDVH.Size = new System.Drawing.Size(226, 20);
            this.cboID_TDVH.StyleController = this.dataLayoutControl1;
            this.cboID_TDVH.TabIndex = 2;
            this.cboID_TDVH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboID_TDVH_KeyDown);
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // cboCHUYEN_MON
            // 
            this.cboCHUYEN_MON.Location = new System.Drawing.Point(94, 12);
            this.cboCHUYEN_MON.Name = "cboCHUYEN_MON";
            this.cboCHUYEN_MON.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCHUYEN_MON.Properties.NullText = "";
            this.cboCHUYEN_MON.Properties.PopupView = this.searchLookUpEdit1View;
            this.cboCHUYEN_MON.Size = new System.Drawing.Size(225, 20);
            this.cboCHUYEN_MON.StyleController = this.dataLayoutControl1;
            this.cboCHUYEN_MON.TabIndex = 1;
            this.cboCHUYEN_MON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboCHUYEN_MON_KeyDown);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblCHUYEN_MON,
            this.lblID_TDVH,
            this.lblID_KNLV,
            this.lblID_BC,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(643, 310);
            this.Root.TextVisible = false;
            // 
            // lblCHUYEN_MON
            // 
            this.lblCHUYEN_MON.Control = this.cboCHUYEN_MON;
            this.lblCHUYEN_MON.Location = new System.Drawing.Point(0, 0);
            this.lblCHUYEN_MON.Name = "lblCHUYEN_MON";
            this.lblCHUYEN_MON.Size = new System.Drawing.Size(311, 24);
            this.lblCHUYEN_MON.TextSize = new System.Drawing.Size(79, 13);
            // 
            // lblID_TDVH
            // 
            this.lblID_TDVH.Control = this.cboID_TDVH;
            this.lblID_TDVH.Location = new System.Drawing.Point(311, 0);
            this.lblID_TDVH.Name = "lblID_TDVH";
            this.lblID_TDVH.Size = new System.Drawing.Size(312, 24);
            this.lblID_TDVH.TextSize = new System.Drawing.Size(79, 13);
            // 
            // lblID_KNLV
            // 
            this.lblID_KNLV.Control = this.cboID_KNLV;
            this.lblID_KNLV.Location = new System.Drawing.Point(0, 24);
            this.lblID_KNLV.Name = "lblID_KNLV";
            this.lblID_KNLV.Size = new System.Drawing.Size(311, 24);
            this.lblID_KNLV.TextSize = new System.Drawing.Size(79, 13);
            // 
            // lblID_BC
            // 
            this.lblID_BC.Control = this.cboID_BC;
            this.lblID_BC.Location = new System.Drawing.Point(311, 24);
            this.lblID_BC.Name = "lblID_BC";
            this.lblID_BC.Size = new System.Drawing.Size(312, 24);
            this.lblID_BC.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grdChonUV;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(623, 242);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btnALL
            // 
            this.btnALL.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.btnALL.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.Gray;
            this.btnALL.AppearanceButton.Hovered.Options.UseFont = true;
            this.btnALL.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.btnALL.AppearanceButton.Normal.FontSizeDelta = -1;
            this.btnALL.AppearanceButton.Normal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnALL.AppearanceButton.Normal.Options.UseFont = true;
            this.btnALL.AppearanceButton.Normal.Options.UseForeColor = true;
            this.btnALL.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnALL.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.btnALL.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.btnALL.AppearanceButton.Pressed.Options.UseBorderColor = true;
            this.btnALL.AppearanceButton.Pressed.Options.UseFont = true;
            this.btnALL.AppearanceButton.Pressed.Options.UseImage = true;
            this.btnALL.AppearanceButton.Pressed.Options.UseTextOptions = true;
            windowsUIButtonImageOptions1.ImageUri.Uri = "SaveAll";
            windowsUIButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions1.SvgImage")));
            windowsUIButtonImageOptions2.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("windowsUIButtonImageOptions2.SvgImage")));
            windowsUIButtonImageOptions3.ImageUri.Uri = "richedit/clearheaderandfooter";
            this.btnALL.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "in", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "ghi", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("", true, windowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "thoat", -1, false)});
            this.tablePanel1.SetColumn(this.btnALL, 0);
            this.tablePanel1.SetColumnSpan(this.btnALL, 3);
            this.btnALL.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btnALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnALL.Location = new System.Drawing.Point(3, 327);
            this.btnALL.Name = "btnALL";
            this.tablePanel1.SetRow(this.btnALL, 2);
            this.btnALL.Size = new System.Drawing.Size(663, 40);
            this.btnALL.TabIndex = 6;
            this.btnALL.Text = "btnALLPanel1";
            this.btnALL.UseButtonBackgroundImages = false;
            this.btnALL.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.btnALL_ButtonClick);
            // 
            // frmChonUngVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 370);
            this.Controls.Add(this.tablePanel1);
            this.Name = "frmChonUngVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmChonUngVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdChonUV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChonUV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_BC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit4View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_KNLV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit3View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboID_TDVH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCHUYEN_MON.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHUYEN_MON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_TDVH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_KNLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblID_BC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraGrid.GridControl grdChonUV;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChonUV;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_BC;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit4View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_KNLV;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit3View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboID_TDVH;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraEditors.SearchLookUpEdit cboCHUYEN_MON;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem lblCHUYEN_MON;
        private DevExpress.XtraLayout.LayoutControlItem lblID_TDVH;
        private DevExpress.XtraLayout.LayoutControlItem lblID_KNLV;
        private DevExpress.XtraLayout.LayoutControlItem lblID_BC;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel btnALL;
    }
}