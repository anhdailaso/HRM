using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class frmInQuyetDinhThoiViec : DevExpress.XtraEditors.XtraForm
    {
        private int iID_CN = 494;
        private int iID_QDTV = 13;
        DateTime dtNgayThoiViec;
        public frmInQuyetDinhThoiViec(int ID_QDTV, int ID_CN, DateTime ngaythoiviec)
        {
            InitializeComponent();
            iID_CN = ID_CN;
            iID_QDTV = ID_QDTV;
            dtNgayThoiViec = ngaythoiviec;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }



        //sự kiên load form
        private void frmInQuyetDinhThoiViec_Load(object sender, EventArgs e)
        {
            rdo_ChonBaoCao.SelectedIndex = 0;


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
                        switch (rdo_ChonBaoCao.SelectedIndex)
                        {
                            // Quyết định thôi việc
                            case 0:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhThoiViec(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);

                                    frm.ShowDialog();
                                }
                                break;
                            //Quyết định sa thải
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhSaThai(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);

                                    frm.ShowDialog();
                                }
                                break;
                            //Quyết định thanh lý hợp đồng trước năm 2008
                            case 2:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhThanhLyHDTruoc2008(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);

                                    frm.ShowDialog();
                                }
                                break;
                            //Quyết định thanh lý hợp đồng sau năm 2008 có trợ cấp
                            case 3:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhThoiViecTroCap(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);

                                    frm.ShowDialog();
                                    break;
                                }
                            //Quyết định sa thải có trợ cấp
                            case 4:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhSaThaiTroCap(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);
                                    frm.ShowDialog();
                                }
                                break;
                            //Quyết định thôi việc vi phạm thời gian báo trước
                            case 5:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    frmViewReport frm = new frmViewReport();
                                    frm.rpt = new rptQuyetDinhViPhamTGHopDong(DateTime.Now, 1);

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptQuyetDinhThoiViec", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@KHDV", SqlDbType.NVarChar).Value = "MT";
                                    cmd.Parameters.Add("@ID_SQD", SqlDbType.Int).Value = iID_QDTV;
                                    cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = iID_CN;
                                    cmd.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = dtNgayThoiViec;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    DataTable dt = new DataTable();
                                    dt = ds.Tables[0].Copy();
                                    dt.TableName = "DATA";
                                    frm.AddDataSource(dt);

                                    DataTable dt1 = new DataTable();
                                    dt1 = ds.Tables[1].Copy();
                                    dt1.TableName = "NOI_DUNG";
                                    frm.AddDataSource(dt1);
                                    frm.ShowDialog();
                                }
                                break;

                            default:
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