using System;
using System.Data;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraBars.Docking2010;

namespace Vs.Payroll
{
    public partial class frmPhieuCongDoan : DevExpress.XtraEditors.XtraUserControl
    {
        //string sCnstr = "Server=192.168.2.5;database=DATA_MT;uid=sa;pwd=123;Connect Timeout=0;";
        public frmPhieuCongDoan()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this,windowsUIButton);
            optXCLP.SelectedIndex = 0;
        }
        string sBT = "PCDTmp" + Commons.Modules.UserName;
        DataTable dtMQL = new DataTable();

        private void frmPhieuCongDoan_Load(object sender, EventArgs e)
        {
            chkKT.Visible = false;
            Commons.Modules.sPS = "0Load";

            RepositoryItemLookUpEdit cboMQL = new RepositoryItemLookUpEdit();
            dtMQL.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT T1.MaQL, T1.TEN_CD_QT AS TEN_CD FROM QUI_TRINH_CONG_NGHE_CHI_TIET T1 LEFT JOIN PHIEU_CONG_DOAN T2 ON T1.ID_CD = T2.ID_CD"));
            cboMQL.NullText = "";
            cboMQL.ValueMember = "MaQL";
            cboMQL.DisplayMember = "TEN_CD";
            cboMQL.DataSource = dtMQL;
            cboMQL.Columns.Clear();
            TSua(false);

            cboMQL.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaQL"));
            cboMQL.Columns["MaQL"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "MaQL");

            cboMQL.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_CD"));
            cboMQL.Columns["TEN_CD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "TEN_CD");

            cboMQL.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cboMQL.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            try
            {
                Commons.Modules.sPS = "0Load";
                Commons.Modules.ObjSystems.LoadCboDonVi(cboDV);
                Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
                Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
                Commons.Modules.sPS = "";
                LoadChuyen();
                LoadThang();
                LoadPCD();
                LoadCN();
                LoadCD();
                grvTo_FocusedRowChanged(null, null);
                grvCD.Columns["TEN_CD"].ColumnEdit = cboMQL;
                cboMQL.EditValueChanged += CboMQL_EditValueChanged;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBT, (DataTable)grdCD.DataSource, "");  //20213103 phong add
            }
            catch { }
        }
        private void CboMQL_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;

            //string id = lookUp.get;

            // Access the currently selected data row
            DataRowView dataRow = lookUp.GetSelectedDataRow() as DataRowView;

            try
            {
                grvCD.SetFocusedRowCellValue("TEN_CD", dataRow.Row["MaQL"]);
                grvCD.SetFocusedRowCellValue("MaQL", dataRow.Row["MaQL"]);
                grvCD.SetFocusedRowCellValue("ID_CN", grvTo.GetFocusedRowCellValue("ID_CN"));
            }
            catch
            {
                //string sSql = "SELECT DISTINCT T1.MaQL, T1.TEN_CD_QT AS TEN_CD FROM QUI_TRINH_CONG_NGHE_CHI_TIET T1 INNER JOIN PHIEU_CONG_DOAN T2 ON T1.ID_CD = T2.ID_CD";
                //DataTable dt = new DataTable();
                //dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                //grvCD.SetFocusedRowCellValue("TEN_CD", );
            }
            //grvLamThem.SetFocusedRowCellValue("PHUT_BD", dataRow.Row["PHUT_BD"]);
            //grvLamThem.SetFocusedRowCellValue("PHUT_KT", dataRow.Row["PHUT_KT"]);
        }
        public void XoaTable(string strTableName)
        {
            try
            {
                string strSql = "DROP TABLE " + strTableName;
                SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, strSql);
            }
            catch
            {
            }
        }
        private void LoadChuyen()
        {
            try
            {
                string sSql = "SELECT ID_CHUYEN, TEN_CHUYEN FROM CHUYEN UNION SELECT '-1', ' < ALL > ' FROM CHUYEN ORDER BY CHUYEN.TEN_CHUYEN";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboChuyen, dt, "ID_CHUYEN", "TEN_CHUYEN", "TEN_CHUYEN");
                searchLookUpEdit1View.Columns[0].Caption = "STT Chuyền";
                searchLookUpEdit1View.Columns[1].Caption = "Tên Chuyền";
                searchLookUpEdit1View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                searchLookUpEdit1View.Columns[1].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                searchLookUpEdit1View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                searchLookUpEdit1View.Columns[0].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            }
            catch { }
        }
        private void LoadThang()
        {

            try
            {
                if (Commons.Modules.sPS == "0Load") return;
                Commons.Modules.sPS = "0LoadTo";
                string sSql = "SELECT DISTINCT CONVERT(NVARCHAR(10),[NGAY],103) AS NGAY_THANG,[NGAY] FROM PHIEU_CONG_DOAN ORDER BY [NGAY] DESC";
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNgay, grvNgay, dt, false, false, true, true, true, this.Name);


                grvNgay.Columns["NGAY"].Visible = false;

                cboNgay.EditValue = grvNgay.GetFocusedRowCellValue("NGAY_THANG").ToString();
            }
            catch
            {
                cboNgay.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            }
            Commons.Modules.sPS = "";
        }


        private void optXCLP_SelectedIndexChanged(object sender, EventArgs e)
        {

            btnTSua.Enabled = true;
            if (optXCLP.SelectedIndex == 1)
            {
                //cboNgay.Enabled = false;
                //cboNgay.Enabled = false;
                cboNgay_EditValueChanged_1(null, null);
            }
            else
            {
                //cboNgay.Enabled = true;
                //cboNgay.Enabled = true;
                //btnTSua.Enabled = false;
                LoadPCD();
                LoadCD();
                LoadCN();
                cboNgay_EditValueChanged_1(null, null);
            }
            LoadThang();

        }

        private void LoadPCD()
        {

            Commons.Modules.sPS = "0LoadCN";
            try
            {
                DateTime dtNgay;
                try
                {
                    dtNgay = Convert.ToDateTime(cboNgay.EditValue.ToString());
                }
                catch { dtNgay = DateTime.Now; }
                //optXCLP.SelectedIndex = 0  XEM CU
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spPCDHDMH", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, Commons.Modules.UserName,
                        Commons.Modules.TypeLanguage, optXCLP.SelectedIndex, cboChuyen.EditValue, cboNgay.EditValue));


                dt.PrimaryKey = new DataColumn[] { dt.Columns["KHOALST"] };
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdPCD, grvPCD, dt, false, false, true, true, true, this.Name);

                for (int i = 0; i <= 3; i++)
                {
                    grvPCD.Columns[i].Visible = false;
                }
                for (int i = 0; i < grvPCD.Columns.Count; i++)
                {
                    grvPCD.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
                }
                grvPCD.Columns["SL_CHOT"].DisplayFormat.FormatType = FormatType.Numeric;
                grvPCD.Columns["SL_CHOT"].DisplayFormat.FormatString = "N0";


            }
            catch { }
            Commons.Modules.sPS = "";
        }
        private void LoadCD()
        {

            if (Commons.Modules.sPS == "0Load") return;
            if (Commons.Modules.sPS == "0LoadTo") return;
            if (Commons.Modules.sPS == "0LoadCD") return;
            try
            {
                String sOrd, sCNhan;

                sOrd = ""; sCNhan = "";

                try
                {
                    sCNhan = grvTo.GetFocusedRowCellValue("ID_CN").ToString();
                    sOrd = grvPCD.GetFocusedRowCellValue("ID_ORD").ToString();

                }
                catch
                {
                    sOrd = "1";
                }

                DateTime dtNgay;
                try
                {
                    dtNgay = Convert.ToDateTime(cboNgay.EditValue.ToString());
                }
                catch { dtNgay = DateTime.Now; }


                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spPCDGetCDoan", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, Commons.Modules.UserName,
                        Commons.Modules.TypeLanguage, cboChuyen.EditValue, sOrd, dtNgay.ToString("yyyyMMdd")));

                //if (btnGhi.Visible)
                //{
                //    string sBTCD = "CDTmp" + Commons.Modules.UserName;
                //    XoaTable(sBTCD);
                //    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTCD, dt, "");
                //    string sSql = "INSERT INTO " + sBT + " (MS_CD,TEN_CD,SO_LUONG,STT_CHUYEN,CHUYEN_SD,MS_DDH,MS_MH,[ORDER],NGAY,MS_CN,MAQL,THU_TU_CONG_DOAN)SELECT MS_CD,TEN_CD,SO_LUONG,STT_CHUYEN,CHUYEN_SD,MS_DDH,MS_MH,[ORDER],NGAY,MS_CN,MAQL,THU_TU_CONG_DOAN FROM " + sBTCD + " T1 WHERE NOT EXISTS (SELECT * FROM PCDTmpadmin T2 WHERE T1.MS_DDH = T2.MS_DDH AND T1.MS_MH = T2.MS_MH AND T1.[ORDER] = T2.[ORDER] AND T1.NGAY = T2.NGAY) ORDER BY THU_TU_CONG_DOAN";
                //    SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

                //    //sSql = "SELECT DISTINCT MS_CD,TEN_CD, SO_LUONG, STT_CHUYEN, CHUYEN_SD, MS_DDH, MS_MH, [ORDER], NGAY, MS_CN, MaQL, THU_TU_CONG_DOAN FROM " + sBT + " WHERE (MS_DDH = '" + sDDH + "') AND (MS_MH = '" + sMH + "') AND ([ORDER] = '" + sOrd + "') AND (MS_CN = '" + sCNhan + "') AND (NGAY = '" + dtNgay.ToString("MM/dd/yyyy") + "' )  ORDER BY THU_TU_CONG_DOAN";
                //    dt = new DataTable();
                //    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                //    dt.Columns[0].ReadOnly = true;
                //    dt.Columns[1].ReadOnly = true;
                //    dt.Columns[2].ReadOnly = false;
                //    XoaTable(sBTCD);
                //}
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCD, grvCD, dt, windowsUIButton.Buttons[3].Properties.Visible, false, false, true, true, this.Name);
                grvCD.Columns["ID_CN"].Visible = false;

                grvCD.Columns["TEN_CD"].Width = 900;
                for (int i = 0; i < grvCD.Columns.Count; i++)
                {
                    grvCD.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
                }
            }
            catch (Exception EX)
            { }

        }

        private void LoadCN()
        {
            if (Commons.Modules.sPS == "0Load") return;
            if (Commons.Modules.sPS == "0LoadTo") return;
            if (Commons.Modules.sPS == "0LoadCN") return;

            try
            {
                String sChu, sChuyen, sOrd;

                if (grvPCD.RowCount == 0)
                { sChu = "-1"; sChuyen = "-1"; sOrd = "-1"; }
                else
                {
                    sChu = cboChuyen.EditValue.ToString();
                    sChuyen = grvPCD.GetFocusedRowCellValue("ID_CHUYEN").ToString();
                    sOrd = grvPCD.GetFocusedRowCellValue("ID_ORD").ToString();
                }
                DateTime dtNgay;
                try
                {
                    dtNgay = Convert.ToDateTime(cboNgay.EditValue);
                }
                catch
                {
                    dtNgay = DateTime.Now;
                }

                //optXCLP.SelectedIndex = 0  XEM CU

                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spPCDGetCNhan", cboDV.EditValue, cboXN.EditValue, cboTo.EditValue, Commons.Modules.UserName,
                        Commons.Modules.TypeLanguage, optXCLP.SelectedIndex, sChuyen, sOrd, dtNgay.ToString("yyyyMMdd")));
                //Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboCN, dt, "MS_CN", "LMS", "LMS");
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTo, grvTo, dt, false, false, true, true, true, this.Name);
                grvTo.Columns["LMS"].Visible = false;
                grvTo.Columns["ID_CN"].Visible = false;
                for (int i = 0; i < grvTo.Columns.Count; i++)
                {
                    grvTo.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(200, 200, 200);
                }
            }
            catch (Exception e) { }
        }


        private void cboChuyen_EditValueChanged(object sender, EventArgs e)
        {
            cboNgay_EditValueChanged_1(null, null);
        }

        private void grvPCD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            grvCD.UpdateCurrentRow();
            Commons.Modules.sPS = "0LoadCD";
            if (!windowsUIButton.Buttons[3].Properties.Visible) LoadCN();
            Commons.Modules.sPS = "";
            LoadCD();
        }

        private void grvTo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //LoadgrdNgungDongBHXH();
            if (Commons.Modules.sPS == "0Load") return;
            DataTable dtTmp = new DataTable();
            String sIDCN;
            try
            {
                dtTmp = (DataTable)grdCD.DataSource;

                string sDK = "";
                sIDCN = "-1";
                try { sIDCN = grvTo.GetFocusedRowCellValue("ID_CN").ToString(); } catch { }
                if (sIDCN != "-1") sDK = " ID_CN = '" + sIDCN + "' ";

                dtTmp.DefaultView.RowFilter = sDK;
              
            }
            catch { }
        }
        private void btnKhong_Click(object sender, EventArgs e)
        {
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.GotoHome(this);
        }
        private void btnTSua_Click(object sender, EventArgs e)
        {
            
           
        }


        private void TSua(Boolean TSua)
        {
            //btnGhi.Visible = TSua;
            //btnKhong.Visible = TSua;
            //btnTSua.Visible = !TSua;
            //btnThoat.Visible = !TSua;
            //btnMH.Visible = !TSua;

            windowsUIButton.Buttons[0].Properties.Visible = !TSua;
            windowsUIButton.Buttons[1].Properties.Visible = !TSua;
            windowsUIButton.Buttons[2].Properties.Visible = !TSua;
            windowsUIButton.Buttons[5].Properties.Visible = !TSua;

            windowsUIButton.Buttons[3].Properties.Visible = TSua;
            windowsUIButton.Buttons[4].Properties.Visible = TSua;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            

        }

        private void btnChonCD_Click(object sender, EventArgs e)
        {
            //LoadThemCD();
        }
        //private void LoadThemCD()
        //{

        //    if (Commons.Modules.sPS == "0Load") return;
        //    if (Commons.Modules.sPS == "0LoadTo") return;
        //    if (Commons.Modules.sPS == "0LoadCD") return;
        //    try
        //    {
        //        String sSql, sChu, sDDH, sMH, sOrd,sChSD;
        //        string sCN;
        //         sChu = ""; sDDH = ""; sMH = ""; sOrd = ""; sChSD = "";sCN = "";
        //        try
        //        {
        //            sChu = cboChuyen.EditValue.ToString();
        //            sDDH = grvPCD.GetFocusedRowCellValue("MS_DDH").ToString();
        //            sMH = grvPCD.GetFocusedRowCellValue("MS_MH").ToString();
        //            sOrd = grvPCD.GetFocusedRowCellValue("ORDER").ToString();
        //            sChSD = grvPCD.GetFocusedRowCellValue("CHUYEN_SD").ToString();
        //            sCN = grvTo.GetFocusedRowCellValue("MS_CN").ToString();
        //        }
        //        catch { }



        //        DataTable dt = new DataTable();
        //        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spPCDGetThemCDoan", sChu, sDDH, sMH, sOrd,sBT));
        //        dt.Columns[0].ReadOnly = false;
        //        dt.Columns[1].ReadOnly = true;
        //        dt.Columns[2].ReadOnly = true;
        //        dt.Columns[3].ReadOnly = true;

        //        frmPCDChonCD fr = new frmPCDChonCD();
        //        fr.dtPCD = dt;

        //        if (fr.ShowDialog() != DialogResult.OK) return;
        //        string sBTCD = "CDTmp" + Commons.Modules.UserName;
        //        try
        //        {
        //            sSql = "DROP TABLE " + sBTCD;
        //            SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql);
        //        }
        //        catch { }
        //        XoaTable(sBTCD);
        //        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTCD, dt, "");
        //        DateTime dtNgay;
        //        try
        //        {
        //            dtNgay = Convert.ToDateTime(cboNgay.EditValue.ToString());
        //        }
        //        catch { dtNgay = DateTime.Now; }
        //        string sCNhan = "";
        //        sCNhan = grvTo.GetFocusedRowCellValue("MS_CN").ToString();

        //        sSql = "INSERT INTO " + sBT + " (MS_CD,TEN_CD,SO_LUONG,STT_CHUYEN,CHUYEN_SD,MS_DDH,MS_MH,[ORDER],NGAY,MS_CN,MAQL,THU_TU_CONG_DOAN)SELECT MS_CD,TEN_CD, CONVERT(FLOAT,0)  AS SO_LUONG,STT_CHUYEN,N'" + sChSD + "' AS CHUYEN_SD,MS_DDH,MS_MH,[ORDER], '" + dtNgay.ToString("MM/dd/yyyy") + "'  NGAY, '" + sCN + "' AS MS_CN,MAQL,THU_TU_CONG_DOAN FROM " + sBTCD + " WHERE CHON = 1 ORDER BY THU_TU_CONG_DOAN";
        //        SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

        //        sSql = "SELECT DISTINCT MS_CD,TEN_CD, SO_LUONG, STT_CHUYEN, CHUYEN_SD, MS_DDH, MS_MH, [ORDER], NGAY, MS_CN, MaQL, THU_TU_CONG_DOAN FROM " + sBT + " WHERE (MS_DDH = '" + sDDH + "') AND (MS_MH = '" + sMH + "') AND ([ORDER] = '" + sOrd + "') AND (MS_CN = '" + sCNhan + "') AND (NGAY = '" + dtNgay.ToString("MM/dd/yyyy") + "' )  ORDER BY THU_TU_CONG_DOAN";
        //        dt = new DataTable();
        //        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));

        //        dt.Columns[0].ReadOnly = true;
        //        dt.Columns[1].ReadOnly = true;
        //        dt.Columns[2].ReadOnly = false;

        //        Commons.Modules.ObjSystems.MLoadXtraGrid(grdCD, grvCD, dt, true, false, true, true, true, this.Name);
        //        XoaTable(sBTCD);
        //    }
        //    catch 
        //    { }
        //}

        private void btnMH_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboNgay.Text))
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày");
                return;
            }
            frmPCDHDMHChot frm = new frmPCDHDMHChot();
            DateTime dThang = Convert.ToDateTime(cboNgay.EditValue);

            frm.dThang = Convert.ToDateTime("01/" + dThang.Month + "/" + dThang.Year);
            frm.ShowDialog();
        }

        private void cboTo_EditValueChanged_1(object sender, EventArgs e)
        {

            LoadCN();
            LoadCD();
        }

        private void cboDV_EditValueChanged_1(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
        }

        private void cboXN_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
        }

        private void cboNgay_BeforePopup(object sender, EventArgs e)
        {
            popupContainerControl1.Height = 300;
            popupContainerControl1.Width = 300;

            popupContainerControl2.Width = 300;
            popupContainerControl2.Height = 200;
            grdNgay.Height = 200;
            grdNgay.Width = 300;
        }

        private void grvNgay_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                GridView grv = (GridView)sender;
                cboNgay.Text = grvNgay.GetFocusedRowCellValue("NGAY_THANG").ToString();
            }
            catch { }
            cboNgay.ClosePopup();
        }

        private void calendarControl1_DateTimeCommit(object sender, EventArgs e)
        {
            try
            {
                cboNgay.Text = calendarControl1.DateTime.ToString("dd/MM/yyyy");
                DataTable dtTmp = Commons.Modules.ObjSystems.ConvertDatatable(grdNgay);
                DataRow[] dr;
                dr = dtTmp.Select("NGAY_TTXL" + "='" + cboNgay.Text + "'", "NGAY_TTXL", DataViewRowState.CurrentRows);
                if (dr.Count() == 1)
                {
                }
                else { }
            }
            catch (Exception ex)
            {
                cboNgay.Text = calendarControl1.DateTime.ToString("dd/MM/yyyy");
            }
            cboNgay.ClosePopup();
        }

        private void cboNgay_EditValueChanged_1(object sender, EventArgs e)
        {
            LoadPCD();
            LoadCD();
            LoadCN();
            grvTo_FocusedRowChanged(null, null);
        }


        private void grvPCD_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void grvCD_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            grvCD.ClearColumnErrors();
            GridView view = sender as GridView;
            String sIDCN;

            if (view.FocusedColumn.FieldName == "MaQL")
            {
                //kiểm tra tồn tại trong combo
                if (dtMQL.AsEnumerable().Count(x => x["MaQL"].ToString().Equals(e.Value.ToString())) == 0)
                {
                    e.Valid = false;
                    e.ErrorText = "ton tai";
                    view.SetColumnError(view.Columns["MaQL"], e.ErrorText);
                    return;
                }
                //kiểm tra không trùng trên lưới
                if (Commons.Modules.ObjSystems.ConvertDatatable(grdCD).AsEnumerable().Where(x=> x["ID_CN"].ToString().Trim().Equals(grvTo.GetFocusedRowCellValue("ID_CN").ToString().Trim())).Count(x => x["MaQL"].ToString().Trim().Equals(e.Value.ToString().Trim())) >= 1)
                {
                    e.Valid = false;
                    e.ErrorText = "trung";
                    view.SetColumnError(view.Columns["MaQL"], e.ErrorText);
                    return;
                }
                grvCD.SetFocusedRowCellValue("TEN_CD", e.Value);
                grvCD.SetFocusedRowCellValue("MaQL", e.Value);
                grvCD.SetFocusedRowCellValue("ID_CN", grvTo.GetFocusedRowCellValue("ID_CN"));
            }
        }

        private void grvCD_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvCD_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
               
                case "ChonMH":
                    {
                        if (string.IsNullOrEmpty(cboNgay.Text))
                        {
                            XtraMessageBox.Show("Bạn chưa chọn ngày");
                            return;
                        }
                        frmPCDHDMHChot frm = new frmPCDHDMHChot();
                        DateTime dThang = Convert.ToDateTime(cboNgay.EditValue);

                        frm.dThang = Convert.ToDateTime("01/" + dThang.Month + "/" + dThang.Year);
                        frm.ShowDialog();
                        break;
                    }
                case "sua":
                    {
                        Commons.Modules.ObjSystems.AddnewRow(grvCD, true);
                        TSua(true);
                        break;
                    }
                case "luu":
                    {
                        string stbCongNhan = "BTPCD" + Commons.Modules.UserName;
                        DateTime ngay = Convert.ToDateTime(cboNgay.EditValue);
                        try
                        {
                            Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, stbCongNhan, (DataTable)grdCD.DataSource, "");

                            SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSavePhieuCongDoan", stbCongNhan, grvPCD.GetFocusedRowCellValue("ID_CHUYEN"), grvPCD.GetFocusedRowCellValue("ID_CHUYEN_SD"), grvPCD.GetFocusedRowCellValue("ID_ORD"), ngay.ToString("yyyyMMdd"));
                            Commons.Modules.ObjSystems.XoaTable(stbCongNhan);

                        }
                        catch (Exception ex) { }
                        TSua(false);
                        LoadCD();
                        LoadCN();
                        grvTo_FocusedRowChanged(null, null);
                        break;
                    }
                case "khongluu":
                    {
                        TSua(false);
                        Commons.Modules.ObjSystems.DeleteAddRow(grvCD);
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