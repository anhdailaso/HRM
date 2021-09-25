using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class frmInLuongCN : DevExpress.XtraEditors.XtraForm
    {
        private long idCN;
        private long idL;

        public frmInLuongCN(Int64 idCongNhan, Int64 idLuong, string tencn)
        {
            InitializeComponent();
            NONN_HoTenCN.Text = tencn.ToUpper();
            idCN = idCongNhan;
            idL= idLuong;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
 
        //sự kiên load form
        private void formInLuongCN_Load(object sender, EventArgs e)
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
                                frm.rpt = new rptQuyetDinhLuongCN(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhLuongCN", conn);
                                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idL;
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
                                frm.rpt = new rptQuaTrinhLuongCN(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuaTrinhLuongCN", conn);
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
        
    }
}