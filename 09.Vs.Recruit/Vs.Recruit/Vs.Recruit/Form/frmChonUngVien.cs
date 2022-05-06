using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vs.Report;

namespace Vs.Recruit
{
    public partial class frmChonUngVien : DevExpress.XtraEditors.XtraForm
    {
        Int64 iID_TB = -1;
        Int64 iID_UV = -1;
        private DataTable dt_CHON;
        private ucCTQLUV ucUV;

        string strChuyenMon = "";
        string strTrinhDo = "";
        string strKNLV = "";
        string strBangCap = "";
        public frmChonUngVien(Int64 ID_TB)
        {
            InitializeComponent();
            iID_TB = ID_TB;
        }

        #region even
        private void frmChonUngVien_Load(object sender, EventArgs e)
        {
            Commons.Modules.sLoad = "0Load";
            Loadcbo();
            Commons.Modules.sLoad = "";
            LoadData();
            LoadNN();
        }
        private void btnALL_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            try
            {
                WindowsUIButton btn = e.Button as WindowsUIButton;
                XtraUserControl ctl = new XtraUserControl();
                switch (btn.Tag.ToString())
                {
                    case "in":
                        {
                            #region inExcel
                            //try
                            //{
                            //    dt_CHON = new DataTable();
                            //    DataTable dt_temp = ((DataTable)grdChonUV.DataSource);
                            //    DataTable dt1 = new DataTable();
                            //    try
                            //    {
                            //        if (dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).Count() > 0)
                            //        {
                            //            dt_CHON = dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).CopyToDataTable().Copy();
                            //            if (grdChonUV.DataSource == null)
                            //            {
                            //                Commons.Modules.ObjSystems.MLoadXtraGrid(grdChonUV, grvChonUV, dt_CHON, false, true, false, true, false, "frmReport");
                            //                grvChonUV.Columns["CHON"].Visible = false;
                            //                grvChonUV.Columns["ID_UV"].Visible = false;
                            //            }
                            //            else
                            //            {
                            //                grdChonUV.DataSource = dt_CHON;
                            //            }
                            //            grvChonUV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
                            //            grvChonUV.Columns[0].Visible = false;
                            //MExportGrid(grdChonUV);

                            //            grvChonUV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                            //            LoadData();
                            //        }
                            //        else
                            //        {
                            //            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChuaChonUV"));
                            //            return;
                            //        }
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        //Trong truong hop ma no where khong ra thi no se bi catch, nen cho nay minh dung Clone()
                            //        dt_CHON = dt_temp.Clone();
                            //    }
                            //}
                            //catch
                            //{ }
                            //string strChuyenMon = cboID_NGANH_TD.Text.Trim();
                            //string strTrinhDo = cboID_TDVH.Text.Trim();
                            //string strKNLV = cboID_KNLV.Text.Trim();
                            //string strBangCap = cboID_BC.Text.Trim();
                            #endregion
                            try
                            {
                                dt_CHON = new DataTable();
                                DataTable dt_temp = ((DataTable)grdChonUV.DataSource);
                                DataTable dt1 = new DataTable();
                                try
                                {
                                    if (dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).Count() > 0)
                                    {
                                        dt_CHON = dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).CopyToDataTable().Copy();


                                        frmViewReport frm = new frmViewReport();
                                        frm.rpt = new rptDSUngVien(strChuyenMon, strTrinhDo, strKNLV, strBangCap);
                                        dt_CHON.TableName = "DA_TA";
                                        frm.AddDataSource(dt_CHON);
                                        frm.ShowDialog();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChuaChonUV"));
                                        return;
                                    }
                                }
                                catch
                                {
                                    //Trong truong hop ma no where khong ra thi no se bi catch, nen cho nay minh dung Clone()
                                    dt_CHON = dt_temp.Clone();
                                }
                            }
                            catch
                            { }
                            break;
                        }
                    case "ghi":
                        {
                            dt_CHON = new DataTable();
                            DataTable dt_temp = ((DataTable)grdChonUV.DataSource);
                            try
                            {
                                if (dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).Count() > 0)
                                {
                                    dt_CHON = dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).CopyToDataTable().Copy();
                                }
                                else
                                {
                                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChuaChonUV"));
                                    return;
                                }
                            }
                            catch
                            {
                                //Trong truong hop ma no where khong ra thi no se bi catch, nen cho nay minh dung Clone()
                                dt_CHON = dt_temp.Clone();
                            }

                            for (int i = 0; i < dt_CHON.Rows.Count; i++)
                            {
                                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();
                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spTBTuyenDung", conn);
                                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 9;
                                cmd.Parameters.Add("@ID_UV", SqlDbType.BigInt).Value = Convert.ToInt64(dt_CHON.Rows[i]["ID_UV"]);
                                cmd.Parameters.Add("@ID_TB", SqlDbType.BigInt).Value = iID_TB;
                                cmd.Parameters.Add("@NGAY_UNG_TUYEN", SqlDbType.Date).Value = DateTime.Now;
                                cmd.Parameters.Add("@GHI_CHU", SqlDbType.NVarChar).Value = null;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                            }
                            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_ThemThanhCong"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                LoadData();
                            }
                            else
                                this.Close();
                            break;
                        }
                    case "thoat":
                        {
                            this.Close();
                            break;
                        }
                }
            }
            catch { }
        }
        private void cboID_BC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Commons.Modules.sLoad == "0Load") return;
                    LoadData();
                    strBangCap = cboID_BC.Text.Trim();
                }
            }
            catch
            { }
        }
        private void cboID_TDVH_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Commons.Modules.sLoad == "0Load") return;
                    LoadData();
                    strTrinhDo = cboID_TDVH.Text.Trim();
                }
            }
            catch
            { }
        }

        private void cboID_KNLV_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Commons.Modules.sLoad == "0Load") return;
                    LoadData();
                    strKNLV = cboID_KNLV.Text.Trim();
                }
            }
            catch
            { }
        }
        private void cboCHUYEN_MON_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Commons.Modules.sLoad == "0Load") return;
                    LoadData();
                    strChuyenMon = cboCHUYEN_MON.Text.Trim();
                }
            }
            catch
            { }
        }
        #endregion

        #region function
        private void Loadcbo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spTBTuyenDung", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 7;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ////Load combo ID_NGANH_TD    
                //DataTable dt = new DataTable();
                //dt = ds.Tables[0].Copy();
                //Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_NGANH_TD, dt, "ID_NGANH_TD", "TEN_NGANH_TD", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_NGANH_TD"), true, true);

                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboCHUYEN_MON, dt, "ID_CM", "CHUYEN_MON", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CHUYEN_MON"), true, true);

                //Load combo ID_TDVH
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_TDVH, dt1, "ID_TDVH", "TEN_TDVH", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_TDVH"), true, true);

                //Load combo ID_KNLV
                DataTable dt2 = new DataTable();
                dt2 = ds.Tables[2].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_KNLV, dt2, "ID_KNLV", "TEN_KNLV", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_KNLV"), true, true);

                //Load combo ID_BC
                DataTable dt3 = new DataTable();
                dt3 = ds.Tables[3].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_BC, dt3, "ID_BC", "TEN_BANG", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_BANG"), true, true);
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Commons.Modules.sLoad == "0Load") return;
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spTBTuyenDung", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 8;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@ID_TB", SqlDbType.BigInt).Value = iID_TB;
                cmd.Parameters.Add("@CHUYEN_MON", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(cboCHUYEN_MON.Text.Trim()) ? "" : cboCHUYEN_MON.Text.Trim();
                cmd.Parameters.Add("@ID_TDVH", SqlDbType.BigInt).Value = (Convert.ToInt64(cboID_TDVH.EditValue) < 0) ? -1 : Convert.ToInt64(cboID_TDVH.EditValue);
                cmd.Parameters.Add("@ID_KNLV", SqlDbType.BigInt).Value = (Convert.ToInt64(cboID_KNLV.EditValue) < 0) ? -1 : Convert.ToInt64(cboID_KNLV.EditValue);
                cmd.Parameters.Add("@TEN_BANG", SqlDbType.NVarChar).Value = string.IsNullOrEmpty(cboID_BC.Text.Trim()) ? "" : cboID_BC.Text.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0].Copy();

                if (grdChonUV.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdChonUV, grvChonUV, dt, false, true, false, false, true, this.Name);
                    grvChonUV.Columns["ID_UV"].Visible = false;
                    grvChonUV.Columns["CHON"].Visible = false;
                    grvChonUV.OptionsSelection.CheckBoxSelectorField = "CHON";
                    grvChonUV.Columns["CHON"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                {
                    grdChonUV.DataSource = dt;
                }

            }
            catch (Exception ex) { }
        }
        public void MExportGrid(DevExpress.XtraGrid.GridControl grd)
        {
            DevExpress.XtraPrinting.XlsExportOptionsEx grdSet = new DevExpress.XtraPrinting.XlsExportOptionsEx();
            grdSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
            grdSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
            grdSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
            grdSet.ShowGridLines = true;
            grdSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
            grdSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

            string sPath;
            //sPath = Commons.Modules.ObjSystems.SaveFiles("Excel (2010)(.xlsx)|*.xlsx|Excel (2003)(.xls)|*.xls|Word (.docx)|*.docx|Richtext File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html|Mht File (.mht)|*.mht");
            sPath = SaveFiles("Excel Workbook |*.xlsx|Excel 97-2003 Workbook |*.xls|Word Document |*.docx|Rich Text Format |*.rtf|PDF File |*.pdf|Web Page |*.html|Single File Web Page |*.mht");

            if (sPath != "")
            {
                string fileExtenstion = new System.IO.FileInfo(sPath).Extension;
                try
                {

                    switch (fileExtenstion.ToLower())
                    {
                        case ".xls":
                            {
                                grd.ExportToXls(sPath, grdSet);
                                break;
                            }
                        case ".xlsx":
                            {
                                DevExpress.XtraPrinting.XlsxExportOptionsEx grdxLSXSet = new DevExpress.XtraPrinting.XlsxExportOptionsEx();
                                grdxLSXSet.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                                grdxLSXSet.AllowFixedColumnHeaderPanel = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True;
                                grdxLSXSet.ShowGridLines = true;
                                grdxLSXSet.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
                                grdxLSXSet.SheetName = DateTime.Now.ToString("yyyyMMdd");

                                grd.ExportToXlsx(sPath, grdxLSXSet);
                                break;
                            }
                        case ".rtf":
                            {
                                grd.ExportToRtf(sPath);
                                break;
                            }
                        case ".pdf":
                            {
                                grd.ExportToPdf(sPath);
                                break;
                            }
                        case ".html":
                            {
                                grd.ExportToHtml(sPath);
                                break;
                            }
                        case ".mht":
                            {
                                grd.ExportToMht(sPath);
                                break;
                            }
                        case ".docx":
                            {
                                grd.ExportToDocx(sPath);
                                break;
                            }
                    }


                    System.IO.FileInfo fi = new System.IO.FileInfo(sPath);
                    if (fi.Exists)
                    {
                        System.Diagnostics.Process.Start(sPath);
                    }
                    else
                    {
                        //file doesn't exist
                    }
                }
                catch
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Inkhongthanhcong"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK);
                }

            }
        }
        public string SaveFiles(string MFilter)
        {
            try
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = MFilter;
                f.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                try
                {
                    DialogResult res = f.ShowDialog();
                    if (res == DialogResult.OK)
                        return f.FileName;
                    return "";
                }
                catch
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        private void LoadNN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this, Root, btnALL);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvChonUV, this.Name);
        }
        #endregion

        #region chuot phai
        class RowInfo
        {
            public RowInfo(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
            {
                this.RowHandle = rowHandle;
                this.View = view;
            }

            public DevExpress.XtraGrid.Views.Grid.GridView View;
            public int RowHandle;
        }
        public DXMenuItem MCreateMenuXemUngVien(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "frmChonUngVien", "mnuXemUngVien", Commons.Modules.TypeLanguage);
            DXMenuItem menuXemUngVien = new DXMenuItem(sStr, new EventHandler(XemUngVienRowClick));
            menuXemUngVien.Tag = new RowInfo(view, rowHandle);
            return menuXemUngVien;
        }
        public void XemUngVienRowClick(object sender, EventArgs e)
        {
            try
            {
                ucUV = new ucCTQLUV(iID_UV);
                Commons.Modules.ObjSystems.ShowWaitForm(this);
                ucUV.Refresh();
                //ns.accorMenuleft = accorMenuleft;

                // dt_CHON  nay de luu du lieu da~ chon lai,trươc khi double click
                dt_CHON = new DataTable();
                DataTable dt_temp = ((DataTable)grdChonUV.DataSource);
                try
                {
                    if (dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).Count() > 0)
                    {
                        dt_CHON = dt_temp.AsEnumerable().Where(r => r.Field<Boolean>("CHON") == true).CopyToDataTable().Copy();
                    }
                }
                catch
                {
                    //Trong truong hop ma no where khong ra thi no se bi catch, nen cho nay minh dung Clone()
                    dt_CHON = dt_temp.Clone();
                }


                tablePanel1.Hide();
                this.Controls.Add(ucUV);
                ucUV.Dock = DockStyle.Fill;
                ucUV.backWindowsUIButtonPanel.ButtonClick += BackWindowsUIButtonPanel_ButtonClick;
                Commons.Modules.ObjSystems.HideWaitForm();
            }
            catch { }
        }
        public void BackWindowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            ucUV.Hide();
            tablePanel1.Show();
            LoadData();
            // khi click nút trở lại, vẫn dữ lại được những dòng đã chọn
            DataTable dt = new DataTable();
            dt = (DataTable)grdChonUV.DataSource;
            try
            {
                dt.AsEnumerable().Where(row => dt_CHON.AsEnumerable()
                                                         .Select(r => r.Field<Int64>("ID_UV"))
                                                         .Any(x => x == row.Field<Int64>("ID_UV"))
                                                         ).ToList<DataRow>().ForEach(y => y["CHON"] = 1);
                dt.AcceptChanges();
            }
            catch { }

        }
        //Nhap ung vien
        public DXMenuItem MCreateMenuNhapUngVien(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucTHONG_BAO_TUYEN_DUNG", "mnuNhapUV", Commons.Modules.TypeLanguage);
            DXMenuItem menuNhapUV = new DXMenuItem(sStr, new EventHandler(NhapUngVien));
            menuNhapUV.Tag = new RowInfo(view, rowHandle);
            return menuNhapUV;
        }
        public void NhapUngVien(object sender, EventArgs e)
        {
            ucUV = new ucCTQLUV(-1);
            ucUV.Dock = DockStyle.Fill;
            Commons.Modules.ObjSystems.ShowWaitForm(this);
            ucUV.Refresh();
            //ns.accorMenuleft = accorMenuleft;
            tablePanel1.Hide();
            this.Controls.Add(ucUV);
            this.Dock = DockStyle.Fill;
            ucUV.backWindowsUIButtonPanel.ButtonClick += BackWindowsUIButtonPanel_ButtonClick;
            //accorMenuleft.Visible = false;
            Commons.Modules.ObjSystems.HideWaitForm();
        }
        private void grvChonUV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                iID_UV = Convert.ToInt64(grvChonUV.GetFocusedRowCellValue("ID_UV"));
                DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
                {
                    int irow = e.HitInfo.RowHandle;
                    e.Menu.Items.Clear();

                    DevExpress.Utils.Menu.DXMenuItem itemXemUV = MCreateMenuXemUngVien(view, irow);
                    e.Menu.Items.Add(itemXemUV);
                }
                else
                {
                    if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
                    {
                        return;
                    }
                    e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu(view);
                    int irow = 0;
                    try { e.Menu.Items.Clear(); } catch { }

                    DevExpress.Utils.Menu.DXMenuItem itemNhapUV = MCreateMenuNhapUngVien(view, irow);
                    try { e.Menu.Items.Add(itemNhapUV); } catch { }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }




        #endregion

        private void grvChonUV_MouseWheel(object sender, MouseEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            //view.LeftCoord += e.Delta;
            //(e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
        }
    }
}
