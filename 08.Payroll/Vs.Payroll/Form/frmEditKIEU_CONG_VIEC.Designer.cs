namespace Vs.Payroll
{
    partial class frmEditKIEU_CONG_VIEC
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
            this.txtKCV = new DevExpress.XtraEditors.TextEdit();
            this.txtKCV_A = new DevExpress.XtraEditors.TextEdit();
            this.txtKCV_H = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForKCV = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForKCV_A = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForKCV_H = new DevExpress.XtraLayout.LayoutControlItem();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtMS_KCV = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider11 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.ItemForMC_KCV = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV_A.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV_H.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV_A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV_H)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_KCV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMC_KCV)).BeginInit();
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
            this.dataLayoutControl1.Controls.Add(this.txtKCV);
            this.dataLayoutControl1.Controls.Add(this.txtKCV_A);
            this.dataLayoutControl1.Controls.Add(this.txtKCV_H);
            this.dataLayoutControl1.Controls.Add(this.txtMS_KCV);
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
            // txtKCV
            // 
            this.txtKCV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKCV.Location = new System.Drawing.Point(112, 36);
            this.txtKCV.Name = "txtKCV";
            this.txtKCV.Size = new System.Drawing.Size(464, 20);
            this.txtKCV.StyleController = this.dataLayoutControl1;
            this.txtKCV.TabIndex = 7;
            // 
            // txtKCV_A
            // 
            this.txtKCV_A.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKCV_A.Location = new System.Drawing.Point(112, 60);
            this.txtKCV_A.Name = "txtKCV_A";
            this.txtKCV_A.Size = new System.Drawing.Size(464, 20);
            this.txtKCV_A.StyleController = this.dataLayoutControl1;
            this.txtKCV_A.TabIndex = 7;
            // 
            // txtKCV_H
            // 
            this.txtKCV_H.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtKCV_H.Location = new System.Drawing.Point(112, 84);
            this.txtKCV_H.Name = "txtKCV_H";
            this.txtKCV_H.Size = new System.Drawing.Size(464, 20);
            this.txtKCV_H.StyleController = this.dataLayoutControl1;
            this.txtKCV_H.TabIndex = 7;
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
            this.ItemForKCV,
            this.ItemForKCV_A,
            this.ItemForKCV_H,
            this.ItemForMC_KCV});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "autoGeneratedGroup0";
            this.layoutControlGroup1.Size = new System.Drawing.Size(568, 283);
            // 
            // ItemForKCV
            // 
            this.ItemForKCV.Control = this.txtKCV;
            this.ItemForKCV.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKCV.CustomizationFormText = "Hệ số đơn giá";
            this.ItemForKCV.Location = new System.Drawing.Point(0, 24);
            this.ItemForKCV.Name = "ItemForKCV";
            this.ItemForKCV.Size = new System.Drawing.Size(568, 24);
            this.ItemForKCV.Text = "Kiểu công việc";
            this.ItemForKCV.TextSize = new System.Drawing.Size(97, 13);
            // 
            // ItemForKCV_A
            // 
            this.ItemForKCV_A.Control = this.txtKCV_A;
            this.ItemForKCV_A.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKCV_A.Location = new System.Drawing.Point(0, 48);
            this.ItemForKCV_A.Name = "ItemForKCV_A";
            this.ItemForKCV_A.Size = new System.Drawing.Size(568, 24);
            this.ItemForKCV_A.Text = "Kiểu công việc (Eng)";
            this.ItemForKCV_A.TextSize = new System.Drawing.Size(97, 13);
            // 
            // ItemForKCV_H
            // 
            this.ItemForKCV_H.Control = this.txtKCV_H;
            this.ItemForKCV_H.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForKCV_H.Location = new System.Drawing.Point(0, 72);
            this.ItemForKCV_H.Name = "ItemForKCV_H";
            this.ItemForKCV_H.Size = new System.Drawing.Size(568, 211);
            this.ItemForKCV_H.Text = "Kiểu công việc (Ch)";
            this.ItemForKCV_H.TextSize = new System.Drawing.Size(97, 13);
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
            // txtMS_KCV
            // 
            this.txtMS_KCV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtMS_KCV.Location = new System.Drawing.Point(112, 12);
            this.txtMS_KCV.Name = "txtMS_KCV";
            this.txtMS_KCV.Size = new System.Drawing.Size(464, 20);
            this.txtMS_KCV.StyleController = this.dataLayoutControl1;
            this.txtMS_KCV.TabIndex = 7;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider11.SetValidationRule(this.txtMS_KCV, conditionValidationRule1);
            // 
            // ItemForMC_KCV
            // 
            this.ItemForMC_KCV.Control = this.txtMS_KCV;
            this.ItemForMC_KCV.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.ItemForMC_KCV.CustomizationFormText = "MS kiểu công việc";
            this.ItemForMC_KCV.Location = new System.Drawing.Point(0, 0);
            this.ItemForMC_KCV.Name = "ItemForMC_KCV";
            this.ItemForMC_KCV.Size = new System.Drawing.Size(568, 24);
            this.ItemForMC_KCV.Text = "MS kiểu công việc";
            this.ItemForMC_KCV.TextSize = new System.Drawing.Size(97, 13);
            // 
            // frmEditKIEU_CONG_VIEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 395);
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.btnALL);
            this.Name = "frmEditKIEU_CONG_VIEC";
            this.Text = "frmEditKIEU_CONG_VIEC";
            this.Load += new System.EventHandler(this.frmEditKIEU_CONG_VIEC_Load);
            this.Resize += new System.EventHandler(this.frmEditKIEU_CONG_VIEC_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV_A.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKCV_H.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV_A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKCV_H)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMS_KCV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMC_KCV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel btnALL;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtKCV;
        private DevExpress.XtraEditors.TextEdit txtKCV_A;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKCV;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKCV_A;
        private DevExpress.XtraEditors.TextEdit txtKCV_H;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKCV_H;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtMS_KCV;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider11;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMC_KCV;
    }
}