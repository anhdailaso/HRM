using System;
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
using System.Diagnostics;
using Vs.Report;

namespace Vs.TimeAttendance.Form
{
    public partial class frmInKehoachdica : DevExpress.XtraEditors.XtraForm
    {
        public frmInKehoachdica()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this,Root);
        }

        private void frmInKehoachdica_Load(object sender, EventArgs e)
        {
            loadcbm();
            txtTngay.EditValue = Convert.ToDateTime("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year).ToString("dd/MM/yyyy");
            DateTime dtTN = DateTime.Today;
            DateTime dtDN = DateTime.Today;
            txtDngay.EditValue = dtTN.AddDays((-1));
            dtDN = dtDN.AddMonths(1);

        }

        private void loadcbm()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboNhomca", Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboID_nhom, dt, "ID_NHOM", "TEN_NHOM", "Ten_nhom");
                cboID_nhom.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void loadcbm_ca()
        {
            try
            {
                DataTable dt = new DataTable();
                
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboCatheokihoach", cboID_nhom.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));

                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(cboCa, dt, "ID_CDLV", "CA", "Ca_lam");
                cboCa.EditValue = -1;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn;
                DataTable dt = new DataTable();
                frmViewReport frm = new frmViewReport();
                string tieude = "KẾ HOẠCH ĐI CA";
                frm.rpt = new rptKeHoachDiCa(DateTime.Today,txtTngay.DateTime,txtDngay.DateTime,tieude);

                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                conn.Open();

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCKeHoachDiCa", conn);
                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                cmd.Parameters.AddWithValue("Nhom_sx", cboID_nhom.EditValue);
                cmd.Parameters.AddWithValue("CA", cboCa.EditValue);
                cmd.Parameters.AddWithValue("TNGAY", txtTngay.DateTime);
                cmd.Parameters.AddWithValue("DNGAY", txtDngay.DateTime);

                cmd.CommandType = CommandType.StoredProcedure;

                System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                dt = new DataTable();
                dt = ds.Tables[0].Copy();
                dt.TableName = "DA_TA";
                frm.AddDataSource(dt);
                frm.ShowDialog();

            }
            catch
            { }
        }

        private void cboID_nhom_EditValueChanged(object sender, EventArgs e)
        {
            loadcbm_ca();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}