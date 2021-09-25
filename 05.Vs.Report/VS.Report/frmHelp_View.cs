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
using DevExpress.XtraReports.UI;

namespace Vs.Report
{
    public partial class frmHelp_View : DevExpress.XtraEditors.XtraForm
    {
        public frmHelp_View()
        {
            InitializeComponent();
        }

        private void frmHelp_View_Load(object sender, EventArgs e)
        {

            // Commons.Modules.iCongNhan = 161;
            // ucThuongKhacLuong ns = new ucThuongKhacLuong();
            // //ucDaoTao ns = new ucDaoTao();
            // //ucDanhGia ns = new ucDanhGia(161);
            // //ucHopDong ns = new ucHopDong(161);
            // //ucLyLich ns = new ucLyLich(161);
            // //ucTaiNanLD ns = new ucTaiNanLD(24);
            // //ucBHXHThang ns = new ucBHXHThang();
            // this.Controls.Clear();
            // this.Controls.Add(ns);
            // ns.Dock = DockStyle.Fill;
        }
        public void ShowDiaLogControls(Control fr)
        {
            string str = "";

            foreach (Control c1 in fr.Controls)
            {
                str += c1.Name + "\n";
                foreach (Control c2 in c1.Controls)
                {
                    str += "\t" + c2.Name + "\n";
                    List<Control> l3 = new List<Control>();
                    foreach (Control c3 in c2.Controls)
                    {
                        str += "\t\t" + c3.Name + "\n";
                        foreach (Control c4 in c3.Controls)
                        {
                            str += "\t\t\t" + c4.Name + "\n";
                            foreach (Control c5 in c4.Controls)
                            {
                                str += "\t\t\t\t" + c5.Name + "\n";
                                foreach (Control c6 in c5.Controls)
                                {
                                    str += "\t\t\t\t\t" + c6.Name + "\n";
                                    foreach (Control c7 in c6.Controls)
                                    {
                                        str += "\t\t\t\t\t\t" + c7.Name + "\n";
                                        foreach (Control c8 in c7.Controls)
                                        {
                                            str += "\t\t\t\t\t\t\t" + c8.Name + "\n";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            txHelp.Text = str;
            this.ShowDialog();
        }
        public void ShowDiaLogControls2(XtraReport report)
        {
            string str = "";
            str += report.Band + "\n";

            DataSet ds = (DataSet)report.DataSource;
            if (ds.Tables.Count > 0)
            {
                DataGrid dg = new DataGrid();
                dg.Dock = System.Windows.Forms.DockStyle.Fill;
                dg.DataSource = ds.Tables[0];
                dg.Name = ds.Tables[0].TableName;
                panelControl1.Controls.Add(dg);
            }

            if (ds.Tables.Count > 1)
            {
                DataGrid dg = new DataGrid();
                dg.Dock = System.Windows.Forms.DockStyle.Fill;
                dg.DataSource = ds.Tables[1];
                dg.Name = ds.Tables[1].TableName;

                panelControl2.Controls.Add(dg);
            }
            if (ds.Tables.Count > 2)
            {
                DataGrid dg = new DataGrid();
                dg.Dock = System.Windows.Forms.DockStyle.Fill;
                dg.DataSource = ds.Tables[2];
                dg.Name = ds.Tables[2].TableName;

                panelControl3.Controls.Add(dg);
            }


            txHelp.Text = str;
            this.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:

                    this.Close();
                    return true;
           //     case Keys.Control | Keys.C:
           //         Clipboard.SetText(txHelp.Text);
           //         return true;
                default: return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}