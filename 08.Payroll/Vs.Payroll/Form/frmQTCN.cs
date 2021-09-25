using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraGrid.Views.Grid;
using Vs.Report;
using DevExpress.Utils;
using System.Globalization;
using DevExpress.XtraBars.Docking2010;

namespace Vs.Payroll
{
    public partial class frmQTCN : DevExpress.XtraEditors.XtraUserControl
    {
        private bool isAdd = false;
        int id_NHH = 0;
        //string sCnstr = "Server=192.168.2.5;database=DATA_MT;uid=sa;pwd=123;Connect Timeout=0;"; 
        public frmQTCN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this,windowsUIButton);
            InitializeComponent();
            optHT.SelectedIndex = 0;
        }
               
        private void frmQTCN_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            
            try
            {
                LoadCbo();
                LoadHD(0);
                LoadLuoi();
                cboCum_EditValueChanged(null, null);
                cboChuyen_EditValueChanged(null, null);
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message.ToString()); }

            Commons.Modules.sPS = "";
        }

        private void LoadHD(int iLoad)
        {
            Commons.Modules.sPS = "0LoadCbo";
            String sKH, sDDH, sMH, sOrd;
            sKH = "-1"; sDDH = "-1"; sMH = "-1"; sOrd = "-1";

            try { sKH = cboKH.EditValue.ToString(); } catch { }
            try { sDDH = cboHD.EditValue.ToString(); } catch { }
            try { sMH = cboMH.EditValue.ToString(); } catch { }
            try { sOrd = cboOrd.EditValue.ToString(); } catch { }

            System.Data.SqlClient.SqlConnection conn;
            DataTable dt = new DataTable();

            try
            {
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spQTCNGetCbo", conn);

                cmd.Parameters.Add("@HoanThanh", SqlDbType.Int).Value = optHT.SelectedIndex;
                cmd.Parameters.Add("@sKH", SqlDbType.NVarChar, 50).Value = sKH;
                cmd.Parameters.Add("@sDDH", SqlDbType.NVarChar, 50).Value = sDDH;
                cmd.Parameters.Add("@sMH", SqlDbType.NVarChar, 50).Value = sMH;
                cmd.Parameters.Add("@sOrd", SqlDbType.NVarChar, 50).Value = sOrd;

                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);

                dt = new DataTable();
                dt = ds.Tables[0].Copy();
                dt.TableName = "KHACH_HANG";
                if (iLoad == 0) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboKH, dt, "ID_DT", "TEN_NGAN", "TEN_NGAN", true);

                dt = new DataTable();
                dt = ds.Tables[1].Copy();
                dt.TableName = "HOP_DONG";
                if (iLoad == 0 || iLoad == 1) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboHD, dt, "ID_DHB", "SO_DHB", "SO_DHB", true);


                dt = new DataTable();
                dt = ds.Tables[2].Copy();
                dt.TableName = "MA_HANG";
                if (iLoad == 0 || iLoad == 1 || iLoad == 2) {
                    Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMH, dt, "ID_HH", "TEN_HH", "TEN_HH", true);
                    id_NHH = Convert.ToInt32(dt.Rows[0]["ID_NHH"].ToString());
                }

                dt = new DataTable();
                dt = ds.Tables[3].Copy();
                dt.TableName = "TEN_ORDER";
                if (iLoad == 0 || iLoad == 1 || iLoad == 2 || iLoad == 3) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboOrd, dt, "ID_DHBORD", "TEN_ORD", "TEN_ORD", true);
                                             
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

        }

        private void LoadCbo()
        {
            try
            {
                string sSql = "SELECT ID_CHUYEN, TEN_CHUYEN FROM CHUYEN UNION SELECT '-1', '' FROM CHUYEN ORDER BY CHUYEN.TEN_CHUYEN";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboChuyen, dt, "ID_CHUYEN", "TEN_CHUYEN", "TEN_CHUYEN");
                cboChuyen.Properties.View.Columns[0].Caption = "STT Chuyền";
                cboChuyen.Properties.View.Columns[1].Caption = "Tên Chuyền";
                cboChuyen.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cboChuyen.Properties.View.Columns[1].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cboChuyen.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cboChuyen.Properties.View.Columns[0].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                
                sSql = "SELECT ID_NHH, TEN_NHH FROM NHOM_HANG_HOA UNION SELECT '-1', '' FROM NHOM_HANG_HOA ORDER BY TEN_NHH";
                dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboLMH, dt, "ID_NHH", "TEN_NHH", "TEN_NHH");
                LoadCboCum(id_NHH);
            }
            catch { }
        }

        private void LoadCboCum(int LSP)
        {
            try
            {
                string sSql = "SELECT ID_CUM, TEN_CUM FROM CUM WHERE ID_NHH = " + cboLMH.EditValue + " UNION SELECT '-1','' FROM CUM ";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboCum, dt, "ID_CUM", "TEN_CUM", "TEN_CUM");
                cboCum.Properties.View.Columns[0].Caption = "ID cụm";
                cboCum.Properties.View.Columns[1].Caption = "Tên cụm";
                cboCum.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cboCum.Properties.View.Columns[1].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                cboCum.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                cboCum.Properties.View.Columns[0].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                
            }
            catch { }
        }

        DataTable dtBT;
        DataTable dtCD, dtLoaiMay, dtChuyen, dtCum;
        private void LoadLuoi()
        {
            Commons.Modules.sPS = "0Load";
            String sDDH, sMH, sOrd;
            sDDH = "-1"; sMH = "-1"; sOrd = "-1";

            try { sDDH = cboHD.EditValue.ToString(); } catch { }
            try { sMH = cboMH.EditValue.ToString(); } catch { }
            try { sOrd = cboOrd.EditValue.ToString(); } catch { }

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spQTCNGet", sDDH, sMH, sOrd));
            //dt.Columns["MS_CD"].ReadOnly = false;
            //dt.Columns["CD_DUNG_CHUNG"].ReadOnly = false;
            //dt.Columns["STT_CHUYEN"].ReadOnly = false;
            //dt.Columns["MS_DDH"].ReadOnly = false;
            //dt.Columns["MS_MH"].ReadOnly = false;
            //dt.Columns["ORDER"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdQT, grvQT, dt, false, false, false, true, true, this.Name);
            
            try { dNgayLap.EditValue = Convert.ToDateTime(dt.Rows[0]["NGAY_LAP"]).ToString("dd/MM/yyyy");}
            catch{ }
            dtCD = new DataTable();
            dtLoaiMay = new DataTable();
            dtChuyen = new DataTable();
            dtCum = new DataTable();

            try
            {
                dtCD.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboCongDoan",  1));
                Commons.Modules.ObjSystems.AddCombo("ID_CD", "TEN_CD", grvQT, dtCD, true);

                dtLoaiMay = new DataTable();
                dtLoaiMay.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboLoaiMay",Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.AddCombo("ID_LM", "TEN_LOAI_MAY", grvQT, dtLoaiMay, true);

                dtBT = new DataTable();
                dtBT.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboBacTho", 1));
                Commons.Modules.ObjSystems.AddCombo("ID_BT", "TEN_BAC_THO", grvQT, dtBT, true);

                dtChuyen = new DataTable();
                dtChuyen.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "Select ID_CHUYEN, TEN_CHUYEN from CHUYEN"));
                Commons.Modules.ObjSystems.AddCombo("ID_CHUYEN", "TEN_CHUYEN", grvQT, dtChuyen, true);

                dtCum = new DataTable();
                dtCum.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "Select ID_CUM, TEN_CUM from CUM"));
                Commons.Modules.ObjSystems.AddCombo("ID_CUM", "TEN_CUM", grvQT, dtCum, true);
            }
            catch
            {

            }

            FormatGrid();
            SetButton(isAdd);
        }

        private void FormatGrid()
        {
            //An cot
            grvQT.Columns["NGAY_LAP"].Visible = false;
            grvQT.Columns["ID_DHB"].Visible = false;
            grvQT.Columns["ID_HH"].Visible = false;
            grvQT.Columns["ID_DHBORD"].Visible = false;
            //grvQT.Columns["STT_CHUYEN"].Visible = false;
            //grvQT.Columns["MS_DDH"].Visible = false;
            //grvQT.Columns["MS_MH"].Visible = false;
            //grvQT.Columns["ORDER"].Visible = false;
            //grvQT.Columns["MS_CUM"].Visible = false;
            
            grvQT.Columns["THOI_GIAN_THIET_KE"].DisplayFormat.FormatType = FormatType.Numeric;
            grvQT.Columns["THOI_GIAN_THIET_KE"].DisplayFormat.FormatString = "N0";
            grvQT.Columns["THOI_GIAN_QUI_DOI"].DisplayFormat.FormatType = FormatType.Numeric;
            grvQT.Columns["THOI_GIAN_QUI_DOI"].DisplayFormat.FormatString = "N0";
            grvQT.Columns["HS_HT_DG"].DisplayFormat.FormatType = FormatType.Numeric;
            grvQT.Columns["HS_HT_DG"].DisplayFormat.FormatString = "N0";
            grvQT.Columns["DON_GIA_GIAY"].DisplayFormat.FormatType = FormatType.Numeric;
            grvQT.Columns["DON_GIA_GIAY"].DisplayFormat.FormatString = "N0";
            grvQT.Columns["DON_GIA_THUC_TE"].DisplayFormat.FormatType = FormatType.Numeric;
            grvQT.Columns["DON_GIA_THUC_TE"].DisplayFormat.FormatString = "N0";

            //grvQT.Columns["THU_TU_CONG_DOAN"].Width = 50;
            //grvQT.Columns["MaQL"].Width = 50;
            //grvQT.Columns["BAC_THO"].Width = 80;
            //grvQT.Columns["HE_SO_BAC_THO"].Width = 70;
            grvQT.Columns["ID_CD"].Width = 350;
            //grvQT.Columns["CD_DUNG_CHUNG"].Width = 90;
            //grvQT.Columns["THOI_GIAN_THIET_KE"].Width = 70;
            //grvQT.Columns["THOI_GIAN_QUI_DOI"].Width = 70;
            //grvQT.Columns["DON_GIA_GIAY"].Width = 70;
            //grvQT.Columns["DON_GIA_THUC_TE"].Width = 100;
            //grvQT.Columns["MS_LOAI_MAY"].Width = 100;
            //grvQT.Columns["HS_HT_DG"].UnboundExpression = txtHS.Text;
            for (int i = 0; i < grvQT.Columns.Count; i++)
            {
                grvQT.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
            }

        }


        private void cboKH_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(1);
            Commons.Modules.sPS = "";
        }

        private void cboMH_EditValueChanged(object sender, EventArgs e)
        {
            //if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(3);

            GridView view = cboMH.Properties.View;
            int rowHandle = view.FocusedRowHandle;
            string fieldName = "ID_NHH"; // or other field name  
            object value = view.GetRowCellValue(rowHandle, fieldName);
            cboLMH.EditValue = Convert.ToInt32(value);
            //LoadCbo();
            LoadLuoi();
            Commons.Modules.sPS = "";
        }

        private void cboHD_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(2);
            LoadLuoi();
            Commons.Modules.sPS = "";

            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void cboOrd_EditValueChanged(object sender, EventArgs e)
        {
            LoadLuoi();
        }

        private void LocData()
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grdQT.DataSource;
                String sCum, sChuyen;
                string sDK = " 1 = 1 ";
                sCum = "-1"; sChuyen = "-1";
                try { sCum = cboCum.EditValue.ToString(); } catch { }
                try { sChuyen = cboChuyen.EditValue.ToString(); } catch { }

                if (sCum != "-1") sDK = sDK + " AND ID_CUM = '"+ sCum +"' ";
                if (sChuyen != "-1") sDK = sDK + " AND ID_CHUYEN = '" + sChuyen + "' ";

                dtTmp.DefaultView.RowFilter = sDK;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void cboCum_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        private void cboChuyen_EditValueChanged(object sender, EventArgs e)
        {
            LocData();
        }

        /// <summary>
        /// Set btn Enable
        /// </summary>
        /// <param name="isAdd"></param>
        private void SetButton(bool isAdd)
        {
            //btnThemSua.Visible = !isAdd;
            //btnXoa.Visible = !isAdd;
            //btnIn.Visible = !isAdd;
            //btnThoat.Visible = !isAdd;
            //btnGhi.Visible = isAdd;
            //btnKhongGhi.Visible = isAdd;

            windowsUIButton.Buttons[0].Properties.Visible = !isAdd;
            windowsUIButton.Buttons[1].Properties.Visible = !isAdd;
            windowsUIButton.Buttons[2].Properties.Visible = !isAdd;
            windowsUIButton.Buttons[3].Properties.Visible = !isAdd;
            windowsUIButton.Buttons[6].Properties.Visible = !isAdd;


            windowsUIButton.Buttons[4].Properties.Visible = isAdd;
            windowsUIButton.Buttons[5].Properties.Visible = isAdd;


            optHT.Enabled = !isAdd;
            cboKH.Enabled = !isAdd;
            cboHD.Enabled = !isAdd;
            cboMH.Enabled = !isAdd;
            cboLMH.Enabled = !isAdd;
            cboOrd.Enabled = !isAdd;
            cboChuyen.Enabled = !isAdd;
            dNgayLap.Enabled = !isAdd;
            txtSLCN.Enabled = !isAdd;
            cboCum.Enabled = !isAdd;

            txtHS.Enabled = isAdd;
            txtDG.Enabled = isAdd;

        }

        int ttCD, ttChuyen;
        /// <summary>
        /// them Sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void GetStt(ref int ttCD, ref int ttChuyen)
        {
            ttCD = ttChuyen = 0;
            try
            {
                if (grvQT.RowCount == 0)
                    return;
                Int32.TryParse(Commons.Modules.ObjSystems.ConvertDatatable(grvQT).AsEnumerable().Max(row => row["THU_TU_CONG_DOAN"]).ToString(), out ttCD);
                Int32.TryParse(Commons.Modules.ObjSystems.ConvertDatatable(grvQT).AsEnumerable().Max(row => row["MaQL"]).ToString(), out ttChuyen);
                return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// Khong ghi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    


        /// <summary>
        /// btn Xoa Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      

        private void grvQT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ////Validate();
            //if (grvQT.RowCount == 0) return;
            //GridView view = sender as GridView;
            //try
            //{
            //    Decimal hsBT, tgTK, dgG, hsDG;
            //    Decimal.TryParse(grvQT.GetFocusedRowCellValue("HE_SO_BAC_THO").ToString(), out hsBT);
            //    Decimal.TryParse(grvQT.GetFocusedRowCellValue("THOI_GIAN_THIET_KE").ToString(), out tgTK);
            //    Decimal.TryParse(grvQT.GetFocusedRowCellValue("DON_GIA_GIAY").ToString(), out dgG);
            //    Decimal.TryParse(grvQT.GetFocusedRowCellValue("HS_HT_DG").ToString(), out hsDG);

            //    if (e.Column.FieldName == "BAC_THO")
            //    {
            //        hsBT = Convert.ToDecimal((from DataRow row in dtBT.Rows
            //                                          where row["BAC_THO"] == e.Value
            //                                          select row["HE_SO_BAC_THO"]).FirstOrDefault());
            //        grvQT.SetFocusedRowCellValue("HE_SO_BAC_THO", hsBT);
            //    }
            //    if (e.Column.FieldName == "MS_CD")
            //    {
            //        tgTK = Convert.ToDecimal((from DataRow row in dtCD.Rows
            //                                      where row["MS_CD"] == e.Value
            //                                      select row["TGTK"]).FirstOrDefault());

            //        grvQT.SetFocusedRowCellValue("THOI_GIAN_THIET_KE", tgTK);
            //    }
            //    if(e.Column.FieldName == "HE_SO_BAC_THO" || e.Column.FieldName == "THOI_GIAN_THIET_KE")
            //    {
            //        grvQT.SetFocusedRowCellValue("THOI_GIAN_QUI_DOI", hsBT * tgTK );
            //        grvQT.SetFocusedRowCellValue("DON_GIA_THUC_TE", hsBT * tgTK * dgG * hsDG);
            //    }
            //    if(e.Column.FieldName == "DON_GIA_GIAY" || e.Column.FieldName == "HS_HT_DG")
            //    {
            //        grvQT.SetFocusedRowCellValue("DON_GIA_THUC_TE", hsBT * tgTK * dgG * hsDG);
            //    }
            //}
            //catch { }

        }

        private void Savedata()
        {
            string stbQT = "stbQT" + Commons.Modules.UserName;
            try
            {
                //tạo một datatable 
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, stbQT, Commons.Modules.ObjSystems.ConvertDatatable(grvQT), "");
                string sSql = "UPDATE QUI_TRINH_CONG_NGHE_CHI_TIET SET THU_TU_CONG_DOAN = tmp.THU_TU_CONG_DOAN "
                            + " , MaQL = tmp.MaQL, ID_LM = tmp.ID_LM, ID_BT = tmp.ID_BT, THOI_GIAN_THIET_KE = tmp.THOI_GIAN_THIET_KE,"
                            + " THOI_GIAN_QUI_DOI = tmp.THOI_GIAN_QUI_DOI, HS_HT_DG = tmp.HS_HT_DG, DON_GIA_GIAY = tmp.DON_GIA_GIAY, DON_GIA_THUC_TE "
                            + " = tmp.DON_GIA_THUC_TE, CD_DUNG_CHUNG = tmp.CD_DUNG_CHUNG, YEU_CAU_KT = tmp.YEU_CAU_KT "
                            + " FROM QUI_TRINH_CONG_NGHE_CHI_TIET QT "
                            + " INNER JOIN "+ stbQT + " tmp ON QT.ID_CHUYEN = tmp.ID_CHUYEN "
                            + " AND QT.ID_ORD = tmp.ID_DHBORD AND QT.ID_CD = tmp.ID_CD "
                            + " INSERT INTO QUI_TRINH_CONG_NGHE_CHI_TIET(THU_TU_CONG_DOAN, MaQL, ID_CD, ID_LM, ID_BT, THOI_GIAN_THIET_KE, "
                            + " THOI_GIAN_QUI_DOI, HS_HT_DG, DON_GIA_GIAY, DON_GIA_THUC_TE, CD_DUNG_CHUNG, YEU_CAU_KT, ID_CHUYEN,  ID_ORD)"
                            + " SELECT THU_TU_CONG_DOAN, MaQL, ID_CD, ID_LM, ID_BT, THOI_GIAN_THIET_KE, THOI_GIAN_QUI_DOI, HS_HT_DG,"
                            + " DON_GIA_GIAY, DON_GIA_THUC_TE, CD_DUNG_CHUNG, YEU_CAU_KT, ID_CHUYEN, ID_DHBORD"
                            + " FROM " + stbQT + " tmp1 WHERE NOT EXISTS(SELECT* FROM QUI_TRINH_CONG_NGHE_CHI_TIET QTCT"
                            + " WHERE tmp1.ID_CHUYEN = QTCT.ID_CHUYEN "
                            + " AND tmp1.ID_DHBORD = QTCT.ID_ORD AND tmp1.ID_CD = QTCT.ID_CD)";

                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                    string strSql1 = "DROP TABLE " + stbQT;
                    SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, strSql1);
                Commons.Modules.ObjSystems.XoaTable(stbQT);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }



        private void txtHS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtHS.Text == "") return;
                decimal _hs;
                NumberStyles style;
                CultureInfo culture;
                //style = NumberStyles.AllowDecimalPoint;
                //culture = CultureInfo.CreateSpecificCulture("fr-FR");
                //decimal.TryParse(txtHS.Text, style,culture, out _hs);

                
                style = NumberStyles.AllowDecimalPoint;
                culture = CultureInfo.CreateSpecificCulture("fr-FR");
                if (Decimal.TryParse(txtHS.Text, style, culture, out _hs))
                    Console.WriteLine("Converted '{0}' to {1}.", txtHS.Text, _hs);
                else
                    Console.WriteLine("Unable to convert '{0}'.", _hs);


                //string _hs = txtHS.Text;
                string sTBGrv = "QTCN_ADD_HS" + Commons.Modules.UserName;
                DataTable dt = new DataTable();
                string sSql = "";
                try
                {
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sTBGrv, Commons.Modules.ObjSystems.ConvertDatatable(grvQT), "");
                    sSql = " SELECT THU_TU_CONG_DOAN, MaQL, ID_CD, ID_LM, ID_BT, HE_SO_BAC_THO, THOI_GIAN_THIET_KE, " +
                           " THOI_GIAN_QUI_DOI, " + _hs + " HS_HT_DG, DON_GIA_GIAY, " +
                           _hs + " * ISNULL(THOI_GIAN_THIET_KE,0) * ISNULL(HE_SO_BAC_THO,0) * ISNULL(DON_GIA_GIAY,0) DON_GIA_THUC_TE, CD_DUNG_CHUNG, YEU_CAU_KT, ID_CUM, ID_CHUYEN, ID_DHB, ID_HH, ID_DHBORD, NGAY_LAP " +
                           " FROM " + sTBGrv + "";
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdQT, grvQT, dt, true, false, true, true, true, this.Name);

                    Commons.Modules.ObjSystems.XoaTable(sTBGrv);

                    FormatGrid();
                }
                catch (Exception EX)
                {
                    XtraMessageBox.Show(EX.Message.ToString());
                }
            }
        }

        private void txtDG_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDG.Text == "") return;
                decimal _dg;
                decimal.TryParse(txtDG.Text, out _dg);
                string sTBGrv = "QTCN_ADD_DG" + Commons.Modules.UserName;
                DataTable dt = new DataTable();
                string sSql = "";
                try
                {
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sTBGrv, Commons.Modules.ObjSystems.ConvertDatatable(grvQT), "");
                    sSql = " SELECT THU_TU_CONG_DOAN, MaQL, ID_CD, ID_LM, ID_BT, HE_SO_BAC_THO, THOI_GIAN_THIET_KE," +
                           " THOI_GIAN_QUI_DOI, HS_HT_DG," + _dg + " DON_GIA_GIAY, " +
                           _dg + " * ISNULL(THOI_GIAN_THIET_KE,0) * ISNULL(HS_HT_DG,0) * ISNULL(HE_SO_BAC_THO,0) DON_GIA_THUC_TE, CD_DUNG_CHUNG, YEU_CAU_KT, ID_CUM, ID_CHUYEN, ID_DHB, ID_HH, ID_DHBORD, NGAY_LAP " +
                           " FROM " + sTBGrv + "";
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdQT, grvQT, dt, true, false, true, true, true, this.Name);

                    Commons.Modules.ObjSystems.XoaTable(sTBGrv);

                    FormatGrid();
                }
                catch (Exception EX)
                {
                    XtraMessageBox.Show(EX.Message.ToString());
                }
            }
        }

        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "in":
                    {
                        DataTable GroupFooter = new DataTable();
                        try
                        {
                            GroupFooter.Rows.Add("ID_CD", typeof(String));
                            GroupFooter.Rows.Add("TEN_CUM", typeof(String));
                            GroupFooter.Rows.Add("SUM_THOI_GIAN_THIET_KE", typeof(decimal));
                            GroupFooter.Rows.Add("SUM_THOI_GIAN_QUI_DOI", typeof(decimal));
                            GroupFooter.Rows.Add("SUM_DMLD", typeof(decimal));
                            GroupFooter.Rows.Add("SUM_DON_GIA_THUC_TE", typeof(decimal));

                        }
                        catch
                        {
                        }
                        DataTable dt = new DataTable();
                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "rptQuiTrinhCongNgheChiTiet", Commons.Modules.UserName, Commons.Modules.TypeLanguage,
                                                        cboHD.EditValue, cboMH.EditValue, cboOrd.EditValue));
                        frmViewReport frm = new frmViewReport();
                        //var Gp = dt.Rows
                        //    .GroupBy(g => g.Field<String>("TEN_CUM"))
                        //    .Select new
                        //    {
                        //        TEN_TO = X.First().Field<String>("TEN_TO")
                        //    });


                        var Gp = from d in dt.AsEnumerable()
                                 group d by d.Field<String>("TEN_CUM") into g
                                 select new
                                 {
                                     ID_CD = g.First().Field<String>("ID_CD"),
                                     TEN_CUM = g.First().Field<String>("TEN_CUM"),
                                     SUM_THOI_GIAN_THIET_KE = g.Sum(gp => gp.Field<decimal>("THOI_GIAN_THIET_KE")),
                                     SUM_THOI_GIAN_QUI_DOI = g.Sum(gp => gp.Field<decimal>("THOI_GIAN_QUI_DOI")),
                                     SUM_DMLD = g.Sum(gp => gp.Field<decimal>("DMLD")),
                                     SUM_DON_GIA_THUC_TE = g.Sum(gp => gp.Field<decimal>("DON_GIA_THUC_TE")),
                                 };

                        foreach (var x in Gp)
                        {
                            DataRow newRow = GroupFooter.NewRow();

                            newRow.SetField("ID_CD", x.ID_CD);
                            newRow.SetField("TEN_CUM", x.TEN_CUM);
                            newRow.SetField("SUM_THOI_GIAN_THIET_KE", x.SUM_THOI_GIAN_THIET_KE);
                            newRow.SetField("SUM_THOI_GIAN_QUI_DOI", x.SUM_THOI_GIAN_QUI_DOI);
                            newRow.SetField("SUM_DMLD", x.SUM_DMLD);
                            newRow.SetField("SUM_DON_GIA_THUC_TE", x.SUM_DON_GIA_THUC_TE);
                            GroupFooter.Rows.Add(newRow);
                        };

                        //Convert.ToInt64(grvCongNhan.GetFocusedRowCellValue("ID_CN"))
                        //string tieuDe = "QUY TRINH CONG NGHE";

                        //frm.rpt = new rptBCQuyTrinhCongNghe(DateTime.Now, GroupFooter);
                        //if (dt == null || dt.Rows.Count == 0) return;
                        //dt.TableName = "DATA";
                        //GroupFooter.TableName = "CHILD_DATA";

                        //DataSet ds = new DataSet();
                        //ds.Tables.Add(dt);
                        //ds.Tables.Add(GroupFooter);
                        //frm.AddDataSource(ds);
                        //frm.ShowDialog();
                        break;
                    }
                case "xoa":
                    {
                        string sSql = "";
                        try
                        {
                            if (grvQT.RowCount == 0) { Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa); return; }
                            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;

                            sSql = "DELETE QUI_TRINH_CONG_NGHE_CHI_TIET WHERE ID_CHUYEN = '" + grvQT.GetFocusedRowCellValue("ID_CHUYEN") +
                                                                    "' AND ID_ORD = '" + grvQT.GetFocusedRowCellValue("ID_DHBORD") +
                                                                    "' AND ID_CD = '" + grvQT.GetFocusedRowCellValue("ID_CD") + "'";
                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                            grvQT.DeleteSelectedRows();
                        }
                        catch
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
                        }
                        break;
                    }
                case "sua":
                    {
                        if (cboChuyen.Text == "")
                        {
                            Commons.Modules.ObjSystems.msgChung("@ChuaNhapSttChuyen@");
                            return;
                        }
                        if (cboHD.Text == "")
                        {
                            Commons.Modules.ObjSystems.msgChung("@ChuaNhapHopDong@");
                            return;
                        }
                        if (cboMH.Text == "")
                        {
                            Commons.Modules.ObjSystems.msgChung("@ChuaNhapMaHang@");
                            return;
                        }
                        if (cboOrd.Text == "")
                        {
                            Commons.Modules.ObjSystems.msgChung("@ChuaNhapOrder@");
                            return;
                        }
                        GetStt(ref ttCD, ref ttChuyen);
                        isAdd = true;
                        SetButton(isAdd);
                        grvQT.OptionsBehavior.Editable = true;
                        Commons.Modules.ObjSystems.AddnewRow(grvQT, true);
                        grvQT.SetRowCellValue(grvQT.RowCount - 1, "THU_TU_CONG_DOAN", ttCD + 1);
                        grvQT.SetRowCellValue(grvQT.RowCount - 1, "MaQL", ttChuyen + 1 + 1);
                        DataTable dtdgg = new DataTable();
                        try
                        {
                            dtdgg.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT NGAY_QD, HS_DG_GIAY FROM DonGiaGiay WHERE NGAY_QD <= " + Convert.ToDateTime(dNgayLap.EditValue).ToString("yyyy/MM/dd") + " ORDER BY NGAY_QD DESC"));
                            txtDG.Text = dtdgg.Rows[0]["HS_DG_GIAY"].ToString();
                        }
                        catch
                        {
                            dtdgg.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT NGAY_QD, HS_DG_GIAY FROM DonGiaGiay WHERE NGAY_QD >= " + Convert.ToDateTime(dNgayLap.EditValue).ToString("yyyy/MM/dd") + " ORDER BY NGAY_QD ASC"));
                            txtDG.Text = dtdgg.Rows[0]["HS_DG_GIAY"].ToString();
                        }
                        break;
                    }
                case "luu":
                    {
                        isAdd = false;
                        SetButton(isAdd);
                        Validate();
                        if (grvQT.HasColumnErrors) return;
                        Savedata();
                        Commons.Modules.ObjSystems.DeleteAddRow(grvQT);
                        LoadLuoi();
                        LocData();
                        break;
                    }
                case "khongluu":
                    {
                        isAdd = false;
                        Commons.Modules.ObjSystems.DeleteAddRow(grvQT);
                        SetButton(isAdd);
                        LoadLuoi();
                        LocData();
                        grvQT.OptionsBehavior.Editable = false;
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

        private void optHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHD(0);
        }

        private void cboLMH_EditValueChanged(object sender, EventArgs e)
        {
            LoadCboCum(0);
        }

        private void txtDG_Validated(object sender, EventArgs e)
        {
            
        }

        private void grvQT_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                view.SetFocusedRowCellValue("CD_DUNG_CHUNG", 0);
                view.SetFocusedRowCellValue("STT_CHUYEN", cboChuyen.EditValue);
                view.SetFocusedRowCellValue("MS_DDH", cboHD.EditValue);
                view.SetFocusedRowCellValue("MS_MH", cboMH.EditValue);
                view.SetFocusedRowCellValue("ORDER", cboOrd.EditValue);
                view.SetFocusedRowCellValue("THU_TU_CONG_DOAN", ttCD + 1);
                view.SetFocusedRowCellValue("MaQL", ttChuyen + 1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
    }
}