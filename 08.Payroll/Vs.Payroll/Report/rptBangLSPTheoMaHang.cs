using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Vs.Payroll
{
    public partial class rptBangLSPTheoMaHang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangLSPTheoMaHang(DateTime tngay, DateTime dngay)
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);

            time.Text = "Từ ngày " + tngay.ToString("dd/MM/yyyy") + "  Đến ngày " + dngay.ToString("dd/MM/yyyy");

        }

    }

}
