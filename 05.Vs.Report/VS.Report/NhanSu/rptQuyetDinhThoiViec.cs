using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace Vs.Report
{
    public partial class rptQuyetDinhThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptQuyetDinhThoiViec(DateTime ngayin, int QDTV )
        {   //DateTime ngayin
            InitializeComponent();


            System.Data.SqlClient.SqlConnection conn;
            DataTable dt = new DataTable();

            try
            {
               
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "rptQuyetDinhThoiViec", Commons.Modules.UserName, Commons.Modules.TypeLanguage, QDTV));
                DateTime NgayHL = Convert.ToDateTime(dt.Rows[0]["NGAY_KY"]);
                string Ngay = "0" + NgayHL.Day;
                string Thang = "0" + NgayHL.Month;
                string Nam = "00" + NgayHL.Year;

                lb0.Text = dt.Rows[0]["TEN_DV"].ToString().ToUpper();
               
                lb1.Text = dt.Rows[0]["SO_QD"].ToString();

                lb3.Text = "          - Căn cứ Điều lệ tổ chức và hoạt động của "
                    + dt.Rows[0]["TEN_DV"].ToString() + " quy định nhiệm vụ, chức năng và quyền hạn của Giám đốc.";
                lb4.Text = "          - Căn cứ vào Quy chế lương của "
                    + dt.Rows[0]["TEN_DV"].ToString();

                lb5.Text = "          - Căn cứ vào Quy chế lao động của " 
                    + dt.Rows[0]["TEN_DV"].ToString() + " .";
                lb6.Text = "           <b>Điều 1. </b> Chấm dứt hợp đồng lao động với Ông/Bà có tên dưới đây:";
                lb7.Text = dt.Rows[0]["HO_TEN"].ToString();
                lb8.Text = Convert.ToDateTime(dt.Rows[0]["NGAY_SINH"]).ToString("dd/MM/yyyy");
                lb9.Text = dt.Rows[0]["DIA_CHI_THUONG_TRU"].ToString();
                lb10.Text = dt.Rows[0]["MS_CN"].ToString();
                lb11.Text = dt.Rows[0]["TEN_CV"].ToString();
                lb12.Text = dt.Rows[0]["TEN_TO"].ToString();

                lb13.Text = Convert.ToDateTime(dt.Rows[0]["NGAY_THOI_VIEC"]).ToString("dd/MM/yyyy");
                lb14.Text = dt.Rows[0]["LY_DO"].ToString();

                lb15.Text = Convert.ToDateTime(dt.Rows[0]["NGAY_KY"]).ToString("MM/yyyy");

                lb16.Text = "           <b>Điều 2. </b> Ông/bà " + dt.Rows[0]["HO_TEN"].ToString() + " có trách nhiệm bàn giao toàn bộ công việc, tài liệu (nếu có) và các giấy tờ liên quan cho phòng HCNS từ ngày "
                    + Convert.ToDateTime(dt.Rows[0]["NGAY_KY"]).ToString("dd/MM/yyyy");
                lb17.Text = "           <b>Điều 3. </b> Quyết định có hiệu lực kể từ ngày " 
                    + Convert.ToDateTime(dt.Rows[0]["NGAY_KY"]).ToString("dd/MM/yyyy") + "Phòng Hành chính nhân sự, Phòng Tài chính Kế toán, các Phòng/Bộ phận có liên quan và Ông/Bà "
                    + dt.Rows[0]["HO_TEN"].ToString() + " chịu trách nhiệm thi hành quyết định này.";
                lb18.Text = dt.Rows[0]["CV_NK"].ToString();
                lb19.Text = dt.Rows[0]["HO_TEN_NK"].ToString();
            }
            catch
            { }

            string NgayBC = "0" + ngayin.Day;
            string ThangBC = "0" + ngayin.Month;
            string NamBC = "00" + ngayin.Year;

            lbNgay.Text = "Tp.HCM, Ngày " + NgayBC.Substring(NgayBC.Length - 2, 2) + " Tháng " + ThangBC.Substring(ThangBC.Length - 2, 2) + " Năm " + NamBC.Substring(NamBC.Length - 4, 4);


        }

    }
}


