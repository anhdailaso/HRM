﻿using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Vs.Payroll
{
    public partial class frmEditKINH_NGHIEM_LAM_VIEC : DevExpress.XtraEditors.XtraForm
    {
        static Int64 Id = 0;
        static Boolean AddEdit = true;  // true la add false la edit

        public frmEditKINH_NGHIEM_LAM_VIEC(Int64 iId, Boolean bAddEdit)
        {
            InitializeComponent();
            Id = iId;
            AddEdit = bAddEdit;
        }

        private void frmEditKINH_NGHIEM_LAM_VIEC_Load(object sender, EventArgs e)
        {
            if (!AddEdit) LoadText();
            Commons.Modules.ObjSystems.ThayDoiNN(this, layoutControlGroup1, btnALL);
        }
        private void frmEditKINH_NGHIEM_LAM_VIEC_Resize(object sender, EventArgs e) => dataLayoutControl1.Refresh();
        private void LoadText()
        {
            try
            {
                string sSql = "select * from KINH_NGHIEM_LV where ID_KNLV  = " + Id ;
                DataTable dtTmp = new DataTable();
                dtTmp.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                
                txtMS_KNLV.EditValue = dtTmp.Rows[0]["MS_KNLV"].ToString();
                txtKNLV.EditValue = dtTmp.Rows[0]["TEN_KNLV"].ToString();
                txtKNLV_A.EditValue = dtTmp.Rows[0]["TEN_KNLV_A"].ToString();
                txtKNLV_H.EditValue = dtTmp.Rows[0]["TEN_KNLV_H"].ToString();
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }

        }
        private void LoadTextNull()
        {
            try
            {
                
                txtMS_KNLV.EditValue = String.Empty;
                txtKNLV.EditValue = String.Empty;
                txtKNLV_A.EditValue = String.Empty;
                txtKNLV_H.EditValue = String.Empty;
            }
            catch { }
        }
        private void btnALL_ButtonClick(object sender, ButtonEventArgs e)
        {
            try
            {
                WindowsUIButton btn = e.Button as WindowsUIButton;
                XtraUserControl ctl = new XtraUserControl();
                switch (btn.Tag.ToString())
                {

                    case "luu":
                        {
                            if (!dxValidationProvider1.Validate()) return;
                            if (bKiemTrung()) return;
                            try
                            {
                                DataTable dt = new DataTable();
                                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spUpdateKINH_NGHIEM_LV", (AddEdit ? 1 : 0),Id,  txtMS_KNLV.EditValue.ToString(), txtKNLV.EditValue.ToString(), txtKNLV_A.EditValue.ToString(), txtKNLV_H.EditValue.ToString()));

                                if (AddEdit)
                                {
                                    if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("frmMain", "msgThemThanhCongBanMuonThemTiep"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        LoadTextNull();
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(ex.Message.ToString());
                                throw;
                            }

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            break;
                        }
                    case "thoat":
                        {
                            this.Close();
                            break;
                        }
                    default: break;
                }
            }
            catch (Exception EX)
            {
                XtraMessageBox.Show(EX.Message.ToString());
            }
        }
        private bool bKiemTrung()
        {
            try
            {
                string sSql = "";
                if (AddEdit)
                {
                    sSql = "SELECT COUNT(*) FROM KINH_NGHIEM_LV WHERE MS_KNLV = '" + txtMS_KNLV.EditValue +"'";
                    if (Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)) != 0)
                    {
                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgMS_MSkNLvNayDaTonTai"));
                        
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return true;
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}