namespace Vs.TimeAttendance
{
    partial class XtraForm1
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
            this.grdTest = new DevExpress.XtraGrid.GridControl();
            this.grvTest = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtDate = new DevExpress.XtraEditors.TextEdit();
            this.maskTest = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskTest.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskTest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTest
            // 
            this.grdTest.Location = new System.Drawing.Point(73, 43);
            this.grdTest.MainView = this.grvTest;
            this.grdTest.Name = "grdTest";
            this.grdTest.Size = new System.Drawing.Size(704, 305);
            this.grdTest.TabIndex = 0;
            this.grdTest.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTest});
            // 
            // grvTest
            // 
            this.grvTest.GridControl = this.grdTest;
            this.grvTest.Name = "grvTest";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(298, 354);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(132, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(86, 354);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(142, 26);
            this.txtDate.TabIndex = 2;
            // 
            // maskTest
            // 
            this.maskTest.EditValue = null;
            this.maskTest.Location = new System.Drawing.Point(474, 361);
            this.maskTest.Name = "maskTest";
            this.maskTest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.maskTest.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.maskTest.Size = new System.Drawing.Size(164, 26);
            this.maskTest.TabIndex = 3;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 399);
            this.Controls.Add(this.maskTest);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grdTest);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskTest.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maskTest.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdTest;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTest;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtDate;
        private DevExpress.XtraEditors.DateEdit maskTest;
    }
}