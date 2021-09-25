using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace Vs.HRM
{
    public partial class frmGiaDinh : DevExpress.XtraEditors.XtraForm
    {
        bool cothem = false;
        public frmGiaDinh(string tencn)
        {
            InitializeComponent();
            lbl_HoTenCN.Text = tencn.ToUpper();
            Commons.Modules.ObjSystems.ThayDoiNN(this, layoutControlGroup1, windowsUIButton);
            Commons.OSystems.SetDateEditFormat(NGAY_SINHDateEdit);
        }
        #region sự kiện form
        //sự kiên load form
        private void formGiaDinh_Load(object sender, EventArgs e)
        {
            //load combobox ID_QHLookUpEdit
            Commons.Modules.ObjSystems.MLoadLookUpEdit(HO_TENLookupEdit, Commons.Modules.ObjSystems.DataCongNhan(false), "ID_CN", "TEN_CN", "TEN_CN");
            Commons.Modules.ObjSystems.MLoadLookUpEdit(ID_QHLookUpEdit, Commons.Modules.ObjSystems.DataQHGD(false), "ID_QH", "TEN_QH", "TEN_QH");
            LoadgrdGiaDinh(-1);
            enableButon(true);
            Commons.Modules.ObjSystems.SetPhanQuyen(windowsUIButton);
            rdo_CongTy.SelectedIndex = 1;
        }
        //sự kiện các nút xử lí
        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "them":
                    {
                        Bindingdata(true);
                        cothem = true;
                        enableButon(false);
                        break;
                    }
                case "sua":
                    {
                        if (grvGiaDinh.RowCount == 0) return;
                        cothem = false;
                        enableButon(false);
                        break;
                    }

                case "xoa":
                    {
                        if (grvGiaDinh.RowCount == 0) return;
                        DeleteData();
                        break;
                    }
                case "luu":
                    {
                        DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
                        conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
                        conditionValidationRule1.ErrorText = "This value is not valid";
                        conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;

                        if (rdo_CongTy.SelectedIndex == 1)
                        {
                            //       dxValidationProvider1.SetValidationRule(this.HO_TENTextEdit, conditionValidationRule1);
                            dxValidationProvider1.RemoveControlError(this.HO_TENTextEdit);
                        }
                        else
                        {
                            //     dxValidationProvider1.SetValidationRule(this.HO_TENLookupEdit, conditionValidationRule1);
                            dxValidationProvider1.RemoveControlError(this.HO_TENLookupEdit);
                        }
                        if (!dxValidationProvider1.Validate()) return;
                        SaveData();
                        enableButon(true);
                        break;
                    }
                case "khongluu":
                    {

                        enableButon(true);
                        if (grvGiaDinh.RowCount == 1)
                        {
                            Bindingdata(false);
                        }
                        dxValidationProvider1.Validate();
                        break;
                    }
                case "thoat":
                    {
                        if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgBanCoMuonThoatChuongtrinh"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeThoat"), MessageBoxButtons.YesNo) == DialogResult.No) return;
                        this.Close();
                        break;
                    }
                default:
                    break;
            }
        }
        //sự kiện phím delete
        private void grdGiaDinh_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteData();
            }
        }
        //sự kiện radio button cùng công ty hay không
        private void rdo_CongTy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdo_CongTy.SelectedIndex == 1)
            {
                ItemForHO_TEN.Visibility = LayoutVisibility.Always;
                ItemForHO_TEN_L.Visibility = LayoutVisibility.Never;
                ItemForHO_TEN_L.Enabled = true;
            }
            else
            {
                ItemForHO_TEN.Visibility = LayoutVisibility.Never;
                ItemForHO_TEN_L.Visibility = LayoutVisibility.Always;
                ItemForHO_TEN_L.Enabled = true;
            }
            if (!cothem)
            {
                LoadgrdGiaDinh(-1);
            }
        }

        #endregion

        #region hàm load form
        //hàm load gridview
        private void LoadgrdGiaDinh(int id)
        {
            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListGiaDinh", rdo_CongTy.SelectedIndex, Commons.Modules.iCongNhan, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_GD"] };
            Commons.Modules.ObjSystems.MLoadXtraGrid(grdGiaDinh, grvGiaDinh, dt, false, true, true, true, true, this.Name);
            grvGiaDinh.Columns["ID_GD"].Visible = false;
            grvGiaDinh.Columns["ID_CN"].Visible = false;
            grvGiaDinh.Columns["ID_QHGD"].Visible = false;
            grvGiaDinh.Columns["DIA_CHI"].Visible = false;
            grvGiaDinh.Columns["ID_CN_QH"].Visible = false;
            grvGiaDinh.Columns["NGUOI_GH"].Visible = false;

            //for(int i=0;i< grvGiaDinh.Columns.Count;i++)
            //{
            //    grvGiaDinh.Columns[i].AppearanceHeader.BackColor = Color.FromArgb(240, 128, 25);
            //}

            if (id != -1)
            {
                int index = dt.Rows.IndexOf(dt.Rows.Find(id));
                grvGiaDinh.FocusedRowHandle = grvGiaDinh.GetRowHandle(index);
            }
            if (grvGiaDinh.RowCount == 1)
            {
                Bindingdata(false);
            }
        }
        //hàm bingding dữ liệu
        private void Bindingdata(bool bthem)
        {
            Commons.Modules.sPS = "0Load";
            if (bthem == true || grvGiaDinh.RowCount == 0)
            {
                //lấy dữ liệu mặc định theo id công nhân
                try
                {
                    NGAY_SINHDateEdit.EditValue = DateTime.Today;
                    NGHE_NGHIEPTextEdit.EditValue = "";
                    DIA_CHITextEdit.EditValue = "";
                    NGUOI_GHCheckEdit.EditValue = false;
                    HO_TENTextEdit.EditValue = "";
                    ID_QHLookUpEdit.EditValue = null;
                    HO_TENLookupEdit.EditValue = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                try
                {
                    HO_TENLookupEdit.EditValue = Convert.ToInt64(grvGiaDinh.GetFocusedRowCellValue("ID_CN_QH"));
                }
                catch (Exception ex)
                {
                }
                ID_QHLookUpEdit.EditValue = Convert.ToInt64(grvGiaDinh.GetFocusedRowCellValue("ID_QHGD"));
                rdo_CongTy.SelectedIndex = grvGiaDinh.GetFocusedRowCellValue("ID_CN_QH").ToString() == "" ? 1 : 0;
                NGAY_SINHDateEdit.EditValue = grvGiaDinh.GetFocusedRowCellValue("NGAY_SINH");
                NGHE_NGHIEPTextEdit.EditValue = grvGiaDinh.GetFocusedRowCellValue("NGHE_NGHIEP");
                DIA_CHITextEdit.EditValue = grvGiaDinh.GetFocusedRowCellValue("DIA_CHI");
                NGUOI_GHCheckEdit.EditValue = Convert.ToBoolean(grvGiaDinh.GetFocusedRowCellValue("NGUOI_GH"));
                HO_TENTextEdit.EditValue = grvGiaDinh.GetFocusedRowCellValue("HO_TEN");
            }
        }
        private void enableButon(bool visible)
        {
            windowsUIButton.Buttons[0].Properties.Visible = visible;
            windowsUIButton.Buttons[1].Properties.Visible = visible;
            windowsUIButton.Buttons[2].Properties.Visible = visible;
            windowsUIButton.Buttons[3].Properties.Visible = visible;
            windowsUIButton.Buttons[4].Properties.Visible = !visible;
            windowsUIButton.Buttons[5].Properties.Visible = !visible;
            windowsUIButton.Buttons[6].Properties.Visible = visible;
            grdGiaDinh.Enabled = visible;
            ID_QHLookUpEdit.Properties.ReadOnly = visible;
            NGAY_SINHDateEdit.Properties.ReadOnly = visible;
            NGHE_NGHIEPTextEdit.Properties.ReadOnly = visible;
            DIA_CHITextEdit.Properties.ReadOnly = visible;
            NGUOI_GHCheckEdit.Properties.ReadOnly = visible;
            HO_TENLookupEdit.Properties.ReadOnly = visible;
            HO_TENTextEdit.Properties.ReadOnly = visible;
        }
        #endregion

        #region hàm sử lý data
        //hàm sử lý khi lưu dữ liệu(thêm/Sửa)
        private void SaveData()
        {
            try
            {
                int n = Convert.ToInt32(SqlHelper.ExecuteScalar(Commons.IConnections.CNStr, "spUpdateGiaDinh",
              grvGiaDinh.GetFocusedRowCellValue("ID_GD"),
            Commons.Modules.iCongNhan,
            ID_QHLookUpEdit.EditValue,
            rdo_CongTy.SelectedIndex == 0 ? HO_TENLookupEdit.Text : HO_TENTextEdit.Text,
            NGAY_SINHDateEdit.EditValue,
            rdo_CongTy.SelectedIndex == 0 ? HO_TENLookupEdit.EditValue : null,
            NGHE_NGHIEPTextEdit.EditValue,
            DIA_CHITextEdit.EditValue,
            NGUOI_GHCheckEdit.EditValue,
            cothem
                ));
                LoadgrdGiaDinh(n);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message.ToString());
            }
        }
        //hàm xử lý khi xóa dữ liệu
        private void DeleteData()
        {
            if (XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgDeleteGiaDinh"), Commons.Modules.ObjLanguages.GetLanguage(this.Name, "msgTieuDeXoa"), MessageBoxButtons.YesNo) == DialogResult.No) return;
            //xóa
            try
            {
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, "DELETE dbo.GIA_DINH WHERE ID_GD = " + grvGiaDinh.GetFocusedRowCellValue("ID_GD") + "");
                grvGiaDinh.DeleteSelectedRows();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void HO_TENLookupEdit_EditValueChanged(object sender, EventArgs e)
        {
            HO_TENTextEdit.Text = HO_TENLookupEdit.Text;
        }

        private void grdGiaDinh_Click(object sender, EventArgs e)
        {

        }

        private void grvGiaDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            bool tmp = cothem;
            cothem = true;
            Bindingdata(false);
            cothem = tmp;
        }
    }
}