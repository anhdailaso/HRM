using System;
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
using DevExpress.XtraEditors.Mask;

namespace Vs.TimeAttendance
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
       

        public XtraForm1()
        {
            InitializeComponent();
            //ucPhepThang uac = new ucPhepThang();
            //this.Controls.Add(uac);
            //uac.Dock = DockStyle.Fill;
            //txtDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            //txtDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            Commons.OSystems.SetDateEditFormat(maskTest);

            DataTable dt = new DataTable();
            dt.Load(SqlHelper.ExecuteReader(Commons.IConnections.CNStr, "spGetListCheDoLamViec_TEST", Convert.ToDateTime("01/01/2021"), 2, Commons.Modules.UserName, Commons.Modules.TypeLanguage));

            grdTest.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grvTest.AddNewRow();
        }
    }
}