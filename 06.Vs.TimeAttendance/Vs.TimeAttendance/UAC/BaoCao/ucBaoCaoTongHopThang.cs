﻿using DevExpress.CodeParser;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Linq;
using Vs.Payroll;
using Vs.Report;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;

namespace Vs.TimeAttendance
{
    public partial class ucBaoCaoTongHopThang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoTongHopThang()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
        }
        static string CharacterIncrement(int colCount)
        {
            int TempCount = 0;
            string returnCharCount = string.Empty;

            if (colCount <= 25)
            {
                TempCount = colCount;
                char CharCount = Convert.ToChar((Convert.ToInt32('A') + TempCount));
                returnCharCount += CharCount;
                return returnCharCount;
            }
            else
            {
                var rev = 0;

                while (colCount >= 26)
                {
                    colCount = colCount - 26;
                    rev++;
                }

                returnCharCount += CharacterIncrement(rev - 1);
                returnCharCount += CharacterIncrement(colCount);
                return returnCharCount;
            }
        }


        private void windowsUIButton_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "Print":
                    {
                        frmViewReport frm = new frmViewReport();
                        DataTable dt;
                        switch (rdo_ChonBaoCao.SelectedIndex)
                        {
                            case 0:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();
                                    DataTable dtBCThang;

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangCongThang", conn);

                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                    cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                    cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                    cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);
                                    cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dtBCThang = new DataTable();
                                    dtBCThang = ds.Tables[0].Copy();

                                    Excel.Application oXL;
                                    Excel._Workbook oWB;
                                    Excel._Worksheet oSheet;

                                    oXL = new Excel.Application();
                                    oXL.Visible = true;

                                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                                    string fontName = "Times New Roman";
                                    int fontSizeTieuDe = 16;
                                    int fontSizeNoiDung = 12;
                                    int iTNgay = Convert.ToDateTime(lk_TuNgay.EditValue).Day;
                                    int iDNgay = Convert.ToDateTime(lk_DenNgay.EditValue).Day;
                                    int iSoNgay = (iDNgay - iTNgay) + 1;

                                    string lastColumn = string.Empty;
                                    lastColumn = CharacterIncrement(dtBCThang.Columns.Count - 1);
                                    string lastColumNgay = string.Empty;
                                    lastColumNgay = CharacterIncrement(iSoNgay + 7);
                                    string firstColumTT = string.Empty;
                                    firstColumTT = CharacterIncrement(iSoNgay + 8);

                                    Range row2_TieuDe_BaoCao = oSheet.get_Range("A2", lastColumn + "2");
                                    row2_TieuDe_BaoCao.Merge();
                                    row2_TieuDe_BaoCao.Font.Size = fontSizeTieuDe;
                                    row2_TieuDe_BaoCao.Font.Name = fontName;
                                    row2_TieuDe_BaoCao.Font.Bold = true;
                                    row2_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    row2_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                    row2_TieuDe_BaoCao.RowHeight = 50;
                                    row2_TieuDe_BaoCao.Value2 = "BẢNG CHẤM CÔNG THÁNG " + Convert.ToDateTime(lk_TuNgay.EditValue).ToString("MM/yyyy");

                                    Range row5_TieuDe_Format = oSheet.get_Range("A4", lastColumn + "6"); //27 + 31
                                    row5_TieuDe_Format.Font.Size = fontSizeNoiDung;
                                    row5_TieuDe_Format.Font.Name = fontName;
                                    row5_TieuDe_Format.Font.Bold = true;
                                    row5_TieuDe_Format.WrapText = true;
                                    row5_TieuDe_Format.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    row5_TieuDe_Format.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                    row5_TieuDe_Format.Interior.Color = Color.Yellow;

                                    Range row5_TieuDe = oSheet.get_Range("A4", "H4");
                                    row5_TieuDe.Merge();
                                    row5_TieuDe.Value2 = "Thông tin nhân viên";

                                    Range row5_TieuDe2 = oSheet.get_Range("I4", lastColumNgay + "4");
                                    row5_TieuDe2.Merge();
                                    row5_TieuDe2.Value2 = "Ngày làm việc";

                                    Range row5_TieuDe3 = oSheet.get_Range(firstColumTT + "4", lastColumn + "4");
                                    row5_TieuDe3.Merge();
                                    row5_TieuDe3.Value2 = "Thông tin chấm công tháng";

                                    Range row5_TieuDe_Stt = oSheet.get_Range("A5", "A6");
                                    row5_TieuDe_Stt.Merge();
                                    row5_TieuDe_Stt.Value2 = "Stt";
                                    row5_TieuDe_Stt.ColumnWidth = 6;

                                    Range row5_TieuDe_MaSo = oSheet.get_Range("B5", "B6");
                                    row5_TieuDe_MaSo.Merge();
                                    row5_TieuDe_MaSo.Value2 = "MSCN";
                                    row5_TieuDe_MaSo.ColumnWidth = 15;

                                    Range row5_TieuDe_HoTen = oSheet.get_Range("C5", "C6");
                                    row5_TieuDe_HoTen.Merge();
                                    row5_TieuDe_HoTen.Value2 = "Họ và tên";
                                    row5_TieuDe_HoTen.ColumnWidth = 30;

                                    Range row5_TieuDe_ChucDanh = oSheet.get_Range("D5", "D6");
                                    row5_TieuDe_ChucDanh.Merge();
                                    row5_TieuDe_ChucDanh.Value2 = "Chức vụ";
                                    row5_TieuDe_ChucDanh.ColumnWidth = 20;

                                    Range row5_TieuDe_BoPhan = oSheet.get_Range("E5", "E6");
                                    row5_TieuDe_BoPhan.Merge();
                                    row5_TieuDe_BoPhan.Value2 = "Xí nghiệp";
                                    row5_TieuDe_BoPhan.ColumnWidth = 20;

                                    Range row5_TieuDe_To = oSheet.get_Range("F5", "F6");
                                    row5_TieuDe_To.Merge();
                                    row5_TieuDe_To.Value2 = "Tổ";
                                    row5_TieuDe_To.ColumnWidth = 20;

                                    Range row5_TieuDe_NgayTV = oSheet.get_Range("G5", "G6");
                                    row5_TieuDe_NgayTV.Merge();
                                    row5_TieuDe_NgayTV.Value2 = "Ngày thử việc";
                                    row5_TieuDe_NgayTV.ColumnWidth = 12;

                                    Range row5_TieuDe_NgayVL = oSheet.get_Range("H5", "H6");
                                    row5_TieuDe_NgayVL.Merge();
                                    row5_TieuDe_NgayVL.Value2 = "Ngày vào làm";
                                    row5_TieuDe_NgayVL.ColumnWidth = 12;

                                    int col = 9;
                                    while (iTNgay <= iDNgay)
                                    {
                                        oSheet.Cells[5, col] = iTNgay;
                                        oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                        col++;
                                        iTNgay++;
                                    }

                                    oSheet.Cells[5, col] = "Tổng số ngày làm việc";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col + 1]].Merge();
                                    oSheet.Cells[6, col] = "Ngày thường";
                                    oSheet.Cells[6, col + 1] = "Chủ nhật";

                                    col = col + 2;
                                    oSheet.Cells[5, col] = "Số ngày phép";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ bù";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ lễ";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ hưởng BHXH";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ được hưởng lương";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ không lương, nghỉ tự do";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số ngày nghỉ việc";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Tổng số công đi muộn, về sớm, ra ngoài việc riêng";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "TI (Số lần đi muộn)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số giờ đi muộn";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "EO (Số lần về sớm)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số giờ về sớm";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số lần ra ngoài việc riêng";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Số giờ ra ngoài";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Tổng ngày công";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    DataRow[] dr = dtBCThang.Select();
                                    string[,] rowData = new string[dr.Count(), dtBCThang.Columns.Count];

                                    int rowCnt = 0;
                                    foreach (DataRow row in dr)
                                    {
                                        for (col = 0; col < dtBCThang.Columns.Count; col++)
                                        {
                                            rowData[rowCnt, col] = row[col].ToString();
                                        }

                                        rowCnt++;
                                    }
                                    rowCnt = rowCnt + 6;
                                    oSheet.get_Range("A7", lastColumn + rowCnt.ToString()).Value2 = rowData;
                                    Excel.Range formatRange;
                                    formatRange = oSheet.get_Range("G7", "G" + rowCnt.ToString());
                                    formatRange.NumberFormat = "dd/MM/yyyy";
                                    formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    formatRange = oSheet.get_Range("H7", "H" + rowCnt.ToString());
                                    formatRange.NumberFormat = "dd/MM/yyyy";
                                    formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    formatRange = oSheet.get_Range("I7", lastColumNgay + rowCnt.ToString());
                                    formatRange.NumberFormat = "@";
                                    formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                    string CurentColumn = string.Empty;
                                    int colBD = iSoNgay + 8;
                                    int colKT = colBD + 9;

                                    for (col = colBD; col <= colKT; col++)
                                    {
                                        CurentColumn = CharacterIncrement(col);
                                        formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                        formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";
                                        formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    }

                                    //so lan di muon
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //so gio di muon
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //so lan ve som
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //so gio ve som
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //so lan ra ngoai
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //so gio ra ngoai
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    //tong ngay cong
                                    colKT++;
                                    CurentColumn = CharacterIncrement(colKT);
                                    formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                    formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);

                                    ////Kẻ khung toàn bộ
                                    formatRange = oSheet.get_Range("A7", lastColumn + rowCnt.ToString());
                                    formatRange.Font.Name = fontName;
                                    formatRange.Font.Size = fontSizeNoiDung;
                                    BorderAround(oSheet.get_Range("A4", lastColumn + rowCnt.ToString()));

                                    oXL.Visible = true;
                                    oXL.UserControl = true;

                                    oWB.SaveAs("D:\\BangCongThang.xlsx",
                                        AccessMode: Excel.XlSaveAsAccessMode.xlShared);

                                }
                                break;
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    conn.Open();
                                    DataTable dtBCThang;

                                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangCongTCThang", conn);

                                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                    cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                    cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                    cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);
                                    cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                    DataSet ds = new DataSet();
                                    adp.Fill(ds);
                                    dtBCThang = new DataTable();
                                    dtBCThang = ds.Tables[0].Copy();

                                    Excel.Application oXL;
                                    Excel._Workbook oWB;
                                    Excel._Worksheet oSheet;

                                    oXL = new Excel.Application();
                                    oXL.Visible = true;

                                    oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                                    oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                                    string fontName = "Times New Roman";
                                    int fontSizeTieuDe = 16;
                                    int fontSizeNoiDung = 12;
                                    int iTNgay = Convert.ToDateTime(lk_TuNgay.EditValue).Day;
                                    int iDNgay = Convert.ToDateTime(lk_DenNgay.EditValue).Day;
                                    int iSoNgay = (iDNgay - iTNgay) + 1;

                                    string lastColumn = string.Empty;
                                    lastColumn = CharacterIncrement(dtBCThang.Columns.Count - 1);
                                    string lastColumNgay = string.Empty;
                                    lastColumNgay = CharacterIncrement(iSoNgay + 7);
                                    string firstColumTT = string.Empty;
                                    firstColumTT = CharacterIncrement(iSoNgay + 8);

                                    Range row2_TieuDe_BaoCao = oSheet.get_Range("A2", lastColumn + "2");
                                    row2_TieuDe_BaoCao.Merge();
                                    row2_TieuDe_BaoCao.Font.Size = fontSizeTieuDe;
                                    row2_TieuDe_BaoCao.Font.Name = fontName;
                                    row2_TieuDe_BaoCao.Font.Bold = true;
                                    row2_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    row2_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                    row2_TieuDe_BaoCao.RowHeight = 50;
                                    row2_TieuDe_BaoCao.Value2 = "BẢNG CHẤM CÔNG THÁNG NGOÀI GIỜ THÁNG " + Convert.ToDateTime(lk_TuNgay.EditValue).ToString("MM/yyyy");

                                    Range row5_TieuDe_Format = oSheet.get_Range("A4", lastColumn + "6"); //27 + 31
                                    row5_TieuDe_Format.Font.Size = fontSizeNoiDung;
                                    row5_TieuDe_Format.Font.Name = fontName;
                                    row5_TieuDe_Format.Font.Bold = true;
                                    row5_TieuDe_Format.WrapText = true;
                                    row5_TieuDe_Format.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    row5_TieuDe_Format.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                    row5_TieuDe_Format.Interior.Color = Color.Yellow;

                                    Range row5_TieuDe = oSheet.get_Range("A4", "H4");
                                    row5_TieuDe.Merge();
                                    row5_TieuDe.Value2 = "Thông tin nhân viên";

                                    Range row5_TieuDe2 = oSheet.get_Range("I4", lastColumNgay + "4");
                                    row5_TieuDe2.Merge();
                                    row5_TieuDe2.Value2 = "Ngày tăng ca";

                                    Range row5_TieuDe3 = oSheet.get_Range(firstColumTT + "4", lastColumn + "4");
                                    row5_TieuDe3.Merge();
                                    row5_TieuDe3.Value2 = "Thông tin tăng ca tháng";

                                    Range row5_TieuDe_Stt = oSheet.get_Range("A5", "A6");
                                    row5_TieuDe_Stt.Merge();
                                    row5_TieuDe_Stt.Value2 = "Stt";
                                    row5_TieuDe_Stt.ColumnWidth = 6;

                                    Range row5_TieuDe_MaSo = oSheet.get_Range("B5", "B6");
                                    row5_TieuDe_MaSo.Merge();
                                    row5_TieuDe_MaSo.Value2 = "MSCN";
                                    row5_TieuDe_MaSo.ColumnWidth = 15;

                                    Range row5_TieuDe_HoTen = oSheet.get_Range("C5", "C6");
                                    row5_TieuDe_HoTen.Merge();
                                    row5_TieuDe_HoTen.Value2 = "Họ và tên";
                                    row5_TieuDe_HoTen.ColumnWidth = 30;

                                    Range row5_TieuDe_ChucDanh = oSheet.get_Range("D5", "D6");
                                    row5_TieuDe_ChucDanh.Merge();
                                    row5_TieuDe_ChucDanh.Value2 = "Chức vụ";
                                    row5_TieuDe_ChucDanh.ColumnWidth = 20;

                                    Range row5_TieuDe_BoPhan = oSheet.get_Range("E5", "E6");
                                    row5_TieuDe_BoPhan.Merge();
                                    row5_TieuDe_BoPhan.Value2 = "Xí nghiệp";
                                    row5_TieuDe_BoPhan.ColumnWidth = 20;

                                    Range row5_TieuDe_To = oSheet.get_Range("F5", "F6");
                                    row5_TieuDe_To.Merge();
                                    row5_TieuDe_To.Value2 = "Tổ";
                                    row5_TieuDe_To.ColumnWidth = 20;

                                    Range row5_TieuDe_NgayTV = oSheet.get_Range("G5", "G6");
                                    row5_TieuDe_NgayTV.Merge();
                                    row5_TieuDe_NgayTV.Value2 = "Ngày thử việc";
                                    row5_TieuDe_NgayTV.ColumnWidth = 12;

                                    Range row5_TieuDe_NgayVL = oSheet.get_Range("H5", "H6");
                                    row5_TieuDe_NgayVL.Merge();
                                    row5_TieuDe_NgayVL.Value2 = "Ngày vào làm";
                                    row5_TieuDe_NgayVL.ColumnWidth = 12;

                                    int col = 9;
                                    while (iTNgay <= iDNgay)
                                    {
                                        oSheet.Cells[5, col] = iTNgay;
                                        oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                        col++;
                                        iTNgay++;
                                    }

                                    oSheet.Cells[5, col] = "Tổng số giờ tăng ca (đối với ngày thường)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col + 1]].Merge();
                                    oSheet.Cells[6, col] = "Tăng ca ban ngày";
                                    oSheet.Cells[6, col + 1] = "Tăng ca ban đêm";

                                    col = col + 2;
                                    oSheet.Cells[5, col] = "Tổng số giờ tăng ca (đối với ngày chủ nhật)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col + 1]].Merge();
                                    oSheet.Cells[6, col] = "Tăng ca ban ngày";
                                    oSheet.Cells[6, col + 1] = "Tăng ca ban đêm";

                                    col = col + 2;
                                    oSheet.Cells[5, col] = "Tổng số giờ tăng ca (đối với ca đêm)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col + 1]].Merge();
                                    oSheet.Cells[6, col] = "Số giờ ca đêm";
                                    oSheet.Cells[6, col + 1] = "Tăng ca ca đêm";

                                    col = col + 2;
                                    oSheet.Cells[5, col] = "Tổng số giờ tăng ca (ngày thường)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    col = col + 1;
                                    oSheet.Cells[5, col] = "Tổng số giờ tăng ca (ngày ngày chủ nhật)";
                                    oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[6, col]].Merge();

                                    DataRow[] dr = dtBCThang.Select();
                                    string[,] rowData = new string[dr.Count(), dtBCThang.Columns.Count];

                                    int rowCnt = 0;
                                    //int redRows = 7;
                                    foreach (DataRow row in dr)
                                    {
                                        for (col = 0; col < dtBCThang.Columns.Count; col++)
                                        {
                                            rowData[rowCnt, col] = row[col].ToString();
                                        }

                                        rowCnt++;
                                    }
                                    rowCnt = rowCnt + 6;
                                    oSheet.get_Range("A7", lastColumn + rowCnt.ToString()).Value2 = rowData;
                                    Excel.Range formatRange;
                                    formatRange = oSheet.get_Range("G7", "G" + rowCnt.ToString());
                                    formatRange.NumberFormat = "dd/MM/yyyy";
                                    formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    formatRange = oSheet.get_Range("H7", "H" + rowCnt.ToString());
                                    formatRange.NumberFormat = "dd/MM/yyyy";
                                    formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);

                                    string CurentColumn = string.Empty;
                                    for (col = 8; col < dtBCThang.Columns.Count; col++)
                                    {
                                        CurentColumn = CharacterIncrement(col);
                                        formatRange = oSheet.get_Range(CurentColumn + "7", CurentColumn + rowCnt.ToString());
                                        formatRange.NumberFormat = "#,##0.0;(#,##0.0); ; ";
                                        formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                    }
                                    ////Kẻ khung toàn bộ
                                    formatRange = oSheet.get_Range("A7", lastColumn + rowCnt.ToString());
                                    formatRange.Font.Name = fontName;
                                    formatRange.Font.Size = fontSizeNoiDung;
                                    BorderAround(oSheet.get_Range("A4", lastColumn + rowCnt.ToString()));

                                    oXL.Visible = true;
                                    oXL.UserControl = true;

                                    oWB.SaveAs("D:\\BangCongTCThang.xlsx",
                                        AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                                }
                                break;

                            case 2:
                                {

                                    try
                                    {
                                        System.Data.SqlClient.SqlConnection conn;
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        DataTable dtBCGaiDoan;

                                        //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangXacNhanGioQuetThe", conn);


                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangTHDiTreVeSomThang", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue);
                                        cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = rdo_DiTreVeSom.SelectedIndex;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                        if (Convert.ToDateTime(lk_TuNgay.EditValue).Month != Convert.ToDateTime(lk_DenNgay.EditValue).Month)
                                        {
                                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTu ngay den ngay khong hop le"));
                                            return;
                                        }
                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dtBCGaiDoan = new DataTable();
                                        dtBCGaiDoan = ds.Tables[0].Copy();


                                        Excel.Application oXL;
                                        Excel._Workbook oWB;
                                        Excel._Worksheet oSheet;

                                        oXL = new Excel.Application();
                                        oXL.Visible = true;

                                        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                                        oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                                        string fontName = "Times New Roman";
                                        int fontSizeTieuDe = 16;
                                        int fontSizeNoiDung = 12;
                                        int iTNgay = Convert.ToDateTime(lk_TuNgay.EditValue).Day;
                                        int iDNgay = Convert.ToDateTime(lk_DenNgay.EditValue).Day;
                                        int iSoNgay = (iDNgay - iTNgay);

                                        string lastColumn = string.Empty;
                                        lastColumn = CharacterIncrement(dtBCGaiDoan.Columns.Count-1);
                                        Excel.Range row2_TieuDe_BaoCao0 = oSheet.get_Range("A1", lastColumn + "2");
                                        row2_TieuDe_BaoCao0.Merge();
                                        row2_TieuDe_BaoCao0.Font.Size = fontSizeTieuDe;
                                        row2_TieuDe_BaoCao0.Font.Name = fontName;
                                        row2_TieuDe_BaoCao0.Font.Bold = true;
                                        row2_TieuDe_BaoCao0.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        row2_TieuDe_BaoCao0.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                                        //=====

                                        Excel.Range row2_TieuDe_BaoCao = oSheet.get_Range("A3", lastColumn + "3");
                                        row2_TieuDe_BaoCao.Merge();
                                        row2_TieuDe_BaoCao.Font.Size = fontSizeTieuDe;
                                        row2_TieuDe_BaoCao.Font.Name = fontName;
                                        row2_TieuDe_BaoCao.Font.Bold = true;
                                        row2_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row2_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row2_TieuDe_BaoCao.RowHeight = 50;
                                        if (rdo_DiTreVeSom.SelectedIndex==0)
                                        {
                                            row2_TieuDe_BaoCao.Value2 = "BẢNG TỔNG HỢP ĐI TRỄ (" + Convert.ToDateTime(LK_Thang.EditValue).ToString("MM/yyyy")+")";
                                        }
                                        if (rdo_DiTreVeSom.SelectedIndex==1)
                                        {
                                            row2_TieuDe_BaoCao.Value2 = "BẢNG TỔNG HỢP VỀ SỚM (" + Convert.ToDateTime(LK_Thang.EditValue).ToString("MM/yyyy") + ")";
                                        }
                                        else
                                        {
                                            row2_TieuDe_BaoCao.Value2 = "BẢNG TỔNG HỢP ĐI TRỄ, VỀ SỚM (" + Convert.ToDateTime(LK_Thang.EditValue).ToString("MM/yyyy") + ")";
                                        }
                                        Excel.Range row5_TieuDe = oSheet.get_Range("A4", "A5");
                                        row5_TieuDe.Merge();
                                        row5_TieuDe.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe.Font.Name = fontName;
                                        row5_TieuDe.Font.Bold = true;
                                        row5_TieuDe.Value2 = "Stt";
                                        row5_TieuDe.Interior.Color = Color.Yellow;

                                        Excel.Range row5_TieuDe1 = oSheet.get_Range("B4", "B5");
                                        row5_TieuDe1.Merge();
                                        row5_TieuDe1.Font.Name = fontName;
                                        row5_TieuDe1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe1.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe1.Font.Bold = true;
                                        row5_TieuDe1.Interior.Color = Color.Yellow;

                                        row5_TieuDe1.Value2 = "Mã số NV";

                                        Excel.Range row5_TieuDe2 = oSheet.get_Range("C4", "C5");
                                        row5_TieuDe2.Merge();
                                        row5_TieuDe2.Font.Name = fontName;
                                        row5_TieuDe2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe2.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe2.Font.Bold = true;
                                        row5_TieuDe2.Interior.Color = Color.Yellow;
                                        row5_TieuDe2.Value2 = "Họ tên";



                                        Excel.Range row5_TieuDe3 = oSheet.get_Range("D4", "D5");
                                        row5_TieuDe3.Merge();
                                        row5_TieuDe3.Font.Name = fontName;
                                        row5_TieuDe3.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe3.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe3.Font.Bold = true;
                                        row5_TieuDe3.Interior.Color = Color.Yellow;
                                        row5_TieuDe3.Value2 = "Xí nghiệp/P.ban";

                                        Excel.Range row5_TieuDe4 = oSheet.get_Range("E4", "E5");
                                        row5_TieuDe4.Merge();
                                        row5_TieuDe4.Font.Name = fontName;
                                        row5_TieuDe4.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe4.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe4.Font.Bold = true;
                                        row5_TieuDe4.Interior.Color = Color.Yellow;
                                        row5_TieuDe4.Value2 = "Tổ";

                                        //tô màu
                                        //Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                                        //range.Cells.Interior.Color = System.Drawing.Color.Red;


                                        Excel.Range formatRange;
                                        int col = 6;

                                        while (iTNgay <= iDNgay)
                                        {
                                            oSheet.Cells[4, col] = Convert.ToDateTime(lk_TuNgay.EditValue).AddDays(iTNgay - 1);
                                            oSheet.Cells[4, col].Font.Name = fontName;
                                            oSheet.Cells[4, col].Font.Bold = true;
                                            oSheet.Cells[4, col].Interior.Color = Color.Yellow;
                                            oSheet.Cells[4, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                            oSheet.Cells[4, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                            oSheet.Cells[5, col] = "Đi trễ";
                                            oSheet.Cells[5, col].Font.Bold = true;
                                            oSheet.Cells[5, col].Interior.Color = Color.Yellow;
                                            oSheet.Cells[5, col].Font.Name = fontName;
                                            oSheet.Cells[5, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                            oSheet.Cells[5, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                                            oSheet.Cells[5, col + 1] = "Về sớm";
                                            oSheet.Cells[5, col + 1].Interior.Color = Color.Yellow;
                                            oSheet.Cells[5, col + 1].Font.Bold = true;
                                            oSheet.Cells[5, col + 1].Font.Name = fontName;
                                            oSheet.Cells[5, col + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                            oSheet.Cells[5, col + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                            oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[4, col + 1]].Merge();
                                            oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]].Merge();
                                            oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]].Merge();

                                            col = col + 2;
                                            iTNgay++;
                                        }
                                        oSheet.Cells[4, col] = "Đi trễ";
                                        oSheet.Cells[4, col].Font.Name = fontName;
                                        oSheet.Cells[4, col].Font.Bold = true;
                                        oSheet.Cells[4, col].Interior.Color = Color.Yellow;
                                        oSheet.Cells[4, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[4, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                        oSheet.Cells[5, col] = "Số lần đi trễ";
                                        oSheet.Cells[5, col].Font.Bold = true;
                                        oSheet.Cells[5, col].RowHeight = 20;
                                        oSheet.Cells[5, col].Interior.Color = Color.Yellow;
                                        oSheet.Cells[5, col].Font.Name = fontName;
                                        oSheet.Cells[5, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[5, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        


                                        oSheet.Cells[5, col + 1] = "Số phút đi trễ";
                                        oSheet.Cells[5, col + 1].Interior.Color = Color.Yellow;
                                        oSheet.Cells[5, col + 1].Font.Bold = true;
                                        oSheet.Cells[5, col+1].RowHeight = 20;
                                        oSheet.Cells[5, col + 1].Font.Name = fontName;
                                        oSheet.Cells[5, col + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[5, col + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                        oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[4, col + 1]].Merge();
                                        oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]].Merge();
                                        formatRange = oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]];
                                        formatRange.ColumnWidth = 15;

                                        oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]].Merge();
                                        formatRange = oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]];
                                        formatRange.ColumnWidth = 15;


                                        col = col + 2;
                                        oSheet.Cells[4, col] = "Về sớm";
                                        oSheet.Cells[4, col].Font.Name = fontName;
                                        oSheet.Cells[4, col].Font.Bold = true;

                                        oSheet.Cells[4, col].Interior.Color = Color.Yellow;
                                        oSheet.Cells[4, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[4, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                        oSheet.Cells[5, col] = "Số lần Về sớm";
                                        oSheet.Cells[5, col].Font.Bold = true;
                                        oSheet.Cells[5, col].Interior.Color = Color.Yellow;
                                        oSheet.Cells[5, col].RowHeight = 20;
                                        oSheet.Cells[5, col].Font.Name = fontName;
                                        oSheet.Cells[5, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[5, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                                        oSheet.Cells[5, col + 1] = "Số phút Về sớm";
                                        oSheet.Cells[5, col + 1].Interior.Color = Color.Yellow;
                                        oSheet.Cells[5, col + 1].RowHeight = 20;
                                        oSheet.Cells[5, col + 1].Font.Bold = true;
                                        oSheet.Cells[5, col + 1].Font.Name = fontName;
                                        oSheet.Cells[5, col + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[5, col + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                        oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[4, col + 1]].Merge();
                                        oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]].Merge();
                                        formatRange = oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]];
                                        formatRange.ColumnWidth = 15;


                                        oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]].Merge();
                                        formatRange = oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]];
                                        formatRange.ColumnWidth = 15;


                                        col = col + 2;

                                        oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[5, col]].Merge();
                                        oSheet.Cells[4, col] = "Tổng số lần";
                                        oSheet.Cells[4, col].Font.Name = fontName;
                                        oSheet.Cells[4, col].Font.Bold = true;
                                        oSheet.Cells[4, col].Interior.Color = Color.Yellow;
                                        oSheet.Cells[4, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[4, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        formatRange = oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[5, col]];
                                        formatRange.ColumnWidth = 15;

                                        oSheet.Range[oSheet.Cells[4, col+1], oSheet.Cells[5, col+1]].Merge();
                                        oSheet.Cells[4, col+1] = "Tổng số phút";
                                        oSheet.Cells[4, col+1].Font.Name = fontName;
                                        oSheet.Cells[4, col+1].Font.Bold = true;
                                        oSheet.Cells[4, col+1].Interior.Color = Color.Yellow;
                                        oSheet.Cells[4, col+1].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                        oSheet.Cells[4, col+1].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        formatRange = oSheet.Range[oSheet.Cells[4, col+1], oSheet.Cells[5, col+1]];
                                        formatRange.ColumnWidth = 15;

                                        oSheet.Range[oSheet.Cells[4, col+1], oSheet.Cells[5, col+1]].Merge();



                                        DataRow[] dr = dtBCGaiDoan.Select();
                                        string[,] rowData = new string[dr.Length, dtBCGaiDoan.Columns.Count];

                                        int rowCnt = 0;
                                        //int redRows = 7;
                                        foreach (DataRow row in dr)
                                        {
                                            for (col = 0; col < dtBCGaiDoan.Columns.Count; col++)
                                            {
                                                rowData[rowCnt, col] = row[col].ToString();
                                            }

                                            rowCnt++;
                                        }
                                        oSheet.get_Range("A6", lastColumn + (rowCnt+5).ToString()).Value2 = rowData;
                                        rowCnt = rowCnt + 5;
                                        string CurentColumn = string.Empty;
                                        for (col = 5; col < dtBCGaiDoan.Columns.Count; col++)
                                        {
                                            CurentColumn = CharacterIncrement(col);
                                            formatRange = oSheet.get_Range(CurentColumn + "6", CurentColumn + rowCnt.ToString());
                                            formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                            formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                        }

                                        ////Kẻ khung toàn bộ
                                        formatRange = oSheet.get_Range("A4", lastColumn + rowCnt.ToString());
                                        formatRange.Borders.Color = Color.Black;
                                        //dữ liệu
                                        formatRange = oSheet.get_Range("A6", lastColumn + rowCnt.ToString());
                                        formatRange.Font.Name = fontName;
                                        formatRange.Font.Size = fontSizeNoiDung;
                                        
                                        //stt

                                        formatRange = oSheet.get_Range("A5", "A" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        formatRange.ColumnWidth = 5;
                                        //ma nv
                                        formatRange = oSheet.get_Range("B6", "B" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 15;
                                        //ho ten
                                        formatRange = oSheet.get_Range("C5", "C" + (rowCnt + 5).ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 35;
                                        //xí nghiệp
                                        formatRange = oSheet.get_Range("D5", "D" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 20;
                                        //tổ
                                        formatRange = oSheet.get_Range("E5", "E" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 20;

                                        //CẠNH giữ côt động
                                        formatRange = oSheet.get_Range("F4", lastColumn + "5");
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                       
                                        if (rdo_DiTreVeSom.SelectedIndex == 0)
                                        {
                                            oWB.SaveAs("D:\\BangTongHopDiTre.xlsx",
                                        AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                                        }
                                        if (rdo_DiTreVeSom.SelectedIndex == 1)
                                        {
                                            oWB.SaveAs("D:\\BangTongHopVeSom.xlsx",
                                          AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                                        }
                                        else
                                        {
                                            oWB.SaveAs("D:\\BangTongHopDiTreVeSom.xlsx",
                                          AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        
                                    }



                                }
                                break;


                            case 3:
                                {
                                    try
                                    {
                                        System.Data.SqlClient.SqlConnection conn;
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        DataTable dtBCThang;

                                        //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangXacNhanGioQuetThe", conn);


                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangTongCongThang", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                        if (Convert.ToDateTime(lk_TuNgay.EditValue).Month != Convert.ToDateTime(lk_DenNgay.EditValue).Month)
                                        {
                                            XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTu ngay den ngay khong hop le"));
                                            return;
                                        }
                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dtBCThang = new DataTable();
                                        dtBCThang = ds.Tables[0].Copy();


                                        Excel.Application oXL;
                                        Excel._Workbook oWB;
                                        Excel._Worksheet oSheet;

                                        oXL = new Excel.Application();
                                        oXL.Visible = true;

                                        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                                        oSheet = (Excel._Worksheet)oWB.ActiveSheet;

                                        string fontName = "Times New Roman";
                                        int fontSizeTieuDe = 16;
                                        int fontSizeNoiDung = 12;

                                        int TotalColumn = 26;

                                        
                                        string lastColumn = string.Empty;
                                        lastColumn = CharacterIncrement(TotalColumn-1);

                                        Excel.Range row2_TieuDe_BaoCao0 = oSheet.get_Range("A1", lastColumn + "2");
                                        row2_TieuDe_BaoCao0.Merge();
                                        row2_TieuDe_BaoCao0.Font.Size = fontSizeTieuDe;
                                        row2_TieuDe_BaoCao0.Font.Name = fontName;
                                        row2_TieuDe_BaoCao0.Font.Bold = true;
                                        row2_TieuDe_BaoCao0.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row2_TieuDe_BaoCao0.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row2_TieuDe_BaoCao0.Value2 = "BÁO CÁO LAO ĐỘNG THÁNG (" + Convert.ToDateTime(LK_Thang.EditValue).ToString("MM/yyyy") + ")";
                                        
                                        //=====

                                        Excel.Range row3_TieuDe_BaoCao = oSheet.get_Range("A3", lastColumn + "3");
                                        row3_TieuDe_BaoCao.Merge();
                                        row3_TieuDe_BaoCao.Font.Size = fontSizeNoiDung;
                                        row3_TieuDe_BaoCao.Font.Name = fontName;
                                        row3_TieuDe_BaoCao.Font.Bold = true;
                                        row3_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row3_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row3_TieuDe_BaoCao.Value2 = "Công trong tháng (" + Convert.ToInt16((Convert.ToDateTime(LK_Thang.EditValue).AddMonths(1).AddDays(-1)).Day) + ")";

                                        Range row5_TieuDe_Format = oSheet.get_Range("A5", lastColumn + "6"); //27 + 31
                                        row5_TieuDe_Format.Font.Size = fontSizeNoiDung;
                                        row5_TieuDe_Format.Font.Name = fontName;
                                        row5_TieuDe_Format.Font.Bold = true;
                                        row5_TieuDe_Format.WrapText = true;
                                        row5_TieuDe_Format.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe_Format.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe_Format.Interior.Color = Color.Yellow;

                                        oSheet.get_Range("A6").RowHeight = 40;
                                        Excel.Range row5_TieuDe_Cot1 = oSheet.get_Range("A5", "A6");
                                        row5_TieuDe_Cot1.Merge();
                                        row5_TieuDe_Cot1.Value2 = "Stt";
                                        row5_TieuDe_Cot1.ColumnWidth = 8;

                                        Excel.Range row5_TieuDe_Cot2 = oSheet.get_Range("B5", "B6");
                                        row5_TieuDe_Cot2.Merge();
                                        row5_TieuDe_Cot2.Value2 = "Xí nghiệp/P.ban";
                                        row5_TieuDe_Cot2.ColumnWidth = 20;

                                        Excel.Range row5_TieuDe_Cot3 = oSheet.get_Range("C5", "C6");
                                        row5_TieuDe_Cot3.Merge();
                                        row5_TieuDe_Cot3.Value2 = "Tổ";
                                        row5_TieuDe_Cot3.ColumnWidth = 20;

                                        Excel.Range row5_TieuDe_Cot4 = oSheet.get_Range("D5", "D6");
                                        row5_TieuDe_Cot4.Merge();
                                        row5_TieuDe_Cot4.Value2 = "Công trong tháng";
                                        row5_TieuDe_Cot4.ColumnWidth = 8;

                                        Excel.Range row5_TieuDe_Cot5 = oSheet.get_Range("E5", "E6");
                                        row5_TieuDe_Cot5.Merge();
                                        row5_TieuDe_Cot5.Value2 = "LĐ T.tế";
                                        row5_TieuDe_Cot5.ColumnWidth = 8;

                                        Excel.Range row5_TieuDe_Cot6 = oSheet.get_Range("F5", "F6");
                                        row5_TieuDe_Cot6.Merge();
                                        row5_TieuDe_Cot6.Value2 = "LĐ BQ";
                                        row5_TieuDe_Cot6.ColumnWidth = 8;

                                        Excel.Range row5_TieuDe_Cot79 = oSheet.get_Range("G5", "I5");
                                        row5_TieuDe_Cot79.Merge();
                                        row5_TieuDe_Cot79.Value2 = "Lao động tăng";
                                        Excel.Range row5_TieuDe_Cot7 = oSheet.get_Range("G6", "G6");
                                        row5_TieuDe_Cot7.ColumnWidth = 6;
                                        row5_TieuDe_Cot7.Value2 = "+";
                                        Excel.Range row5_TieuDe_Cot8 = oSheet.get_Range("H6", "H6");
                                        row5_TieuDe_Cot8.ColumnWidth = 6;
                                        row5_TieuDe_Cot8.Value2 = "CN";
                                        Excel.Range row5_TieuDe_Cot9 = oSheet.get_Range("I6", "I6");
                                        row5_TieuDe_Cot9.ColumnWidth = 6;
                                        row5_TieuDe_Cot9.Value2 = "Đào tạo";

                                        Excel.Range row5_TieuDe_Cot1012 = oSheet.get_Range("J5", "L5");
                                        row5_TieuDe_Cot1012.Merge();
                                        row5_TieuDe_Cot1012.Value2 = "Lao động giảm";
                                        Excel.Range row5_TieuDe_Cot10 = oSheet.get_Range("J6");
                                        row5_TieuDe_Cot10.ColumnWidth = 6;
                                        row5_TieuDe_Cot10.Value2 = "+";
                                        Excel.Range row5_TieuDe_Cot11 = oSheet.get_Range("K6");
                                        row5_TieuDe_Cot11.ColumnWidth = 6;
                                        row5_TieuDe_Cot11.Value2 = "BV";
                                        Excel.Range row5_TieuDe_Cot12 = oSheet.get_Range("L6");
                                        row5_TieuDe_Cot12.ColumnWidth = 6;
                                        row5_TieuDe_Cot12.Value2 = "NV";
                                        
                                        Excel.Range row5_TieuDe_Cot13 = oSheet.get_Range("M5","M6");
                                        row5_TieuDe_Cot13.Merge();
                                        row5_TieuDe_Cot13.ColumnWidth = 8;
                                        row5_TieuDe_Cot13.Value2 = "Công chế độ";

                                        Excel.Range row5_TieuDe_Cot1417 = oSheet.get_Range("N5", "Q5");
                                        row5_TieuDe_Cot1417.Merge();
                                        row5_TieuDe_Cot1417.Value2 = "Công thực tế ngoài giờ";
                                        Excel.Range row5_TieuDe_Cot14 = oSheet.get_Range("N6");
                                        row5_TieuDe_Cot14.ColumnWidth = 8;
                                        row5_TieuDe_Cot14.Value2 = "Trong giờ";
                                        Excel.Range row5_TieuDe_Cot15 = oSheet.get_Range("O6");
                                        row5_TieuDe_Cot15.ColumnWidth = 8;
                                        row5_TieuDe_Cot15.Value2 = "1,5";
                                        Excel.Range row5_TieuDe_Cot16 = oSheet.get_Range("P6");
                                        row5_TieuDe_Cot16.ColumnWidth = 8;
                                        row5_TieuDe_Cot16.Value2 = "2";
                                        Excel.Range row5_TieuDe_Cot17 = oSheet.get_Range("Q6");
                                        row5_TieuDe_Cot17.ColumnWidth = 8;
                                        row5_TieuDe_Cot17.Value2 = "+";

                                        Excel.Range row5_TieuDe_Cot18 = oSheet.get_Range("R5","R6");
                                        row5_TieuDe_Cot18.Merge();
                                        row5_TieuDe_Cot18.ColumnWidth = 8;
                                        row5_TieuDe_Cot18.Value2 = "% Công thực tế so công chế độ";

                                        Excel.Range row5_TieuDe_Cot1926 = oSheet.get_Range("S5","Z5");
                                        row5_TieuDe_Cot1926.Merge();
                                        row5_TieuDe_Cot1926.Value2 = "Các loại công vắng mặt";
                                        Excel.Range row5_TieuDe_Cot19 = oSheet.get_Range("S6");
                                        row5_TieuDe_Cot19.Value2 = "+";
                                        Excel.Range row5_TieuDe_Cot20 = oSheet.get_Range("T6");
                                        row5_TieuDe_Cot20.Value2 = "P";
                                        Excel.Range row5_TieuDe_Cot21 = oSheet.get_Range("U6");
                                        row5_TieuDe_Cot21.Value2 = "L";
                                        Excel.Range row5_TieuDe_Cot22 = oSheet.get_Range("V6");
                                        row5_TieuDe_Cot22.Value2 = "BU";
                                        Excel.Range row5_TieuDe_Cot23 = oSheet.get_Range("W6");
                                        row5_TieuDe_Cot23.Value2 = "BHXH";
                                        Excel.Range row5_TieuDe_Cot24 = oSheet.get_Range("X6");
                                        row5_TieuDe_Cot24.Value2 = "HL";
                                        Excel.Range row5_TieuDe_Cot25 = oSheet.get_Range("Y6");
                                        row5_TieuDe_Cot25.Value2 = "Ro, O";
                                        Excel.Range row5_TieuDe_Cot26 = oSheet.get_Range("Z6");
                                        row5_TieuDe_Cot26.Value2 = "RN";

                                        Excel.Range formatRange;
                                        formatRange = oSheet.get_Range("S5", "Z5");
                                        formatRange.ColumnWidth = 6;


                                        DataRow[] dr = dtBCThang.Select();
                                        int sDonVi = 0;
                                        int rowCnt = 7;
                                        int dem = 1;
                                        foreach (DataRow row in dr)
                                        {
                                            if (Convert.ToInt32(row["ID_DV"].ToString()) != sDonVi)
                                            {
                                                Excel.Range row_DonVi = oSheet.get_Range("B" + rowCnt, "C" + rowCnt);
                                                row_DonVi.Merge();
                                                row_DonVi.Value2 = row["TEN_DV"].ToString();
                                                rowCnt++;
                                            }

                                            Excel.Range row_A = oSheet.get_Range("A" + rowCnt);
                                            row_A.Value2 = dem;
                                            Excel.Range row_B = oSheet.get_Range("B" + rowCnt);
                                            row_B.Value2 = row["TEN_XN"].ToString();
                                            Excel.Range row_C = oSheet.get_Range("C" + rowCnt);
                                            row_C.Value2 = row["TEN_TO"].ToString();
                                            Excel.Range row_D = oSheet.get_Range("D" + rowCnt);
                                            row_D.Value2 = row["CONG_CHUAN"].ToString();
                                            Excel.Range row_E = oSheet.get_Range("E" + rowCnt);
                                            row_E.Value2 = row["LDTT"].ToString();
                                            Excel.Range row_F = oSheet.get_Range("F" + rowCnt);
                                            row_F.Value2 = "=M" + rowCnt + "/D" + rowCnt;
                                            Excel.Range row_G = oSheet.get_Range("G" + rowCnt);
                                            row_G.Value2 = "=SUM(H" + rowCnt + ":I" + rowCnt + ")";
                                            Excel.Range row_H = oSheet.get_Range("H" + rowCnt);
                                            row_H.Value2 = row["LD_TANG_CN"].ToString();
                                            Excel.Range row_I = oSheet.get_Range("I" + rowCnt);
                                            row_I.Value2 = row["LD_TANG_DT"].ToString();
                                            Excel.Range row_J = oSheet.get_Range("J" + rowCnt);
                                            row_J.Value2 = "=SUM(K" + rowCnt + ":L" + rowCnt + ")";
                                            Excel.Range row_K = oSheet.get_Range("K" + rowCnt);
                                            row_K.Value2 = row["LD_GIAM_BV"].ToString();
                                            Excel.Range row_L = oSheet.get_Range("L" + rowCnt);
                                            row_L.Value2 = row["LD_GIAM_NV"].ToString();
                                            Excel.Range row_M = oSheet.get_Range("M" + rowCnt);
                                            row_M.Value2 = "=N" + rowCnt + "+S" + rowCnt; 
                                            Excel.Range row_N = oSheet.get_Range("N" + rowCnt);
                                            row_N.Value2 = row["SN_LV"].ToString();
                                            Excel.Range row_O = oSheet.get_Range("O" + rowCnt);
                                            row_O.Value2 = row["SN_TC_NT"].ToString();
                                            Excel.Range row_P = oSheet.get_Range("P" + rowCnt);
                                            row_P.Value2 = row["SN_TC_CN"].ToString();
                                            Excel.Range row_Q = oSheet.get_Range("Q" + rowCnt);
                                            row_Q.Value2 = "=SUM(N" + rowCnt + ":P" + rowCnt + ")";
                                            Excel.Range row_R = oSheet.get_Range("R" + rowCnt);
                                            row_R.Value2 = "=Q" + rowCnt + "/M" + rowCnt + "*100";
                                            Excel.Range row_S = oSheet.get_Range("S" + rowCnt);
                                            row_S.Value2 = "=SUM(T" + rowCnt + ":Z" + rowCnt + ")"; ;
                                            Excel.Range row_T = oSheet.get_Range("T" + rowCnt);
                                            row_T.Value2 = row["SNV_P"].ToString();
                                            Excel.Range row_U = oSheet.get_Range("U" + rowCnt);
                                            row_U.Value2 = row["SNV_L"].ToString();
                                            Excel.Range row_V = oSheet.get_Range("V" + rowCnt);
                                            row_V.Value2 = row["SNV_BU"].ToString();
                                            Excel.Range row_W = oSheet.get_Range("W" + rowCnt);
                                            row_W.Value2 = row["SNV_BHXH"].ToString();
                                            Excel.Range row_X = oSheet.get_Range("X" + rowCnt);
                                            row_X.Value2 = row["SNV_HL"].ToString();
                                            Excel.Range row_Y = oSheet.get_Range("Y" + rowCnt);
                                            row_Y.Value2 = row["SNV_KL"].ToString();
                                            Excel.Range row_Z = oSheet.get_Range("Z" + rowCnt);
                                            row_Z.Value2 = row["SNV_RN"].ToString();

                                            dem++;
                                            rowCnt++;
                                            sDonVi = Convert.ToInt32(row["ID_DV"].ToString());
                                            
                                        }

                                        //Kẻ khung toàn bộ
                                        //Excel.Range formatRange;
                                        rowCnt--;
                                        formatRange = oSheet.get_Range("A5", lastColumn + rowCnt.ToString());
                                        formatRange.Borders.Color = Color.Black;

                                        formatRange = oSheet.get_Range("F7", "F" + rowCnt.ToString());
                                        formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";

                                        formatRange = oSheet.get_Range("G7", "L" + rowCnt.ToString());
                                        formatRange.NumberFormat = "#,##0;(#,##0); ; ";

                                        formatRange = oSheet.get_Range("M7", lastColumn + rowCnt.ToString());
                                        formatRange.NumberFormat = "#,##0.00;(#,##0.00); ; ";

                                        //dữ liệu
                                        formatRange = oSheet.get_Range("A7", lastColumn + rowCnt.ToString());
                                        formatRange.Font.Name = fontName;
                                        formatRange.Font.Size = fontSizeNoiDung;


                                        ////CẠNH giữ côt động
                                        //formatRange = oSheet.get_Range("F3", lastColumn + "4");
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        //oWB.SaveAs("D:\\BaoCaoLaoDongThang.xlsx",
                                        //AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                break;
                            case 4:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    dt = new DataTable();
                                    string sTieuDe = "BÁO CÁO NGHỈ BỎ VIỆC";
                                    frm.rpt = new rptBaoCaoNghiBoViecThang(Convert.ToDateTime(LK_Thang.EditValue), sTieuDe);
                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBaoCaoNghiBoViecThang", conn);
                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNGAY", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue).ToString("yyyy/MM/dd");
                                        cmd.Parameters.Add("@DNGAY", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue).ToString("yyyy/MM/dd");
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }
                                    frm.ShowDialog();
                                break;
                                }
                            case 5:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    dt = new DataTable();
                                    string sTieuDe = "DANH SÁCH CHUYỂN CÔNG TÁC THÁNG";
                                    frm.rpt = new rptDSChuyenCongTac(lk_DenNgay.DateTime, sTieuDe, Convert.ToDateTime(NgayIn.EditValue));

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDanhSachChuyenCongTac", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_DenNgay.EditValue);
                                        cmd.Parameters.Add("@TNGAY", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch
                                    { }
                                    frm.ShowDialog();
                                    break;
                                }
                            case 6:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    dt = new DataTable();
                                    string sTieuDe = "ĐĂNG KÝ LÀM THÊM GIỜ";
                                    frm.rpt = new rptDKLamThemGio(lk_TuNgay.DateTime, sTieuDe, LK_XI_NGHIEP.Text.ToString());

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        
                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBieuMauDangKyLamThemGio", conn);
                                        
                                        cmd.Parameters.Add("@ID_DV", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@ID_XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@ID_TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Ngay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);

                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                        //DataSet ds = new DataSet();
                                        dt = new DataTable();
                                        adp.Fill(dt);
                                        
                                        //dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    }
                                    catch(Exception ex )
                                    { }
                                    frm.ShowDialog();
                                    break;
                                }
                        }
                        
                        break;
                    }
                default:
                    break;
            }
        }
        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }

        private void ucBaoCaoTongHopThang_Load(object sender, EventArgs e)
        {
            LoadCboDonVi();
            LoadCboXiNghiep();
            LoadCboTo();
            LoadNgay();
            Commons.OSystems.SetDateEditFormat(lk_TuNgay);
            Commons.OSystems.SetDateEditFormat(lk_DenNgay);
            //LoadTinhTrangHopDong();

            //lk_DenNgay.EditValue = DateTime.Today;
            //DateTime dtTN = DateTime.Today;
            //DateTime dtDN = DateTime.Today;
            ////dTuNgay.EditValue = dtTN.AddDays((-dtTN.Day) + 1);
            //dtDN = dtDN.AddMonths(1);
            //dtDN = dtDN.AddDays(-(dtDN.Day));
            //LK_NgayXemBaoCao.EditValue = dtDN;
            NgayIn.EditValue = DateTime.Today;

        }

        private void LoadNgay()
        {
            try
            {
                string sNam = DateTime.Today.Year.ToString();
                string sThang = "";
                DataTable dtthang = new DataTable();
                dtthang.Columns.Add("M", typeof(string));
                dtthang.Columns.Add("Y", typeof(string));
                dtthang.Columns.Add("THANG", typeof(string));

                for (int col = 1; col <= 12; col++)
                {
                    sThang = "0" + col.ToString();
                    sThang = sThang.Substring(sThang.Length-2, 2);
                    dtthang.Rows.Add(sThang, sNam, sThang + "/" + sNam);
                }


                //ItemForDateThang.Visibility = LayoutVisibility.Never;
                //DataTable dtthang = new DataTable();
                //string sSql = "SELECT DISTINCT SUBSTRING(CONVERT(VARCHAR(10),TU_NGAY,103),4,2) as M, RIGHT(CONVERT(VARCHAR(10),TU_NGAY,103),4) AS Y ,RIGHT(CONVERT(VARCHAR(10),TU_NGAY,103),7) AS THANG FROM dbo.CHAM_CONG ORDER BY Y DESC , M DESC";
                //dtthang.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdThang, grvThang, dtthang, false, true, true, true, true, this.Name);
                grvThang.Columns["M"].Visible = false;
                grvThang.Columns["Y"].Visible = false;

                LK_Thang.Text = grvThang.GetFocusedRowCellValue("THANG").ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadCboDonVi()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboDON_VI", Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(LK_DON_VI, dt, "ID_DV", "TEN_DV", "TEN_DV");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadCboXiNghiep()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboXI_NGHIEP", LK_DON_VI.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(LK_XI_NGHIEP, dt, "ID_XN", "TEN_XN", "TEN_XN");
                LK_XI_NGHIEP.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        private void LoadCboTo()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboTO", LK_DON_VI.EditValue, LK_XI_NGHIEP.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
                Commons.Modules.ObjSystems.MLoadSearchLookUpEdit(LK_TO, dt, "ID_TO", "TEN_TO", "TEN_TO");
                LK_TO.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }

        }

        private void LoadTinhTrangHopDong()
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComBoTinhTrangHopDong", Commons.Modules.UserName, Commons.Modules.TypeLanguage, 1));
            //Commons.Modules.ObjSystems.MLoadLookUpEdit(LK_LOAI_HD, dt, "ID_TT_HT", "TEN_TT_HT", "TEN_TT_HT");
        }

        private void LK_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            LoadCboXiNghiep();
            LoadCboTo();
        }

        private void LK_XI_NGHIEP_EditValueChanged(object sender, EventArgs e)
        {
            LoadCboTo();
        }

        private void rdo_ChonBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdo_ChonBaoCao.SelectedIndex)
            {
                case 0:
                    {
                        rdo_DiTreVeSom.Visible = false;

                    }
                    break;
                case 1:
                    {
                        rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 2:
                    {
                        rdo_DiTreVeSom.Visible = true;
                    }
                    break;
                case 3:
                    {
                        rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 4:
                    {
                        rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 5:
                    {
                        rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 6:
                    {
                        rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void grvThang_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                GridView grv = (GridView)sender;
                LK_Thang.Text = grvThang.GetFocusedRowCellValue("THANG").ToString();
            }
            catch { }
            LK_Thang.ClosePopup();

        }

        

       
        private void windowsUIButton_Click(object sender, EventArgs e)
        {

        }

        private void rdo_DiTreVeSom_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdo_ChonBaoCao.SelectedIndex)
            {
                case 0:
                    {
                        rdo_DiTreVeSom.Visible = true;

                    }
                    break;
                case 1:
                    {
                        rdo_DiTreVeSom.Visible = true;
                    }
                    break;
                case 2:
                    {
                        rdo_DiTreVeSom.Visible = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void calThang_DateTimeCommit_1(object sender, EventArgs e)
        {
            try
            {
                LK_Thang.Text = calThang.DateTime.ToString("MM/yyyy");
                DataTable dtTmp = Commons.Modules.ObjSystems.ConvertDatatable(grdThang);
                DataRow[] dr;
                dr = dtTmp.Select("NGAY_TTXL" + "='" + LK_Thang.Text + "'", "NGAY_TTXL", DataViewRowState.CurrentRows);
                if (dr.Count() == 1)
                {
                }
                else { }
            }
            catch (Exception ex)
            {
                LK_Thang.Text = calThang.DateTime.ToString("MM/yyyy");
            }
            LK_Thang.ClosePopup();
        }

        private void LK_Thang_EditValueChanged(object sender, EventArgs e)
        {
            DateTime tungay = Convert.ToDateTime(LK_Thang.EditValue);
            DateTime denngay = Convert.ToDateTime(LK_Thang.EditValue).AddMonths(+1);
            lk_TuNgay.EditValue =Convert.ToDateTime("01/"+ tungay.Month+"/"+ tungay.Year);
            lk_DenNgay.EditValue =Convert.ToDateTime("01/"+ denngay.Month+"/"+ tungay.Year).AddDays(-1);
        }
    }
}
