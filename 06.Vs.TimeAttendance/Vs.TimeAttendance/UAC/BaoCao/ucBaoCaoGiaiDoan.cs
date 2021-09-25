using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using Vs.Report;
using Excel= Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Linq;
using System.Reflection;



namespace Vs.HRM
{
    public partial class ucBaoCaoGiaiDoan : DevExpress.XtraEditors.XtraUserControl
    {
        public string uFontName = "Times New Roman";
        public float uFontSize = 11.25F;
        public ucBaoCaoGiaiDoan()
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
                                    string sTieuDe = "DANH SÁCH NHÂN VIÊN ĐI TRỄ VỀ SỚM THEO GIAI ĐOẠN";

                                    frm.rpt = new rptDSDiTreVeSomGiaiDoan(lk_TuNgay.DateTime, lk_DenNgay.DateTime, lk_NgayIn.DateTime, sTieuDe);

                                    try
                                    {
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSDiTreVeSomGiaiDoan", conn);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
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
                                    {
                                    }


                                    frm.ShowDialog();
                                }
                                break;
                            case 1:
                                {
                                    System.Data.SqlClient.SqlConnection conn1;
                                    dt = new DataTable();
                                    string sTieuDe1 = "DANH SÁCH VẮNG ĐẦU GIỜ THEO GIAI ĐOẠN";
                                    frm.rpt = new rptDSVangDauGioGiaiDoan(lk_TuNgay.DateTime, lk_DenNgay.DateTime, sTieuDe1);

                                    try
                                    {
                                        conn1 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn1.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSVangDauGioGiaiDoan", conn1);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNGAY", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.Parameters.Add("@DNGAY", SqlDbType.Date).Value = lk_DenNgay.DateTime;
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
                                    {
                                    }


                                    frm.ShowDialog();
                                }
                                break;
                            case 2:
                                {
                                    string id_ldv = "";
                                    try
                                    {
                                        DataTable ldv = new DataTable();
                                        ldv = Commons.Modules.ObjSystems.ConvertDatatable(grvLydovang).AsEnumerable().Where(x => x["CHON"].ToString().ToLower() == "true").CopyToDataTable();


                                        for (int i = 0; i < ldv.Rows.Count; i++)
                                        {
                                            if (Convert.ToString(ldv.Rows[i]["ID_LDV"]) == "-1")
                                            {
                                                id_ldv = "-1";
                                                break;
                                            }
                                            else
                                            {
                                                id_ldv = id_ldv + ", " + Convert.ToString(ldv.Rows[i]["ID_LDV"]);
                                            }


                                        }
                                        if (id_ldv != "-1")
                                        {
                                            id_ldv = id_ldv.Remove(0, 2);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        id_ldv = "-1";
                                    }


                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    string sTieuDe2 = "DANH SÁCH CHẤM VẮNG THEO GIAI ĐOẠN";
                                    frm.rpt = new rptDSChamCongVang(lk_TuNgay.DateTime, lk_DenNgay.DateTime, lk_NgayIn.DateTime, sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSChamCongVang", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                                        cmd.Parameters.Add("@LDV", SqlDbType.NVarChar, 50).Value = id_ldv;
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
                                    {
                                    }


                                    frm.ShowDialog();
                                }
                                break;
                               case 3:
                                {
                                    string id_ldv = "";
                                    try
                                    {
                                        DataTable ldv = new DataTable();
                                        ldv = Commons.Modules.ObjSystems.ConvertDatatable(grvLydovang).AsEnumerable().Where(x => x["CHON"].ToString().ToLower() == "true").CopyToDataTable();


                                        for (int i = 0; i < ldv.Rows.Count; i++)
                                        {
                                            if (Convert.ToString(ldv.Rows[i]["ID_LDV"]) == "-1")
                                            {
                                                id_ldv = "-1";
                                                break;
                                            }
                                            else
                                            {
                                                id_ldv = id_ldv + ", " + Convert.ToString(ldv.Rows[i]["ID_LDV"]);
                                            }


                                        }
                                        if (id_ldv != "-1")
                                        {
                                            id_ldv = id_ldv.Remove(0, 2);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        id_ldv = "-1";
                                    }
                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    string sTieuDe2 = "DANH SÁCH CHẤM CÔNG VẮNG LŨY KẾ";
                                    frm.rpt = new rptDSChamCongVangLuyKe(lk_TuNgay.DateTime, lk_DenNgay.DateTime, lk_NgayIn.DateTime, sTieuDe2);

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptDSChamCongVangLuyKe", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@DVi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;
                                        cmd.Parameters.Add("@TNGAY", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.Parameters.Add("@DNGAY", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                                        cmd.Parameters.Add("@LDV", SqlDbType.NVarChar, 50).Value = id_ldv;
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
                            case 4:
                                {

                                    try
                                    {
                                        System.Data.SqlClient.SqlConnection conn;
                                        conn = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn.Open();
                                        DataTable dtBCGaiDoan;

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptBangXacNhanGioQuetThe", conn);

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
                                        row2_TieuDe_BaoCao.Value2 = "BẢNG CHẤM CÔNG " + Convert.ToDateTime(lk_TuNgay.EditValue).ToString("MM/yyyy");

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
                                            oSheet.Cells[4, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                            oSheet.Cells[4, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                            oSheet.Cells[5, col] = "Giờ Vào";
                                            oSheet.Cells[5, col].Font.Bold = true;
                                            oSheet.Cells[5, col].Interior.Color = Color.Yellow;
                                            oSheet.Cells[5, col].Font.Name = fontName;
                                            oSheet.Cells[5, col].Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                            oSheet.Cells[5, col].Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;



                                            oSheet.Cells[5, col + 1] = "Giờ ra";
                                            oSheet.Cells[5, col + 1].Interior.Color = Color.Yellow;
                                            oSheet.Cells[5, col + 1].Font.Bold = true;
                                            oSheet.Cells[5, col + 1].Font.Name = fontName;
                                            oSheet.Cells[5, col + 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                            oSheet.Cells[5, col + 1].VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;


                                            oSheet.Range[oSheet.Cells[4, col], oSheet.Cells[4, col + 1]].Merge();
                                            oSheet.Range[oSheet.Cells[5, col], oSheet.Cells[5, col]].Merge();
                                            oSheet.Range[oSheet.Cells[5, col + 1], oSheet.Cells[5, col + 1]].Merge();

                                            col = col + 2;
                                            iTNgay++;
                                        }







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
                                        rowCnt = rowCnt + 5;
                                        oSheet.get_Range("A6", lastColumn + rowCnt.ToString()).Value2 = rowData;


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
                                        formatRange = oSheet.get_Range("C5", "C" + rowCnt.ToString());
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
                                        formatRange = oSheet.get_Range("F4", lastColumn + rowCnt.ToString());
                                        formatRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                        oWB.SaveAs("D:\\BangCongThang.xlsx",
                                        AccessMode: Excel.XlSaveAsAccessMode.xlShared);

                                    }
                                    catch (Exception ex)
                                    {

                                    }


                                }

                                break;
                            case 5:
                                {
                                    System.Data.SqlClient.SqlConnection conn2;
                                    dt = new DataTable();
                                    string sTieuDe2 = "CHẤM CÔNG CHI TIẾT CÔNG NHÂN THEO GIAI ĐOẠN";
                                    frm.rpt = new rptBangCCTheoGD(lk_TuNgay.DateTime, lk_DenNgay.DateTime, sTieuDe2, lk_NgayIn.DateTime );

                                    try
                                    {
                                        conn2 = new System.Data.SqlClient.SqlConnection(Commons.IConnections.CNStr);
                                        conn2.Open();

                                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("rptChiTietQuetTheCNGD", conn2);

                                        cmd.Parameters.Add("@UName", SqlDbType.NVarChar, 50).Value = Commons.Modules.UserName;
                                        cmd.Parameters.Add("@NNgu", SqlDbType.Int).Value = Commons.Modules.TypeLanguage;
                                        cmd.Parameters.Add("@Dvi", SqlDbType.Int).Value = LK_DON_VI.EditValue;
                                        cmd.Parameters.Add("@XN", SqlDbType.Int).Value = LK_XI_NGHIEP.EditValue;
                                        cmd.Parameters.Add("@TO", SqlDbType.Int).Value = LK_TO.EditValue;

                                        cmd.Parameters.Add("@TNgay", SqlDbType.Date).Value = lk_TuNgay.DateTime;
                                        cmd.Parameters.Add("@DNgay", SqlDbType.Date).Value = lk_DenNgay.DateTime;
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        System.Data.SqlClient.SqlDataAdapter adp = new System.Data.SqlClient.SqlDataAdapter(cmd);
                                        //LOAD BÁO CÁO CỦA 1 CÔNG ANH ĐƯỢC CHỌN
                                        if (chkInTheoCongNhan.Checked)
                                        {
                                            cmd.Parameters.Add("@CN", SqlDbType.Int).Value = Convert.ToInt32(grvCN.GetFocusedRowCellValue("ID_CN"));
                                        }
                                        else
                                        {
                                            //LOAD BÁO CÁO TẤT CẢ CÔNG NHÂN
                                            cmd.Parameters.Add("@CN", SqlDbType.Int).Value = -1;
                                        }
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

                        }

                        break;
                    }
                default:
                    break;
            }
        }

        private void ucBaoCaoGiaiDoan_Load(object sender, EventArgs e)
        {
            LoadCboDonVi();
            LoadCboXiNghiep();
            LoadCboTo();

            LoadGrvLydovang();
            LoadGrvCongNhan();

            lk_TuNgay.EditValue = Convert.ToDateTime("01/" + DateTime.Today.Month + "/" + DateTime.Today.Year).ToString("dd/MM/yyyy");
            DateTime dtTN = DateTime.Today;
            DateTime dtDN = DateTime.Today;
            lk_DenNgay.EditValue = dtTN.AddDays((-1));
            dtDN = dtDN.AddMonths(1);
            lk_NgayIn.EditValue = dtDN;

        }

        private void LoadGrvCongNhan()
        {
            try
            {
                DataTable dtCongNhan = new DataTable();
                dtCongNhan.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCongNhanTheoDieuKien", LK_DON_VI.EditValue, LK_XI_NGHIEP.EditValue,
                                                        LK_TO.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage, 0));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdCN, grvCN, dtCongNhan, false, false, false, true, true, this.Name);
            }
            catch
            {

            }

            //format grid view Cong nhan
            grvCN.Columns["ID_CN"].Visible = false;
            grvCN.OptionsView.ShowColumnHeaders = false;
            grvCN.OptionsView.ShowGroupPanel = false;
            grvCN.OptionsView.ShowFooter = true;
        }

        private  void LoadGrvLydovang()
        {
            try
            {
                DataTable dtLydovang = new DataTable();
                dtLydovang.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "rptGetListLY_DO_VANG", Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdLydovang, grvLydovang, dtLydovang, false, false, false, true, true, this.Name);
                grvLydovang.Columns["ID_LDV"].Visible = false;
                dtLydovang.Columns["CHON"].ReadOnly = false;
            }
            catch
            {

            }
            grvLydovang.OptionsBehavior.Editable = true;
            grvLydovang.Columns["TEN_CHE_DO"].OptionsColumn.ReadOnly = true;
            grvLydovang.Columns["TEN_LDV"].OptionsColumn.ReadOnly = true;
            //grvLydovang.Columns["CHON"].OptionsColumn.ReadOnly = false;
            grvLydovang.OptionsView.ShowColumnHeaders = false;
            grvLydovang.OptionsSelection.MultiSelect = true;
            // Controls whether multiple cells or rows can be selected
            grvLydovang.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
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
        private void LK_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            LoadCboXiNghiep();
            LoadCboTo();
            LoadGrvCongNhan();
        }

        private void LK_XI_NGHIEP_EditValueChanged(object sender, EventArgs e)
        {
            LoadCboTo();
            LoadGrvCongNhan();
        }

        private void LK_TO_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrvCongNhan();
        }

        private void grvLydovang_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void grvLydovang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                GridView grv = (GridView)sender;
                cboLydoVang.EditValue = grvLydovang.GetFocusedRowCellValue("TEN_CHE_DO").ToString();
            }
            catch { }
        }



        


    }

}
