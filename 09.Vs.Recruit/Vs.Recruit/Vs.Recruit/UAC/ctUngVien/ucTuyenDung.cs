using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.ApplicationBlocks.Data;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using System.Drawing;
using Vs.Report;

namespace Vs.Recruit
{
    public partial class ucTuyenDung : DevExpress.XtraEditors.XtraUserControl
    {
        static Int64 iduv = -1;
        Int64 idtb = -1;
        private Int64 iIDTB_TMP;
        public ucTuyenDung(Int64 id)
        {
            InitializeComponent();
            iduv = id;
        }

        #region function form Load
        private void LoadgrvTBTuyenDung()
        {
            DataTable dtTBTD = new DataTable();
            dtTBTD.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetTBTuyenDung", Commons.Modules.TypeLanguage, iduv));
            dtTBTD.Columns["ID_TB"].ReadOnly = false;
            dtTBTD.Columns["TEN_TO"].ReadOnly = false;
            dtTBTD.Columns["TEN_VI_TRI"].ReadOnly = false;
            dtTBTD.Columns["TINH_TRANG"].ReadOnly = false;
            dtTBTD.PrimaryKey = new DataColumn[] { dtTBTD.Columns["ID_TB"] };

            //AddnewRowTBTD();
            if (grdTBTuyenDung.DataSource == null)
            {
                Commons.Modules.ObjSystems.MLoadXtraGrid(grdTBTuyenDung, grvTBTuyenDung, dtTBTD, true, true, false, false, false, this.Name);
                //dtTBTD.Columns["ID_TB"].ReadOnly = false;
                grvTBTuyenDung.Columns["ID_TB"].Visible = false;
                for (int i = 1; i < grvTBTuyenDung.Columns.Count; i++)
                {
                    grvTBTuyenDung.Columns[i].OptionsColumn.AllowEdit = false;
                }
            }
            else
            {
                grdTBTuyenDung.DataSource = dtTBTD;
            }

            if (iIDTB_TMP != -1)
            {
                int index = dtTBTD.Rows.IndexOf(dtTBTD.Rows.Find(iIDTB_TMP));
                grvTBTuyenDung.FocusedRowHandle = grvTBTuyenDung.GetRowHandle(index);
            }

            //dtTBTD1 = new DataTable();
            //dtTBTD1.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetComboTBTuyenDung", Commons.Modules.UserName, Commons.Modules.TypeLanguage, iduv));
            //cbo = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            //if (cbo.DataSource == null)
            //{
            //    Commons.Modules.ObjSystems.AddCombSearchLookUpEdit(cbo, "ID_TB", "SO_TB", grvTBTuyenDung, dtTBTD1);
            //    try
            //    {
            //        cbo.PopulateViewColumns();
            //        cbo.View.Columns["ID_TB"].Visible = false;
            //        cbo.View.Columns["TIEU_DE"].Visible = false;
            //        cbo.View.Columns["NGAY_LAP"].Visible = false;
            //        cbo.View.Columns["TEN_VI_TRI"].Visible = false;
            //        cbo.View.Columns["TEN_TO"].Visible = false;
            //        cbo.View.Columns["NGUOI_YEU_CAU"].Visible = false;
            //        cbo.View.Columns["NGAY_BAT_DAU"].Visible = false;
            //        cbo.View.Columns["NGAY_KET_THUC"].Visible = false;
            //        cbo.View.Columns["TINH_TRANG"].Visible = false;
            //        cbo.View.Columns["NGUOI_LIEN_HE"].Visible = false;
            //        cbo.View.Columns["GHI_CHU"].Visible = false;
            //    }
            //    catch { }
            //}
            //else
            //{
            //    cbo.DataSource = dtTBTD1;
            //}
        }

        private void LoadgrvPhongVan()
        {
            try
            {
                DataTable dtUVPV = new DataTable();
            
                dtUVPV.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetPhongVan", Commons.Modules.TypeLanguage, iduv, grvTBTuyenDung.GetFocusedRowCellValue("ID_TB")));
               
                if (grdPhongVan.DataSource == null)
                {
                    Commons.Modules.ObjSystems.MLoadXtraGrid(grdPhongVan, grvPhongVan, dtUVPV, false, true, false, false, false, this.Name);
                    grvPhongVan.Columns["ID_PV"].Visible = false;
                    grvPhongVan.Columns["ID_TB"].Visible = false;
                    grvPhongVan.Columns["ID_PVUV"].Visible = false;
                }
                else
                {
                    grdPhongVan.DataSource = dtUVPV;
                }
            }
            catch
            { }
        }

        private void LoadNN()
        {
            Commons.Modules.ObjSystems.ThayDoiNN(this, new List<LayoutControlGroup>() { Root, layoutControlGroup1 }, windowsUIButton);
        }
        #endregion

        #region function dung chung
        private void AddnewRowTBTD()
        {
            grvTBTuyenDung.OptionsBehavior.Editable = true;
            grvTBTuyenDung.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grvTBTuyenDung.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }
        private void AddnewRowUVPV()
        {
            grvPhongVan.OptionsBehavior.Editable = true;
            grvPhongVan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grvPhongVan.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        #endregion

        #region sự kiện form
        private void ucTuyenDung_Load(object sender, EventArgs e)
        {
            grvPhongVan.OptionsBehavior.ReadOnly = true;
            if (iduv == -1)
            {
                grvTBTuyenDung.OptionsBehavior.Editable = false;
            }
            LoadgrvTBTuyenDung();
            LoadgrvPhongVan();
            Commons.Modules.ObjSystems.SetPhanQuyen(windowsUIButton);
            LoadNN();
        }

        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {


                case "thoat":
                    {
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
                default:
                    break;
            }
        }
        private void grvTBTuyenDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadgrvPhongVan();
        }
        private void grvTBTuyenDung_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grvTBTuyenDung.RowCount == 0)
                {
                    return;
                }
                idtb = Convert.ToInt64(grvTBTuyenDung.GetFocusedRowCellValue("ID_TB"));
                frmEditTHONG_BAO_TUYEN_DUNG_VIEW frm = new frmEditTHONG_BAO_TUYEN_DUNG_VIEW(idtb);
                //frm.Size = new Size(900, 600);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.Size = new Size((this.Width / 2) + (frm.Width / 2), (this.Height / 2) + (frm.Height / 2));
                //frm.StartPosition = FormStartPosition.Manual;
                //frm.Location = new Point(this.Width / 2 - frm.Width / 2 + this.Location.X,
                //                          this.Height / 2 - frm.Height / 2 + this.Location.Y);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    iIDTB_TMP = frm.iID_TBTMP;
                    LoadgrvTBTuyenDung();
                }
                else
                {
                    iIDTB_TMP = frm.iID_TBTMP;
                    LoadgrvTBTuyenDung();
                }
            }
            catch
            {

            }
        }
        #endregion
        
    }
}
