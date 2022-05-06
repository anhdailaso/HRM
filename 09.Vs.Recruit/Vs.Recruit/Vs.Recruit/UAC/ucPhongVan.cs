using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vs.Recruit.UAC
{
    public partial class ucPhongVan : DevExpress.XtraEditors.XtraUserControl
    {
        private Int64 iIDPV = -1;
        private ucCTQLUV ucUV;
        private int maxDot;
        public AccordionControl accorMenuleft;

        public ucPhongVan(Int64 idpv)
        {
            InitializeComponent();
            iIDPV = idpv;
        }

        #region even
        private void ucPhongVan_Load(object sender, EventArgs e)
        {
            datNGAY_LAP.EditValue = DateTime.Now.ToShortDateString();
            datTG_BD.EditValue = DateTime.Now.ToShortDateString();
            datTG_KT.EditValue = DateTime.Now.ToShortDateString();
            Bindingdata(true);
            enableButon(true);
            LoadData(false, "", -1);
            Loadcbo();
            // AddnewRow();
            LoadNN();
        }
        private void txtMA_SO_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                frmDSPhongVan ctl = new frmDSPhongVan();
                if (ctl.ShowDialog() == DialogResult.OK)
                {
                    iIDPV = ctl.iIDPV;
                    LoadText(iIDPV);
                    LoadData(false, "", iIDPV);
                    enableButon(true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
        private void btnALL_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "them":
                    {
                        iIDPV = -1;
                        datNGAY_LAP.EditValue = DateTime.Now;
                        cboID_TB.Focus();
                        Bindingdata(true);
                        enableButon(false);
                        grdPhongVanUV.DataSource = ((DataTable)grdPhongVanUV.DataSource).Clone();
                        //Bindingdata(true);
                        //cothem = true;
                        //enableButon(false);
                        break;
                    }
                case "sua":
                    {
                        if (iIDPV == -1)
                        {
                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgChonDongCanXuLy"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        enableButon(false);
                        //Bindingdata(true);
                        //cothem = true;
                        //enableButon(false);
                        break;
                    }
                case "chonUV":
                    {
                        try
                        {
                            if (Convert.ToInt32(cboID_TB.EditValue) < 1)
                            {
                                XtraMessageBox.Show(lblID_TB.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                                cboID_TB.Focus();
                                return;
                            }
                            frmDanhSachUngVien frm = new frmDanhSachUngVien(0);
                            DataTable dtTmp = new DataTable();
                            dtTmp = (DataTable)grdPhongVanUV.DataSource;
                            frm.dt_CHON = dtTmp;
                            frm.iID_TB = string.IsNullOrEmpty(cboID_TB.EditValue.ToString()) ? -1 : Convert.ToInt64(cboID_TB.EditValue);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                DataTable dtChon = new DataTable();
                                dtChon = frm.dt_CHON;
                                DataRow dr;
                                foreach (DataRow dr1 in dtChon.Rows)
                                {
                                    dr = dtTmp.NewRow();
                                    dr["CHON"] = dr1["CHON"];
                                    dr["ID_UV"] = dr1["ID_UV"];
                                    dr["MS_UV"] = dr1["MS_UV"];
                                    dr["HO_TEN"] = dr1["HO_TEN"];
                                    dr["NGAY_SINH"] = dr1["NGAY_SINH"];
                                    dr["NAM_SINH"] = dr1["NAM_SINH"];
                                    dr["PHAI"] = dr1["PHAI"];
                                    dr["HINH_THUC_TUYEN"] = dr1["HINH_THUC_TUYEN"];
                                    dr["CHUYEN_MON"] = dr1["CHUYEN_MON"];
                                    dr["TEN_TDVH"] = dr1["TEN_TDVH"];
                                    dr["TEN_KNLV"] = dr1["TEN_KNLV"];
                                    dr["NGUYEN_QUAN"] = dr1["NGUYEN_QUAN"];
                                    dr["DT_DI_DONG"] = dr1["DT_DI_DONG"];
                                    dr["EMAIL"] = dr1["EMAIL"];
                                    dr["DIA_CHI_TAM_TRU"] = dr1["DIA_CHI_TAM_TRU"];
                                    dr["GHI_CHU"] = dr1["GHI_CHU"];
                                    dr["ID_PVUV"] = dr1["ID_PVUV"];
                                    dr["ID_PV"] = dr1["ID_PV"];
                                    dr["NOI_DUNG1"] = dr1["NOI_DUNG1"];
                                    dr["DIEM1"] = dr1["DIEM1"];
                                    dr["NOI_DUNG2"] = dr1["NOI_DUNG2"];
                                    dr["DIEM2"] = dr1["DIEM2"];
                                    dr["NOI_DUNG3"] = dr1["NOI_DUNG3"];
                                    dr["DIEM3"] = dr1["DIEM3"];
                                    dr["NOI_DUNG4"] = dr1["NOI_DUNG4"];
                                    dr["DIEM4"] = dr1["DIEM4"];
                                    dr["NOI_DUNG5"] = dr1["NOI_DUNG5"];
                                    dr["DIEM5"] = dr1["DIEM5"];
                                    dr["DIEM_TONG_KET"] = dr1["DIEM_TONG_KET"];
                                    dr["DAT"] = dr1["DAT"];

                                    dtTmp.Rows.Add(dr);
                                    dtTmp.AcceptChanges();
                                }
                            }
                        }
                        catch { }

                        break;
                    }

                case "luu":
                    {
                        try
                        {
                            grdPhongVanUV.MainView.CloseEditor();
                            grvPhongVanUV.UpdateCurrentRow();

                            if (!dxValidationProvider1.Validate()) return;
                            dxValidationProvider1.Validate();
                            if (KiemTrung()) return;
                            if (kiemTrungDOT()) return;
                            if (KiemTrong()) return;
                            string sBT_grvPhongVan = "sBT_grvPhongVan" + Commons.Modules.UserName;
                            //grdPhongVanUV.DataSource = dt_PVUV.Clone();

                            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT_grvPhongVan, Commons.Modules.ObjSystems.ConvertDatatable(grdPhongVanUV), "");
                            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                            conn.Open();
                            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPhongVan", conn);
                            cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 6;
                            cmd.Parameters.Add("@sBT", SqlDbType.NVarChar).Value = sBT_grvPhongVan;
                            cmd.Parameters.Add("@ID_PV", SqlDbType.BigInt).Value = iIDPV;
                            cmd.Parameters.Add("@MA_SO", SqlDbType.NVarChar).Value = txtMA_SO.EditValue;
                            cmd.Parameters.Add("@NGAY_LAP", SqlDbType.Date).Value = datNGAY_LAP.EditValue;
                            cmd.Parameters.Add("@ID_TB", SqlDbType.BigInt).Value = cboID_TB.EditValue;
                            cmd.Parameters.Add("@DOT", SqlDbType.Int).Value = txtDOT.EditValue;
                            cmd.Parameters.Add("@NOI_DUNG_PV", SqlDbType.NVarChar).Value = txtNOI_DUNG_PV.EditValue;
                            cmd.Parameters.Add("@NGUOI_PV", SqlDbType.NVarChar).Value = txtNGUOI_PV.EditValue;
                            cmd.Parameters.Add("@TG_BD", SqlDbType.DateTime).Value = datTG_BD.EditValue;
                            cmd.Parameters.Add("@TG_KT", SqlDbType.DateTime).Value = datTG_KT.EditValue;
                            cmd.Parameters.Add("@THONG_TIN", SqlDbType.NText).Value = txtTHONG_TIN.EditValue;
                            cmd.Parameters.Add("@TINH_TRANG", SqlDbType.Int).Value = cboTINH_TRANG.EditValue;
                            cmd.CommandType = CommandType.StoredProcedure;
                            iIDPV = Convert.ToInt64(cmd.ExecuteScalar());
                            if (iIDPV != -1)
                            {
                                enableButon(true);
                                LoadData(false, "", iIDPV);
                            }
                            if (conn.State == ConnectionState.Open)
                                conn.Close();
                        }

                        catch (Exception ex) { MessageBox.Show(ex.Message); }

                        break;
                    }
                case "khongluu":
                    {
                        if (iIDPV == -1) // nếu iIDPV = -1, thêm thì xóa grid
                        {
                            grdPhongVanUV.DataSource = ((DataTable)grdPhongVanUV.DataSource).Clone();
                            ((DataTable)grdPhongVanUV.DataSource).AcceptChanges();
                        }
                        else
                        {
                            LoadData(false, "", iIDPV);
                        }
                        Bindingdata(false);
                        enableButon(true);
                        //enableButon(true);
                        //if (grvBangCapUV.RowCount == 1)
                        //{
                        //    Bindingdata(false);
                        //}
                        //dxValidationProvider1.Validate();
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

        private void grvPhongVanUV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    if (btnALL.Buttons[0].Properties.Visible)
                    {
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Xoa"), Commons.Modules.ObjLanguages.GetLanguage("msgThongBao", "msg_Caption"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            String sSql = " DELETE FROM dbo.PHONG_VAN_UNG_VIEN WHERE ID_PV = " + iIDPV.ToString() + " AND   ID_UV = " + grvPhongVanUV.GetFocusedRowCellValue("ID_UV").ToString();

                            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                            grvPhongVanUV.DeleteSelectedRows();
                        }
                        else
                            return;
                    }
                    else
                    {
                        grvPhongVanUV.DeleteSelectedRows();
                    }
                    ((DataTable)grdPhongVanUV.DataSource).AcceptChanges();
                }
                catch { }
            }
        }
        private void cboID_TB_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                maxDot = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, "SELECT  MAX(PV.DOT) AS DOT FROM dbo.PHONG_VAN PV WHERE PV.ID_TB = " + Convert.ToInt32(cboID_TB.EditValue) + ""));
                txtDOT.EditValue = maxDot + 1;


            }
            catch
            {
                txtDOT.EditValue = 1;
            }
        }

        private void grvPhongVanUV_DoubleClick(object sender, EventArgs e)
        {
            if (grvPhongVanUV.RowCount < 1)
            {
                return;
            }
            ucUV = new ucCTQLUV(Convert.ToInt64(grvPhongVanUV.GetFocusedRowCellValue("ID_UV")));
            Commons.Modules.ObjSystems.ShowWaitForm(this);
            ucUV.Refresh();
            //ns.accorMenuleft = accorMenuleft;
            dataLayoutControl1.Hide();
            this.Controls.Add(ucUV);
            ucUV.Dock = DockStyle.Fill;
            ucUV.backWindowsUIButtonPanel.ButtonClick += BackWindowsUIButtonPanel_ButtonClick;
            accorMenuleft.Visible = false;
            Commons.Modules.ObjSystems.HideWaitForm();
        }
        #endregion

        #region function 
        private void Loadcbo()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPhongVan", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //Load combo ID_TB
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_TB, dt, "ID_TB", "SO_TB", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "SO_TB"), true, true);

                //Load combo TINH_TRANG
                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[1].Copy();
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboTINH_TRANG, dt1, "ID_TT", "TINH_TRANG", Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TINH_TRANG"), true, true);
                cboTINH_TRANG.Properties.View.Columns[0].Visible = false;
            }
            catch { }
        }
        private void TaoMa()
        {
            string Ma = "";
            try
            {
                Ma = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "MTaoSoPhieuTD", "PV", "PHONG_VAN", "MA_SO", Convert.ToDateTime(datNGAY_LAP.EditValue).ToString()).ToString();
            }
            catch { Ma = ""; }
            txtMA_SO.Text = Ma;
        }
        private void enableButon(bool visible)
        {
            btnALL.Buttons[0].Properties.Visible = visible;
            btnALL.Buttons[1].Properties.Visible = visible;
            btnALL.Buttons[2].Properties.Visible = !visible;
            btnALL.Buttons[3].Properties.Visible = !visible;
            btnALL.Buttons[4].Properties.Visible = !visible;
            btnALL.Buttons[5].Properties.Visible = !visible;
            btnALL.Buttons[6].Properties.Visible = visible;

            grvPhongVanUV.OptionsBehavior.Editable = !visible;

            txtMA_SO.Properties.ReadOnly = visible;
            datNGAY_LAP.Enabled = !visible;
            cboID_TB.Properties.ReadOnly = visible;
            txtDOT.Properties.ReadOnly = visible;
            txtNGUOI_PV.Properties.ReadOnly = visible;
            txtNOI_DUNG_PV.Properties.ReadOnly = visible;
            datTG_BD.Enabled = !visible;
            datTG_KT.Enabled = !visible;
            txtTHONG_TIN.Properties.ReadOnly = visible;
            cboTINH_TRANG.Properties.ReadOnly = visible;
        }
        private void Bindingdata(bool bthem)
        {
            if (bthem == true)
            {
                TaoMa();
                datNGAY_LAP.EditValue = DateTime.Today;
                cboID_TB.EditValue = -99;
                txtDOT.EditValue = 1;
                txtNGUOI_PV.EditValue = "";
                txtNOI_DUNG_PV.EditValue = "";
                datTG_BD.EditValue = DateTime.Today;
                datTG_KT.EditValue = DateTime.Today;
                txtTHONG_TIN.EditValue = "";
                cboTINH_TRANG.EditValue = -99;
            }
            else
            {
                LoadText(iIDPV);
                return;
            }
        }
        private void LoadData(bool colTmp, string chuoiIDUV, Int64 idpv)
        {

            DataTable dt = new DataTable();
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPhongVan", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.Add("@ColTmp", SqlDbType.Bit).Value = colTmp;
                cmd.Parameters.Add("@CHUOI_IDUV", SqlDbType.NVarChar).Value = chuoiIDUV;
                cmd.Parameters.Add("@ID_PV", SqlDbType.BigInt).Value = idpv;
                cmd.CommandType = CommandType.StoredProcedure;

                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0].Copy();
                dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_UV"] };

            }
            catch { }
            try
            {
                if (grdPhongVanUV.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPhongVanUV, grvPhongVanUV, dt, false, true, false, false, false, "");
                    grvPhongVanUV.Columns["CHON"].Visible = false;
                    grvPhongVanUV.Columns["ID_UV"].Visible = false;
                    grvPhongVanUV.Columns["ID_PVUV"].Visible = false;
                    grvPhongVanUV.Columns["ID_PV"].Visible = false;
                    grvPhongVanUV.Columns["TEN_TDVH"].Visible = false;
                    grvPhongVanUV.Columns["TEN_KNLV"].Visible = false;
                    grvPhongVanUV.Columns["NGUYEN_QUAN"].Visible = false;
                    grvPhongVanUV.Columns["DT_DI_DONG"].Visible = false;
                    grvPhongVanUV.Columns["EMAIL"].Visible = false;
                    grvPhongVanUV.Columns["DIA_CHI_TAM_TRU"].Visible = false;

                    grvPhongVanUV.Columns["DAT"].OptionsColumn.AllowEdit = true;
                    grvPhongVanUV.Columns["MS_UV"].OptionsColumn.AllowEdit = false;
                    grvPhongVanUV.Columns["HO_TEN"].OptionsColumn.AllowEdit = false;
                    grvPhongVanUV.Columns["NGAY_SINH"].OptionsColumn.AllowEdit = false;
                    grvPhongVanUV.Columns["PHAI"].OptionsColumn.AllowEdit = false;
                    grvPhongVanUV.Columns["HINH_THUC_TUYEN"].OptionsColumn.AllowEdit = false;
                    grvPhongVanUV.Columns["CHUYEN_MON"].OptionsColumn.AllowEdit = false;

                    grvPhongVanUV.Columns["MS_UV"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvPhongVanUV.Columns["HO_TEN"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvPhongVanUV.Columns["NGAY_SINH"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvPhongVanUV.Columns["PHAI"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvPhongVanUV.Columns["HINH_THUC_TUYEN"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    grvPhongVanUV.Columns["CHUYEN_MON"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                    grdPhongVanUV.DataSource = dt;

                if (Commons.Modules.iUngVien != -1)
                {
                    try
                    {
                        int index = dt.Rows.IndexOf(dt.Rows.Find(Commons.Modules.iUngVien));
                        grvPhongVanUV.FocusedRowHandle = grvPhongVanUV.GetRowHandle(index);
                    }
                    catch { }
                }
            }
            catch { }
        }
        private void LoadText(Int64 idpv)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPhongVan", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@ID_PV", SqlDbType.BigInt).Value = idpv;
                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();

                txtMA_SO.EditValue = dt.Rows[0]["MA_SO"];
                datNGAY_LAP.EditValue = dt.Rows[0]["NGAY_LAP"];
                cboID_TB.EditValue = dt.Rows[0]["ID_TB"];
                txtDOT.EditValue = dt.Rows[0]["DOT"];
                txtNGUOI_PV.EditValue = dt.Rows[0]["NGUOI_PV"];
                txtNOI_DUNG_PV.EditValue = dt.Rows[0]["NOI_DUNG_PV"];
                datTG_BD.EditValue = dt.Rows[0]["TG_BD"];
                datTG_KT.EditValue = dt.Rows[0]["TG_KT"];
                txtTHONG_TIN.EditValue = dt.Rows[0]["THONG_TIN"];
                cboTINH_TRANG.EditValue = dt.Rows[0]["TINH_TRANG"];
            }
            catch
            {
                TaoMa();
                datNGAY_LAP.EditValue = DateTime.Today;
                cboID_TB.EditValue = -99;
                txtDOT.EditValue = 1;
                txtNGUOI_PV.EditValue = "";
                txtNOI_DUNG_PV.EditValue = "";
                datTG_BD.EditValue = DateTime.Today;
                datTG_KT.EditValue = DateTime.Today;
                txtTHONG_TIN.EditValue = "";
                cboTINH_TRANG.EditValue = -99;
            }
        }
        private bool KiemTrung()
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPhongVan", conn);
                cmd.Parameters.Add("@iLoai", SqlDbType.Int).Value = 7;
                cmd.Parameters.Add("@MA_SO", SqlDbType.NVarChar).Value = txtMA_SO.EditValue;
                cmd.Parameters.Add("@ID_PV", SqlDbType.BigInt).Value = iIDPV;
                cmd.CommandType = CommandType.StoredProcedure;
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                {
                    XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrung"));
                    txtMA_SO.Focus();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool KiemTrong()
        {
            try
            {
                if (string.IsNullOrEmpty(txtMA_SO.Text.Trim()))
                {
                    XtraMessageBox.Show(lblMA_SO.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    txtMA_SO.Focus();
                    return true;
                }

                if (string.IsNullOrEmpty(datNGAY_LAP.Text))
                {
                    XtraMessageBox.Show(lblNGAY_LAP.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    datNGAY_LAP.Focus();
                    return true;
                }

                if (Convert.ToInt32(cboID_TB.EditValue) < 1)
                {
                    XtraMessageBox.Show(lblID_TB.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    cboID_TB.Focus();
                    return true;
                }
                if (Convert.ToInt32(txtDOT.EditValue) < 1)
                {
                    XtraMessageBox.Show(lblDOT.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocNhoHon0"));
                    txtDOT.Focus();
                    return true;
                }

                //if (Convert.ToInt32(txtDOT.EditValue) <= maxDot)
                //{
                //    XtraMessageBox.Show(lblDOT.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, txtDOT.EditValue + " " + "msgDaTonTai"));
                //    txtDOT.Focus();
                //    return true;
                //}
                if (Convert.ToInt32(cboTINH_TRANG.EditValue) < 1)
                {
                    XtraMessageBox.Show(lblTINH_TRANG.Text + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgKhongDuocTrong"));
                    cboTINH_TRANG.Focus();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return false;
            }
        }
        private void LoadNN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup> { Root }, btnALL);
            Commons.Modules.ObjSystems.MLoadNNXtraGrid(grvPhongVanUV, this.Name);
        }

        private void AddnewRow()
        {
            grvPhongVanUV.OptionsBehavior.Editable = true;
            grvPhongVanUV.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grvPhongVanUV.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private bool kiemTrungDOT()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(Commons.IConnections.CNStr, CommandType.Text, "SELECT DOT FROM dbo.PHONG_VAN WHERE ID_TB  = " + Convert.ToInt32(cboID_TB.EditValue) + " AND ID_PV <> " + iIDPV + " ORDER BY DOT DESC");
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(txtDOT.EditValue) == Convert.ToInt32(dt.Rows[i][0]))
                {
                    XtraMessageBox.Show(lblDOT.Text + " " + txtDOT.EditValue + " " + Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDaTonTai"));
                    txtDOT.Focus();
                    return true;
                }
            }
            return false;
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

        public DevExpress.Utils.Menu.DXMenuItem MCreateMenuNhapUngVien(DevExpress.XtraGrid.Views.Grid.GridView view, int rowHandle)
        {
            string sStr = Commons.Modules.ObjLanguages.GetLanguage(Commons.Modules.ModuleName, "ucPhongVan", "mnuNhapUV", Commons.Modules.TypeLanguage);
            DevExpress.Utils.Menu.DXMenuItem menuNhapUV = new DevExpress.Utils.Menu.DXMenuItem(sStr, new EventHandler(NhapUngVien));
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
            dataLayoutControl1.Hide();
            this.Controls.Add(ucUV);
            this.Dock = DockStyle.Fill;
            ucUV.backWindowsUIButtonPanel.ButtonClick += BackWindowsUIButtonPanel_ButtonClick;
            Commons.Modules.ObjSystems.HideWaitForm();
        }
        public void BackWindowsUIButtonPanel_ButtonClick(object sender, ButtonEventArgs e)
        {
            ucUV.Hide();
            dataLayoutControl1.Show();



            DataTable dtmp = new DataTable();
            dtmp = (DataTable)grdPhongVanUV.DataSource;
            if (dtmp.Rows.Count == 0) return;
            string chuoiIDUV_tmp = "";
            for (int i = 0; i < dtmp.Rows.Count; i++)
            {
                chuoiIDUV_tmp += dtmp.Rows[i]["ID_UV"].ToString() + ",";
            }
            string chuoiIDUV = chuoiIDUV_tmp.Remove(chuoiIDUV_tmp.Length - 1);

            LoadData(true, chuoiIDUV, iIDPV);
            accorMenuleft.Visible = true;

        }
        private void grvPhongVanUV_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                int irow = e.HitInfo.RowHandle;
                e.Menu.Items.Clear();
                DevExpress.Utils.Menu.DXMenuItem itemNhapUV = MCreateMenuNhapUngVien(view, irow);
                e.Menu.Items.Add(itemNhapUV);
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

        #endregion

        private void grvPhongVanUV_MouseWheel(object sender, MouseEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = (sender as DevExpress.XtraGrid.Views.Grid.GridView);
            //view.LeftCoord += e.Delta;
            //(e as DevExpress.Utils.DXMouseEventArgs).Handled = true;
        }
    }
}
