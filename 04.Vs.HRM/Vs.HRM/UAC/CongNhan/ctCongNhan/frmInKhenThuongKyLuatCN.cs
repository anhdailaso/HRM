using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class frmInKhenThuongKyLuatCN : DevExpress.XtraEditors.XtraForm
    {
        private long idCN;

        public frmInKhenThuongKyLuatCN(Int64 idCongNhan, string tencn)
        {
            InitializeComponent();
            NONN_HoTenCN.Text = tencn.ToUpper();
            idCN = idCongNhan;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
 
        //sự kiên load form
        private void formInKhenThuongKyLuatCN_Load(object sender, EventArgs e)
        {
            rdo_ChonBaoCao.SelectedIndex = 0;
            dNgayIn.EditValue = DateTime.Today;
            dDenNgay.EditValue = DateTime.Today;
            int SoNgay = DateTime.Today.Day-1;
            dTuNgay.EditValue = DateTime.Today.AddDays(-SoNgay);
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
                                frm.rpt = new rptBCKhenThuongKyLuatCN(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptKhenThuongKyLuatCN", conn);
                                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                cmd.Parameters.Add("@TNgay", SqlDbType.DateTime).Value = dTuNgay.DateTime;
                                cmd.Parameters.Add("@DNgay", SqlDbType.DateTime).Value = dDenNgay.DateTime;
                                cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = rdo_ChonBaoCao.SelectedIndex;
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
                                frm.rpt = new rptBCKhenThuongKyLuatCN(dNgayIn.DateTime);

                                conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                conn.Open();

                                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptKhenThuongKyLuatCN", conn);
                                cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                cmd.Parameters.Add("@ID_CN", SqlDbType.Int).Value = idCN;
                                cmd.Parameters.Add("@TNgay", SqlDbType.DateTime).Value = dTuNgay.DateTime;
                                cmd.Parameters.Add("@DNgay", SqlDbType.DateTime).Value = dDenNgay.DateTime;
                                cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = rdo_ChonBaoCao.SelectedIndex;
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