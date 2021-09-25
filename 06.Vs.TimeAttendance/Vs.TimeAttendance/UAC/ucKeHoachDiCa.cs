using Commons;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Vs.TimeAttendance
{
    public partial class ucKeHoachDiCa : DevExpress.XtraEditors.XtraUserControl
    {
        public static ucKeHoachDiCa _instance;
        public static ucKeHoachDiCa Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucKeHoachDiCa();
                return _instance;
            }
        }
        string sBT = "tabKeHoachDiCa" + Commons.Modules.ModuleName;
        public ucKeHoachDiCa()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root }, windowsUIButton);
        }
        private void ucKeHoachDiCa_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboDonVi(cboDV);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            dateNam.DateTime = DateTime.Now;
            LoadGrdCongNhan();
            radTinHTrang_SelectedIndexChanged(null, null);
            Commons.Modules.sPS = "";
            if (Modules.iPermission != 1)
            {
                windowsUIButton.Buttons[0].Properties.Visible = false;
                windowsUIButton.Buttons[1].Properties.Visible = false;
                windowsUIButton.Buttons[2].Properties.Visible = false;
                windowsUIButton.Buttons[4].Properties.Visible = false;
                windowsUIButton.Buttons[7].Properties.Visible = false;
                windowsUIButton.Buttons[8].Properties.Visible = false;
            }
            else
            {
                enableButon(true);

            }
        }
        private void cboDV_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGrdCongNhan();
            Commons.Modules.sPS = "";
        }
        private void cboXN_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGrdCongNhan();
            Commons.Modules.sPS = "";
        }
        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGrdCongNhan();
            Commons.Modules.sPS = "";
        }

        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "Capnhatnhom":

                    {
                        frmDangKyKeHoachDiCa frm = new frmDangKyKeHoachDiCa();
                        frm.ShowDialog();
                        break;

                    }
                case "themsua":
                    {
                        if (grvCongNhan.RowCount == 0)
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgBanChuaChonDuLieu);
                            return;
                        }
                        Commons.Modules.ObjSystems.AddnewRow(grvKeHoachDiCa, true);
                        enableButon(false);
                        break;
                    }
                case "xoa":
                    {
                        XoaKeHoachDiCa();
                        break;
                    }
                case "In":
                    {
                        Form.frmInKehoachdica frm = new Form.frmInKehoachdica();
                        frm.ShowDialog();
                        break;
                    }
                case "luu":
                    {
                        Validate();
                        if (grvKeHoachDiCa.HasColumnErrors) return;
                        if (Savedata() == false)
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgDuLieuDangSuDung);
                        }
                        enableButon(true);
                        Commons.Modules.ObjSystems.DeleteAddRow(grvKeHoachDiCa);
                        break;
                    }
                case "khongluu":
                    {
                        Commons.Modules.ObjSystems.DeleteAddRow(grvKeHoachDiCa);
                        LoadgrdKeHoachDiCa();
                        enableButon(true);
                        break;
                    }
                case "thoat":
                    {
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
            }
        }

        #region hàm xử lý dữ liệu
        private void LoadGrdCongNhan()
        {
            try
            {
                Commons.Modules.sPS = "0Load";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhanTheoTT", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage,1));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongNhan, grvCongNhan, dt, false, false, true, true, true, "");
                grvCongNhan.Columns["ID_CN"].Visible = false;
                grvCongNhan.Columns["TINH_TRANG"].Visible = false;
                //grvCongNhan.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 128, 25);
                for (int i = 0; i < grvCongNhan.Columns.Count; i++)
                {
                    grvCongNhan.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
                }
                Commons.Modules.sPS = "";
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadgrdKeHoachDiCa()
        {
            try
            {
                DataTable dt = new DataTable();
                string select = "SELECT ID_CN,ID_NHOM,CA,TU_NGAY,DEN_NGAY,GHI_CHU FROM KE_HOACH_dI_CA  WHERE ID_CN = " + (grvCongNhan.GetFocusedRowCellValue("ID_CN")==null?-1 : grvCongNhan.GetFocusedRowCellValue("ID_CN")) + " AND YEAR(TU_NGAY) = " + dateNam.Text + "";
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, select));
                if (grdKeHoachDiCa.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdKeHoachDiCa, grvKeHoachDiCa, dt, false, false, true, true, true, "");
                    grvKeHoachDiCa.Columns["ID_CN"].Visible = false;
                    Commons.Modules.ObjSystems.AddCombo("ID_NHOM", "TEN_NHOM", grvKeHoachDiCa, Commons.Modules.ObjSystems.DataNhom(false));
                    //grvKeHoachDiCa.Appearance.HeaderPanel.BackColor = Color.FromArgb(240, 128, 25);
                    for (int i = 0; i < grvKeHoachDiCa.Columns.Count; i++)
                    {
                        grvKeHoachDiCa.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
                    }
                    //addMay ID_CA,CA
                    RepositoryItemLookUpEdit cboMSCa = new RepositoryItemLookUpEdit();
                    cboMSCa.NullText = "";
                    cboMSCa.ValueMember = "CA";
                    cboMSCa.DisplayMember = "CA";
                    cboMSCa.DataSource = Commons.Modules.ObjSystems.DataCa(-1);
                    cboMSCa.Columns.Clear();
                    cboMSCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CA"));
                    cboMSCa.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA");
                    cboMSCa.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    cboMSCa.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    grvKeHoachDiCa.Columns["CA"].ColumnEdit = cboMSCa;
                    cboMSCa.BeforePopup += CboMSCa_BeforePopup;
                }
                else
                {
                    grdKeHoachDiCa.DataSource = dt;
                }
            }
            catch(Exception EX)
            {
            }

        }
        private void CboMSCa_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                if (sender is LookUpEdit cbo)
                {
                    int IDNHOM = Convert.ToInt32(grvKeHoachDiCa.GetFocusedRowCellValue("ID_NHOM"));
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = Commons.Modules.ObjSystems.DataCa(IDNHOM);
                }
            }
            catch
            {
            }
        }

        private bool Savedata()
        {
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, Commons.Modules.ObjSystems.ConvertDatatable(grvKeHoachDiCa), "");
                string sSql = "DELETE KE_HOACH_dI_CA WHERE ID_CN = " + grvCongNhan.GetFocusedRowCellValue("ID_CN") + " INSERT INTO KE_HOACH_dI_CA(ID_CN,ID_NHOM,CA,TU_NGAY,DEN_NGAY,GHI_CHU) SELECT ID_CN,ID_NHOM,CA,TU_NGAY,DEN_NGAY,GHI_CHU FROM " + sBT + "";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void enableButon(bool visible)
        {
            windowsUIButton.Buttons[0].Properties.Visible = visible;
            windowsUIButton.Buttons[1].Properties.Visible = visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = visible;
            windowsUIButton.Buttons[4].Properties.Visible = visible;
            windowsUIButton.Buttons[5].Properties.Visible = visible;
            windowsUIButton.Buttons[5].Properties.Visible = visible;
            windowsUIButton.Buttons[6].Properties.Visible = visible;
            windowsUIButton.Buttons[7].Properties.Visible = !visible;
            windowsUIButton.Buttons[8].Properties.Visible = !visible;
            searchControl.Visible = visible;
        }
        private void XoaKeHoachDiCa()
        {
            if (grvKeHoachDiCa.RowCount == 0) { Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa); return; }
            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;
            //xóa
            try
            {
                string sSql = "DELETE dbo.KE_HOACH_dI_CA WHERE ID_CN = " + grvKeHoachDiCa.GetFocusedRowCellValue("ID_CN") + "  AND TU_NGAY = '" + Convert.ToDateTime(grvKeHoachDiCa.GetFocusedRowCellValue("TU_NGAY")).ToString("MM/dd/yyyy") + "' ";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                grvKeHoachDiCa.DeleteSelectedRows();
            }
            catch
            {
                Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
            }
        }
        #endregion

        private void radTinHTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtTmp = new DataTable();
            string sdkien = "( 1 = 1 )";
            try
            {
                dtTmp = (DataTable)grdCongNhan.DataSource;
                if (radTinHTrang.SelectedIndex == 1) sdkien = "(TINH_TRANG = 1)";
                if (radTinHTrang.SelectedIndex == 2) sdkien = "(TINH_TRANG = 0)";
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

        private void grvCongNhan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadgrdKeHoachDiCa();
        }

        private void grvKeHoachDiCa_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            DevExpress.XtraGrid.Columns.GridColumn ngayngung = View.Columns["TU_NGAY"];
            grvKeHoachDiCa.SetFocusedRowCellValue("ID_CN", grvCongNhan.GetFocusedRowCellValue("ID_CN"));
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(View);
            if (dt.AsEnumerable().Where(x => x.Field<int>("ID_NHOM") == Convert.ToInt32(grvKeHoachDiCa.GetFocusedRowCellValue("ID_NHOM"))).Count(x => x.Field<DateTime>("TU_NGAY").Equals(Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, ngayngung)))) > 1)
            {
                e.Valid = false;
                View.SetColumnError(ngayngung, Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, this.Name, "MsgKiemtraNgayKeHoachDiCa", Commons.Modules.TypeLanguage)); return;
            }
        }

        private void grdKeHoachDiCa_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                XoaKeHoachDiCa();
            }
        }

        private void dateNam_EditValueChanged(object sender, EventArgs e)
        {
            grvCongNhan_FocusedRowChanged(null, null);
        }

        private void grvKeHoachDiCa_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvKeHoachDiCa.ClearColumnErrors();
            GridView view = sender as GridView;
            if (view == null) return;

            if (view.FocusedColumn.Name == "colTU_NGAY")
            {
                if (Convert.ToDateTime(e.Value) > Convert.ToDateTime(view.GetFocusedRowCellValue("DEN_NGAY")))
                {
                    e.Valid = false;
                    e.ErrorText = "This value is not valid";
                    view.SetColumnError(view.Columns["DEN_NGAY"], e.ErrorText);

                    return;
                }
            }
            if (view.FocusedColumn.Name == "colDEN_NGAY")
            {
                if (Convert.ToDateTime(e.Value) < Convert.ToDateTime(view.GetFocusedRowCellValue("TU_NGAY")))
                {
                    e.Valid = false;
                    e.ErrorText = "This value is not valid";
                    view.SetColumnError(view.Columns["DEN_NGAY"], e.ErrorText);
                    return;
                }
            }
            if (view.FocusedColumn.Name == "colCA")
            {
                view.SetFocusedRowCellValue(view.Columns["CA"], e.Value);
            }
        }

        private void grvKeHoachDiCa_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvKeHoachDiCa_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvKeHoachDiCa_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //thêm defaulst khi add một dòng mới
            try
            {
                GridView view = sender as GridView;
                view.SetFocusedRowCellValue("TU_NGAY", Convert.ToDateTime(DateTime.Now.Date));
                view.SetFocusedRowCellValue("DEN_NGAY", Convert.ToDateTime(DateTime.Now.Date));
            }
            catch
            {
            }
        }
    }
}
