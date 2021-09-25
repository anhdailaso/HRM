﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Xml.Linq;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraLayout;

namespace Vs.TimeAttendance
{
    public partial class ucCheDoChamCongNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private static Boolean isAdd = false;
        public static ucCheDoChamCongNhanVien _instance;
        public static ucCheDoChamCongNhanVien Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucCheDoChamCongNhanVien();
                return _instance;
            }
        }
        public ucCheDoChamCongNhanVien()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root }, btnALL);
        }

        private void ucCheDoChamCongNhanVien_Load(object sender, EventArgs e)
        {
            Commons.Modules.sPS = "0Load";
            EnableButon();
            try
            {

                LoadNgay(Convert.ToDateTime("01/01/1900"));
            }
            catch
            {
                MessageBox.Show("err Datetime System");
            }
            Commons.Modules.ObjSystems.LoadCboDonVi(cboDonVi);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDonVi, cboXiNghiep);
            Commons.Modules.ObjSystems.LoadCboTo(cboDonVi, cboXiNghiep, cboTo);

            LoadGrdCDCCNV();
            LoadGrdCDCCNV();
            Commons.Modules.sPS = "";

            DataTable dCa = new DataTable();
            RepositoryItemLookUpEdit cboCa = new RepositoryItemLookUpEdit();
            dCa.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, "SELECT DISTINCT ID_CDLV, CA,GIO_BD,GIO_KT FROM CHE_DO_LAM_VIEC"));

            cboCa.NullText = "";
            cboCa.ValueMember = "ID_CDLV";
            cboCa.DisplayMember = "CA";


            cboCa.DataSource = dCa;
            cboCa.Columns.Clear();
            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CA"));
            cboCa.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA");

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_BD"));
            cboCa.Columns["GIO_BD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_BDChamCong");
            cboCa.Columns["GIO_BD"].FormatType = DevExpress.Utils.FormatType.DateTime;
            cboCa.Columns["GIO_BD"].FormatString = "HH:mm";

            cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_KT"));
            cboCa.Columns["GIO_KT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_KTChamcong");
            cboCa.Columns["GIO_KT"].FormatType = DevExpress.Utils.FormatType.DateTime;
            cboCa.Columns["GIO_KT"].FormatString = "HH:mm";

            cboCa.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            cboCa.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            grvCDCCNV.Columns["CA"].ColumnEdit = cboCa;
            cboCa.BeforePopup += cboCa_BeforePopup;
            cboCa.EditValueChanged += CboCa_EditValueChanged;

            //cboCa.NullText = "";
            //cboCa.ValueMember = "ID_CDLV";
            //cboCa.DisplayMember = "CA";
            //cboCa.DataSource = dCa;
            //cboCa.Columns.Clear();

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CA"));
            //cboCa.Columns["CA"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "CA");

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_BD"));
            //cboCa.Columns["GIO_BD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_BD");
            //cboCa.Columns["GIO_BD"].FormatType = DevExpress.Utils.FormatType.DateTime;
            //cboCa.Columns["GIO_BD"].FormatString = "HH:mm";

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GIO_KT"));
            //cboCa.Columns["GIO_KT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "GIO_KT");
            //cboCa.Columns["GIO_KT"].FormatType = DevExpress.Utils.FormatType.DateTime;
            //cboCa.Columns["GIO_KT"].FormatString = "HH:mm";

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PHUT_BD"));
            //cboCa.Columns["PHUT_BD"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "PHUT_BD");
            //cboCa.Columns["PHUT_BD"].Visible = false;

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PHUT_KT"));
            //cboCa.Columns["PHUT_KT"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "PHUT_KT");
            //cboCa.Columns["PHUT_KT"].Visible = false;

            //cboCa.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID_CDLV"));
            //cboCa.Columns["ID_CDLV"].Caption = Commons.Modules.ObjLanguages.GetLanguage(this.Name, "ID_CDLV");
            //cboCa.Columns["ID_CDLV"].Visible = false;

            //cboCa.AppearanceDropDownHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            //cboCa.AppearanceDropDownHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            //grvLamThem.Columns["CA"].ColumnEdit = cboCa;

            //cboCa.BeforePopup += cboCa_BeforePopup;

            //Commons.Modules.sPS = "";
            //grvCongNhan_FocusedRowChanged(null, null);
        }
        private void CboCa_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lookUp = sender as LookUpEdit;

            //string id = lookUp.get;

            // Access the currently selected data row
            DataRowView dataRow = lookUp.GetSelectedDataRow() as DataRowView;

            if (grvCDCCNV.GetFocusedRowCellValue("NGAY_AD").ToString()=="")
            {
                grvCDCCNV.SetFocusedRowCellValue("NGAY_AD", cboNgay.EditValue.ToString());
            }
            
            grvCDCCNV.SetFocusedRowCellValue("CA", dataRow.Row["ID_CDLV"]);
            //grvLamThem.SetFocusedRowCellValue("PHUT_KT", dataRow.Row["PHUT_KT"]);
        }
        private void cboCa_BeforePopup(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetCaLV", cboNgay.EditValue, grvCDCCNV.GetFocusedRowCellValue("ID_NHOM") , Commons.Modules.UserName, Commons.Modules.TypeLanguage));

                if (sender is LookUpEdit cbo)
                {
                    cbo.Properties.DataSource = null;
                    cbo.Properties.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void LoadGrdCDCCNV()
        {
            try
            {
                Commons.Modules.sPS = "0Load";
                DataTable dt = new DataTable();
                if (isAdd)
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListEditCDCCNV", cboNgay.EditValue, cboDonVi.EditValue, cboXiNghiep.EditValue, cboTo.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvCDCCNV, dt, true, false, true, false, true, this.Name);
                    dt.Columns["NGAY_AD"].ReadOnly = false;
                }
                else
                {
                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListCheDoChamCongNhanVien", cboNgay.EditValue, cboDonVi.EditValue, cboXiNghiep.EditValue, cboTo.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvCDCCNV, dt, false, false, true, false, true, this.Name);
                    dt.Columns["NGAY_AD"].ReadOnly = false;
                }
                DataTable dID_NHOM = new DataTable();
                dID_NHOM.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetNhomCC", cboNgay.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                Commons.Modules.ObjSystems.AddCombXtra("ID_NHOM", "TEN_NHOM", grvCDCCNV, dID_NHOM, false);
                FormatGridView();
                Commons.Modules.sPS = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            grvCDCCNV.Columns["ID_CN"].Visible = false;
            grvCDCCNV.Columns["NGAY_AD"].Visible = false;
        }

        private void cboDonVi_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDonVi, cboXiNghiep);
            Commons.Modules.ObjSystems.LoadCboTo(cboDonVi, cboXiNghiep, cboTo);
            LoadGrdCDCCNV();
            Commons.Modules.sPS = "";
        }

        private void cboXiNghiep_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cboDonVi, cboXiNghiep, cboTo);
            LoadGrdCDCCNV();
            Commons.Modules.sPS = "";
        }

        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGrdCDCCNV();
            Commons.Modules.sPS = "";
        }

        private void dNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            LoadGrdCDCCNV();
            Commons.Modules.sPS = "";
        }

        private void FormatGridView()
        {
            grvCDCCNV.Columns["ID_CN"].OptionsColumn.ReadOnly = true;
            grvCDCCNV.Columns["HO_TEN"].OptionsColumn.ReadOnly = true;
            grvCDCCNV.Columns["TEN_TO"].OptionsColumn.ReadOnly = true;
        }


        private void windowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "themsua":
                    {
                        if (cboNgay.Text == "") return;
                        isAdd = true;
                        EnableButon();
                        LoadGrdCDCCNV();
                        break;
                    }
                case "xoa":
                    {
                        XoaCDCCNV();
                        break;
                    }
                case "ghi":
                    {
                        //if (grvCDCCNV.HasColumnErrors) return;
                        if (Savedata() == false)
                        {
                            Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgDuLieuDangSuDung);
                        }
                        isAdd = false;
                        EnableButon();
                        LoadGrdCDCCNV();
                        break;
                    }
                case "khongghi":
                    {
                        
                        isAdd = false;
                        EnableButon();
                        LoadGrdCDCCNV();
                        break;
                    }
                case "thoat":
                    {
                        isAdd = false;
                        EnableButon();
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
                case "capnhatnhom":
                    {
                        Validate();
                        if (grvCDCCNV.HasColumnErrors) return;
                        if (XtraMessageBox.Show("Bạn có muốn cập nhật nhóm: " + grvCDCCNV.GetFocusedRowCellDisplayText("ID_NHOM") + ", ca: " + grvCDCCNV.GetFocusedRowCellDisplayText("CA") + " cho các nhân viên được chọn", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        {

                            return;
                        }
                        CapNhatNhom();
                        break;
                    }
                case "xoatrangnhom":
                    {
                        Validate();
                        if (grvCDCCNV.HasColumnErrors) return;
                        XoaTrangNhom();
                        break;
                    }
            }
        }

        private void CapNhatNhom()
        {
            DataTable dt = new DataTable();
            string sTB = "CDCCNV_CapNhatNhom" + Commons.Modules.UserName;
            string sSql = "";
            try
            {
               
                //string sID_NHOM, sID_CA, sNgay;
                //sID_NHOM = ""; sID_CA = ""; sNgay = "";

                //try { sID_NHOM = grvCDCCNV.GetFocusedRowCellValue("ID_NHOM").ToString(); } catch { }
                //try { sID_CA = grvCDCCNV.GetFocusedRowCellValue("CA").ToString(); } catch { }
                //try { sNgay = Convert.ToDateTime(grvCDCCNV.GetFocusedRowCellValue("NGAY_AD").ToString()).ToString("dd/MM/yyyy"); } catch { }
                //for (int i = 0; i < grvCDCCNV.RowCount; i++)
                //{
                //    if (grvCDCCNV.GetRowCellValue(i,"CA").ToString()=="")
                //    {
                //        grvCDCCNV.SetRowCellValue(i, "CA", sID_CA);
                //        grvCDCCNV.SetRowCellValue(i, "ID_NHOM", sID_NHOM);
                //        grvCDCCNV.SetRowCellValue(i, "NGAY_AD", Convert.ToDateTime(sNgay));
                //    }
                //}


               
                    Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sTB, Commons.Modules.ObjSystems.ConvertDatatable(grdData), "");
                    sSql = " SELECT ID_CN, '" + grvCDCCNV.GetFocusedRowCellValue("NGAY_AD").ToString()+ "' AS NGAY_AD, HO_TEN, " + grvCDCCNV.GetFocusedRowCellValue("ID_NHOM") + " AS ID_NHOM, " + grvCDCCNV.GetFocusedRowCellValue("CA") + " AS CA,  TEN_TO FROM " + sTB + "";

                    dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvCDCCNV, dt, true, false, true, false, true, this.Name);
                    dt.Columns["ID_NHOM"].ReadOnly = false;
                    dt.Columns["CA"].ReadOnly = false;
                    dt.Columns["NGAY_AD"].ReadOnly = false;
                FormatGridView();
                    Commons.Modules.ObjSystems.XoaTable(sTB);
                    Commons.Modules.sPS = "";

                }
            catch
            {
            }
        }

        private void XoaTrangNhom()
        {
            //int idKip;
            //Int32.TryParse(grvCDCCNV.GetFocusedRowCellValue("ID_NHOM").ToString(), out idKip);
            //if (idKip == 0) return;
            //for (int i = 0; i < grvCDCCNV.DataRowCount; i++)
            //{
            //    DataRow row = grvCDCCNV.GetDataRow(i);
            //    if (row["ID_NHOM"] != null && Convert.ToInt32(row["ID_NHOM"]) == idKip)
            //    {
            //        grvCDCCNV.SetRowCellValue(i, "ID_NHOM", null);
            //        continue;
            //    }
            //    //Do something here  
            //}

            DataTable dt = new DataTable();
            string sTB = "CDCCNV_XoaNhom" + Commons.Modules.UserName;
            string sSql = "";
            try
            {
               
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sTB, Commons.Modules.ObjSystems.ConvertDatatable(grvCDCCNV), "");
               
                sSql = " SELECT ID_CN,  NULL NGAY_AD, HO_TEN, NULL ID_NHOM, NULL CA, TEN_TO FROM " + sTB + "";

                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, CommandType.Text, sSql));
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdData, grvCDCCNV, dt, true, false, true, false, true, this.Name);
                dt.Columns["ID_NHOM"].ReadOnly = false;
                dt.Columns["CA"].ReadOnly = false;
                dt.Columns["NGAY_AD"].ReadOnly = false;
                FormatGridView();
                Commons.Modules.ObjSystems.XoaTable(sTB);
                Commons.Modules.sPS = "";
            }
            catch(Exception ex)
            {
            }
        }

        private void EnableButon()
        {
            btnALL.Buttons[0].Properties.Visible = !isAdd;
            btnALL.Buttons[1].Properties.Visible = !isAdd;
            btnALL.Buttons[2].Properties.Visible = !isAdd;
            btnALL.Buttons[3].Properties.Visible = isAdd;
            btnALL.Buttons[4].Properties.Visible = isAdd;
            btnALL.Buttons[5].Properties.Visible = isAdd;
            btnALL.Buttons[6].Properties.Visible = isAdd;
        }


        private void XoaCDCCNV()
        {
            if (grvCDCCNV.RowCount == 0) { Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa); return; }
            if (Commons.Modules.ObjSystems.msgHoi(Commons.ThongBao.msgXoa) == DialogResult.No) return;
            //xóa
            try
            {
                
                String dele= "DELETE dbo.CHE_DO_CHAM_CONG_NHAN_VIEN WHERE ID_CN = "+ grvCDCCNV.GetFocusedRowCellValue("ID_CN") + "AND ID_NHOM ="+grvCDCCNV.GetFocusedRowCellValue("ID_NHOM")+" AND NGAY_AD = '" +Convert.ToDateTime(cboNgay.EditValue).ToString("yyyyMMdd") + "'";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, dele);
                grvCDCCNV.DeleteSelectedRows();
            }
            catch
            {
                Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgKhongCoDuLieuXoa);
            }
        }

        private void grvData_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void grvData_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvData_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
        }

        private bool Savedata()
        {
            string sTB = "CDCC_NV_TMP" + Commons.Modules.UserName;
            string sSql = "";
            try
            {
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, sTB, Commons.Modules.ObjSystems.ConvertDatatable(grdData), "");
               
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, "spSaveCheDoChamCongNV", sTB);
                Commons.Modules.ObjSystems.XoaTable(sTB);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        //LOAD THANG
        private void LoadNgay(DateTime dNgay)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListNgayCDCCNV", Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            if (grdNgay.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNgay, grvNgay, dt, false, true, true, true, true, this.Name);
            }
            else
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdNgay, grvNgay, dt, false, false, true, false, false, this.Name);
            cboNgay.EditValue = dt.Rows[0]["NGAY_AD"];
        }

        private void calNgay_DateTimeCommit(object sender, EventArgs e)
        {
            try
            {
                cboNgay.Text = calNgay.DateTime.Date.ToShortDateString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
                cboNgay.Text = DateTime.Now.ToShortDateString();
            }
            cboNgay.ClosePopup();
        }

        private void LoadNull()
        {
            try
            {
                if (cboNgay.Text == "") cboNgay.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                cboNgay.Text = "";
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }

        private void grvNgay_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                GridView grv = (GridView)sender;
                cboNgay.Text = Convert.ToDateTime(grv.GetFocusedRowCellValue("NGAY_AD").ToString()).ToShortDateString();
            }
            catch { LoadNull(); }
            cboNgay.ClosePopup();
        }

        private void cboNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrdCDCCNV();
        }

        private void grvCDCCNV_RowCountChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                int index = ItemForSumNhanVien.Text.IndexOf(':');
                if (index > 0)
                {
                    if (view.RowCount > 0)
                    {
                        ItemForSumNhanVien.Text = ItemForSumNhanVien.Text.Substring(0, index) + ": " + view.RowCount.ToString();
                    }
                    else
                    {
                        ItemForSumNhanVien.Text = ItemForSumNhanVien.Text.Substring(0, index) + ": 0";
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
   }
}