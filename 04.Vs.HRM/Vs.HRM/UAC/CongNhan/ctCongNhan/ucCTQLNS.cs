
using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Vs.HRM
{
    public partial class ucCTQLNS : DevExpress.XtraEditors.XtraUserControl
    {
        List<LabelControl> List;
        private string tab = "";
        public DataTable dt;

        public ucCTQLNS(Int64 iIdCN)
        {
            InitializeComponent();
            Commons.Modules.ObjSystems.ThayDoiNN(this);
            Commons.Modules.iCongNhan = iIdCN;
        }
        private void ucCTQLNS_Load(object sender, EventArgs e)
        {
            XuLyTab();
            Lb_Click(labLyLich, null);
        } 
        bool flag = true;
        private void XuLyTab()
        {
            List = new List<LabelControl>() { labLyLich, labCongTac, labHopDong, labTienLuong, labKhanThuong, labTaiNan, labDanhGia, labBangCap };
            foreach (LabelControl lb in List)
            {
                lb.Click += Lb_Click;
            }
        }
        private void Lb_Click(object sender, EventArgs e)
        {
            try
            {
                var lable = sender as LabelControl;
                if (Commons.Modules.iCongNhan == 0 && lable.Name != "labLyLich") return;
                if (tab == lable.Name) return;
                foreach (LabelControl lc in List)
                {
                    if (lable.Name == lc.Name)
                    {
                        lc.Appearance.ForeColor = Color.FromArgb(240, 128, 25);   //CommonColors.GetQuestionColor(DevExpress.LookAndFeel.UserLookAndFeel.Default);
                        LoaduacCongNhan(lc.Name);
                        tab = lable.Name;
                        //return;
                    }
                    if(lable.Name!=lc.Name)
                    {
                        lc.Appearance.ForeColor = Color.Empty;
                        //lc.Appearance.Font = this.Font;
                    }
                    

                }
            }
            catch
            {
            }
        } 
        private void LoaduacCongNhan(string tenlable)
        {
            
            switch (tenlable)
            {
                case "labLyLich":
                    {
                        ucLyLich ll = new ucLyLich(Commons.Modules.iCongNhan);
                        dt = ll.dt;
                        LoadUac(ll);
                        ll.back = navigationFrame1;
                        break;
                    }
                case "labCongTac":
                    {
                        ucQTCongTac ct = new ucQTCongTac(Commons.Modules.iCongNhan);
                        LoadUac(ct);
                        break;
                    }
                case "labHopDong":
                    {
                        ucHopDong hd = new ucHopDong(Commons.Modules.iCongNhan);
                        LoadUac(hd);
                        break;
                    }
                case "labTienLuong":
                    {
                        ucTienLuong tl = new ucTienLuong(Commons.Modules.iCongNhan);
                        LoadUac(tl);
                        break;
                    }
                case "labKhanThuong":
                    {
                        ucKhenThuong ll = new ucKhenThuong(Commons.Modules.iCongNhan);
                        LoadUac(ll);
                        break;
                    }
                case "labTaiNan":
                    {
                        ucTaiNanLD tn = new ucTaiNanLD(Commons.Modules.iCongNhan);
                        LoadUac(tn);
                        break;
                    }
                case "labDanhGia":
                    {
                        ucDanhGia dg = new ucDanhGia(Commons.Modules.iCongNhan);
                        LoadUac(dg);
                        break;
                    }
                case "labBangCap":
                    {
                        ucBangCap ll = new ucBangCap(Commons.Modules.iCongNhan);
                        LoadUac(ll);
                        break;
                    }
                default:
                    break;
            }
        }
        private void LoadUac(XtraUserControl uac)
        {
            //if (checkfameexits(uac.Name).Tag != null)
            //{
              //  navigationFrame1.SelectedPage = checkfameexits(uac.Name); return;
            //}
            uac.Dock = DockStyle.Fill;
            NavigationPage page = new NavigationPage();
            page.Tag = uac.Name;
            page.Controls.Add(uac);
            navigationFrame1.Pages.Add(page);
            navigationFrame1.SelectedPageIndex = navigationFrame1.Pages.Count;
        }
        private NavigationPage checkfameexits(string tab)
        {
            NavigationPage page = new NavigationPage();
            foreach (NavigationPage item in navigationFrame1.Pages)
            {
                if (item.Tag == tab)
                {
                    page = item;
                }

            }
            return page;
        }

    }
}
