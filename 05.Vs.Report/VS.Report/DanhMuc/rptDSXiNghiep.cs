using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSXiNghiep : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSXiNghiep()
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

    }
}
