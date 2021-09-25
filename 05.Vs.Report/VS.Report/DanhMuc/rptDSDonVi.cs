using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSDonVi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSDonVi()
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

    }
}
