using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using System.Threading;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraEditors.Repository;

namespace Vs.HRM
{
    public partial class ucBaoHiemYTe : DevExpress.XtraEditors.XtraUserControl
    {
        public static ucBaoHiemYTe _instance;
        public static ucBaoHiemYTe Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucBaoHiemYTe();
                return _instance;
            }
        }


        public ucBaoHiemYTe()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this,new List<LayoutControlGroup>{ Root}, windowsUIButton);
        }
        #region bảo hiểm y tế
        private void ucBaoHiemYTe_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboDonVi(cboDV);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGridBaoHiemYTe(true);
            Commons.Modules.sPS = "";
            enableButon(true);
        }
        private void cboDV_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGridBaoHiemYTe(false);
            Commons.Modules.sPS = "";
        }
        private void cboXN_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGridBaoHiemYTe(false);
            Commons.Modules.sPS = "";
        }
        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGridBaoHiemYTe(false);
            Commons.Modules.sPS = "";
        }
        private void grdBHYT_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                XoaBaoHiemYTe();
            }
        }
        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "themsua":
                    {
                        enableButon(false);
                        Commons.Modules.ObjSystems.AddnewRow(grvNgungDongBHXH, false);
                        break;
                    }

                case "xoa":
                    {
                        XoaBaoHiemYTe();
                        break;
                    }
                case "luu":
                    {
                        Savedata();
                        LoadGridBaoHiemYTe(false);
                        enableButon(true);
                        Commons.Modules.ObjSystems.DeleteAddRow(grvNgungDongBHXH);
                        break;
                    }
                case "khongluu":
                    {
                        Commons.Modules.ObjSystems.DeleteAddRow(grvNgungDongBHXH);
                        enableButon(true);
                        break;
                    }
                case "thoat":
                    {
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
                case "ngayhethan":
                    {
                        try
                        {
                            XtraInputBoxArgs args = new XtraInputBoxArgs();
                            // set required Input Box options
                            args.Caption = "Cập nhật ngày hết hạn";
                            args.Prompt = "Chọn ngày cập nhật";
                            args.DefaultButtonIndex = 0;

                            // initialize a DateEdit editor with custom settings
                            DateEdit editor = new DateEdit();
                            editor.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Default;
                            args.Editor = editor;
                            // a default DateEdit value
                            args.DefaultResponse = DateTime.Now.Date;
                            // display an Input Box with the custom editor
                            var result = XtraInputBox.Show(args);
                            if (result.ToString() != "")
                            {
                                //cập nhật toàn bộ ngày cho bảo hiểm y tết
                                string sSql = "UPDATE dbo.BAO_HIEM_Y_TE SET NGAY_HET_HAN ='" + Convert.ToDateTime(result).ToString("MM/dd/yyyy") + "'";
                                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                                LoadGridBaoHiemYTe(false);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    }
            }
        }
        #endregion

        #region hàm xử lý dữ liệu
        private void LoadGridBaoHiemYTe(bool co)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhanBHYT", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            if (co == true)
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBHYT, grvNgungDongBHXH, dt, false, false, true, true, true, this.Name);
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdBHYT, grvNgungDongBHXH, dt, false, false, true, false, true, this.Name);
            grvNgungDongBHXH.Columns["ID_CN"].Visible = false;
            grvNgungDongBHXH.Columns["ID_BHYT"].Visible = false;
            Commons.Modules.ObjSystems.AddCombXtra("ID_TP", "TEN_TP", grvNgungDongBHXH, Commons.Modules.ObjSystems.DataThanhPho(-1, false),"ID_TP", "THANH_PHO");
            Commons.Modules.ObjSystems.AddCombXtra("ID_BV", "TEN_BV", grvNgungDongBHXH, Commons.Modules.ObjSystems.DataBenhVien(false), "ID_BV", "DANH_SACH_BENH_VIEN");
            grvNgungDongBHXH.Columns["MS_CN"].OptionsColumn.ReadOnly = true;
            grvNgungDongBHXH.Columns["MS_CN"].Width = 50;
            grvNgungDongBHXH.Columns["HO_TEN"].Width = 100;
            grvNgungDongBHXH.Columns["SO_THE"].Width = 100;
            grvNgungDongBHXH.Columns["NGAY_HET_HAN"].Width = 100;

            RepositoryItemDateEdit dEditN = new RepositoryItemDateEdit();
            Commons.OSystems.SetDateRepositoryItemDateEdit(dEditN);
            grvNgungDongBHXH.Columns["NGAY_HET_HAN"].ColumnEdit = dEditN;
        }
        private void Savedata()
        {
            try
            {
                //tạo một datatable 
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "tabBHYT" + Commons.Modules.UserName, Commons.Modules.ObjSystems.ConvertDatatable(grvNgungDongBHXH), "");
                string sSql = "UPDATE A SET A.SO_THE = B.SO_THE,A.ID_TP = B.ID_TP,A.ID_BV = B.ID_BV,A.NGAY_HET_HAN = B.NGAY_HET_HAN FROM dbo.BAO_HIEM_Y_TE A INNER JOIN dbo." + "tabBHYT" + Commons.Modules.UserName + " B ON B.ID_BHYT = A.ID_BHYT INSERT INTO dbo.BAO_HIEM_Y_TE(ID_CN,SO_THE,ID_TP,ID_BV,NGAY_HET_HAN) SELECT ID_CN, SO_THE, ID_TP, ID_BV, NGAY_HET_HAN FROM dbo." + "tabBHYT" + Commons.Modules.UserName + " WHERE ISNULL(ID_BHYT, '') = ''";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable("tabBHYT" + Commons.Modules.UserName);
            }
            catch
            {
            }
        }
        private void enableButon(bool visible)
        {
            windowsUIButton.Buttons[0].Properties.Visible = !visible;
            windowsUIButton.Buttons[1].Properties.Visible = !visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = visible;
            windowsUIButton.Buttons[4].Properties.Visible = visible;
            windowsUIButton.Buttons[5].Properties.Visible = !visible;
            windowsUIButton.Buttons[6].Properties.Visible = !visible;
            windowsUIButton.Buttons[7].Properties.Visible = visible;
            searchControl.Visible = visible;
        }
        private void XoaBaoHiemYTe()
        {
            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;
            //xóa
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.BAO_HIEM_Y_TE WHERE ID_BHYT = " + grvNgungDongBHXH.GetFocusedRowCellValue("ID_BHYT") + "");
                LoadGridBaoHiemYTe(false);
            }
            catch
            {
                Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
            }
        }
        #endregion

    }
}
