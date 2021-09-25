using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class rptDSThamGiaCongDoan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSThamGiaCongDoan()
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

    }
}
