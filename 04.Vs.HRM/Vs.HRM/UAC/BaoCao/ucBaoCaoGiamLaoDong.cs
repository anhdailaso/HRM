using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using Vs.Report;

namespace Vs.HRM
{
    public partial class ucBaoCaoGiamLaoDong : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoGiamLaoDong()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        
        private void windowsUIButton_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "Print":
                    {
                        frmViewReport frm = new frmViewReport();

                        switch (rdo_ChonBaoCao.SelectedIndex)
                        {
                            case 0:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    DataTable dt = new DataTable();
                                    frm = new frmViewReport();
                                    frm.rpt = new rptBCGiamLaoDongThang(lk_NgayIn.DateTime, dtTuNgay.DateTime, dtDenNgay.DateTime);

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCGiamLaoDongThang", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = dtTuNgay.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = dtDenNgay.EditValue;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                    }
                                    catch
                                    { }
                               

                                frm.ShowDialog(); }
                                break;
                            case 1:
                                {
                                    DateTime firstDateTime = new DateTime(Convert.ToInt32(txNam.EditValue), 1, 1);
                                    DateTime secondDateTime = new DateTime(Convert.ToInt32(txNam.EditValue), 6, 30);
                                    string sTieuDe = "BÁO CÁO GIẢM LAO ĐỘNG 6 THÁNG ĐẦU NĂM " + Convert.ToString(txNam.EditValue);

                                    System.Data.SqlClient.SqlConnection conn1;
                                    DataTable dt = new DataTable();
                                    frm = new frmViewReport();
                                    frm.rpt = new rptBCTangGiamLD6Thang(lk_NgayIn.DateTime, sTieuDe);

                                    try
                                    {
                                        conn1 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn1.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCTangGiamLD6Thang", conn1);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = firstDateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = secondDateTime;
                                        cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = 1;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            case 2:
                                {
                                    DateTime firstDateTime2 = new DateTime(Convert.ToInt32(txNam.EditValue), 6, 1);
                                    DateTime secondDateTime2 = new DateTime(Convert.ToInt32(txNam.EditValue), 12, 31);
                                    string sTieuDe2 = "BÁO CÁO GIẢM LAO ĐỘNG 6 THÁNG CUỐI NĂM " + Convert.ToString(txNam.EditValue);

                                    System.Data.SqlClient.SqlConnection conn2;
                                    DataTable dt = new DataTable();
                                    frm = new frmViewReport();
                                    frm.rpt = new rptBCTangGiamLD6Thang(lk_NgayIn.DateTime, sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCTangGiamLD6Thang", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = firstDateTime2;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = secondDateTime2;
                                        cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = 1;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            default:
                            break;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        private void ucBaoCaoGiamLaoDong_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboDonVi(LK_DON_VI);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
            dtTuNgay.EditValue = Convert.ToDateTime(("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year)).ToShortDateString();
            dtDenNgay.EditValue = Convert.ToDateTime(("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year)).AddMonths(1).AddDays(-1).ToShortDateString();
            txNam.EditValue = DateTime.Today.Year.ToString();
            lk_NgayIn.EditValue = DateTime.Today;
        }

        private void LK_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
        }

        private void LK_XI_NGHIEP_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
        }

        private void rdo_ChonBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (rdo_ChonBaoCao.SelectedIndex)
                {
                    case 0:
                        {
                            dtTuNgay.Enabled = true;
                            dtDenNgay.Enabled = true;
                        }
                        break;
                    case 1:
                        {
                            dtTuNgay.EditValue = new DateTime(int.Parse(txNam.Text), 1, 1);
                            dtDenNgay.EditValue = new DateTime(int.Parse(txNam.Text), 6, 30);
                            dtTuNgay.Enabled = false;
                            dtDenNgay.Enabled = false;
                        }
                        break;
                    case 2:
                        {
                            dtTuNgay.EditValue = new DateTime(int.Parse(txNam.Text), 7, 1);
                            dtDenNgay.EditValue = new DateTime(int.Parse(txNam.Text), 12, 31);
                            dtTuNgay.Enabled = false;
                            dtDenNgay.Enabled = false;
                        }
                        break;

                    default:
                        dtTuNgay.EditValue = Convert.ToDateTime(("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year)).ToShortDateString();
                        dtDenNgay.EditValue = Convert.ToDateTime(("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year)).AddMonths(1).AddDays(-1).ToShortDateString();
                        dtTuNgay.Enabled = true;
                        dtDenNgay.Enabled = true;
                        break;
                }
            }
            catch
            { }
        }
    }
}
