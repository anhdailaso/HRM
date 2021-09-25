using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Vs.TimeAttendance
{
    public partial class frmLinkDuLieuChamCong : DevExpress.XtraEditors.XtraUserControl
    {
        private bool them = false;
        public static frmLinkDuLieuChamCong _instance;
        public static frmLinkDuLieuChamCong Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmLinkDuLieuChamCong();
                return _instance;
            }
        }
        RepositoryItemTimeEdit repositoryItemTimeEdit1;
        public frmLinkDuLieuChamCong()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root }, windowsUIButton);
            Commons.Modules.ObjSystems.ThayDoiNN(this, layoutControlGroup1);
            repositoryItemTimeEdit1 = new RepositoryItemTimeEdit();
        }
        private void frmLinkDuLieuChamCong_Load(object sender, EventArgs e)
        {
            try
            {
                Commons.Modules.ObjSystems.SetPhanQuyen(windowsUIButton);

                repositoryItemTimeEdit1.TimeEditStyle = TimeEditStyle.TouchUI;
                repositoryItemTimeEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                repositoryItemTimeEdit1.Mask.EditMask = "HH:mm:ss";

                repositoryItemTimeEdit1.NullText = "00:00:00";
                repositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                repositoryItemTimeEdit1.DisplayFormat.FormatString = "HH:mm:ss";
                repositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                repositoryItemTimeEdit1.EditFormat.FormatString = "HH:mm:ss";


                Commons.Modules.sPS = "0Load";
                Commons.Modules.ObjSystems.LoadCboDonVi(cbDonVi);
                Commons.Modules.ObjSystems.LoadCboXiNghiep(cbDonVi, cbXiNghiep);
                Commons.Modules.ObjSystems.LoadCboTo(cbDonVi, cbXiNghiep, cbTo);
                Commons.Modules.sPS = "";
                DateTime dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                dtNgayChamCong.EditValue = dt;
                LoadLuoiNgay(-1);
                grdDSCN.DataSource = null;
                grvDSCN.RefreshData();
                lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + "0";
                enableButon(true);



                DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");

                LoadGridCongNhan(ngay);

               
            }
            catch (Exception ex)
            {
            }
        }

        #region Các hàm load tab 0
        private void LoadLuoiNgay(int ID)
        {
            try
            {
                DateTime tn = new DateTime(dtNgayChamCong.DateTime.Year, dtNgayChamCong.DateTime.Month, 1);
                DateTime dn = DateTime.Now;
                if (dtNgayChamCong.DateTime.Month == 12)
                {
                    dn = new DateTime(dtNgayChamCong.DateTime.Year + 1, 1, 1);
                }
                else
                {
                    dn = new DateTime(dtNgayChamCong.DateTime.Year, dtNgayChamCong.DateTime.Month + 1, 1);
                }
                dn = dn.AddDays(-1);
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDuLieuQuetThe", tn, dn, Commons.Modules.UserName, Commons.Modules.TypeLanguage, cbDonVi.EditValue, cbXiNghiep.EditValue, cbTo.EditValue));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["NGAY"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNgay, grvNgay, dt, false, false, true, true, true, this.Name);
                grvNgay.Columns["NGAY"].Visible = true;
                grvNgay.Columns["TH"].Visible = true;

            }
            catch (Exception ex)
            {
            }
        }


        #endregion

        #region Các hàm xử lý
        private void enableButon(bool visible)
        {

            windowsUIButton.Buttons[0].Properties.Visible = visible;
            windowsUIButton.Buttons[1].Properties.Visible = visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = !visible;
            windowsUIButton.Buttons[4].Properties.Visible = !visible;
            windowsUIButton.Buttons[5].Properties.Visible = visible;
            windowsUIButton.Buttons[6].Properties.Visible = visible;
            windowsUIButton.Buttons[7].Properties.Visible = visible;
            windowsUIButton.Buttons[8].Properties.Visible = visible;
            windowsUIButton.Buttons[9].Properties.Visible = visible;
            windowsUIButton.Buttons[10].Properties.Visible = visible;
            //      groupDanhSachKhoaHoc.Enabled = visible;
        }


        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "them":
                    {
                        try
                        {
                            them = true;
                            enableButon(false);
                            DateTime ngay = dtNgayChamCong.DateTime;
                            Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
                            LoadGridChamCong(ngay, idcn);
                            grvChamCong.AddNewRow();
                            Commons.Modules.ObjSystems.AddnewRow(grvChamCong, true);
                        }
                        catch
                        {}
                        break;
                    }
                case "sua":
                    {
                        try
                        {
                        them = true;
                        enableButon(false);
                        DateTime ngay = dtNgayChamCong.DateTime;
                        Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
                        LoadGridChamCong(ngay, idcn);
                        }
                        catch
                        {}
                        break;
                    }
                case "xoa":
                    {
                        Xoa();
                        //them = true;
                        //enableButon(false);
                        break;
                    }
                case "luu":
                    {
                        them = false;
                        enableButon(true);
                        if (saveChamCong() == false)
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgDuLieuDangSuDung);
                        }
                        DateTime ngay = dtNgayChamCong.DateTime;
                        Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
                        LoadGridChamCong(ngay, idcn);
                        Commons.Modules.ObjSystems.DeleteAddRow(grvChamCong);
                        break;
                    }
                case "khongluu":
                    {
                        try
                        {
                            them = false;
                            enableButon(true);
                            DateTime ngay = dtNgayChamCong.DateTime;
                            Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
                            LoadGridChamCong(ngay, idcn);
                            Commons.Modules.ObjSystems.DeleteAddRow(grvChamCong);
                        }
                        catch
                        {  }
                        
                        break;
                    }
                case "TongHopThongTin":
                    {
                        TongHopDuLieu();
                        XtraMessageBox.Show("Tổng hợp thông tin thành công", "", MessageBoxButtons.OK);
                        break;
                    }
                case "LinkTay":
                    {
                        frmLinklBangTay frm = new frmLinklBangTay();
                        frm.ngaylink = dtNgayChamCong.DateTime;
                        frm.flag = 1;
                        frm.ShowDialog();
                        LoadLuoiNgay(-1);
                        break;
                    }
                case "LinkDuLieu":
                    {
                        LinkDuLieu();
                        XtraMessageBox.Show("Link dữ liệu thành công", "", MessageBoxButtons.OK);
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
        private void Xoa()
        {
            Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
            if (grvChamCong.RowCount == 0) { Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa); return; }

            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;
            //xóa
            try
            {
                string sSql = "DELETE dbo.DU_LIEU_QUET_THE WHERE ID_CN = " + idcn +
                                                        " AND NGAY = '"
                                                        + Convert.ToDateTime(dtNgayChamCong.EditValue).ToString("yyyy/MM/dd") +
                                                        "' AND CONVERT(nvarchar(10),GIO_DEN,108) = '"
                                                        + Convert.ToDateTime(grvChamCong.GetFocusedRowCellValue("GIO_DEN")).ToString("HH:mm:ss") + "'";
                

                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                grvChamCong.DeleteSelectedRows();
            }
            catch
            {
                Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
            }
        }
        private bool saveChamCong()
        {
            DataTable dataChamCong = new DataTable();

            string stbChamCong = "stbChamCong" + Commons.Modules.UserName;
            string sSql = "";
            Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, stbChamCong,Commons.Modules.ObjSystems.ConvertDatatable(grvChamCong), "");
                sSql = " DELETE FROM DU_LIEU_QUET_THE WHERE NGAY = '" + Convert.ToDateTime(dtNgayChamCong.EditValue).ToString("yyyyMMdd") +
                       "' AND ID_CN = "+ idcn+ "" +
                       " INSERT INTO DU_LIEU_QUET_THE (ID_CN, NGAY, ID_NHOM, CA, NGAY_DEN, GIO_DEN, NGAY_VE, GIO_VE, CHINH_SUA) " +
                       " SELECT '"+idcn+"','" + Convert.ToDateTime(dtNgayChamCong.EditValue).ToString("yyyyMMdd") + "', ID_NHOM, CA, NGAY_DEN, GIO_DEN, NGAY_VE, GIO_VE, CHINH_SUA" +
                       " FROM " + stbChamCong+"";


                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable(stbChamCong);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //Commons.Modules.ObjSystems.XoaTable(stbCongNhan);
                return false;
            }
        }
        #endregion

        //hàm link dữ liệu
        private void LinkDuLieu()
        {
            //tạo một table để chứa dữ liệu
            DataTable tbDLQT = new DataTable("DLQT");
            switch (1)
            {
                case 1:
                    {
                        tbDLQT.Columns.Add(new DataColumn("MS_THE_CC", typeof(string)));
                        tbDLQT.Columns.Add(new DataColumn("NGAY", typeof(DateTime)));
                        //load txt
                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            //openFileDialog.InitialDirectory = "C:\\";
                            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                            openFileDialog.FilterIndex = 2;
                            openFileDialog.RestoreDirectory = true;
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Convert1(openFileDialog.FileName, tbDLQT, "\t");
                            }
                        }

                        System.Data.SqlClient.SqlConnection conn;
                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                        conn.Open();

                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("usp_InsertDLQT", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@tableDLQT", tbDLQT);
                        cmd.Parameters.AddWithValue("@UName", Commons.Modules.UserName);
                        cmd.Parameters.AddWithValue("@NNgu", Commons.Modules.TypeLanguage);
                        cmd.Parameters.AddWithValue("@DVi", cbDonVi.EditValue);
                        cmd.Parameters.AddWithValue("@XN", cbXiNghiep.EditValue);
                        cmd.Parameters.AddWithValue("@TO", cbTo.EditValue);
                        cmd.Parameters.AddWithValue("@Ngay", dtNgayChamCong.DateTime);
                        cmd.ExecuteNonQuery();

                        LoadLuoiNgay(1);
                        //SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr,CommandType.StoredProcedure, "usp_InsertDLQT", tbDLQT);

                        break;
                    }
                case 2:
                    {
                        //load access
                        //Provider = Microsoft.Jet.OLEDB.4.0; Data Source = G:\READFILE\WiseEyeOn39.mdb; Persist Security Info = False; Jet OLEDB:Database Password = 12112009; Jet OLEDB:Compact Without Replica Repair = True
                        string queryString = @"SELECT UserEnrollNumber as MS_THE_CC,TimeStr AS NGAY  FROM CheckInOut WHERE FORMAT(TimeStr,""dd/MM/yyyy"") = #" + dtNgayChamCong.Text + "#";
                        using (OleDbConnection connection = new OleDbConnection(Commons.Modules.connect))
                        using (OleDbCommand command = new OleDbCommand(queryString, connection))
                        {
                            try
                            {
                                connection.Open();
                                OleDbDataReader reader = command.ExecuteReader();
                                tbDLQT.Load(reader);
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        //load csdl
                        string s = Commons.IConnections.CNStr;
                        //Server=192.168.2.5;database=abriDBHRPro7;uid=sa;pwd=123;Connect Timeout=9999
                        tbDLQT.Load(SqlHelper.ExecuteReader(Commons.Modules.connect, CommandType.Text, "SELECT EmployeeATID AS	MS_THE_CC,Time  AS NGAY FROM dbo.TA_TimeLog WHERE  CONVERT(NVARCHAR(13),tIME,103) = '" + dtNgayChamCong.Text + "'"));
                        break;
                    }
                default:
                    break;
            }
        }
        //ham tong hop du lieu
        private void TongHopDuLieu()
        {
            try
            {
                int iLB = 0;
                if (ckLamBu.Checked)
                {
                    iLB = 1;
                }
                System.Data.SqlClient.SqlConnection conn;
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("TongHopDuLieu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UName", Commons.Modules.UserName);
                cmd.Parameters.AddWithValue("@NNgu", Commons.Modules.TypeLanguage);
                cmd.Parameters.AddWithValue("@DVi", cbDonVi.EditValue);
                cmd.Parameters.AddWithValue("@XN", cbXiNghiep.EditValue);
                cmd.Parameters.AddWithValue("@TO", cbTo.EditValue);
                cmd.Parameters.AddWithValue("@LB", iLB);
                cmd.Parameters.AddWithValue("@Ngay", dtNgayChamCong.DateTime);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            
        }
        private void Convert1(string File, DataTable dt, string delimiter)
        {
            StreamReader s = new StreamReader(File);
            string AllData = s.ReadToEnd();
            string[] rows = AllData.Split("\r\n".ToCharArray());
            foreach (string r in rows)
            {
                if (r.Trim() == "") continue;
                string[] items = r.Split(delimiter.ToCharArray());
                dt.Rows.Add(items[0], items[1]);
            }

        }


        #region Cac Ham Load Tab 1

        #endregion

        private void LoadGridCongNhan(DateTime dtNgay)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDuLieuQuetTheCN", dtNgay, Commons.Modules.UserName, Commons.Modules.TypeLanguage, cbDonVi.EditValue, cbXiNghiep.EditValue, cbTo.EditValue));
                dt.Columns["ID_CN"].ReadOnly = false;
                dt.Columns["HO_TEN"].ReadOnly = true;
                dt.Columns["MS_THE_CC"].ReadOnly = true;
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdDSCN, grvDSCN, dt, false, false, true, true, true, this.Name);
                grvDSCN.Columns["ID_CN"].Visible = false;
                grvDSCN.RefreshData();
            }
            catch
            {

            }
            try
            {
                lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + dt.Rows.Count.ToString();
            }
            catch { }
        }
        private void LoadGridChamCong(DateTime dtNgay, int idCN)
        {
            
            try
            {
                DataTable dt = new DataTable();
                if (them)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDuLieuQuetTheCNCT", dtNgay, idCN));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChamCong, grvChamCong, dt, true, false, true, true, true, this.Name);
                    DataTable dID_NHOM = new DataTable();
                    dID_NHOM.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetNhomCC", dtNgayChamCong.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.AddCombXtra("ID_NHOM", "TEN_NHOM", grvChamCong, dID_NHOM, false);
                    dt.Columns["ID_NHOM"].ReadOnly = false;
                }
                else
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetDuLieuQuetTheCNCT", dtNgay, idCN));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChamCong, grvChamCong, dt, false, false, true, true, true, this.Name);
                    DataTable dID_NHOM = new DataTable();
                    dID_NHOM.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetNhomCC", dtNgayChamCong.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.AddCombXtra("ID_NHOM", "TEN_NHOM", grvChamCong, dID_NHOM, false);
                    //do nothing;
                }
                
                
                
                grvChamCong.Columns["GIO_VE"].DisplayFormat.FormatType = FormatType.DateTime;
                grvChamCong.Columns["GIO_VE"].DisplayFormat.FormatString = "HH:mm:ss";
                grvChamCong.Columns["GIO_DEN"].DisplayFormat.FormatType = FormatType.DateTime;
                grvChamCong.Columns["GIO_DEN"].DisplayFormat.FormatString = "HH:mm:ss";
                grvChamCong.Columns["GIO_DEN"].ColumnEdit = this.repositoryItemTimeEdit1;
                grvChamCong.Columns["GIO_VE"].ColumnEdit = this.repositoryItemTimeEdit1;
                grvChamCong.RefreshData();
            }
            catch (Exception ex)
            {

            }
        }

        private void cbDonVi_EditValueChanged(object sender, EventArgs e)
        {
            //if (Commons.Modules.sPS == "0Load") return;
            //Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cbDonVi, cbXiNghiep);
            //Commons.Modules.ObjSystems.LoadCboTo(cbDonVi, cbXiNghiep, cbTo);
            //grdDSCN.DataSource = null;
            //grvDSCN.RefreshData();
            //lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + "0";
            //try
            //{
            //    DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");
            //    LoadGridCongNhan(ngay);
            //}
            //catch
            //{

            //}
            //Commons.Modules.sPS = "";
        }

        private void cbXiNghiep_EditValueChanged(object sender, EventArgs e)
        {
            //if (Commons.Modules.sPS == "0Load") return;
            //Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cbDonVi, cbXiNghiep, cbTo);
            //grdDSCN.DataSource = null;
            //grvDSCN.RefreshData();
            //try
            //{
            //    DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");
            //    LoadGridCongNhan(ngay);
            //}
            //catch
            //{
            //}
            //Commons.Modules.sPS = "";
        }

        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            grdDSCN.DataSource = null;
            grvDSCN.RefreshData();
            lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + "0";
            try
            {
                //DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");
                LoadGridCongNhan(dtNgayChamCong.DateTime);
            }
            catch
            {

            }
            Commons.Modules.sPS = "";

        }

        private void dtNgayChamCong_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS != "0Load")
            {
                LoadLuoiNgay(1);
            }
            else
            {
                Commons.Modules.sPS = "";
            }
            grdDSCN.DataSource = null;
            grvDSCN.RefreshData();
            lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + "0";
            try
            {
                LoadGridCongNhan(dtNgayChamCong.DateTime);
            }
            catch(Exception ex)
            {

            }
            Commons.Modules.sPS = "";
        }

        private void grvNgay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //Commons.Modules.sPS = "0Load";
                lblTongCong.Text = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTongSoCN") + "0";
                //DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");
                //dtNgayChamCong.EditValue = ngay;
                //grdDSCN.DataSource = null;
                //grvDSCN.RefreshData();
                //LoadGridCongNhan(ngay);
            }
            catch
            {

            }
        }

        private void grvDSCN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                grdChamCong.DataSource = null;
                grvChamCong.RefreshData();
                DateTime ngay = dtNgayChamCong.DateTime;
                Int32 idcn = int.Parse(grvDSCN.GetFocusedRowCellValue("ID_CN").ToString());
                LoadGridChamCong(ngay, idcn);
                loadCa();
            }
            catch
            {

            }
        }
        private void loadCa()
        {
            DataTable dCa = new DataTable();
            RepositoryItemLookUpEdit cboCa = new RepositoryItemLookUpEdit();
            dCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT ID_CDLV, CA, GIO_BD, GIO_KT, PHUT_BD, PHUT_KT " +
                                             " FROM CHE_DO_LAM_VIEC"));
            cboCa.NullText = "";
            cboCa.ValueMember = "CA";
            cboCa.DisplayMember = "CA";
            cboCa.DataSource = dCa;
            cboCa.Columns.Clear();

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CA"));
            cboCa.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA");

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_BD"));
            cboCa.Columns["GIO_BD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_BD");
            cboCa.Columns["GIO_BD"].FormatType = DevExpress.Utils.FormatType.DateTime;
            cboCa.Columns["GIO_BD"].FormatString = "HH:mm";

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_KT"));
            cboCa.Columns["GIO_KT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_KT");
            cboCa.Columns["GIO_KT"].FormatType = DevExpress.Utils.FormatType.DateTime;
            cboCa.Columns["GIO_KT"].FormatString = "HH:mm";

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PHUT_BD"));
            cboCa.Columns["PHUT_BD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "PHUT_BD");
            cboCa.Columns["PHUT_BD"].Visible = false;

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PHUT_KT"));
            cboCa.Columns["PHUT_KT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "PHUT_KT");
            cboCa.Columns["PHUT_KT"].Visible = false;

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID_CDLV"));
            cboCa.Columns["ID_CDLV"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID_CDLV");
            cboCa.Columns["ID_CDLV"].Visible = false;

            cboCa.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cboCa.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvChamCong.Columns["CA"].ColumnEdit = cboCa;
            cboCa.BeforePopup += cboCa_BeforePopup;
            cboCa.EditValueChanged += CboCa_EditValueChanged;
        }
        private void CboCa_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;

            //string id = lookUp.get;

            // Access the currently selected data row
            DataRowView dataRow = lookUp.GetSelectedDataRow() as DataRowView;
            
            grvChamCong.SetFocusedRowCellValue("CA", (dataRow.Row[1]));
            //grvLamThem.SetFocusedRowCellValue("PHUT_BD", dataRow.Row["PHUT_BD"]);
            //grvLamThem.SetFocusedRowCellValue("PHUT_KT", dataRow.Row["PHUT_KT"]);
        }

        DataTable dtCaLV;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCa_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                dtCaLV = new DataTable();
                dtCaLV.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCaLVThem", dtNgayChamCong.EditValue, grvChamCong.GetFocusedRowCellValue("ID_NHOM"), Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = dtCaLV;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void grdNgay_DoubleClick(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            DateTime ngay = (DateTime)grvNgay.GetFocusedRowCellValue("NGAY");
            dtNgayChamCong.EditValue = ngay;
            grdDSCN.DataSource = null;
            grvDSCN.RefreshData();
            LoadGridCongNhan(ngay);
        }

        private void grvChamCong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            grvChamCong.SetFocusedRowCellValue("NGAY_DEN", dtNgayChamCong.EditValue );
            grvChamCong.SetFocusedRowCellValue("NGAY_VE", dtNgayChamCong.EditValue );
            grvChamCong.SetFocusedRowCellValue("GIO_DEN", dtNgayChamCong.EditValue );
        }
    }
}