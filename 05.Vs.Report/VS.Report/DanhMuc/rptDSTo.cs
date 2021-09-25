using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSTo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSTo()
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

    }
}
