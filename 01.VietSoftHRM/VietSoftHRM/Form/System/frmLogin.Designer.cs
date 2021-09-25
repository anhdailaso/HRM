﻿namespace VietSoftHRM
{
    partial class frmLogin
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLogin = new DevExpress.XtraEditors.LabelControl();
            this.cbo_database = new DevExpress.XtraEditors.LookUpEdit();
            this.che_Repass = new System.Windows.Forms.CheckBox();
            this.che_Reuser = new System.Windows.Forms.CheckBox();
            this.btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_login = new DevExpress.XtraEditors.SimpleButton();
            this.pan_pass = new System.Windows.Forms.Panel();
            this.pan_user = new System.Windows.Forms.Panel();
            this.pan_database = new System.Windows.Forms.Panel();
            this.pic_pass = new DevExpress.XtraEditors.PictureEdit();
            this.pic_user = new DevExpress.XtraEditors.PictureEdit();
            this.pic_database = new DevExpress.XtraEditors.PictureEdit();
            this.txt_pass = new DevExpress.XtraEditors.TextEdit();
            this.txt_user = new DevExpress.XtraEditors.TextEdit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_database.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblLogin);
            this.panel2.Controls.Add(this.cbo_database);
            this.panel2.Controls.Add(this.che_Repass);
            this.panel2.Controls.Add(this.che_Reuser);
            this.panel2.Controls.Add(this.btn_Exit);
            this.panel2.Controls.Add(this.btn_login);
            this.panel2.Controls.Add(this.pan_pass);
            this.panel2.Controls.Add(this.pan_user);
            this.panel2.Controls.Add(this.pan_database);
            this.panel2.Controls.Add(this.pic_pass);
            this.panel2.Controls.Add(this.pic_user);
            this.panel2.Controls.Add(this.pic_database);
            this.panel2.Controls.Add(this.txt_pass);
            this.panel2.Controls.Add(this.txt_user);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 353);
            this.panel2.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogin.Appearance.Options.UseFont = true;
            this.lblLogin.Appearance.Options.UseTextOptions = true;
            this.lblLogin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLogin.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLogin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogin.Location = new System.Drawing.Point(0, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(318, 54);
            this.lblLogin.TabIndex = 12;
            this.lblLogin.Text = "Login";
            // 
            // cbo_database
            // 
            this.cbo_database.Location = new System.Drawing.Point(35, 79);
            this.cbo_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_database.Name = "cbo_database";
            this.cbo_database.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cbo_database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_database.Properties.NullText = "Database";
            this.cbo_database.Size = new System.Drawing.Size(276, 24);
            this.cbo_database.TabIndex = 11;
            this.cbo_database.Click += new System.EventHandler(this.Cbo_database_Click);
            this.cbo_database.Validated += new System.EventHandler(this.Cbo_database_Validated);
            // 
            // che_Repass
            // 
            this.che_Repass.AutoSize = true;
            this.che_Repass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.che_Repass.Location = new System.Drawing.Point(148, 239);
            this.che_Repass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.che_Repass.Name = "che_Repass";
            this.che_Repass.Size = new System.Drawing.Size(163, 24);
            this.che_Repass.TabIndex = 4;
            this.che_Repass.Text = "Remember Password";
            this.che_Repass.UseVisualStyleBackColor = true;
            // 
            // che_Reuser
            // 
            this.che_Reuser.AutoSize = true;
            this.che_Reuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.che_Reuser.Location = new System.Drawing.Point(10, 239);
            this.che_Reuser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.che_Reuser.Name = "che_Reuser";
            this.che_Reuser.Size = new System.Drawing.Size(129, 24);
            this.che_Reuser.TabIndex = 3;
            this.che_Reuser.Text = "Remember user";
            this.che_Reuser.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_Exit.AppearanceHovered.Options.UseFont = true;
            this.btn_Exit.AppearanceHovered.Options.UseForeColor = true;
            this.btn_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Exit.Location = new System.Drawing.Point(6, 316);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(304, 30);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Register_Click);
            // 
            // btn_login
            // 
            this.btn_login.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.btn_login.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.btn_login.AppearanceHovered.BorderColor = System.Drawing.Color.White;
            this.btn_login.AppearanceHovered.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_login.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btn_login.AppearanceHovered.Options.UseBackColor = true;
            this.btn_login.AppearanceHovered.Options.UseBorderColor = true;
            this.btn_login.AppearanceHovered.Options.UseFont = true;
            this.btn_login.AppearanceHovered.Options.UseForeColor = true;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Location = new System.Drawing.Point(7, 276);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(304, 30);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Login";
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // pan_pass
            // 
            this.pan_pass.BackColor = System.Drawing.Color.Gray;
            this.pan_pass.Location = new System.Drawing.Point(10, 201);
            this.pan_pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pan_pass.Name = "pan_pass";
            this.pan_pass.Size = new System.Drawing.Size(300, 2);
            this.pan_pass.TabIndex = 3;
            // 
            // pan_user
            // 
            this.pan_user.BackColor = System.Drawing.Color.Gray;
            this.pan_user.Location = new System.Drawing.Point(10, 153);
            this.pan_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pan_user.Name = "pan_user";
            this.pan_user.Size = new System.Drawing.Size(300, 2);
            this.pan_user.TabIndex = 3;
            // 
            // pan_database
            // 
            this.pan_database.BackColor = System.Drawing.Color.Gray;
            this.pan_database.Location = new System.Drawing.Point(10, 105);
            this.pan_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pan_database.Name = "pan_database";
            this.pan_database.Size = new System.Drawing.Size(300, 2);
            this.pan_database.TabIndex = 3;
            // 
            // pic_pass
            // 
            this.pic_pass.EditValue = global::VietSoftHRM.Properties.Resources.icon_pass;
            this.pic_pass.Location = new System.Drawing.Point(7, 170);
            this.pic_pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_pass.Name = "pic_pass";
            this.pic_pass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_pass.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_pass.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_pass.Size = new System.Drawing.Size(31, 38);
            this.pic_pass.TabIndex = 2;
            // 
            // pic_user
            // 
            this.pic_user.EditValue = global::VietSoftHRM.Properties.Resources.icon_user;
            this.pic_user.Location = new System.Drawing.Point(6, 121);
            this.pic_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_user.Name = "pic_user";
            this.pic_user.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_user.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_user.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_user.Size = new System.Drawing.Size(31, 38);
            this.pic_user.TabIndex = 2;
            // 
            // pic_database
            // 
            this.pic_database.EditValue = global::VietSoftHRM.Properties.Resources.icon_data;
            this.pic_database.Location = new System.Drawing.Point(7, 79);
            this.pic_database.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_database.Name = "pic_database";
            this.pic_database.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pic_database.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_database.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pic_database.Size = new System.Drawing.Size(30, 26);
            this.pic_database.TabIndex = 2;
            // 
            // txt_pass
            // 
            this.txt_pass.EditValue = "Password";
            this.txt_pass.Location = new System.Drawing.Point(35, 178);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_pass.Properties.PasswordChar = '•';
            this.txt_pass.Size = new System.Drawing.Size(276, 24);
            this.txt_pass.TabIndex = 2;
            this.txt_pass.Click += new System.EventHandler(this.Txt_pass_Click);
            this.txt_pass.Validated += new System.EventHandler(this.Txt_pass_Validated);
            // 
            // txt_user
            // 
            this.txt_user.EditValue = "Username";
            this.txt_user.Location = new System.Drawing.Point(34, 130);
            this.txt_user.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_user.Name = "txt_user";
            this.txt_user.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txt_user.Properties.Appearance.Options.UseForeColor = true;
            this.txt_user.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txt_user.Size = new System.Drawing.Size(277, 24);
            this.txt_user.TabIndex = 1;
            this.txt_user.Click += new System.EventHandler(this.Txt_user_Click);
            this.txt_user.Validated += new System.EventHandler(this.Txt_user_Validated);
            // 
            // frmLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(318, 353);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.InactiveGlowColor = System.Drawing.Color.Black;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_user.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_database.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_user.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txt_user;
        private DevExpress.XtraEditors.TextEdit txt_pass;
        private System.Windows.Forms.Panel pan_database;
        private DevExpress.XtraEditors.SimpleButton btn_login;
        private DevExpress.XtraEditors.PictureEdit pic_database;
        private System.Windows.Forms.CheckBox che_Repass;
        private System.Windows.Forms.CheckBox che_Reuser;
        private System.Windows.Forms.Panel pan_user;
        private System.Windows.Forms.Panel pan_pass;
        private DevExpress.XtraEditors.SimpleButton btn_Exit;
        private DevExpress.XtraEditors.PictureEdit pic_pass;
        private DevExpress.XtraEditors.PictureEdit pic_user;
        private DevExpress.XtraEditors.LookUpEdit cbo_database;
        private DevExpress.XtraEditors.LabelControl lblLogin;
    }
}