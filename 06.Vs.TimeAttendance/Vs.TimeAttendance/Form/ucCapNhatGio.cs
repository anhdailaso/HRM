using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraLayout;
using System.Threading;
using Microsoft.ApplicationBlocks.Data;
namespace Vs.HRM
{
    public partial class ucCapNhatGio : DevExpress.XtraEditors.XtraUserControl
    {
        public static ucCapNhatGio _instance;
        public static ucCapNhatGio Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucCapNhatGio();
                return _instance;
            }
        }


        public ucCapNhatGio()
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this,new List<LayoutControlGroup>{ Root}, windowsUIButton);
        }
        #region Cập nhật giờ
        private void ucCapNhatGio_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboDonVi(cboDV);
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            Commons.Modules.sPS = "";
        }
        private void cboDV_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboXiNghiep(cboDV, cboXN);
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            Commons.Modules.sPS = "";
        }
        private void cboXN_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.ObjSystems.LoadCboTo(cboDV, cboXN, cboTo);
            Commons.Modules.sPS = "";
        }
        private void cboTo_EditValueChanged(object sender, EventArgs e)
        {
            if (Commons.Modules.sPS == "0Load") return;
            Commons.Modules.sPS = "0Load";
            Commons.Modules.sPS = "";
        }
        private int TuNgayDenNgay;
        private bool kiemtrangay()
        {
            DateTime t = Convert.ToDateTime(dTuNgay.EditValue);
            DateTime d = Convert.ToDateTime(dDenNgay.EditValue);
            if(t>d)
            {
                XtraMessageBox.Show(Commons.Modules.ObjLanguages.GetLanguage(this.Name, "MSpHAILONHONNGAYDB"));
                dDenNgay.Focus();
                return false;
            }
            return true;
        }
        private void windowsUIButton_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            WindowsUIButton btn = e.Button as WindowsUIButton;
            XtraUserControl ctl = new XtraUserControl();
            switch (btn.Tag.ToString())
            {
                case "chamtudong":
                    {
                        if (!kiemtrangay()) return ;
                        TuNgayDenNgay = 0;
                        ButtonClick();
                        break;
                    }

                case "gioden":
                    {
                        TuNgayDenNgay = 1;
                        ButtonClick();
                        break;
                    }
                case "giove":
                    {
                        TuNgayDenNgay = 2;
                        ButtonClick();
                        break;
                    }
                case "thoat":
                    {
                        Commons.Modules.ObjSystems.GotoHome(this);
                        break;
                    }
            }
        }
        #endregion

        #region hàm xử lý dữ liệu

        private void ButtonClick()
        {
            try
            {
                if (TuNgayDenNgay == 0) // từ ngày đến ngày
                {
                    if(dTuNgay.Text == "" || dDenNgay.Text == "")
                    {
                        return;
                    }
                    var dates = new List<DateTime>();

                    for (DateTime dt = Convert.ToDateTime(dTuNgay.EditValue); dt <= Convert.ToDateTime(dDenNgay.EditValue); dt = dt.AddDays(1))
                    {
                        UpdateTimekeeping(dt);
                    }
                }
                else if (TuNgayDenNgay == 1) //từ ngày
                {
                    if (dTuNgay.Text == "")
                    {
                        return;
                    }
                    UpdateTimekeeping(Convert.ToDateTime(dTuNgay.EditValue));
                }
                else // đến ngày
                {
                    if (dDenNgay.Text == "")
                    {
                        return;
                    }
                    UpdateTimekeeping(Convert.ToDateTime(dDenNgay.EditValue));
                }
            }
            catch { }
        }
        private void UpdateTimekeeping(DateTime dDate)
        {
            string stbTimekeeping = "Timekeeping" + Commons.Modules.UserName;
            DataTable dt = new DataTable();
            try
            {
                dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spAutoUpdateTimekeeping", dDate, cboDV.EditValue, cboXN.EditValue,
                                        cboTo.EditValue, Commons.Modules.UserName, Commons.Modules.TypeLanguage));
                if (dt.Rows.Count == 0)
                {
                    return;
                }
                Commons.Modules.ObjSystems.MCreateTableToDatatable(Commons.IConnections.CNStr, stbTimekeeping, dt, "");

                string sSql = "DELETE DU_LIEU_QUET_THE WHERE  CONVERT(NVARCHAR,NGAY,112) = '" + Convert.ToDateTime(dDate).ToString("yyyyMMdd")
                            + "' AND ID_CN IN (SELECT ID_CN FROM " + stbTimekeeping + ")"
                            + " INSERT INTO DU_LIEU_QUET_THE (ID_CN, NGAY, ID_NHOM, CA, NGAY_DEN, GIO_DEN, PHUT_DEN, NGAY_VE, GIO_VE, PHUT_VE,CHINH_SUA) "
                                                    + " SELECT ID_CN, NGAYD, ID_NHOM, CA, NGAYD, GBD, PBD, NGAYV, GKT, PKT, 1 FROM " 
                                                    + stbTimekeeping + "";
                SqlHelper.ExecuteNonQuery(Commons.IConnections.CNStr, CommandType.Text, sSql);
                Commons.Modules.ObjSystems.XoaTable(stbTimekeeping);
                //Commons.Modules.ObjSystems.msgChung(Commons.ThongBao.msgCapNhatThanhCong);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

    }
}
