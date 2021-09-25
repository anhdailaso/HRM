using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSGiaDinh: DevExpress.XtraReports.UI.XtraReport
    {
        private object editValue;

        public rptDSGiaDinh(DateTime ngayin)
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            string Ngay = "0" + ngayin.Day;
            string Thang = "0" + ngayin.Month;
            string Nam = "00" + ngayin.Year;

            lblNgay.Text = " Ngày " + Ngay.Substring(Ngay.Length-2,2) + " Tháng " + Thang.Substring(Thang.Length - 2, 2) + " Năm " + Nam.Substring(Nam.Length - 4, 4);
        }

        public rptDSGiaDinh(object editValue)
        {
            this.editValue = editValue;
        }
    }
}
