﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;

namespace Vs.Payroll
{
    public partial class frmPCDHDMHChot : DevExpress.XtraEditors.XtraForm
    {
        
        public DateTime dThang = Convert.ToDateTime("2014-02-01");
        public frmPCDHDMHChot()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void frmPCDHDMHChot_Load(object sender, EventArgs e)
        {
            lblTD.Text = lblTD.Text + dThang.ToString("MM/yyyy");
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "	SELECT DISTINCT	 [CHUYEN].[ID_CHUYEN], [CHUYEN].[TEN_CHUYEN] FROM dbo.CHUYEN	UNION SELECT	'-1',  ' < ALL > ' ORDER BY [TEN_CHUYEN]"));

            Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboChuTH, dt, "ID_CHUYEN", "TEN_CHUYEN", "TEN_CHUYEN");

            LoadLuoi();

            LoadHD(0);


            Commons.Modules.sPS = "";
        }
        private void LoadLuoi()
        {
            Commons.Modules.sPS = "0Load" ;
            String  sChuSD, sDDH, sMH, sOrd, sChuTH;
            sChuSD = "-1"; sDDH = "-1"; sMH = "-1"; sOrd = "-1"; sChuTH = "-1"; 

            try{sChuSD = cboChuSD.EditValue.ToString();}catch { }
            try{sChuTH = cboChuTH.EditValue.ToString();}catch { }
            try{sDDH = cboHD.EditValue.ToString();}catch { }
            try{sMH = cboMH.EditValue.ToString();}catch { }
            try{sOrd = cboOrd.EditValue.ToString();}catch { }
            
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spPCDChotGet", optHT.SelectedIndex, sOrd, sChuTH, sChuSD, dThang));
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                dt.Columns[i].ReadOnly = true;
            }
            dt.Columns["ID_CHUYEN"].ReadOnly = false;
            dt.Columns["SL_CHOT"].ReadOnly = false;

            Commons.Modules.ObjSystems.MLoadXtraGrid(grdHD, grvHD, dt, true, false, true, true, true, this.Name);
            Commons.Modules.ObjSystems.AddCombXtra("ID_CHUYEN", "TEN_CHUYEN", grvHD, ((DataTable)cboChuTH.Properties.DataSource).Copy());
            grvHD.Columns["ID_CHUYEN_SD"].Visible = false;
            grvHD.Columns["ID_DHBORD"].Visible = false;
            grvHD.Columns["SL_CHOT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grvHD.Columns["SL_CHOT"].DisplayFormat.FormatString = Commons.Modules.sSoLeSL;
            

        }

        private void cboHD_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void LoadHD(int iLoad)
        {
            Commons.Modules.sPS = "0LoadCbo";
            String sChuSD, sDDH, sMH, sOrd;
            sChuSD = "-1"; sDDH = "-1"; sMH = "-1"; sOrd = "-1"; 

            try { sChuSD = cboChuSD.EditValue.ToString(); } catch { }
            try { sDDH = cboHD.EditValue.ToString(); } catch { }
            try { sMH = cboMH.EditValue.ToString(); } catch { }
            try { sOrd = cboOrd.EditValue.ToString(); } catch { }

            System.Data.SqlClient.SqlConnection conn;
            DataTable dt = new DataTable();

            try
            {
                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("spPCDChotGetCbo", conn);
                
                cmd.Parameters.Add("@HoanThanh", SqlDbType.Int).Value = optHT.SelectedIndex;
                cmd.Parameters.Add("@sDDH", SqlDbType.NVarChar, 50).Value = sDDH;
                cmd.Parameters.Add("@sMH", SqlDbType.NVarChar, 50).Value = sMH;
                cmd.Parameters.Add("@sOrd", SqlDbType.NVarChar, 50).Value = sOrd;
                cmd.Parameters.Add("@sChuSD", SqlDbType.NVarChar, 50).Value = sChuSD;
                cmd.Parameters.Add("@dThang", SqlDbType.DateTime, 50).Value = dThang;

                cmd.CommandType = CommandType.StoredProcedure;
                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);

                
                dt = new DataTable();
                dt = ds.Tables[0].Copy();
                dt.TableName = "HOP_DONG";
                if (iLoad == 0 ) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboHD, dt, "ID_DHB", "SO_DHB", "SO_DHB");
                

                dt = new DataTable();
                dt = ds.Tables[1].Copy();
                dt.TableName = "MA_HANG";
                if (iLoad == 0 || iLoad ==1 ) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboMH, dt, "ID_HH", "TEN_HH", "TEN_HH");


                DataTable dt1 = new DataTable();
                dt1 = ds.Tables[2].Copy();
                dt1.TableName = "TEN_ORDER";
                if (iLoad == 0 || iLoad == 1 || iLoad == 2 ) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboOrd, dt1, "ID_DHBORD", "ORDER_NUMBER", "ORDER_NUMBER");

                

                dt = new DataTable();
                dt = ds.Tables[3].Copy();
                dt.TableName = "CHUYEN_SD";
                if (iLoad == 0 || iLoad == 1 || iLoad == 2 || iLoad == 3) Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboChuSD, dt, "ID_CHUYEN_SD", "CHUYEN_SD", "CHUYEN_SD");
                


            }
            catch
            { }
            
        }

        private void optHT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadLuoi();
            LoadHD(0);
            Commons.Modules.sPS = "";
            LocData();
        }

        private void cboHD_EditValueChanged_1(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(1);
            Commons.Modules.sPS = "";
            LocData();
        }

        private void cboMH_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(2);
            Commons.Modules.sPS = "";
            LocData();
        }

        private void cboOrd_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(3);
            Commons.Modules.sPS = "";
            LocData();
        }

        private void cboChuSD_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            LoadHD(4);
            Commons.Modules.sPS = "";
            LocData();
        }
        
        private void LocData()
        {
            if (Commons.Modules.sPS == "0LoadCbo") return;
            DataTable dtTmp = new DataTable();
            try
            {
                dtTmp = (DataTable)grdHD.DataSource;
                String sChuTH, sDDH, sMH, sOrd, sChuSD;
                string sDK = " 1 = 1 ";
                sChuTH = "-1"; sDDH = "-1"; sMH = "-1"; sOrd = "-1"; sChuSD = "-1";
                try { sChuSD = cboChuSD.EditValue.ToString(); } catch { }
                try { sChuTH = cboChuTH.EditValue.ToString(); } catch { }
                try { sDDH = cboHD.EditValue.ToString(); } catch { }
                try { sMH = cboMH.EditValue.ToString(); } catch { }
                try { sOrd = cboOrd.EditValue.ToString(); } catch { }

                if (sDDH != "-1") sDK = sDK + " AND ID_DHB = '" + sDDH + "' ";
                if (sMH != "-1") sDK = sDK + " AND ID_HH = '" + sMH + "' ";
                if (sOrd != "-1") sDK = sDK + " AND ID_DHBORD = '" + sOrd + "' ";
                if (sChuSD != "-1") sDK = sDK + " AND ID_CHUYEN_SD = '" + sChuSD + "' ";
                if (sChuTH != "-1") sDK = sDK + " AND ID_CHUYEN = N'" + sChuTH + "' ";
                
                dtTmp.DefaultView.RowFilter = sDK;
            }
            catch { dtTmp.DefaultView.RowFilter = ""; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHD.EditValue.ToString() == "-1" || string.IsNullOrEmpty(cboChuTH.Text)) { XtraMessageBox.Show("Bạn chưa chọn hợp đồng. Vui lòng kiểm tra lại"); cboHD.Focus(); return; }
                if (cboMH.EditValue.ToString() == "-1" || string.IsNullOrEmpty(cboMH.Text)) { XtraMessageBox.Show("Bạn chưa chọn mã hàng. Vui lòng kiểm tra lại"); cboMH.Focus(); return; }
                if (cboOrd.EditValue.ToString() == "-1" || string.IsNullOrEmpty(cboOrd.Text)) { XtraMessageBox.Show("Bạn chưa chọn order. Vui lòng kiểm tra lại"); cboOrd.Focus(); return; }
                if (cboChuSD.EditValue.ToString() == "-1" || string.IsNullOrEmpty(cboChuSD.Text)) { XtraMessageBox.Show("Bạn chưa chọn chuyền sữ dụng QTCN. Vui lòng kiểm tra lại"); cboChuSD.Focus(); return; }
                if (cboChuTH.EditValue.ToString() == "-1" || string.IsNullOrEmpty(cboChuTH.Text)) { XtraMessageBox.Show("Bạn chưa chọn chuyền thực hiện. Vui lòng kiểm tra lại"); cboChuTH.Focus(); return; }

                String sChuTH, sDDH, sMH, sOrd, sChuSD;
                sChuTH = "-1"; sDDH = "-1"; sMH = "-1"; sOrd = "-1"; sChuSD = "-1";

                try { sDDH = cboHD.EditValue.ToString(); } catch { }
                try { sMH = cboMH.EditValue.ToString(); } catch { }
                try { sOrd = cboOrd.EditValue.ToString(); } catch { }
                try { sChuSD = cboChuSD.EditValue.ToString(); } catch { }
                try { sChuTH = cboChuTH.EditValue.ToString(); } catch { }

                String sSql = "SELECT ISNULL(SUM(T1.SO_LUONG - ISNULL(T1.SL_GIAM, 0)), 0) AS TSL FROM dbo.CHI_TIET_ORDER AS T1 WHERE (MS_DDH = N'" + sDDH + "') AND (MS_MH = N'" + sMH + "') AND ([ORDER] = N'" + sOrd + "')";

                double SLDH = 0;
                double SLDaChot = 0;
                double SLCHOT = 0;

                try { SLDH = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)); } catch { }
                sSql = "SELECT ISNULL(SUM(SL_CHOT),0) FROM PHIEU_CONG_DOAN_CHOT_THANG  WHERE (MS_DDH = N'" + sDDH + "') AND (MS_MH = N'" + sMH + "') AND ([ORDER] = N'" + sOrd + "')";

                try { SLDaChot = Convert.ToDouble(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, CommandType.Text, sSql)); } catch { }

                if ((SLDH - SLDaChot) > 0)
                {
                    SLCHOT = SLDH - SLDaChot;
                }
                else { XtraMessageBox.Show("Order này đã được phân bổ hết cho các chuyền.\n Vui lòng chọn Order khác"); return; }

                sSql = "INSERT INTO PHIEU_CONG_DOAN_CHOT_THANG (THANG, STT_CHUYEN, MS_DDH, MS_MH, [ORDER], CHUYEN_SD, SL_CHOT, BU_THANG_TRUOC, PHAT_SINH_CD_BB, CHON)  SELECT '" + dThang.ToString("MM/dd/yyyy") + "',  '" + sChuSD + "', '" + sDDH + "', '" + sMH + "', '" + sOrd + "', '" + sChuTH + "', " + SLCHOT + ", 0, 0, 0";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            }
            catch { }

            try { optHT_SelectedIndexChanged(null, null); } catch { }
        }

        private void cboChuTH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            
            DataTable dtTmp = new DataTable();
            grvHD.PostEditor();
            grvHD.UpdateCurrentRow();
            try {
                dtTmp = (DataTable)grdHD.DataSource;
                DataTable dt = dtTmp.GetChanges();
                string sBTCD = "CDChotTmp" + Commons.Modules.UserName;
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sBTCD, dtTmp, "");

                string sSql = "UPDATE T1 SET SL_CHOT = T2.SL_CHOT, ID_CHUYEN= T2.ID_CHUYEN FROM PHIEU_CONG_DOAN_CHOT_THANG T1 INNER JOIN "+sBTCD+" T2 ON T1.ID_ORD = T2.ID_DHBORD AND T1.ID_CHUYEN_SD = T2.ID_CHUYEN_SD";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);

            } catch (Exception ex)
            {
            }
            this.Close();
        }

        private void grvHD_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            grdHD.FocusedView.PostEditor();
            grdHD.FocusedView.UpdateCurrentRow();
            grvHD.UpdateCurrentRow();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string sSql = "UPDATE PHIEU_CONG_DOAN_CHOT SET PHIEU_CONG_DOAN_CHOT.CHON = 1 WHERE THANG = '" + dThang.ToString("MM/dd/yyyy") + "' ";
            //SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
            //For i As Integer = 0 To gvPhone.RowCount - 1
            //    gvPhone.SetRowCellValue(i, gcPrimary, False)
            //Next

            for (int i = 0; i <= grvHD.RowCount - 1; i++)
            {
                grvHD.SetRowCellValue(i, "CHON", 1);
            }

        }

        private void btnKChon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= grvHD.RowCount - 1; i++)
            {
                grvHD.SetRowCellValue(i, "CHON",0);
            }
        }
    }
}