using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class frmInHopDongCN : DevExpress.XtraEditors.XtraForm
    {
        private long idCN;
        private long idHD;

        public frmInHopDongCN(Int64 idCongNhan, Int64 idHopDong, string tencn)
        {
            InitializeComponent();
            NONN_HoTenCN.Text = tencn.ToUpper();
            idCN = idCongNhan;
            idHD = idHopDong;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        //sự kiên load form
        private void formInHopDongCN_Load(object sender, EventArgs e)
        {
            rdo_ChonBaoCao.SelectedIndex = 0;
            dNgayIn.EditValue = DateTime.Today;
            Commons.OSystems.SetDateEditFormat(dNgayIn);
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
                        DataTable dt = new DataTable();
                        DataTable dtbc = new DataTable();
                        switch (rdo_ChonBaoCao.SelectedIndex)
                        {
                            case 0:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    dt = new DataTable();
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptHopDongLaoDong_MT(dNgayIn.DateTime);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptHopDongLaoDong", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idHD;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    dtbc = new DataTable();
                                    dtbc = ds.Tables[1].Copy();
                                    dtbc.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dtbc);

                                    frm.ShowDialog();
                                }
                                break;
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn1;
                                    dt = new DataTable();
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptHopDongThuViec_CDDH(dNgayIn.DateTime);

                                    conn1 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn1.Open();

                                    System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand("rptHopDongThuViec_MT", conn1);
                                    cmd1.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd1.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd1.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                    cmd1.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idHD;
                                    cmd1.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd1);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    dtbc = new DataTable();
                                    dtbc = ds.Tables[1].Copy();
                                    dtbc.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dtbc);

                                    frm.ShowDialog();
                                }
                                break;
                            case 2:
                                {
                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptHopDongThuViec_CNQC(dNgayIn.DateTime);

                                    conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn2.Open();

                                    System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand("rptHopDongThuViec_MT", conn2);
                                    cmd1.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd1.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd1.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                    cmd1.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idHD;
                                    cmd1.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd1);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    dtbc = new DataTable();
                                    dtbc = ds.Tables[1].Copy();
                                    dtbc.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dtbc);

                                    frm.ShowDialog();
                                }
                                break;
                            case 3:
                                {
                                    System.Data.SqlClient.SqlConnection conn3;
                                    dt = new DataTable();
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptHopDongDaoTao(dNgayIn.DateTime);

                                    conn3 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn3.Open();

                                    System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand("rptHopDongDaoTao", conn3);
                                    cmd1.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd1.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd1.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                    cmd1.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = idHD;
                                    cmd1.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd1);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    dtbc = new DataTable();
                                    dtbc = ds.Tables[1].Copy();
                                    dtbc.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dtbc);

                                    frm.ShowDialog();
                                }
                                break;

                            case 4:
                                {
                                    System.Data.SqlClient.SqlConnection conn4;
                                    dt = new DataTable();
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptToKhaiBHXH(dNgayIn.DateTime);

                                    conn4 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn4.Open();

                                    System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand("rptToKhaiCapSoBHXH", conn4);
                                    cmd2.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd2.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd2.Parameters.Add("@ID_HDLD", SqlDbType.Int).Value = idHD;
                                    cmd2.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                    cmd2.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd2);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DA_TA";
                                    frm.AddDataSource(dt);

                                    frm.ShowDialog();
                                }
                                break;
                        }

                        try
                        {
                            if (rdo_ChonBaoCao.SelectedIndex == 0)
                            {

                            }
                            else
                            {

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