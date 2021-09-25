using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using Vs.Report;

namespace Vs.Payroll
{
    public partial class ucBCLuongSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCLuongSanPham()
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
                        DataTable dt;
                        switch (rdo_ChonBaoCao.SelectedIndex)
                        {
                            case 0:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                     dt = new DataTable();
                                    string sTieuDe = "DANH SÁCH NHÂN VIÊN ĐI TRỄ VỀ SỚM THEO GIAI ĐOẠN";

                                    frm.rpt = new rptDSDiTreVeSomGiaiDoan(lk_TuNgay.DateTime,lk_DenNgay.DateTime,lk_NgayIn.DateTime, sTieuDe);

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCHopDongCongNhan", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn1;
                                     dt = new DataTable();
                                    string sTieuDe1 = "DANH SÁCH VẮNG ĐẦU GIỜ THEO GIAI ĐOẠN";
                                    frm.rpt = new rptDSVangDauGioGiaiDoan(lk_TuNgay.DateTime,lk_DenNgay.DateTime, sTieuDe1);

                                    try
                                    {
                                        conn1 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn1.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSVangDauGioNgay", conn1);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);


                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            case 2:
                                {
                                    System.Data.SqlClient.SqlConnection conn2;
                                     dt = new DataTable();
                                    string sTieuDe2 = "DANH SÁCH CHẤM VẮNG THEO GIAI ĐOẠN";
                                    frm.rpt = new rptDSChamCongVang(lk_TuNgay.DateTime,lk_DenNgay.DateTime, lk_NgayIn.DateTime, sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCHopDongGiaiDoan", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_NgayIn.DateTime;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);


                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            case 3:
                                {
                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    string sTieuDe2 = "DANH SÁCH CHẤM CÔNG VẮNG LŨY KẾ";
                                    frm.rpt = new rptDSChamCongVangLuyKe(lk_TuNgay.DateTime, lk_DenNgay.DateTime, lk_NgayIn.DateTime, sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCHopDongGiaiDoan", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_NgayIn.DateTime;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);


                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            //case 4:
                            //    {
                            //        System.Data.SqlClient.SqlConnection conn2;
                            //        dt = new DataTable();
                            //        string sTieuDe2 = "CHẤM CÔNG CHI TIẾT CÔNG NHÂN GIAI ĐOẠN";
                            //        frm.rpt = new rptBangCCTheoGD();

                            //        try
                            //        {
                            //            conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                            //            conn2.Open();

                            //            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCHopDongGiaiDoan", conn2);

                            //            cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                            //            cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                            //            cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                            //            cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                            //            cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                            //            cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                            //            cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_NgayIn.DateTime;
                            //            cmd.CommandType = CommandType.StoredProcedure;
                            //            System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);


                            //            DataSet ds = new DataSet();
                            //            adp.Fill(ds);
                            //            dt = new DataTable();
                            //            dt = ds.Tables[0].Copy();
                            //            dt.TableName = "DA_TA";
                            //            frm.AddDataSource(dt);
                            //            frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                            //        }
                            //        catch
                            //        { }


                            //        frm.ShowDialog();
                            //    }
                            //    break;
                        }
                        
                        break;
                    }
                default:
                    break;
            }
        }

        private void ucBCLuongSanPham_Load(object sender, EventArgs e)
        {
           
            Commons.Modules.ObjSystems.LoadCboDonVi(LK_DON_VI);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
            LoadGrvCongNhan();

            lk_TuNgay.EditValue = Convert.ToDateTime("01/"+DateTime.Today.Month+"/"+ DateTime.Today.Year).ToString("dd/MM/yyyy");
            DateTime dtTN = DateTime.Today;
            DateTime dtDN = DateTime.Today;
            lk_DenNgay.EditValue = dtTN.AddDays((-1));
            dtDN = dtDN.AddMonths(1);
            lk_NgayIn.EditValue = dtDN;

        }

        private void LoadGrvCongNhan()
        {
            try
            {
                DataTable dtCongNhan = new DataTable();
                dtCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhanBC", LK_DON_VI.EditValue, LK_XI_NGHIEP.EditValue,
                                                        LK_TO.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCN, grvCN, dtCongNhan, true, false, false, true, true, this.Name);
                dtCongNhan.Columns["CHON"].ReadOnly = false;
            }
            catch
            {

            }

            //format grid view Cong nhan
            grvCN.Columns["ID_CN"].Visible = false;
            //grvCN.OptionsView.ShowColumnHeaders = false;
            grvCN.OptionsView.ShowGroupPanel = false;
            //grvCN.OptionsView.ShowFooter = true;
        }

       
        
        private void LK_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
            LoadGrvCongNhan();
        }

        private void LK_XI_NGHIEP_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
            LoadGrvCongNhan();
        }

        private void LK_TO_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrvCongNhan();
        }

        private void grvLydovang_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }
        private void rdo_ChonBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void lbDonVi_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
