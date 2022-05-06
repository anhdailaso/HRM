using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Vs.Recruit
{
    public partial class rptDSUngVien : DevExpress.XtraReports.UI.XtraReport
    {
        private string sChuyenMon = "";
        private string sTrinhDo = "";
        private string sKinhNghiemLV = "";
        private string sBangCap = "";

        public rptDSUngVien(string ChuyenMon, string TrinhDo, string KNLV, string BangCap)
        {
            InitializeComponent();
            sChuyenMon = ChuyenMon;
            sTrinhDo = TrinhDo;
            sKinhNghiemLV = KNLV;
            sBangCap = BangCap;
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }

        private void rptDSUngVien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if(sChuyenMon == "" && sTrinhDo == "")
            {
                GroupHeader4.Visible = false;
            }

            if (sKinhNghiemLV == "" && sBangCap == "")
            {
                GroupHeader3.Visible = false;
            }
            xrTableCellChuyenMon.Text = sChuyenMon;
            xrTableCellTrinhDo.Text = sTrinhDo;
            xrTableCellKNLV.Text = sKinhNghiemLV;
            xrTableCellBangCap.Text = sBangCap;
        }
    }
}
