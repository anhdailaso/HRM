using System;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using DevExpress.LookAndFeel;

namespace VietSoftHRM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Commons.Modules.ModuleName = "VS_HRM";
            Commons.Modules.UserName = "admin";
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\vsconfig.xml");
            Commons.IConnections.Username = ds.Tables[0].Rows[0]["U"].ToString();
            Commons.IConnections.Server = ds.Tables[0].Rows[0]["S"].ToString();
            Commons.IConnections.Database = ds.Tables[0].Rows[0]["D"].ToString();
            Commons.IConnections.Password = ds.Tables[0].Rows[0]["P"].ToString();
            Commons.Modules.ChangLanguage = false;
            ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\lib\\savelogin.xml");
            try
            {
                Commons.Modules.TypeLanguage = int.Parse(ds.Tables[0].Rows[0]["N"].ToString());
            }
            catch { Commons.Modules.TypeLanguage = 0; }

            Commons.Modules.iSoLeSL = 1;
            Commons.Modules.iSoLeDG = 2;
            Commons.Modules.iSoLeTT = 0;
            Commons.Modules.iGio = 8;
            Commons.Modules.iNNghi = 1;
            Commons.Modules.iLamTronGio = 1;
            Commons.Modules.sSoLeSL = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeSL);
            Commons.Modules.sSoLeDG = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeDG);
            Commons.Modules.sSoLeTT = Commons.Modules.ObjSystems.sDinhDangSoLe(Commons.Modules.iSoLeTT);
            //Commons.Modules.sFontReport = "Monotype Corsiva";
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Commons.Modules.ObjSystems.KhoMoi = false;
            //Commons.Modules.PermisString = "Read only";
            Thread t = new Thread(new ThreadStart(MRunForm));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        static void MRunForm()
        {
            try
            {
                Application.Run(new frmLogin());
                //Application.Run(new Vs.Payroll.Form1());
                //Application.Run(new frmPhieuCongDoan());
                //Application.Run(new frmQTCN());
                //Application.Run(new Vs.TimeAttendance.frmVachTheLoi);
                //Application.Run(new Vs.TimeAttendance.XtraForm1());
                //Application.Run(new Vs.Category.frmEditTO(1, true));
                //Application.Run(new frmLogin());
                //Application.Run(new frmLogin());
                //Application.Run(new frmEditLOAI_HD());
                //Application.Run(new Vs.Category.frmEditQUOC_GIA(1,true));
                //Application.Run(new Vs.Category.Form1());
                //Application.Run(new Vs.Category.frmEditTO(1, true));
                //Application.Run(new Vs.Category.frmEditTHANH_PHO(2, false));
                //Application.Run(new Vs.Category.frmEditPHUONG_XA(2, false));
                //Application.Run(new Vs.Category.frmEditQUAN(4, true));
                //Application.Run(new frmPhieuCongDoan());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
