namespace Vs.Payroll
{
    partial class frmEditKINH_NGHIEM_LAM_VIEC
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
            this.btnALL = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.txtKNLV = new DevExpress.XtraEditors.TextEdit();
            this.txtKNLV_A = new DevExpress.XtraEditors.TextEdit();
            this.txtKNLV_H = new DevExpress.XtraEditors.TextEdit();
            this.txtMS_KNLV = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForKNLV = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForKNLV_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForKNLV_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMS_KNLV = new DevExpress.XtraLayout.LayoutControlItem();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.dxValidationProvider11 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_KNLV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMS_KNLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).BeginInit();
            this.SuspendLayout();
            // 
            // btnALL
            // 
            windowsUIButtonImageOptions1.Image = global::Vs.Payroll.Properties.Resources.iconsave;
            windowsUIButtonImageOptions2.Image = global::Vs.Payroll.Properties.Resources.iconxoa;
            this.btnALL.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Lưu", true, windowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "luu", -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Hủy", true, windowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, "huy", -1, false)});
            this.btnALL.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.btnALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnALL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnALL.Location = new System.Drawing.Point(0, 344);
            this.btnALL.Name = "btnALL";
            this.btnALL.Padding = new System.Windows.Forms.Padding(4, 6, 4, 3);
            this.btnALL.Size = new System.Drawing.Size(709, 51);
            this.btnALL.TabIndex = 11;
            this.btnALL.Text = "windowsUIButtonPanel2";
            this.btnALL.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.btnALL_ButtonClick);
            // 
            // dataLayoutControl1
            // 
            this.tablePanel1.SetColumn(this.dataLayoutControl1, 1);
            this.dataLayoutControl1.Controls.Add(this.txtKNLV);
            this.dataLayoutControl1.Controls.Add(this.txtKNLV_A);
            this.dataLayoutControl1.Controls.Add(this.txtKNLV_H);
            this.dataLayoutControl1.Controls.Add(this.txtMS_KNLV);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(51, 38);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(630, 281, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.tablePanel1.SetRow(this.dataLayoutControl1, 1);
            this.dataLayoutControl1.Size = new System.Drawing.Size(588, 303);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // txtKNLV
            // 
            this.txtKNLV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKNLV.Location = new System.Drawing.Point(68, 36);
            this.txtKNLV.Name = "txtKNLV";
            this.txtKNLV.Size = new System.Drawing.Size(508, 20);
            this.txtKNLV.StyleController = this.dataLayoutControl1;
            this.txtKNLV.TabIndex = 7;
            // 
            // txtKNLV_A
            // 
            this.txtKNLV_A.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKNLV_A.Location = new System.Drawing.Point(68, 60);
            this.txtKNLV_A.Name = "txtKNLV_A";
            this.txtKNLV_A.Size = new System.Drawing.Size(508, 20);
            this.txtKNLV_A.StyleController = this.dataLayoutControl1;
            this.txtKNLV_A.TabIndex = 7;
            // 
            // txtKNLV_H
            // 
            this.txtKNLV_H.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKNLV_H.Location = new System.Drawing.Point(68, 84);
            this.txtKNLV_H.Name = "txtKNLV_H";
            this.txtKNLV_H.Size = new System.Drawing.Size(508, 20);
            this.txtKNLV_H.StyleController = this.dataLayoutControl1;
            this.txtKNLV_H.TabIndex = 7;
            // 
            // txtMS_KNLV
            // 
            this.txtMS_KNLV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMS_KNLV.Location = new System.Drawing.Point(68, 12);
            this.txtMS_KNLV.Name = "txtMS_KNLV";
            this.txtMS_KNLV.Size = new System.Drawing.Size(508, 20);
            this.txtMS_KNLV.StyleController = this.dataLayoutControl1;
            this.txtMS_KNLV.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider11.SetValidationRule(this.txtMS_KNLV, conditionValidationRule1);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(588, 303);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AllowDrawBackground = false;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForKNLV,
            this.ItemForKNLV_A,
            this.ItemForKNLV_H,
            this.ItemForMS_KNLV});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(568, 283);
            // 
            // ItemForKNLV
            // 
            this.ItemForKNLV.Control = this.txtKNLV;
            this.ItemForKNLV.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKNLV.CustomizationFormText = "Hệ số đơn giá";
            this.ItemForKNLV.Location = new System.Drawing.Point(0, 24);
            this.ItemForKNLV.Name = "ItemForKNLV";
            this.ItemForKNLV.Size = new System.Drawing.Size(568, 24);
            this.ItemForKNLV.Text = "KNLV";
            this.ItemForKNLV.TextSize = new System.Drawing.Size(53, 13);
            // 
            // ItemForKNLV_A
            // 
            this.ItemForKNLV_A.Control = this.txtKNLV_A;
            this.ItemForKNLV_A.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKNLV_A.Location = new System.Drawing.Point(0, 48);
            this.ItemForKNLV_A.Name = "ItemForKNLV_A";
            this.ItemForKNLV_A.Size = new System.Drawing.Size(568, 24);
            this.ItemForKNLV_A.Text = "KNLV (Eng)";
            this.ItemForKNLV_A.TextSize = new System.Drawing.Size(53, 13);
            // 
            // ItemForKNLV_H
            // 
            this.ItemForKNLV_H.Control = this.txtKNLV_H;
            this.ItemForKNLV_H.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKNLV_H.Location = new System.Drawing.Point(0, 72);
            this.ItemForKNLV_H.Name = "ItemForKNLV_H";
            this.ItemForKNLV_H.Size = new System.Drawing.Size(568, 211);
            this.ItemForKNLV_H.Text = "KNLV(Ch)";
            this.ItemForKNLV_H.TextSize = new System.Drawing.Size(53, 13);
            // 
            // ItemForMS_KNLV
            // 
            this.ItemForMS_KNLV.Control = this.txtMS_KNLV;
            this.ItemForMS_KNLV.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForMS_KNLV.CustomizationFormText = "MS kiểu công việc";
            this.ItemForMS_KNLV.Location = new System.Drawing.Point(0, 0);
            this.ItemForMS_KNLV.Name = "ItemForMS_KNLV";
            this.ItemForMS_KNLV.Size = new System.Drawing.Size(568, 24);
            this.ItemForMS_KNLV.Text = "MS KNLV";
            this.ItemForMS_KNLV.TextSize = new System.Drawing.Size(53, 13);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 6.7F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 83.85F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 9.45F)});
            this.tablePanel1.Controls.Add(this.dataLayoutControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 10.19F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 89.81F)});
            this.tablePanel1.Size = new System.Drawing.Size(709, 344);
            this.tablePanel1.TabIndex = 12;
            // 
            // frmEditKINH_NGHIEM_LAM_VIEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 395);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.btnALL);
            this.Name = "frmEditKINH_NGHIEM_LAM_VIEC";
            this.Text = "frmEditKINH_NGHIEM_LAM_VIEC";
            this.Load += new System.EventHandler(this.frmEditKINH_NGHIEM_LAM_VIEC_Load);
            this.Resize += new System.EventHandler(this.frmEditKINH_NGHIEM_LAM_VIEC_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKNLV_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_KNLV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKNLV_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMS_KNLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel btnALL;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtKNLV;
        private DevExpress.XtraEditors.TextEdit txtKNLV_A;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKNLV;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKNLV_A;
        private DevExpress.XtraEditors.TextEdit txtKNLV_H;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKNLV_H;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtMS_KNLV;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider11;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMS_KNLV;
    }
}