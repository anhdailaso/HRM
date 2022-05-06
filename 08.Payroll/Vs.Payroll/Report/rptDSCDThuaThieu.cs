﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Vs.Report
{
    public partial class rptDSCDThuaThieu : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime ngay;
        string HopDong;
        string MaHang;
        string Order;
        string Chuyen;
        public rptDSCDThuaThieu(DateTime ngayin, string hopdong, string mahang, string order, string chuyen)
        {

            InitializeComponent();

            HopDong = hopdong;
            MaHang = mahang;
            Order = order;
            Chuyen = chuyen;

            Commons.Modules.ObjSystems.ThayDoiNN(this);
            ngay = ngayin;
            DataTable dtNgu = new DataTable();
            dtNgu.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'NgayThangNam' "));
            string Ngay = "0" + ngayin.Day;
            string Thang = "0" + ngayin.Month;
            string Nam = "00" + ngayin.Year;

            lblNgay.Text = Commons.Modules.ObjSystems.GetNN(dtNgu, "Ngay", "NgayThangNam") + " " + Ngay.Substring(Ngay.Length - 2, 2) + " " +
                Commons.Modules.ObjSystems.GetNN(dtNgu, "Thang", "NgayThangNam") + " " + Thang.Substring(Thang.Length - 2, 2) + " " +
                Commons.Modules.ObjSystems.GetNN(dtNgu, "Nam", "NgayThangNam") + " " + Nam.Substring(Nam.Length - 4, 4);

        }

        private void rptDSCDThuaThieu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel11.Text = HopDong;
            xrLabel10.Text = MaHang;
            xrLabel14.Text = Order;
            xrLabel16.Text = Chuyen;
        }
    }
}