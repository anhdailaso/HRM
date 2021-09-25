﻿using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraBars.Navigation;
using System.IO;
using System.Collections.Generic;
using DevExpress.XtraLayout;
using Vs.Report;

namespace Vs.HRM
{
    public partial class ucQuyetDinhThoiViec : DevExpress.XtraEditors.XtraUserControl
    {
        private static int QDTV = 0;
        public static ucQuyetDinhThoiViec _instance;
        public static ucQuyetDinhThoiViec Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucQuyetDinhThoiViec();
                return _instance;
            }
        }

        public ucQuyetDinhThoiViec()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup> { Root, layoutControlGroup1 }, windowsUIButton);
        }
        private void ucQuyetDinhThoiViec_Load(object sender, EventArgs e)
        {
            enableButon(true);
            formatText();
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboDonVi(cboSearch_DV);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboSearch_DV, cboSearch_XN);
            Commons.Modules.ObjSystems.LoadCboTo(cboSearch_DV, cboSearch_XN, cboSearch_TO);
            Commons.Modules.ObjSystems.SetPhanQuyen(windowsUIButton);

            DateTime dTuNgay = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime dDenNgay = new DateTime(DateTime.Now.Year, 12, 31);
            dTNgay.EditValue = dTuNgay;
            dDNgay.EditValue = dDenNgay;
            Commons.OSystems.SetDateEditFormat(dTNgay);
            Commons.OSystems.SetDateEditFormat(dDNgay);

            LoadGridCongNhan(-1);
            Commons.Modules.sPS = "";
            LoadCboLyDoThoiViec();
            LoadNguoiKy();
        }
        private void formatText()
        {
            LUONG_TOI_THIEUTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            TIEN_TRO_CAPTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            HS_LUONGTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            NGAY_PHEPTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeSL.ToString() + "";
            LUONG_TINH_PHEPTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            TIEN_PHEPTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            TRO_CAP_KHACTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";
            TONG_CONGTextEdit.Properties.Mask.EditMask = "N" + Commons.Modules.iSoLeTT.ToString() + "";

            Commons.OSystems.SetDateEditFormat(NGAY_NHAN_DONDateEdit);
            Commons.OSystems.SetDateEditFormat(NGAY_THOI_VIECDateEdit);
            Commons.OSystems.SetDateEditFormat(NGAY_KYDateEdit);
        }
        private void enableButon(bool visible)
        {
            windowsUIButton.Buttons[0].Properties.Visible = visible;
            windowsUIButton.Buttons[1].Properties.Visible = visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = visible;
            windowsUIButton.Buttons[4].Properties.Visible = visible;
            windowsUIButton.Buttons[5].Properties.Visible = !visible;
            windowsUIButton.Buttons[6].Properties.Visible = !visible;
            windowsUIButton.Buttons[7].Properties.Visible = visible;
            searchControl.Visible = visible;
        }
        private void InDuLieu()
        {
            QDTV = Convert.ToInt16(grvCongNhan.GetFocusedRowCellValue("ID_QDTV"));
            frmViewReport frm = new frmViewReport();
            frm.rpt = new rptQuyetDinhThoiViec(DateTime.Now, QDTV);

            frm.ShowDialog();
        }
        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "themsua":
                    {
                        LoadText();
                        navigationFrame.SelectedPage = navigationPage2;
                        enableButon(false);
                        break;
                    }

                case "xoa":
                    {
                        XoaQuyetDinhThoiViec();
                        break;
                    }
                case "in":
                    {
                        InDuLieu();
                        break;
                    }
                case "luu":
                    {
                        Luu();
                        break;
                    }

                case "trove":
                    {
                        navigationFrame.SelectedPage = navigationPage1;
                        enableButon(true);
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
        private void Luu()
        {
            if (!dxValidationProvider1.Validate()) return;
            try
            {
                LoadGridCongNhan(Convert.ToInt32(
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spGetUpdateQuyetDinhThoiViec",
                        (grvCongNhan.GetFocusedRowCellValue("ID_QDTV").ToString() == string.Empty) ? -1 : Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_QDTV")),
                        grvCongNhan.GetFocusedRowCellValue("ID_CN"),
                        SO_QDTextEdit.EditValue,
                        NGAY_NHAN_DONDateEdit.EditValue,
                        NGAY_THOI_VIECDateEdit.EditValue,
                        HS_LUONGTextEdit.EditValue,
                        LUONG_TOI_THIEUTextEdit.EditValue,
                        TIEN_TRO_CAPTextEdit.EditValue,
                        TIEN_PHEPTextEdit.EditValue,
                        TRO_CAP_KHACTextEdit.EditValue,
                        TONG_CONGTextEdit.EditValue,
                        NGAY_KYDateEdit.EditValue,
                        ID_LD_TVLookUpEdit.EditValue,
                        NGAY_VAO_CTYTextEdit.EditValue,
                        NGAY_PHEPTextEdit.EditValue,
                        NGUYEN_NHANTextEdit.EditValue,
                        GHI_CHUMemoEdit.EditValue,
                        ID_NKLookUpEdit.EditValue,
                        LUONG_TINH_PHEPTextEdit.EditValue
                )));
            }
            catch (Exception ex)
            {
            }

            navigationFrame.SelectedPage = navigationPage1;
            enableButon(true);
        }
        private void XoaQuyetDinhThoiViec()
        {
            if (grvCongNhan.RowCount == 0) { Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa); return; }
            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;
            //xóa
            try
            {
                string sSql = "DELETE QUYET_DINH_THOI_VIEC WHERE ID_CN = " + grvCongNhan.GetFocusedRowCellValue("ID_CN") + " UPDATE dbo.CONG_NHAN SET NGAY_NGHI_VIEC = NULL ,ID_LD_TV = NULL, ID_TT_HT = 1 WHERE ID_CN = " + grvCongNhan.GetFocusedRowCellValue("ID_CN") + "";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                LoadGridCongNhan(-1);
            }
            catch
            {
                Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
            }
        }

        private void cboSearch_TO_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGridCongNhan(-1);
            Commons.Modules.sPS = "";
        }
        private void cboSearch_DV_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboSearch_DV, cboSearch_XN);
            Commons.Modules.ObjSystems.LoadCboTo(cboSearch_DV, cboSearch_XN, cboSearch_TO);
            LoadGridCongNhan(-1);
            Commons.Modules.sPS = "";
        }
        private void cboSearch_XN_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cboSearch_DV, cboSearch_XN, cboSearch_TO);
            LoadGridCongNhan(-1);
            Commons.Modules.sPS = "";
        }
        private void LoadGridCongNhan(int idCN)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhanQDTV", Commons.Modules.UserName, Commons.Modules.TypeLanguage, cboSearch_DV.EditValue, cboSearch_XN.EditValue, cboSearch_TO.EditValue, dTNgay.DateTime, dDNgay.DateTime,radChonXem.SelectedIndex));
            if (grdCongNhan.DataSource == null)
            {
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_CN"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongNhan, grvCongNhan, dt, false, false, true, true, true, "");
                grvCongNhan.Columns["ID_CN"].Visible = false;
                grvCongNhan.Columns["ID_QDTV"].Visible = false;
                grvCongNhan.Columns["TinhTrang"].Visible = false;
                grvCongNhan.Columns["ID_LD_TV"].Visible = false;
               
                if (idCN != -1)
                {
                    int index = dt.Rows.IndexOf(dt.Rows.Find(idCN));
                    grvCongNhan.FocusedRowHandle = grvCongNhan.GetRowHandle(index);
                }
            }
            else
            {
                grdCongNhan.DataSource = dt;
            }

        }

        private void LoadCboLyDoThoiViec()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComBoLyDoThoiViec", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_LD_TVLookUpEdit, dt, "ID_LD_TV", "TEN_LD_TV", "TEN_LD_TV");
        }

        private void LoadNguoiKy()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComBoNguoiKi", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_NKLookUpEdit, dt, "ID_NK", "HO_TEN", "HO_TEN");

        }

        private void radTinhTrangLV_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdCongNhan.DataSource;

                if (radTinhTrangLV.SelectedIndex == 1) sdkien = "(TinhTrang = 0)";
                if (radTinhTrangLV.SelectedIndex == 2) sdkien = "(TinhTrang = 1)";
                dtTmp.DefaultView.RowFilter = sdkien;
            }
            catch
            {
                try
                {
                    dtTmp.DefaultView.RowFilter = "";
                }
                catch { }
            }
        }
        private void grvCongNhan_DoubleClick(object sender, EventArgs e)
        {
            navigationFrame.SelectedPage = navigationPage2;
            enableButon(false);
        }
        private void LoadText()
        {
            MS_CNtextEdit.EditValue = grvCongNhan.GetFocusedRowCellValue("MS_CN");
            TEN_CNtextEdit.EditValue = grvCongNhan.GetFocusedRowCellValue("HO_TEN");
            try
            {
                 string sSql = "SELECT Hinh_CN, NGAY_SINH, DT_DI_DONG, NGUYEN_QUAN, NGAY_VAO_CTY FROM dbo.CONG_NHAN WHERE ID_CN = " + grvCongNhan.GetFocusedRowCellValue("ID_CN") + "";
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    DataRow row = dt.Rows[0];
                    NGAY_SINHTextEdit.EditValue = Convert.ToDateTime(row["NGAY_SINH"]).ToString("dd/MM/yyyy");
                    NGAY_VAO_CTYTextEdit.EditValue = Convert.ToDateTime(row["NGAY_VAO_CTY"]).ToString("dd/MM/yyyy");
                    SO_DTtextEdit.EditValue = row["DT_DI_DONG"];
                    NGUYEN_QUANtextEdit.EditValue = row["NGUYEN_QUAN"];
                if (row["Hinh_CN"] != DBNull.Value)
                {
                    Byte[] data = new Byte[0];
                    data = (Byte[])(row["Hinh_CN"]);
                    MemoryStream mem = new MemoryStream(data);
                    Hinh_CNpictureEdit.Image = Image.FromStream(mem);
                }
                else
                {
                    Hinh_CNpictureEdit.EditValue = "";
                    Hinh_CNpictureEdit.Properties.NullText = "No current image to display";
                }

            }
            catch (Exception ex)
            {
            }
            try
            {
                if (grvCongNhan.GetFocusedRowCellValue("ID_QDTV").ToString() != string.Empty)
                {
                    string sSql = "SELECT * FROM dbo.QUYET_DINH_THOI_VIEC WHERE ID_QDTV = " + grvCongNhan.GetFocusedRowCellValue("ID_QDTV") + "";
                    DataTable dt = new DataTable();
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    DataRow row = dt.Rows[0];
                    SO_QDTextEdit.EditValue = row["SO_QD"];
                    NGAY_NHAN_DONDateEdit.EditValue = row["NGAY_NHAN_DON"];
                    NGAY_THOI_VIECDateEdit.EditValue = row["NGAY_THOI_VIEC"];
                    TRO_CAP_KHACTextEdit.EditValue = row["TRO_CAP_KHAC"];
                    TONG_CONGTextEdit.EditValue = row["TONG_CONG"];
                    NGAY_KYDateEdit.EditValue = row["NGAY_KY"];
                    ID_LD_TVLookUpEdit.EditValue = row["ID_LD_TV"];
                    //NGAY_VAO_CTYTextEdit.EditValue = row["NGAY_VAO_CTY"];
                    NGUYEN_NHANTextEdit.EditValue = row["NGUYEN_NHAN"];
                    HS_LUONGTextEdit.EditValue = row["HS_LUONG"];
                    TIEN_TRO_CAPTextEdit.EditValue = row["TIEN_TRO_CAP"];
                    NGAY_PHEPTextEdit.EditValue = row["NGAY_PHEP"];
                    LUONG_TINH_PHEPTextEdit.EditValue = row["LUONG_TINH_PHEP"];
                    TIEN_PHEPTextEdit.EditValue = row["TIEN_PHEP"];
                    LUONG_TOI_THIEUTextEdit.EditValue = row["LUONG_TOI_THIEU"];
                    GHI_CHUMemoEdit.EditValue = row["GHI_CHU"];
                }
                else
                {
                    Commons.Modules.sPS = "0Load";
                    SO_QDTextEdit.EditValue = "";
                    NGAY_NHAN_DONDateEdit.EditValue = DateTime.Today;
                    NGAY_THOI_VIECDateEdit.EditValue = DateTime.Today;
                    TRO_CAP_KHACTextEdit.EditValue = 0;
                    NGAY_KYDateEdit.EditValue = DateTime.Today;
                    ID_LD_TVLookUpEdit.EditValue = null;
                    //NGAY_VAO_CTYTextEdit.EditValue = DateTime.Today;
                    NGUYEN_NHANTextEdit.EditValue = "";
                    GHI_CHUMemoEdit.EditValue = "";
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void navigationFrame_SelectedPageChanging(object sender, SelectedPageChangingEventArgs e)
        {
            if (navigationFrame.SelectedPage == navigationPage1)
            {
                if (grvCongNhan.RowCount == 0)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoChuaChonCongNhan"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgThongBao"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    LoadText();
                    dxValidationProvider1.Validate();
                }
            }
        }

        private void NGAY_THOI_VIECDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            //tính lương
            try
            {
                LUONG_TOI_THIEUTextEdit.EditValue = Commons.Modules.ObjSystems.TienTroCap(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime, Convert.ToInt32(ID_LD_TVLookUpEdit.EditValue))["LUONG_TOI_THIEU"];
                HS_LUONGTextEdit.EditValue = Commons.Modules.ObjSystems.TienTroCap(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime, Convert.ToInt32(ID_LD_TVLookUpEdit.EditValue))["LUONG_TRO_CAP"];
                TIEN_TRO_CAPTextEdit.EditValue = Commons.Modules.ObjSystems.TienTroCap(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime, Convert.ToInt32(ID_LD_TVLookUpEdit.EditValue))["TIEN_TRO_CAP"];
                NGAY_PHEPTextEdit.EditValue = Commons.Modules.ObjSystems.TienPhep(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime)["SO_NGAY_PHEP"];
                LUONG_TINH_PHEPTextEdit.EditValue = Commons.Modules.ObjSystems.TienPhep(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime)["LUONG_TP"];
                TIEN_PHEPTextEdit.EditValue = Commons.Modules.ObjSystems.TienPhep(Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN")), NGAY_THOI_VIECDateEdit.DateTime)["TIEN_PHEP"];
                TONG_CONGTextEdit.EditValue = Convert.ToDouble(TIEN_TRO_CAPTextEdit.EditValue) + Convert.ToDouble(TIEN_PHEPTextEdit.EditValue) + Convert.ToDouble(TRO_CAP_KHACTextEdit.EditValue);
            }
            catch (Exception ex)
            {

            }
        }

        private void TRO_CAP_KHACTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            TONG_CONGTextEdit.EditValue = Convert.ToDouble(TIEN_TRO_CAPTextEdit.EditValue) + Convert.ToDouble(TIEN_PHEPTextEdit.EditValue) + Convert.ToDouble(TRO_CAP_KHACTextEdit.EditValue);
        }

        private void grdCongNhan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaQuyetDinhThoiViec();
            }
        }

        private void radChonXem_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGridCongNhan(-1);
            Commons.Modules.sPS = "";
        }

        private void dTNgay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dDNgay.DateTime != Convert.ToDateTime("01/01/0001"))
                {
                TimeSpan time = dDNgay.DateTime - dTNgay.DateTime;
                if (time.Days < 0)
                {
                    XtraMessageBox.Show("Từ ngày phải nhỏ hơn đến ngày", Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    dTNgay.ErrorText = "Dữ liệu không hợp lệ";
                }
            }
        }

        private void dDNgay_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dTNgay.DateTime != Convert.ToDateTime("01/01/0001"))
            {
                TimeSpan time = dDNgay.DateTime - dTNgay.DateTime;
                if (time.Days < 0)
                {
                    XtraMessageBox.Show("Đến ngày phải lớn hơn từ ngày", Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    dDNgay.ErrorText = "Dữ liệu không hợp lệ";
                }
            }
        }

        private void dTNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dTNgay.DateTime != Convert.ToDateTime("01/01/0001") || dDNgay.DateTime != Convert.ToDateTime("01/01/0001"))
            {
                LoadGridCongNhan(-1);
            }
        }

        private void dDNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (dTNgay.DateTime != Convert.ToDateTime("01/01/0001") || dDNgay.DateTime != Convert.ToDateTime("01/01/0001"))
            {
                LoadGridCongNhan(-1);
            }
        }
    }
}