﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Vs.Report
{
    public partial class rptDKLamThemGio : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDKLamThemGio( DateTime ngayxem, string tDe, string xNghiep)
        {

            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            lblTIEU_DE.Text = tDe;
            DataTable dtNgu = new DataTable();
            dtNgu.Load(Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT KEYWORD, CASE " + Commons.Modules.TypeLanguage + " WHEN 0 THEN VIETNAM WHEN 1 THEN ENGLISH ELSE CHINESE END AS NN  FROM LANGUAGES WHERE FORM = N'NgayThangNam' "));

            string NgayXem = "0" + ngayxem.Day;
            string ThangXem = "0" + ngayxem.Month;
            string NamXem = "00" + ngayxem.Year;
            NONNlbTieuDe2.Text = Commons.Modules.ObjSystems.GetNN(dtNgu, "Ngay", "NgayThangNam") + " " + NgayXem.Substring(NgayXem.Length - 2, 2) + " " +
                Commons.Modules.ObjSystems.GetNN(dtNgu, "Thang", "NgayThangNam") + " " + ThangXem.Substring(ThangXem.Length - 2, 2) + " " +
                Commons.Modules.ObjSystems.GetNN(dtNgu, "Nam", "NgayThangNam") + " " + NamXem.Substring(NamXem.Length - 4, 4);
            lblXiNghiep.Text = xNghiep;

        }

    }
}