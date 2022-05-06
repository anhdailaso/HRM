using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using Vs.Report;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Drawing;
using System.Diagnostics;

namespace Vs.Payroll
{
    public partial class ucBCLuongThang : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCLuongThang()
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

        private void ucBCLuongThang_Load(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboDonVi(LK_DON_VI);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);

            lk_NgayIn.EditValue = DateTime.Today;
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
                                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongSP.xlsx");
                                    }
                                    catch
                                    { }
                                }
                                break;
                            case 1:
                                {
                                    try
                                    {
                                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongQLy.xlsx");
                                    }
                                    catch
                                    { }

                                }
                                break;
                            case 2:
                                {
                                   
                                    try
                                    {
                                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongThoiGian.xlsx");
                                    }
                                    catch
                                    { }

                                }
                                break;
                            case 3:
                                {
                                    
                                    try
                                    {
                                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongQC.xlsx");
                                    }
                                    catch
                                    { }

                                }
                                break;
                            case 4:
                                {
                                    try
                                    {
                                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongToTruong.xlsx");
                                        

                                    }
                                    catch
                                    { }
                                }
                                break;
                            case 5:
                                {
                                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangTienLuongChuyenATM.xlsx");
                                }
                                break;
                            case 6:
                                {
                                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\PhieuLuong_CN.xlsx");
                                    
                                }
                                break;
                            case 7:
                                {
                                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\BangLuongTongHop.xlsx");
                                    
                                }
                                break;
                        }
                        
                        break;
                    }
                default:
                    break;
            }
        }

        private void BorderAround(Excel.Range range)
        {
            Excel.Borders borders = range.Borders;
            borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous;
            borders[Excel.XlBordersIndex.xlDiagonalUp].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            borders[Excel.XlBordersIndex.xlDiagonalDown].LineStyle = Excel.XlLineStyle.xlLineStyleNone;
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
        
        private void LK_DON_VI_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboXiNghiep(LK_DON_VI, LK_XI_NGHIEP);
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
        }

        private void LK_XI_NGHIEP_EditValueChanged(object sender, EventArgs e)
        {
            Commons.Modules.ObjSystems.LoadCboTo(LK_DON_VI, LK_XI_NGHIEP, LK_TO);
        }

    }
}
