using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSQuanLy : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSQuanLy()
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

    }
}
