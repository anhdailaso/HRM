using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Vs.Payroll;
using Vs.Report;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

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
                                     dt = new DataTable();
                                    string sTieuDe = "DANH SÁCH VẮNG ĐẦU GIỜ THEO NGÀY VÀ ĐƠN VỊ";
                                    frm.rpt = new rptDSVangDauGioTheoDV(lk_DenNgay.DateTime, sTieuDe, Convert.ToDateTime(LK_Thang.EditValue));

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSVangNgayDV", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(LK_Thang.EditValue);
                                        cmd.Parameters.Add("@LoaiBC", SqlDbType.Int).Value = 1;
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
                                }
                                break;
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn1;
                                     dt = new DataTable();
                                    string sTieuDe1 = "DANH SÁCH CÔNG NHÂN VẮNG ĐẦU GIỜ NGÀY";
                                    frm.rpt = new rptDSVangDauGioTheoNgay(lk_DenNgay.DateTime, sTieuDe1, Convert.ToDateTime(LK_Thang.EditValue));

                                    try
                                    {
                                        conn1 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn1.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSVangNgayDV", conn1);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(LK_Thang.EditValue);
                                        cmd.Parameters.Add("@LoaiBC", SqlDbType.Int).Value = 0;
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
                                    catch(Exception ex)
                                    {
                                        XtraMessageBox.Show(ex.Message.ToString());
                                    }


                                    frm.ShowDialog();
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

                                        row5_TieuDe1.Value2 = "Mã NV";

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
                                        row5_TieuDe3.Value2 = "Xí nghiệp";

                                        Excel.Range row5_TieuDe4 = oSheet.get_Range("E4", "e6");
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
                                        formatRange = oSheet.get_Range("e6", "E" + rowCnt.ToString());
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
                                        lastColumn = CharacterIncrement(dtBCGaiDoan.Columns.Count - 1);
                                        lastColumn = "W";
                                        Excel.Range row2_TieuDe_BaoCao0 = oSheet.get_Range("A1", lastColumn + "1");
                                        row2_TieuDe_BaoCao0.Merge();
                                        row2_TieuDe_BaoCao0.Font.Size = fontSizeTieuDe;
                                        row2_TieuDe_BaoCao0.Font.Name = fontName;
                                        row2_TieuDe_BaoCao0.Font.Bold = true;
                                        row2_TieuDe_BaoCao0.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row2_TieuDe_BaoCao0.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row2_TieuDe_BaoCao0.Value2 = "BÁO CÁO LAO ĐỘNG THÁNG (" + Convert.ToDateTime(LK_Thang.EditValue).ToString("MM/yyyy") + ")";
                                        
                                        //=====

                                        Excel.Range row2_TieuDe_BaoCao = oSheet.get_Range("A2", lastColumn + "2");
                                        row2_TieuDe_BaoCao.Merge();
                                        row2_TieuDe_BaoCao.Font.Size = fontSizeNoiDung;
                                        row2_TieuDe_BaoCao.Font.Name = fontName;
                                        row2_TieuDe_BaoCao.Font.Bold = true;
                                        row2_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row2_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row2_TieuDe_BaoCao.Value2 = "Công trong tháng (" + Convert.ToInt16((Convert.ToDateTime(LK_Thang.EditValue).AddMonths(1).AddDays(-1)).Day) + ")";
                                        
                                        oSheet.get_Range("A4").RowHeight = 40;
                                        Excel.Range row5_TieuDe = oSheet.get_Range("A3", "A4");
                                        row5_TieuDe.Merge();
                                        row5_TieuDe.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe.Font.Name = fontName;
                                        row5_TieuDe.Font.Bold = true;
                                        row5_TieuDe.Value2 = "Stt";
                                        row5_TieuDe.Interior.Color = Color.Yellow;

                                        Excel.Range row5_TieuDe1 = oSheet.get_Range("B3", "B4");
                                        row5_TieuDe1.Merge();
                                        row5_TieuDe1.Font.Name = fontName;
                                        row5_TieuDe1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe1.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe1.Font.Bold = true;
                                        row5_TieuDe1.Interior.Color = Color.Yellow;

                                        row5_TieuDe1.Value2 = "Đơn vị";

                                        Excel.Range row5_TieuDe2 = oSheet.get_Range("C3", "C4");
                                        row5_TieuDe2.Merge();
                                        row5_TieuDe2.Font.Name = fontName;
                                        row5_TieuDe2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe2.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe2.Font.Bold = true;
                                        row5_TieuDe2.Interior.Color = Color.Yellow;
                                        row5_TieuDe2.WrapText = true;
                                        row5_TieuDe2.Value2 = "Công trong tháng";



                                        Excel.Range row5_TieuDe3 = oSheet.get_Range("D3", "D4");
                                        row5_TieuDe3.Merge();
                                        row5_TieuDe3.Font.Name = fontName;
                                        row5_TieuDe3.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe3.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe3.Font.Bold = true;
                                        row5_TieuDe3.Interior.Color = Color.Yellow;
                                        row5_TieuDe3.Value2 = "LĐ T.tế";

                                        Excel.Range row5_TieuDe4 = oSheet.get_Range("E3", "E4");
                                        row5_TieuDe4.Merge();
                                        row5_TieuDe4.Font.Name = fontName;
                                        row5_TieuDe4.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe4.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe4.Font.Bold = true;
                                        row5_TieuDe4.Interior.Color = Color.Yellow;
                                        row5_TieuDe4.Value2 = "LĐ BQ";

                                        Excel.Range row5_TieuDe6 = oSheet.get_Range("F3", "G3");
                                        row5_TieuDe6.Merge();
                                        row5_TieuDe6.Font.Name = fontName;
                                        row5_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe6.Font.Bold = true;
                                        row5_TieuDe6.Interior.Color = Color.Yellow;
                                        row5_TieuDe6.Value2 = "Lao động tăng";

                                        Excel.Range row4_TieuDe6 = oSheet.get_Range("F4");
                                        row4_TieuDe6.Font.Name = fontName;
                                        row4_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row4_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row4_TieuDe6.Font.Bold = true;
                                        row4_TieuDe6.Interior.Color = Color.Yellow;
                                        row4_TieuDe6.Value2 = "CN";

                                        Excel.Range row4_TieuDe6a = oSheet.get_Range("G4");
                                        row4_TieuDe6a.Font.Name = fontName;
                                        row4_TieuDe6a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row4_TieuDe6a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row4_TieuDe6a.Font.Bold = true;
                                        row4_TieuDe6a.Interior.Color = Color.Yellow;
                                        row4_TieuDe6a.Value2 = "Đào tạo";

                                        Excel.Range row5_TieuDe6a = oSheet.get_Range("H3", "J3");
                                        row5_TieuDe6a.Merge();
                                        row5_TieuDe6a.Font.Name = fontName;
                                        row5_TieuDe6a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe6a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe6a.Font.Bold = true;
                                        row5_TieuDe6a.Interior.Color = Color.Yellow;
                                        row5_TieuDe6a.Value2 = "Lao động giảm";

                                        Excel.Range row5a_TieuDe6 = oSheet.get_Range("H4");
                                        row5a_TieuDe6.Font.Name = fontName;
                                        row5a_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5a_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5a_TieuDe6.Font.Bold = true;
                                        row5a_TieuDe6.Interior.Color = Color.Yellow;
                                        row5a_TieuDe6.Value2 = "+";

                                        Excel.Range row5b_TieuDe6 = oSheet.get_Range("I4");
                                        row5b_TieuDe6.Font.Name = fontName;
                                        row5b_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5b_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5b_TieuDe6.Font.Bold = true;
                                        row5b_TieuDe6.Interior.Color = Color.Yellow;
                                        row5b_TieuDe6.Value2 = "BV";

                                        Excel.Range row5c_TieuDe6 = oSheet.get_Range("J4");
                                        row5c_TieuDe6.Font.Name = fontName;
                                        row5c_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe6.Font.Bold = true;
                                        row5c_TieuDe6.Interior.Color = Color.Yellow;
                                        row5c_TieuDe6.WrapText = true;
                                        row5c_TieuDe6.Value2 = "NV";

                                        Excel.Range row5_TieuDe7 = oSheet.get_Range("K3","K4");
                                        row5_TieuDe7.Merge();
                                        row5_TieuDe7.Font.Name = fontName;
                                        row5_TieuDe7.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe7.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe7.Font.Bold = true;
                                        row5_TieuDe7.Interior.Color = Color.Yellow;
                                        row5_TieuDe7.WrapText = true;
                                        row5_TieuDe7.Value2 = "Công chế độ";

                                        Excel.Range row5_TieuDe8 = oSheet.get_Range("L3", "O3");
                                        row5_TieuDe8.Merge();
                                        row5_TieuDe8.Font.Name = fontName;
                                        row5_TieuDe8.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe8.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe8.Font.Bold = true;
                                        row5_TieuDe8.Interior.Color = Color.Yellow;
                                        row5_TieuDe8.Value2 = "CÔNG THỰC TẾ Ngoài giờ";

                                        Excel.Range row5a_TieuDe8a = oSheet.get_Range("L4");
                                        row5a_TieuDe8a.Font.Name = fontName;
                                        row5a_TieuDe8a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5a_TieuDe8a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5a_TieuDe8a.Font.Bold = true;
                                        row5a_TieuDe8a.Interior.Color = Color.Yellow;
                                        row5a_TieuDe8a.Value2 = "Trong giờ";

                                        Excel.Range row5b_TieuDe8b = oSheet.get_Range("M4");
                                        row5b_TieuDe8b.Font.Name = fontName;
                                        row5b_TieuDe8b.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5b_TieuDe8b.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5b_TieuDe8b.Font.Bold = true;
                                        row5b_TieuDe8b.Interior.Color = Color.Yellow;
                                        row5b_TieuDe8b.Value2 = "1,5";

                                        Excel.Range row5c_TieuDe8c = oSheet.get_Range("N4");
                                        row5c_TieuDe8c.Font.Name = fontName;
                                        row5c_TieuDe8c.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe8c.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe8c.Font.Bold = true;
                                        row5c_TieuDe8c.Interior.Color = Color.Yellow;
                                        row5c_TieuDe8c.WrapText = true;
                                        row5c_TieuDe8c.Value2 = "2";

                                        Excel.Range row5c_TieuDe8d = oSheet.get_Range("O4");
                                        row5c_TieuDe8d.Font.Name = fontName;
                                        row5c_TieuDe8d.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe8d.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe8d.Font.Bold = true;
                                        row5c_TieuDe8d.Interior.Color = Color.Yellow;
                                        row5c_TieuDe8d.WrapText = true;
                                        row5c_TieuDe8d.Value2 = "+";

                                        Excel.Range row5c_TieuDe9 = oSheet.get_Range("P3","P4");
                                        row5c_TieuDe9.Merge();
                                        row5c_TieuDe9.Font.Name = fontName;
                                        row5c_TieuDe9.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe9.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe9.Font.Bold = true;
                                        row5c_TieuDe9.ColumnWidth = 15;
                                        row5c_TieuDe9.Interior.Color = Color.Yellow;
                                        row5c_TieuDe9.WrapText = true;
                                        row5c_TieuDe9.Value2 = "% Công thực tế so công chế độ";

                                        Excel.Range row5c_TieuDe10 = oSheet.get_Range("Q3","W3");
                                        row5c_TieuDe10.Merge();
                                        row5c_TieuDe10.Font.Name = fontName;
                                        row5c_TieuDe10.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe10.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe10.Font.Bold = true;
                                        row5c_TieuDe10.Interior.Color = Color.Yellow;
                                        row5c_TieuDe10.WrapText = true;
                                        row5c_TieuDe10.Value2 = "CÁC LOẠI CÔNG VẮNG MẶT";

                                        Excel.Range row5a_TieuDe11a = oSheet.get_Range("Q4");
                                        row5a_TieuDe11a.Font.Name = fontName;
                                        row5a_TieuDe11a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5a_TieuDe11a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5a_TieuDe11a.Font.Bold = true;
                                        row5a_TieuDe11a.Interior.Color = Color.Yellow;
                                        row5a_TieuDe11a.Value2 = "+";

                                        Excel.Range row5b_TieuDe11b = oSheet.get_Range("R4");
                                        row5b_TieuDe11b.Font.Name = fontName;
                                        row5b_TieuDe11b.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5b_TieuDe11b.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5b_TieuDe11b.Font.Bold = true;
                                        row5b_TieuDe11b.Interior.Color = Color.Yellow;
                                        row5b_TieuDe11b.Value2 = "P";

                                        Excel.Range row5c_TieuDe11c = oSheet.get_Range("S4");
                                        row5c_TieuDe11c.Font.Name = fontName;
                                        row5c_TieuDe11c.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe11c.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe11c.Font.Bold = true;
                                        row5c_TieuDe11c.Interior.Color = Color.Yellow;
                                        row5c_TieuDe11c.WrapText = true;
                                        row5c_TieuDe11c.Value2 = "NL";

                                        Excel.Range row5c_TieuDe11d = oSheet.get_Range("T4");
                                        row5c_TieuDe11d.Font.Name = fontName;
                                        row5c_TieuDe11d.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe11d.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe11d.Font.Bold = true;
                                        row5c_TieuDe11d.Interior.Color = Color.Yellow;
                                        row5c_TieuDe11d.WrapText = true;
                                        row5c_TieuDe11d.Value2 = "NB";

                                        Excel.Range row5c_TieuDe11e = oSheet.get_Range("U4");
                                        row5c_TieuDe11e.Font.Name = fontName;
                                        row5c_TieuDe11e.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe11e.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe11e.Font.Bold = true;
                                        row5c_TieuDe11e.Interior.Color = Color.Yellow;
                                        row5c_TieuDe11e.WrapText = true;
                                        row5c_TieuDe11e.Value2 = "BHXH";

                                        Excel.Range row5c_TieuDe11f = oSheet.get_Range("V4");
                                        row5c_TieuDe11f.Font.Name = fontName;
                                        row5c_TieuDe11f.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe11f.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe11f.Font.Bold = true;
                                        row5c_TieuDe11f.ColumnWidth = 15;
                                        row5c_TieuDe11f.Interior.Color = Color.Yellow;
                                        row5c_TieuDe11f.WrapText = true;
                                        row5c_TieuDe11f.Value2 = "Nghỉ hưởng lương";

                                        Excel.Range row5c_TieuDe11g = oSheet.get_Range("W4");
                                        row5c_TieuDe11g.Font.Name = fontName;
                                        row5c_TieuDe11g.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe11g.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe11g.Font.Bold = true;
                                        row5c_TieuDe11g.ColumnWidth = 15;
                                        row5c_TieuDe11g.Interior.Color = Color.Yellow;
                                        row5c_TieuDe11g.WrapText = true;
                                        row5c_TieuDe11g.Value2 = "Nghỉ không lương, không lý do";
                                        //tô màu
                                        //Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                                        //range.Cells.Interior.Color = System.Drawing.Color.Red;


                                        Excel.Range formatRange;
                                        int col = 6;

                                      

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
                                        oSheet.get_Range("A6", lastColumn + (rowCnt + 5).ToString()).Value2 = rowData;
                                        rowCnt = rowCnt + 5;
                                        //string CurentColumn = string.Empty;
                                        //for (col = 5; col < dtBCGaiDoan.Columns.Count; col++)
                                        //{
                                        //    CurentColumn = CharacterIncrement(col);
                                        //    formatRange = oSheet.get_Range(CurentColumn + "6", CurentColumn + rowCnt.ToString());
                                        //    formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                        //    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                        //}

                                        ////Kẻ khung toàn bộ
                                        formatRange = oSheet.get_Range("A3", lastColumn + rowCnt.ToString());
                                        formatRange.Borders.Color = Color.Black;
                                        //dữ liệu
                                        //formatRange = oSheet.get_Range("A6", lastColumn + rowCnt.ToString());
                                        //formatRange.Font.Name = fontName;
                                        //formatRange.Font.Size = fontSizeNoiDung;

                                        //stt

                                        formatRange = oSheet.get_Range("A5", "A" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        formatRange.ColumnWidth = 5;
                                        //ma nv
                                        formatRange = oSheet.get_Range("B5", "B" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 40;
                                        //ho ten
                                        formatRange = oSheet.get_Range("C5", "C" + (rowCnt + 5).ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 11;
                                        //xí nghiệp
                                        formatRange = oSheet.get_Range("D5", "D" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 10;
                                        //tổ
                                        formatRange = oSheet.get_Range("E5", "E" + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        formatRange.ColumnWidth = 10;

                                        //CẠNH giữ côt động
                                        formatRange = oSheet.get_Range("F3", lastColumn + "4");
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        oWB.SaveAs("D:\\BaoCaoLaoDongThang.xlsx",
                                        AccessMode: Excel.XlSaveAsAccessMode.xlShared);
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
                                    frm.rpt = new rptDSChuyenCongTac(lk_DenNgay.DateTime, sTieuDe, Convert.ToDateTime(LK_Thang.EditValue));

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

        private void ucBaoCaoTongHopThang_Load(object sender, EventArgs e)
        {
            LoadCboDonVi();
            LoadCboXiNghiep();
            LoadCboTo();
            LoadNgay();
            LoadTinhTrangHopDong();
            
            //lk_DenNgay.EditValue = DateTime.Today;
            //DateTime dtTN = DateTime.Today;
            //DateTime dtDN = DateTime.Today;
            ////dTuNgay.EditValue = dtTN.AddDays((-dtTN.Day) + 1);
            //dtDN = dtDN.AddMonths(1);
            //dtDN = dtDN.AddDays(-(dtDN.Day));
            //LK_NgayXemBaoCao.EditValue = dtDN;

        }

        private void LoadNgay()
        {
            try
            {

                //ItemForDateThang.Visibility = LayoutVisibility.Never;
                DataTable dtthang = new DataTable();
                string sSql = "SELECT disTINCT SUBSTRING(CONVERT(VARCHAR(10),TU_NGAY,103),4,2) as M, RIGHT(CONVERT(VARCHAR(10),TU_NGAY,103),4) AS Y ,RIGHT(CONVERT(VARCHAR(10),TU_NGAY,103),7) AS THANG FROM dbo.KE_HOACH_NGHI_PHEP ORDER BY Y DESC , M DESC";
                dtthang.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
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
            lk_TuNgay.EditValue =Convert.ToDateTime("01/"+ tungay.Month+"/"+ tungay.Year).ToString("dd/MM/yyyy");
            lk_DenNgay.EditValue =Convert.ToDateTime("01/"+ denngay.Month+"/"+ tungay.Year).AddDays(-1).ToString("dd/MM/yyyy");
        }
    }
}
