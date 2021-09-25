using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Vs.Payroll
{
    public partial class rptDanhMucCongDoan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhMucCongDoan(string loaisp, string cum)
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
   
        }

    }

}
