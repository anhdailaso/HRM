using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Linq;
using Vs.Report;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Reflection;

namespace Vs.TimeAttendance
{
    public partial class ucBaoCaoQuanLyPhep : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBaoCaoQuanLyPhep()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
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
                                    try
                                    {




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
                                        int iTNgay = 1;
                                        int iDNgay = 20;
                                        int iSoNgay = (iDNgay - iTNgay);

                                        string lastColumn = string.Empty;
                                        //lastColumn = CharacterIncrement(dtBCGaiDoan.Columns.Count - 1);
                                        lastColumn = "Z";
                                        Excel.Range row2_TieuDe_BaoCao0 = oSheet.get_Range("A2", lastColumn + "2");
                                        row2_TieuDe_BaoCao0.Merge();
                                        row2_TieuDe_BaoCao0.Font.Size = fontSizeTieuDe;
                                        row2_TieuDe_BaoCao0.Font.Name = fontName;
                                        row2_TieuDe_BaoCao0.Font.Bold = true;
                                        row2_TieuDe_BaoCao0.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row2_TieuDe_BaoCao0.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row2_TieuDe_BaoCao0.Value2 = "THEO DÕI PHÉP NĂM "+ lk_Nam.Text;

                                        //=====

                                        //Excel.Range row2_TieuDe_BaoCao = oSheet.get_Range("A6", lastColumn + "6");
                                        //row2_TieuDe_BaoCao.Merge();
                                        //row2_TieuDe_BaoCao.Font.Size = fontSizeNoiDung;
                                        //row2_TieuDe_BaoCao.Font.Name = fontName;
                                        //row2_TieuDe_BaoCao.Font.Bold = true;
                                        //row2_TieuDe_BaoCao.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        //row2_TieuDe_BaoCao.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        //row2_TieuDe_BaoCao.Value2 = "Tháng " + Convert.ToDateTime(cboThang.EditValue).ToString("MM/yyyy");

                                        oSheet.get_Range("A4").RowHeight = 45;
                                        Excel.Range row5_TieuDe = oSheet.get_Range("A4");
                                        row5_TieuDe.Merge();
                                        row5_TieuDe.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe.Font.Name = fontName;
                                        row5_TieuDe.Font.Bold = true;
                                        row5_TieuDe.ColumnWidth = 5;
                                        row5_TieuDe.Value2 = "STT";
                                        row5_TieuDe.Interior.Color = Color.Yellow;

                                        Excel.Range row5_TieuDe1 = oSheet.get_Range( "B4");
                                        row5_TieuDe1.Merge();
                                        row5_TieuDe1.Font.Name = fontName;
                                        row5_TieuDe1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe1.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe1.Font.Bold = true;
                                        row5_TieuDe1.ColumnWidth = 8;
                                        row5_TieuDe1.Interior.Color = Color.Yellow;
                                        row5_TieuDe1.Value2 = "MS NV";

                                        Excel.Range row5_TieuDe2 = oSheet.get_Range("C4");
                                        row5_TieuDe2.Merge();
                                        row5_TieuDe2.Font.Name = fontName;
                                        row5_TieuDe2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe2.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe2.Font.Bold = true;
                                        row5_TieuDe2.ColumnWidth = 20;
                                        row5_TieuDe2.Interior.Color = Color.Yellow;
                                        row5_TieuDe2.WrapText = true;
                                        row5_TieuDe2.Value2 = "HỌ TÊN";



                                        Excel.Range row5_TieuDe3 = oSheet.get_Range("D4");
                                        row5_TieuDe3.Merge();
                                        row5_TieuDe3.Font.Name = fontName;
                                        row5_TieuDe3.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe3.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe3.Font.Bold = true;
                                        row5_TieuDe3.WrapText = true;
                                        row5_TieuDe3.ColumnWidth = 15;
                                        row5_TieuDe3.Interior.Color = Color.Yellow;
                                        row5_TieuDe3.Value2 = "SỐ TÀI KHOẢN";

                                        Excel.Range row5_TieuDe4 = oSheet.get_Range( "E4");
                                        row5_TieuDe4.Merge();
                                        row5_TieuDe4.Font.Name = fontName;
                                        row5_TieuDe4.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe4.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe4.Font.Bold = true;
                                        row5_TieuDe4.ColumnWidth = 25;
                                        row5_TieuDe4.Interior.Color = Color.Yellow;
                                        row5_TieuDe4.Value2 = "P.BAN/X.NGHIỆP";

                                        Excel.Range row5_TieuDe6 = oSheet.get_Range( "F4");
                                        row5_TieuDe6.Merge();
                                        row5_TieuDe6.Font.Name = fontName;
                                        row5_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe6.Font.Bold = true;
                                        row5_TieuDe6.WrapText = true;
                                        row5_TieuDe6.ColumnWidth = 15;
                                        row5_TieuDe6.Interior.Color = Color.Yellow;
                                        row5_TieuDe6.Value2 = "TỔ";

                                        Excel.Range row5_TieuDe61 = oSheet.get_Range( "G4");
                                        row5_TieuDe61.Merge();
                                        row5_TieuDe61.Font.Name = fontName;
                                        row5_TieuDe61.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe61.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe61.Font.Bold = true;
                                        row5_TieuDe61.WrapText = true;
                                        row5_TieuDe61.ColumnWidth = 11;
                                        row5_TieuDe61.Interior.Color = Color.Yellow;
                                        row5_TieuDe61.Value2 = "LCBBT";

                                        Excel.Range row4_TieuDe6 = oSheet.get_Range( "H4");
                                        row4_TieuDe6.Merge();
                                        row4_TieuDe6.Font.Name = fontName;
                                        row4_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row4_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row4_TieuDe6.Font.Bold = true;
                                        row4_TieuDe6.ColumnWidth = 12;
                                        row4_TieuDe6.WrapText = true;
                                        row4_TieuDe6.Interior.Color = Color.Yellow;
                                        row4_TieuDe6.Value2 = "NGÀY VÀO LÀM";

                                        Excel.Range row4_TieuDe6a = oSheet.get_Range( "I4");
                                        row4_TieuDe6a.Merge();
                                        row4_TieuDe6a.Font.Name = fontName;
                                        row4_TieuDe6a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row4_TieuDe6a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row4_TieuDe6a.Font.Bold = true;
                                        row4_TieuDe6a.WrapText = true;
                                        row4_TieuDe6a.ColumnWidth = 10;
                                        row4_TieuDe6a.Interior.Color = Color.Yellow;
                                        row4_TieuDe6a.Value2 = "PHÉP NĂM";

                                        Excel.Range row5_TieuDe6a = oSheet.get_Range( "J4");
                                        row5_TieuDe6a.Merge();
                                        row5_TieuDe6a.Font.Name = fontName;
                                        row5_TieuDe6a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe6a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe6a.Font.Bold = true;
                                        row5_TieuDe6a.ColumnWidth = 10;
                                        row5_TieuDe6a.WrapText = true;
                                        row5_TieuDe6a.Interior.Color = Color.Yellow;
                                        row5_TieuDe6a.Value2 = "PHÉP THÂM NIÊN";

                                        Excel.Range row5a_TieuDe6 = oSheet.get_Range( "K4");
                                        row5a_TieuDe6.Merge();
                                        row5a_TieuDe6.Font.Name = fontName;
                                        row5a_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5a_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5a_TieuDe6.Font.Bold = true;
                                        row5a_TieuDe6.ColumnWidth = 10;
                                        row5a_TieuDe6.WrapText = true;
                                        row5a_TieuDe6.Interior.Color = Color.Yellow;
                                        row5a_TieuDe6.Value2 = "THÁNG 1/"+lk_Nam.Text;

                                        //Excel.Range row5b_TieuDe6 = oSheet.get_Range("L7", "W7");
                                        //row5b_TieuDe6.Merge();
                                        //row5b_TieuDe6.Font.Name = fontName;
                                        //row5b_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        //row5b_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        //row5b_TieuDe6.Font.Bold = true;
                                        //row5b_TieuDe6.Interior.Color = Color.Yellow;
                                        //row5b_TieuDe6.Value2 = "Năm " + Convert.ToDateTime(cboThang.EditValue).ToString("yyyy");

                                        Excel.Range row5c_TieuDe6 = oSheet.get_Range("L4");
                                        row5c_TieuDe6.Font.Name = fontName;
                                        row5c_TieuDe6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDe6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDe6.Font.Bold = true;
                                        row5c_TieuDe6.Interior.Color = Color.Yellow;
                                        row5c_TieuDe6.WrapText = true;
                                        row5c_TieuDe6.ColumnWidth = 10;
                                        row5c_TieuDe6.Value2 = "THÁNG 2/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT2 = oSheet.get_Range("M4");
                                        row5c_TieuDeT2.Font.Name = fontName;
                                        row5c_TieuDeT2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT2.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT2.Font.Bold = true;
                                        row5c_TieuDeT2.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT2.WrapText = true;
                                        row5c_TieuDeT2.ColumnWidth = 10;
                                        row5c_TieuDeT2.Value2 = "THÁNG 3/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT3 = oSheet.get_Range("N4");
                                        row5c_TieuDeT3.Font.Name = fontName;
                                        row5c_TieuDeT3.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT3.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT3.Font.Bold = true;
                                        row5c_TieuDeT3.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT3.WrapText = true;
                                        row5c_TieuDeT3.ColumnWidth = 10;
                                        row5c_TieuDeT3.Value2 = "THÁNG 4/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT4 = oSheet.get_Range("O4");
                                        row5c_TieuDeT4.Font.Name = fontName;
                                        row5c_TieuDeT4.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT4.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT4.Font.Bold = true;
                                        row5c_TieuDeT4.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT4.WrapText = true;
                                        row5c_TieuDeT4.ColumnWidth = 10;
                                        row5c_TieuDeT4.Value2 = "THÁNG 5/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT5 = oSheet.get_Range("P4");
                                        row5c_TieuDeT5.Font.Name = fontName;
                                        row5c_TieuDeT5.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT5.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT5.Font.Bold = true;
                                        row5c_TieuDeT5.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT5.WrapText = true;
                                        row5c_TieuDeT5.ColumnWidth = 10;
                                        row5c_TieuDeT5.Value2 = "THÁNG 6" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT6 = oSheet.get_Range("Q4");
                                        row5c_TieuDeT6.Font.Name = fontName;
                                        row5c_TieuDeT6.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT6.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT6.Font.Bold = true;
                                        row5c_TieuDeT6.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT6.WrapText = true;
                                        row5c_TieuDeT6.ColumnWidth = 10;
                                        row5c_TieuDeT6.Value2 = "THÁNG 7" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT7 = oSheet.get_Range("R4");
                                        row5c_TieuDeT7.Font.Name = fontName;
                                        row5c_TieuDeT7.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT7.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT7.Font.Bold = true;
                                        row5c_TieuDeT7.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT7.WrapText = true;
                                        row5c_TieuDeT7.ColumnWidth = 10;
                                        row5c_TieuDeT7.Value2 = "THÁNG 8/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT8 = oSheet.get_Range("S4");
                                        row5c_TieuDeT8.Font.Name = fontName;
                                        row5c_TieuDeT8.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT8.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT8.Font.Bold = true;
                                        row5c_TieuDeT8.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT8.WrapText = true;
                                        row5c_TieuDeT8.ColumnWidth = 10;
                                        row5c_TieuDeT8.Value2 = "THÁNG 9/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT9 = oSheet.get_Range("T4");
                                        row5c_TieuDeT9.Font.Name = fontName;
                                        row5c_TieuDeT9.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT9.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT9.Font.Bold = true;
                                        row5c_TieuDeT9.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT9.WrapText = true;
                                        row5c_TieuDeT9.ColumnWidth = 10;
                                        row5c_TieuDeT9.Value2 = "THÁNG 10/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT10 = oSheet.get_Range("U4");
                                        row5c_TieuDeT10.Font.Name = fontName;
                                        row5c_TieuDeT10.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT10.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT10.Font.Bold = true;
                                        row5c_TieuDeT10.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT10.WrapText = true;
                                        row5c_TieuDeT10.ColumnWidth = 10;
                                        row5c_TieuDeT10.Value2 = "THÁNG 11/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT11 = oSheet.get_Range("V4");
                                        row5c_TieuDeT11.Font.Name = fontName;
                                        row5c_TieuDeT11.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT11.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT11.Font.Bold = true;
                                        row5c_TieuDeT11.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT11.WrapText = true;
                                        row5c_TieuDeT11.ColumnWidth = 10;
                                        row5c_TieuDeT11.Value2 = "THÁNG 12/" + lk_Nam.Text;

                                        Excel.Range row5c_TieuDeT12 = oSheet.get_Range("W4");
                                        row5c_TieuDeT12.Font.Name = fontName;
                                        row5c_TieuDeT12.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5c_TieuDeT12.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5c_TieuDeT12.Font.Bold = true;
                                        row5c_TieuDeT12.Interior.Color = Color.Yellow;
                                        row5c_TieuDeT12.WrapText = true;
                                        row5c_TieuDeT12.ColumnWidth = 10;
                                        row5c_TieuDeT12.Value2 = "PHÉP ĐÃ NGHỈ";




                                        Excel.Range row5_TieuDe8 = oSheet.get_Range("X4");
                                        row5_TieuDe8.Merge();
                                        row5_TieuDe8.Font.Name = fontName;
                                        row5_TieuDe8.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5_TieuDe8.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5_TieuDe8.Font.Bold = true;
                                        row5_TieuDe8.ColumnWidth = 10;
                                        row5_TieuDe8.WrapText = true;
                                        row5_TieuDe8.Interior.Color = Color.Yellow;
                                        row5_TieuDe8.Value2 = "PHÉP CÒN";

                                        Excel.Range row5a_TieuDe4a = oSheet.get_Range("Y4");
                                        row5a_TieuDe4a.Merge();
                                        row5a_TieuDe4a.Font.Name = fontName;
                                        row5a_TieuDe4a.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5a_TieuDe4a.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5a_TieuDe4a.Font.Bold = true;
                                        row5a_TieuDe4a.ColumnWidth = 11;
                                        row5a_TieuDe4a.WrapText = true;
                                        row5a_TieuDe4a.Interior.Color = Color.Yellow;
                                        row5a_TieuDe4a.Value2 = "THÀNH TIỀN";

                                        Excel.Range row5b_TieuDe4b = oSheet.get_Range("Z4");
                                        row5b_TieuDe4b.Font.Name = fontName;
                                        row5b_TieuDe4b.Merge();
                                        row5b_TieuDe4b.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        row5b_TieuDe4b.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        row5b_TieuDe4b.Font.Bold = true;
                                        row5b_TieuDe4b.ColumnWidth = 14;
                                        row5b_TieuDe4b.WrapText = true;
                                        row5b_TieuDe4b.Interior.Color = Color.Yellow;
                                        row5b_TieuDe4b.Value2 = "KÝ NHẬN";
                                        

                                        //tô màu
                                        //Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                                        //range.Cells.Interior.Color = System.Drawing.Color.Red;


                                        Excel.Range formatRange;
                                        int col = 6;



                                        //DataRow[] dr = dtBCGaiDoan.Select();
                                        //string[,] rowData = new string[dr.Length, dtBCGaiDoan.Columns.Count];

                                        //int rowCnt = 0;
                                        ////int redRows = 7;
                                        //foreach (DataRow row in dr)
                                        //{
                                        //    for (col = 0; col < dtBCGaiDoan.Columns.Count; col++)
                                        //    {
                                        //        rowData[rowCnt, col] = row[col].ToString();
                                        //    }

                                        //    rowCnt++;
                                        //}
                                        //oSheet.get_Range("A6", lastColumn + (rowCnt + 5).ToString()).Value2 = rowData;
                                        //rowCnt = rowCnt + 5;
                                        ////string CurentColumn = string.Empty;
                                        ////for (col = 5; col < dtBCGaiDoan.Columns.Count; col++)
                                        ////{
                                        ////    CurentColumn = CharacterIncrement(col);
                                        ////    formatRange = oSheet.get_Range(CurentColumn + "6", CurentColumn + rowCnt.ToString());
                                        ////    formatRange.NumberFormat = "#,##0;(#,##0); ; ";
                                        ////    formatRange.TextToColumns(Type.Missing, Excel.XlTextParsingType.xlDelimited, Excel.XlTextQualifier.xlTextQualifierDoubleQuote);
                                        ////}

                                        ////Kẻ khung toàn bộ
                                        formatRange = oSheet.get_Range("A4", "Z17");
                                        formatRange.Borders.Color = Color.Black;

                                        //dữ liệu
                                        //formatRange = oSheet.get_Range("A6", lastColumn + rowCnt.ToString());
                                        //formatRange.Font.Name = fontName;
                                        //formatRange.Font.Size = fontSizeNoiDung;

                                        ////stt

                                        //formatRange = oSheet.get_Range("A5", "A" + rowCnt.ToString());
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        //formatRange.ColumnWidth = 5;
                                        ////ma nv
                                        //formatRange = oSheet.get_Range("B5", "B" + rowCnt.ToString());
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        //formatRange.ColumnWidth = 40;
                                        ////ho ten
                                        //formatRange = oSheet.get_Range("C5", "C" + (rowCnt + 5).ToString());
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        //formatRange.ColumnWidth = 11;
                                        ////xí nghiệp
                                        //formatRange = oSheet.get_Range("D5", "D" + rowCnt.ToString());
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        //formatRange.ColumnWidth = 10;
                                        ////tổ
                                        //formatRange = oSheet.get_Range("E5", "E" + rowCnt.ToString());
                                        //formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                        //formatRange.ColumnWidth = 10;

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
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn1;
                                     dt = new DataTable();
                                    string sTieuDe1 = "DANH SÁCH CÔNG NHÂN VẮNG ĐẦU GIỜ NGÀY";
                                    frm.rpt = new rptDSVangDauGioTheoNgay(lk_DenNgay.DateTime, sTieuDe1, Convert.ToDateTime(lk_Nam.EditValue));

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
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_Nam.EditValue);
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
                                    System.Data.SqlClient.SqlConnection conn2;
                                     dt = new DataTable();
                                    string sTieuDe2 = "DANH SÁCH NHÂN VIÊN THIẾU NHÓM CA";
                                    frm.rpt = new rptDSNVThieuNhomCa(Convert.ToDateTime(lk_Nam.EditValue), sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSNVThieuNhomCa", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@DVi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = Convert.ToDateTime(lk_Nam.EditValue);
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
                            case 3:
                                {
                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    string sTieuDe2="";
                                    switch (rdo_DiTreVeSom.SelectedIndex)
                                    {
                                        case 0:
                                            {
                                                 sTieuDe2 = "DANH SÁCH NHÂN VIÊN ĐI TRỄ";
                                            }
                                            break;
                                        case 1:
                                            {
                                                sTieuDe2 = "DANH SÁCH NHÂN VIÊN VỀ SỚM";
                                            }
                                            break;
                                        case 2:
                                            {
                                                sTieuDe2 = "DANH SÁCH NHÂN VIÊN ĐI TRỄ, VỀ SỚM";
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    
                                    frm.rpt = new rptDSDiTreVeSom(Convert.ToDateTime(lk_Nam.EditValue), sTieuDe2, Convert.ToDateTime(lk_DenNgay.EditValue));

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSDiTreVeSom", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@DVi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = Convert.ToDateTime(lk_Nam.EditValue);
                                        switch (rdo_DiTreVeSom.SelectedIndex)
                                        {
                                            case 0:
                                                {
                                                    cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = 1;
                                                }
                                                break;
                                            case 1:
                                                {
                                                    cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = 2;
                                                }
                                                break;
                                            case 2:
                                                {
                                                    cmd.Parameters.Add("@Loai", SqlDbType.Int).Value = 3;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);


                                        DataSet ds = new DataSet();
                                        adp.Fill(ds);
                                        dt = new DataTable();
                                        dt = ds.Tables[0].Copy();
                                        dt.TableName = "DA_TA";
                                        Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, "sbT" + Commons.Modules.UserName, dt, "");
                                        dt = new DataTable();
                                        dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr,CommandType.Text, " select ID_CN,MS_CN,HO_TEN,TEN_XN,TEN_TO,GIO_DEN,PHUT_TRE,GIO_VE,case PHUT_VS WHEN 0 THEN null else  PHUT_VS END as PHUT_VS from sbT"+ Commons.Modules.UserName + ""));
                                        frm.AddDataSource(dt);
                                        frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                        Commons.Modules.ObjSystems.XoaTable("sbT" + Commons.Modules.UserName);
                                    }
                                    catch
                                    { }


                                    frm.ShowDialog();
                                }
                                break;
                            case 4:
                                {
                                    System.Data.SqlClient.SqlConnection conn;
                                    dt = new DataTable();
                                    string sTieuDe = "DANH SÁCH NHÂN VIÊN TRÙNG GIỜI THEO NGÀY";
                                    frm.rpt = new rptDSNVTrungGio(Convert.ToDateTime(lk_Nam.EditValue),lk_DenNgay.DateTime, sTieuDe);
                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSNVTrungGio", conn);
                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_Nam.EditValue);
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
                                    string sTieuDe = "DANH SÁCH NHÂN VIÊN CÓ TRÊN 2 CẶP GIỜ";
                                   // frm.rpt = new rptDSChuyenCongTac();

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSNVCoTren2CapGio", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = Convert.ToDateTime(lk_Nam.EditValue);
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
                                    //System.Data.SqlClient.SqlConnection conn;
                                    //dt = new DataTable();
                                    //string sTieuDe = "ĐĂNG KÝ LÀM THÊM GIỜ";
                                    //frm.rpt = new rptDKLamThemGio(lk_TuNgay.DateTime, sTieuDe, LK_XI_NGHIEP.Text.ToString());

                                    //try
                                    //{
                                    //    conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                    //    conn.Open();
                                        
                                    //    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBieuMauDangKyLamThemGio", conn);
                                        
                                    //    cmd.Parameters.Add("@ID_DV", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                    //    cmd.Parameters.Add("@ID_XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                    //    cmd.Parameters.Add("@ID_TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                    //    cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                    //    cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                    //    cmd.Parameters.Add("@Ngay", SqlDbType.Date).Value = Convert.ToDateTime(lk_TuNgay.EditValue);

                                    //    cmd.CommandType = CommandType.StoredProcedure;
                                    //    System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);

                                    //    //DataSet ds = new DataSet();
                                    //    dt = new DataTable();
                                    //    adp.Fill(dt);
                                        
                                    //    //dt = ds.Tables[0].Copy();
                                    //    dt.TableName = "DA_TA";
                                    //    frm.AddDataSource(dt);
                                    //    frm.AddDataSource(Commons.Modules.ObjSystems.DataThongTinChung());
                                    //}
                                    //catch(Exception ex )
                                    //{ }
                                    //frm.ShowDialog();
                                    break;
                                }
                        }
                        
                        break;
                    }
                default:
                    break;
            }
        }

        private void ucBaoCaoQuanLyPhep_Load(object sender, EventArgs e)
        {
            LoadCboDonVi();
            LoadCboXiNghiep();
            LoadCboTo();
            LoadTinhTrangHopDong();
            lk_Nam.Text = DateTime.Now.ToString("yyyy");
            lk_DenNgay.Text= DateTime.Now.ToString("dd/MM/yyyy");
            //lk_DenNgay.EditValue = DateTime.Today;
            //DateTime dtTN = DateTime.Today;
            //DateTime dtDN = DateTime.Today;
            ////dTuNgay.EditValue = dtTN.AddDays((-dtTN.Day) + 1);
            //dtDN = dtDN.AddMonths(1);
            //dtDN = dtDN.AddDays(-(dtDN.Day));
            //LK_NgayXemBaoCao.EditValue = dtDN;

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
                      

                    }
                    break;
                case 1:
                    {
                       
                    }
                    break;
                case 2:
                    {
                       
                    }
                    break;
                case 3:
                    {
                        
                    }
                    break;
                case 4:
                    {
                    }
                    break;
                case 5:
                    {
                        
                    }
                    break;
                case 6:
                    {
                       
                    }
                    break;
                default:
                    break;
            }
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
                        //rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 1:
                    {
                        //rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                case 2:
                    {
                        //rdo_DiTreVeSom.Visible = false;
                    }
                    break;
                default:
                    break;
            }
        }

       
        private void lk_Nam_EditValueChanged(object sender, EventArgs e)
        {
            //DateTime tungay = Convert.ToDateTime(lk_Nam.EditValue);
            //DateTime denngay = Convert.ToDateTime(lk_Nam.EditValue).AddMonths(+1);
            //lk_TuNgay.EditValue =Convert.ToDateTime("01/"+ tungay.Month+"/"+ tungay.Year).ToString("dd/MM/yyyy");
            //lk_DenNgay.EditValue =Convert.ToDateTime("01/"+ denngay.Month+"/"+ tungay.Year).AddDays(-1).ToString("dd/MM/yyyy");
        }

        private void calThang_DateTimeCommit(object sender, EventArgs e)
        {
            try
            {
                lk_Nam.Text = calThang.DateTime.ToString("yyyy");

                lk_Nam.ClosePopup();
            }
            catch { }
        }
    }
}
