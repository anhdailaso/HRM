using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class frmInQTCT : DevExpress.XtraEditors.XtraForm
    {
        private long idCN;
        private long idCT;

        public frmInQTCT(Int64 idCongNhan, Int64 idCongTac, string tencn)
        {
            InitializeComponent();
            NONN_HoTenCN.Text = tencn.ToUpper();
            idCN = idCongNhan;
            idCT = idCongTac;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
 
        //sự kiên load form
        private void formInQTCT_Load(object sender, EventArgs e)
        {
            rdo_ChonBaoCao.SelectedIndex = 0;
            dNgayIn.EditValue = DateTime.Today;
        }
        //sự kiện các nút xử lí
        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "In":
                    {

                        try
                        {
                            if (rdo_ChonBaoCao.SelectedIndex == 0)
                            {
                                System.Data.SqlClient.SqlConnection conn;
                                DataTable dt = new DataTable();
                                frmViewReport frm = new frmViewReport();
                                frm.rpt = new rptQuyetDinhDieuChuyen(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhDieuChuyen", conn);
                                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idCT;
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
                            else
                            {
                                System.Data.SqlClient.SqlConnection conn;
                                DataTable dt = new DataTable();
                                frmViewReport frm = new frmViewReport();
                                frm.rpt = new rptBCQuaTrinhCongTacCN(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuaTrinhCongTacCN", conn);
                                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
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
                            
                        }
                        catch
                        { }

                        
                        break;
                    }
                case "thoat":
                    {
                        this.Close();
                        break;
                    }
                default:
                    break;
            }
        }

        private void dNgayIn_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tablePanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}