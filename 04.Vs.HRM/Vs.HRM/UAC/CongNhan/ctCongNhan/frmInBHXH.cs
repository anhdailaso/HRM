using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Vs.HRM
{
    public partial class frmInBHXH : DevExpress.XtraEditors.XtraForm
    {
        private DateTime ThangBC = new DateTime(DateTime.Now.Year, 1, 1);
        private Int32 DotBC = 1;
        public frmInBHXH(DateTime Thang, Int32 Dot)
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            ThangBC = Thang;
            DotBC = Dot;
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
                                try
                                {

                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();
                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCLaoDongTangBHXH", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@Thang", SqlDbType.Date).Value = Convert.ToDateTime(ThangBC).ToString("yyyy-MM-dd");
                                    cmd.Parameters.Add("@Dot", SqlDbType.Int).Value = Convert.ToInt32(DotBC);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    ds.Tables[0].TableName = "TangLaoDong";
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    saveFileDialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx";
                                    saveFileDialog.FilterIndex = 0;
                                    saveFileDialog.RestoreDirectory = true;
                                    saveFileDialog.CreatePrompt = true;
                                    saveFileDialog.Title = "Export Excel File To";
                                    // If the file name is not an empty string open it for saving.
                                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        if (saveFileDialog.FileName != "")
                                        {
                                            Commons.TemplateExcel.FillReport(saveFileDialog.FileName, Application.StartupPath + "\\lib\\Template\\TemplateTangLaoDong.xlsx", ds, new string[] { "{", "}" });
                                            Process.Start(saveFileDialog.FileName);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            else
                            {
                                System.Data.SqlClient.SqlConnection conn;
                                DataTable dt = new DataTable();
                                try
                                {
                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();
                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBCLaoDongGiamBHXH", conn);
                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@Thang", SqlDbType.Date).Value = Convert.ToDateTime(ThangBC).ToString("yyyy-MM-dd");
                                    cmd.Parameters.Add("@Dot", SqlDbType.Int).Value = Convert.ToInt32(DotBC);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    ds.Tables[0].TableName = "GiamLaoDong";
                                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                                    saveFileDialog.Filter = "Excel Files(.xls)|*.xls| Excel Files(.xlsx)| *.xlsx";
                                    saveFileDialog.FilterIndex = 0;
                                    saveFileDialog.RestoreDirectory = true;
                                    saveFileDialog.CreatePrompt = true;
                                    saveFileDialog.Title = "Export Excel File To";
                                    // If the file name is not an empty string open it for saving.
                                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        if (saveFileDialog.FileName != "")
                                        {
                                            Commons.TemplateExcel.FillReport(saveFileDialog.FileName, Application.StartupPath + "\\lib\\Template\\TemplateGiamLaoDong.xlsx", ds, new string[] { "{", "}" });
                                            //Commons.TemplateExcel.FillReport(saveFileDialog.FileName, Application.StartupPath + "\\lib\\Template\\TemplateGiamLaoDong.xlsx", ds, new string[] { "{", "}" });
                                            Process.Start(saveFileDialog.FileName);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                }
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