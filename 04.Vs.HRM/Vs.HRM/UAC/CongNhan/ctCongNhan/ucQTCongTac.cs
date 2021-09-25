using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using System.Drawing;

namespace Vs.HRM
{
    public partial class ucQTCongTac : DevExpress.XtraEditors.XtraUserControl
    {
        Int64 idcn = 0;
        int idQTCT = -1;
        int idToCu = -1;
        bool cothem = false;
        DataTable tableTTC_CN = new DataTable();
        public ucQTCongTac(Int64 id)
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root }, windowsUIButton);
            idcn = id;
        }

        private void Loaddatatable()
        {
            tableTTC_CN.Clear();
            tableTTC_CN.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT * FROM dbo.funQuaTrinhCongTac(" + idcn + "," + Commons.Modules.TypeLanguage + ")"));
        }

        #region sự kiệm form
        private void ucQTCongTac_Load(object sender, EventArgs e)
        {
            //format datetime
            Commons.OSystems.SetDateEditFormat(NGAY_KYDateEdit);
            Commons.OSystems.SetDateEditFormat(NGAY_HIEU_LUCDateEdit);

            //load combo
            //ID_LQDLookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_LQDLookUpEdit, Commons.Modules.ObjSystems.DataLoaiQuyetDinh(false), "ID_LQD", "TEN_LQD", "TEN_LQD",true);
            //ID_CVLookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_CVLookUpEdit, Commons.Modules.ObjSystems.DataChucVu(false), "ID_CV", "TEN_CV", "TEN_CV",true);
            //ID_CV_CULookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_CV_CULookUpEdit, Commons.Modules.ObjSystems.DataChucVu(false), "ID_CV", "TEN_CV", "TEN_CV",true);
            //ID_NKLookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_NKLookUpEdit, Commons.Modules.ObjSystems.DataNguoiKy(), "ID_NK", "HO_TEN", "HO_TEN");
            //ID_LCVLookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_LCVLookUpEdit, Commons.Modules.ObjSystems.DataLoaiCV(false), "ID_LCV", "TEN_LCV", "TEN_LCV",true);
            //ID_LCV_CULookUpEdit.EditValue = "";
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_LCV_CULookUpEdit, Commons.Modules.ObjSystems.DataLoaiCV(false), "ID_LCV", "TEN_LCV", "TEN_LCV",true);

            LoadComboboxLoc();

            //Commons.Modules.sPS = "0Load";
            //Commons.Modules.ObjSystems.LoadCboDonVi(DON_VILookUpEdit);
            //Commons.Modules.ObjSystems.LoadCboXiNghiep(DON_VILookUpEdit, XI_NGHIEPLookUpEdit);
            //Commons.Modules.ObjSystems.LoadCboTo(DON_VILookUpEdit, XI_NGHIEPLookUpEdit, ID_TOLookUpEdit);
            //Commons.Modules.sPS = "";

            //try
            //{
            //    Loaddatatable();
            //}
            //catch
            //{
            //}
            LoadgrdCongTac(-1);
            enableButon(true);
            Commons.Modules.ObjSystems.SetPhanQuyen(windowsUIButton);
        }

        private void grvCongTac_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Bindingdata(false);
        }
        
        //=========Tung sua ======

        private void DON_VILookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(XI_NGHIEPLookUpEdit, Commons.Modules.ObjSystems.DataXiNghiep(Convert.ToInt32(DON_VILookUpEdit.EditValue), false), "ID_XN", "TEN_XN", "TEN_XN", true, true);
        }

        private void XI_NGHIEPLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(ID_TOLookUpEdit, Commons.Modules.ObjSystems.DataTo(Convert.ToInt32(DON_VILookUpEdit.EditValue), Convert.ToInt32(XI_NGHIEPLookUpEdit.EditValue), false), "ID_TO", "TEN_TO", "TEN_TO", true, true);
        }

        private void grdCongTac_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }

        #endregion

        #region function load
        private void LoadgrdCongTac(int id)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListCongTac", idcn, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_QTCT"] };
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongTac, grvCongTac, dt, false, true, true, true, true, this.Name);
            grvCongTac.Columns["ID_QTCT"].Visible = false;
            grvCongTac.Columns["ID_CN"].Visible = false;
            grvCongTac.Columns["ID_LQD"].Visible = false;
            grvCongTac.Columns["ID_NK"].Visible = false;
            grvCongTac.Columns["ID_CV"].Visible = false;
            grvCongTac.Columns["ID_LCV"].Visible = false;
            grvCongTac.Columns["ID_TO_CU"].Visible = false;
            grvCongTac.Columns["ID_TO"].Visible = false;
            grvCongTac.Columns["ID_CV_CU"].Visible = false;
            grvCongTac.Columns["ID_LCV_CU"].Visible = false;
            grvCongTac.Columns["MUC_LUONG"].Visible = false;
            grvCongTac.Columns["MUC_LUONG_CU"].Visible = false;
            grvCongTac.Columns["TEN_XN"].Visible = false;
            grvCongTac.Columns["TEN_TO"].Visible = false;
            grvCongTac.Columns["ID_XN"].Visible = false;
            grvCongTac.Columns["ID_DV"].Visible = false;
            grvCongTac.Columns["GHI_CHU"].Visible = false;
            grvCongTac.Columns["NGAY_KY"].Visible = false;
            grvCongTac.Columns["TEN_CN"].Visible = false;

            if (id != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                grvCongTac.FocusedRowHandle = grvCongTac.GetRowHandle(index);
            }
        }

        private void LoadComboboxLoc()
        {
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(DON_VILookUpEdit, Commons.Modules.ObjSystems.DataDonVi(false), "ID_DV", "TEN_DV", "TEN_DV", true, true);
            //Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(XI_NGHIEPLookUpEdit, Commons.Modules.ObjSystems.DataXiNghiep(Convert.ToInt32(DON_VILookUpEdit.EditValue), false), "ID_XN", "TEN_XN", "TEN_XN", true, true);
            //Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(ID_TOLookUpEdit, Commons.Modules.ObjSystems.DataTo(Convert.ToInt32(DON_VILookUpEdit.EditValue), Convert.ToInt32(XI_NGHIEPLookUpEdit.EditValue), false), "ID_TO", "TEN_TO", "TEN_TO", true, true);
            Commons.Modules.sPS = "";
        }
        #endregion

        #region funciton dùm chung
        private void enableButon(bool visible)
        {
            windowsUIButton.Buttons[0].Properties.Visible = visible;
            windowsUIButton.Buttons[1].Properties.Visible = visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = visible;
            windowsUIButton.Buttons[4].Properties.Visible = visible;
            windowsUIButton.Buttons[5].Properties.Visible = visible;
            windowsUIButton.Buttons[6].Properties.Visible = !visible;
            windowsUIButton.Buttons[7].Properties.Visible = !visible;
            windowsUIButton.Buttons[8].Properties.Visible = visible;

            grdCongTac.Enabled = visible;
            //SO_HIEU_BANGTextEdit.Properties.ReadOnly = visible;
            SO_QUYET_DINHTextEdit.Properties.ReadOnly = visible;
            NGAY_KYDateEdit.Enabled = !visible;
            NGAY_HIEU_LUCDateEdit.Enabled = !visible;
            ID_LQDLookUpEdit.Properties.ReadOnly = visible;
            ID_CNTextEdit.Properties.ReadOnly = true;
            ID_NKLookUpEdit.Properties.ReadOnly = visible;
            ID_CV_CULookUpEdit.Properties.ReadOnly = visible;
            DON_VI_CUTextEdit.Properties.ReadOnly = true;
            XI_NGHIEP_CUTextEdit.Properties.ReadOnly = true;
            ID_TO_CUTextEdit.Properties.ReadOnly = true;
            NOI_CONG_TACTextEdit.Properties.ReadOnly = visible;
            NHIEM_VUMemoEdit.Properties.ReadOnly = visible;
            MUC_LUONG_CUTextEdit.Properties.ReadOnly = visible;
            ID_LCV_CULookUpEdit.Properties.ReadOnly = visible;

            DON_VILookUpEdit.Properties.ReadOnly = visible;
            XI_NGHIEPLookUpEdit.Properties.ReadOnly = visible;
            ID_TOLookUpEdit.Properties.ReadOnly = visible;
            ID_CVLookUpEdit.Properties.ReadOnly = visible;
            ID_LCVLookUpEdit.Properties.ReadOnly = visible;
            MUC_LUONGTextEdit.Properties.ReadOnly = visible;
            GHI_CHUTextEdit.Properties.ReadOnly = visible;

        }

        private void Bindingdata(bool bthem)
        {

            //Commons.Modules.sPS = "0Load";
            if (bthem == true)
            {
                Loaddatatable();
                //lấy dữ liệu mặc định theo id công nhân
                try
                {
                    NGAY_KYDateEdit.EditValue = DateTime.Today;
                    NGAY_HIEU_LUCDateEdit.EditValue = DateTime.Today;
                    SO_QUYET_DINHTextEdit.EditValue = "";
                    DON_VI_CUTextEdit.EditValue = tableTTC_CN.Rows[0]["TEN_DV"];
                    XI_NGHIEP_CUTextEdit.EditValue = tableTTC_CN.Rows[0]["TEN_XN"];
                    ID_TO_CUTextEdit.EditValue = tableTTC_CN.Rows[0]["TEN_TO"];
                    idToCu = Convert.ToInt32(tableTTC_CN.Rows[0]["ID_TO"]);
                    MUC_LUONG_CUTextEdit.EditValue = tableTTC_CN.Rows[0]["MUC_LUONG_CU"];
                    NOI_CONG_TACTextEdit.EditValue = "";
                    MUC_LUONGTextEdit.EditValue = 0;
                    GHI_CHUTextEdit.EditValue = "";
                    NHIEM_VUMemoEdit.EditValue = "";
                    ID_LQDLookUpEdit.EditValue = "";
                    ID_CNTextEdit.EditValue = tableTTC_CN.Rows[0]["HO_TEN"];
                    ID_NKLookUpEdit.EditValue = "";
                    ID_CV_CULookUpEdit.EditValue = tableTTC_CN.Rows[0]["ID_CV"];
                    ID_LCV_CULookUpEdit.EditValue = tableTTC_CN.Rows[0]["ID_LCV"];
                    ID_CVLookUpEdit.EditValue = tableTTC_CN.Rows[0]["ID_CV"];
                    ID_LCVLookUpEdit.EditValue = tableTTC_CN.Rows[0]["ID_LCV"];
                    DON_VILookUpEdit.EditValue = null;
                    XI_NGHIEPLookUpEdit.EditValue = null;
                    ID_TOLookUpEdit.EditValue = null;
                }
                catch
                {

                }
            }
            else //load du lieu co trong luoi
            {
                NGAY_KYDateEdit.EditValue = Convert.ToDateTime(grvCongTac.GetFocusedRowCellValue("NGAY_KY"));
                NGAY_HIEU_LUCDateEdit.EditValue = Convert.ToDateTime(grvCongTac.GetFocusedRowCellValue("NGAY_HIEU_LUC"));
                SO_QUYET_DINHTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("SO_QUYET_DINH");
                DON_VI_CUTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("TEN_DV");
                XI_NGHIEP_CUTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("TEN_XN");
                ID_TO_CUTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("TEN_TO");
                idToCu = Convert.ToInt32(grvCongTac.GetFocusedRowCellValue("ID_TO_CU"));
                MUC_LUONG_CUTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("MUC_LUONG_CU");
                NOI_CONG_TACTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("NOI_CONG_TAC");
                MUC_LUONGTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("MUC_LUONG");
                GHI_CHUTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("GHI_CHU");
                NHIEM_VUMemoEdit.EditValue = grvCongTac.GetFocusedRowCellValue("NHIEM_VU");
                ID_CNTextEdit.EditValue = grvCongTac.GetFocusedRowCellValue("TEN_CN");

                ID_LQDLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_LQD");
                ID_NKLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_NK");
                ID_CV_CULookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_CV_CU");
                ID_LCV_CULookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_LCV_CU");

                DON_VILookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_DV");
                XI_NGHIEPLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_XN");
                ID_TOLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_TO");
                ID_CVLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_CV");
                ID_LCVLookUpEdit.EditValue = grvCongTac.GetFocusedRowCellValue("ID_LCV");
            }
            Commons.Modules.sPS = "";
        }
        private void SaveData()
        {
            try
            {
                int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spUpdateQuaTrinhCongTac",
                idQTCT, idcn,
                ID_LQDLookUpEdit.EditValue,
                ID_NKLookUpEdit.EditValue,
                ID_TOLookUpEdit.EditValue,
                ID_CVLookUpEdit.EditValue,
                ID_LCVLookUpEdit.EditValue,
                idToCu,
                ID_CV_CULookUpEdit.EditValue,
                ID_LCV_CULookUpEdit.EditValue,
                SO_QUYET_DINHTextEdit.EditValue,
                NGAY_KYDateEdit.EditValue,
                NGAY_HIEU_LUCDateEdit.EditValue,
                NOI_CONG_TACTextEdit.EditValue,
                NHIEM_VUMemoEdit.EditValue,
                MUC_LUONGTextEdit.EditValue,
                MUC_LUONG_CUTextEdit.EditValue,
                GHI_CHUTextEdit.EditValue,
                cothem
                ));
                LoadgrdCongTac( Convert.ToInt32( Commons.Modules.sId));
            }
            //nếu là ngày hiệu lực là ngày mới nhất thì cập nhật lại bảng công nhân về tổ và chức vụ
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DeleteData()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDeleteKhoaDaoTao"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeXoa"), MessageBoxButtons.YesNo) == DialogResult.No) return;
            //xóa
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.QUA_TRINH_CONG_TAC WHERE ID_QTCT =" + grvCongTac.GetFocusedRowCellValue("ID_QTCT") + "");
                grvCongTac.DeleteSelectedRows();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDelDangSuDung") + "\n" + ex.Message.ToString(), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"),MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        #endregion

        private void windowsUIButton_ButtonClick_1(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "them":
                    {
                        Bindingdata(true);
                        cothem = true;
                        enableButon(false);
                        break;
                    }
                case "sua":
                    {
                        if (grvCongTac.RowCount == 0)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChonDongCanXuLy"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"),MessageBoxButtons.OK,MessageBoxIcon.Information);
                            return;
                        }
                        cothem = false;
                        enableButon(false);
                        break;
                    }

                case "xoa":
                    {
                        if (grvCongTac.RowCount == 0)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChonDongCanXuLy"),Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        DeleteData();
                        break;
                    }
                case "In":
                    {

                        if (ID_CNTextEdit.EditValue == null || ID_CNTextEdit.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChonDongCanXuLy"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        idQTCT = Convert.ToInt32(grvCongTac.GetFocusedRowCellValue("ID_QTCT"));
                        frmInQTCT InQTCT = new frmInQTCT(idcn, idQTCT, ID_CNTextEdit.EditValue.ToString());
                        InQTCT.ShowDialog();
                        break;
                    }
                case "luu":
                    {
                        if (!dxValidationProvider1.Validate()) return;
                        //kiem trung ..
                        System.Data.SqlClient.SqlConnection conn;
                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                        conn.Open();
                        if (cothem == true)
                        {
                            idQTCT = -1;
                        }
                        else
                        {
                            idQTCT = Convert.ToInt32(grvCongTac.GetFocusedRowCellValue("ID_QTCT"));
                        }
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spkiemtrungQuaTrinhCongTac", conn);
                        cmd.Parameters.Add("@ID_QTCT", SqlDbType.BigInt).Value = idQTCT;
                        cmd.Parameters.Add("@ID_CN", SqlDbType.BigInt).Value = idcn;
                        cmd.Parameters.Add("@SO_QUYET_DINH", SqlDbType.NVarChar).Value = SO_QUYET_DINHTextEdit.Text;
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                        {
                            XtraMessageBox.Show(ItemForSO_QUYET_DINH.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgSoQD_NayDaTonTai"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SO_QUYET_DINHTextEdit.Focus();
                            return;
                        }
                        conn.Close();
                        SaveData();
                        enableButon(true);
                        break;
                    }
                case "khongluu":
                    {
                        enableButon(true);
                        Bindingdata(false);
                        dxValidationProvider1.Validate();
                        break;
                    }
                case "thoat":
                    {
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
