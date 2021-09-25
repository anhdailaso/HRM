using Commons;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Vs.Report;

namespace Vs.TimeAttendance
{
    public partial class ucVachTheLoi : DevExpress.XtraEditors.XtraUserControl
    {
        public static ucVachTheLoi _instance;
        public static ucVachTheLoi Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucVachTheLoi();
                return _instance;
            }
        }
        string sBT = "tabKeHoachDiCa" + Commons.Modules.ModuleName;
        public ucVachTheLoi()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root }, windowsUIButton);
        }
        private void ucKeHoachDiCa_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            datNgayChamCong.EditValue = DateTime.Now.Date;
            Commons.Modules.ObjSystems.LoadCboDonVi(cboDV);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            LoadGrdCongNhan();
            Commons.Modules.sPS = "";

            if (Modules.iPermission != 1)
            {
                windowsUIButton.Buttons[0].Properties.Visible = false;
                windowsUIButton.Buttons[1].Properties.Visible = false;
                windowsUIButton.Buttons[5].Properties.Visible = false;
                windowsUIButton.Buttons[6].Properties.Visible = false;
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
                case "sua":
                    {
                        if (grvCongNhan.RowCount == 0)
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgBanChuaChonDuLieu);
                            return;
                        }
                        BingdingData();
                        Commons.Modules.ObjSystems.MLoadLookUpEdit(cboMSCN, Commons.Modules.ObjSystems.ConvertDatatable(grdCongNhan), "ID_CN", "MS_CN", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "MS_CN"));
                        enableButon(false);
                        break;
                    }
                case "xoa":
                    {
                        break;
                    }
                case "luu":
                    {
                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "tabTMPVachTheLoi" + Commons.Modules.UserName,Commons.Modules.ObjSystems.ConvertDatatable(grvCongNhan),"");
                        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSaveVachTheLoi", datNgayChamCong.DateTime.Date, "tabTMPVachTheLoi" + Commons.Modules.UserName);
                        enableButon(true);
                        LoadGrdCongNhan();
                        break;
                    }
                case "khongluu":
                    {
                        enableButon(true);
                        LoadGrdCongNhan();
                        break;
                    }
                case "In":

                    {


                        frmViewReport frm = new frmViewReport();
                        DataTable dt;
                        System.Data.SqlClient.SqlConnection conn;
                        dt = new DataTable();
                        string sTieuDe = "DANH SÁCH NHÂN VIÊN CHƯA ĐỦ DỮ LIỆU";
                        frm.rpt = new rptDSNVVachTheLoi(datNgayChamCong.DateTime, datNgayChamCong.DateTime, sTieuDe);

                        try
                        {
                            conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                            conn.Open();

                            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSNVVachTheLoi", conn);

                            cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                            //theo code cũ 
                            cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = cboMSCN.EditValue;
                            cmd.Parameters.Add("@XN", SqlDbType.Int).Value = datNgayDen.EditValue;
                            cmd.Parameters.Add("@TO", SqlDbType.Int).Value = txtCN.EditValue;
                            cmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = datNgayVe.DateTime;  //Convert.ToDateTime(LK_NgayXemBaoCao.EditValue);
                            cmd.CommandType = CommandType.StoredProcedure;
                            System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                            //DataSet ds = new DataSet();
                            dt = new DataTable();
                            adp.Fill(dt);

                            //dt = ds.Tables[0].Copy();
                            dt.TableName = "DA_TA";
                            frm.AddDataSource(dt);
                            frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                        }
                        catch (Exception ex)
                        { }
                        frm.ShowDialog();

                        //======
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
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDuLieuQuetTheLoi", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, datNgayChamCong.DateTime, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_CN"] };
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = false;
                }
                if (grdCongNhan.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdCongNhan, grvCongNhan, dt, false, false, true, true, true, "");
                    grvCongNhan.Columns["ID_CN"].Visible = false;
                    grvCongNhan.Columns["CHINH_SUA"].Visible = false;
                    grvCongNhan.Columns["GIO_DEN_LUU"].Visible = false;
                    grvCongNhan.Columns["GIO_VE_LUU"].Visible = false;
                }
                else
                {
                    grdCongNhan.DataSource = dt;
                }
                Commons.Modules.sPS = "";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
            }
        }
        private bool Savedata()
        {
            try
            {
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
            windowsUIButton.Buttons[5].Properties.Visible = !visible;
            windowsUIButton.Buttons[6].Properties.Visible = !visible;
            navigationFrame1.SelectedPageIndex = visible == true ? 0 : 1;

        }
        private void BingdingData()
        {
            cboMSCN.EditValue = Convert.ToInt32(grvCongNhan.GetFocusedRowCellValue("ID_CN"));
            txtCN.EditValue = grvCongNhan.GetFocusedRowCellValue("HO_TEN");
            datNgayDen.DateTime = Convert.ToDateTime(grvCongNhan.GetFocusedRowCellValue("NGAY_DEN"));
            datNgayVe.DateTime = Convert.ToDateTime(grvCongNhan.GetFocusedRowCellValue("NGAY_VE"));
            timDen.EditValue = grvCongNhan.GetFocusedRowCellValue("GIO_DEN");
            timVe.EditValue = grvCongNhan.GetFocusedRowCellValue("GIO_VE");

        }

        #endregion

        private void grvCongNhan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (windowsUIButton.Buttons[5].Properties.Visible == false) return;
            BingdingData();
        }
        private void cboMSCN_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = Commons.Modules.ObjSystems.ConvertDatatable(grdCongNhan);
            int index = dt.Rows.IndexOf(dt.Rows.Find(cboMSCN.EditValue));
            grvCongNhan.FocusedRowHandle = index;
        }
        //cập nhật all
        private void btnGhiAll_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime NgayDen = Convert.ToDateTime(datNgayDen.DateTime.Date.ToString().Substring(0, 10) + " " + timDen.Text);
                DateTime NgayVe = Convert.ToDateTime(datNgayVe.DateTime.Date.ToString().Substring(0, 10) + " " + timVe.Text);
                if (NgayVe <= NgayDen)
                {
                    Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgNgayKhongHopLe);
                    return;
                }
                for (int i = 0; i <= grvCongNhan.RowCount; i++)
                {
                    if (Convert.ToBoolean(grvCongNhan.GetRowCellValue(i, "CHINH_SUA")) == false)
                    {
                        grvCongNhan.SetRowCellValue(i, "NGAY_DEN", NgayDen.Date);
                        grvCongNhan.SetRowCellValue(i, "NGAY_VE", NgayVe.Date);
                        grvCongNhan.SetRowCellValue(i, "GIO_DEN", NgayDen.TimeOfDay.ToString());
                        grvCongNhan.SetRowCellValue(i, "GIO_VE", NgayVe.TimeOfDay.ToString());
                        grvCongNhan.SetRowCellValue(i, "GIO_DEN_LUU",NgayDen);
                        grvCongNhan.SetRowCellValue(i, "GIO_VE_LUU",NgayVe);
                        grvCongNhan.SetRowCellValue(i, "CHINH_SUA", true);
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnGhiMot_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime NgayDen = Convert.ToDateTime(datNgayDen.DateTime.Date.ToString().Substring(0, 10) + " " + timDen.Text);
                DateTime NgayVe = Convert.ToDateTime(datNgayVe.DateTime.Date.ToString().Substring(0, 10) + " " + timVe.Text);
                grvCongNhan.SetFocusedRowCellValue("NGAY_DEN", NgayDen.Date);
                grvCongNhan.SetFocusedRowCellValue("NGAY_VE", NgayVe.Date);
                grvCongNhan.SetFocusedRowCellValue("GIO_DEN", NgayDen.TimeOfDay.ToString());
                grvCongNhan.SetFocusedRowCellValue("GIO_VE", NgayVe.TimeOfDay.ToString());
                grvCongNhan.SetFocusedRowCellValue("GIO_DEN_LUU", NgayDen);
                grvCongNhan.SetFocusedRowCellValue("GIO_VE_LUU", NgayVe);
                grvCongNhan.SetFocusedRowCellValue("CHINH_SUA", true);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
