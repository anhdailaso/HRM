﻿namespace Vs.TimeAttendance
{
    partial class rptDSVangDauGioTheoDV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rptDSVangDauGioTheoDV));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.NONlblTIEU_DE = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.Title_Stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiPhongBan = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiTo = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiSoLuongCN = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblDIA_CHI = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCONG_TY = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDienThoai = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFax = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lbNguoiLapBieu = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNgay = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.NONlbNgay = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 185F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 192F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 75F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            this.Detail.StylePriority.UseTextAlignment = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 254F;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1846F, 75F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell7,
            this.xrTableCell11,
            this.xrTableCell2});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.xrTableCell1.Summary = xrSummary1;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 0.42279750045294179D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TEN_XN]")});
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "xrTableCell7";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell7.Weight = 3.3850366683705606D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TEN_TO]")});
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.StylePriority.UseTextAlignment = false;
            this.xrTableCell11.Text = "xrTableCell11";
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell11.Weight = 2.3805324854966887D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SLCN]")});
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "xrTableCell2";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell2.Weight = 1.4822390958123035D;
            // 
            // NONlblTIEU_DE
            // 
            this.NONlblTIEU_DE.Dpi = 254F;
            this.NONlblTIEU_DE.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NONlblTIEU_DE.LocationFloat = new DevExpress.Utils.PointFloat(8.106232E-05F, 247.4563F);
            this.NONlblTIEU_DE.Multiline = true;
            this.NONlblTIEU_DE.Name = "NONlblTIEU_DE";
            this.NONlblTIEU_DE.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.NONlblTIEU_DE.SizeF = new System.Drawing.SizeF(1846F, 99.99998F);
            this.NONlblTIEU_DE.StylePriority.UseFont = false;
            this.NONlblTIEU_DE.StylePriority.UsePadding = false;
            this.NONlblTIEU_DE.StylePriority.UseTextAlignment = false;
            this.NONlblTIEU_DE.Text = "THEO ĐƠN VỊ";
            this.NONlblTIEU_DE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.HeightF = 75F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1846F, 75F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Title_Stt,
            this.tiPhongBan,
            this.tiTo,
            this.tiSoLuongCN});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.81904681818500513D;
            // 
            // Title_Stt
            // 
            this.Title_Stt.Dpi = 254F;
            this.Title_Stt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Stt.Multiline = true;
            this.Title_Stt.Name = "Title_Stt";
            this.Title_Stt.RowSpan = 2;
            this.Title_Stt.StylePriority.UseFont = false;
            this.Title_Stt.StylePriority.UseTextAlignment = false;
            this.Title_Stt.Text = "Stt";
            this.Title_Stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.Title_Stt.Weight = 1.7639768462346055D;
            // 
            // tiPhongBan
            // 
            this.tiPhongBan.Dpi = 254F;
            this.tiPhongBan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiPhongBan.Multiline = true;
            this.tiPhongBan.Name = "tiPhongBan";
            this.tiPhongBan.StylePriority.UseFont = false;
            this.tiPhongBan.Text = "Phòng ban";
            this.tiPhongBan.Weight = 14.122898747766596D;
            // 
            // tiTo
            // 
            this.tiTo.Dpi = 254F;
            this.tiTo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiTo.Multiline = true;
            this.tiTo.Name = "tiTo";
            this.tiTo.StylePriority.UseFont = false;
            this.tiTo.Text = "Tổ";
            this.tiTo.Weight = 9.9319511604466655D;
            // 
            // tiSoLuongCN
            // 
            this.tiSoLuongCN.Dpi = 254F;
            this.tiSoLuongCN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiSoLuongCN.Multiline = true;
            this.tiSoLuongCN.Name = "tiSoLuongCN";
            this.tiSoLuongCN.StylePriority.UseFont = false;
            this.tiSoLuongCN.Text = "Vắng mặt";
            this.tiSoLuongCN.Weight = 6.1841322841489692D;
            // 
            // lblDIA_CHI
            // 
            this.lblDIA_CHI.AllowMarkupText = true;
            this.lblDIA_CHI.AutoWidth = true;
            this.lblDIA_CHI.Dpi = 254F;
            this.lblDIA_CHI.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TTC].[DIA_CHI]")});
            this.lblDIA_CHI.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDIA_CHI.LocationFloat = new DevExpress.Utils.PointFloat(372.2663F, 69.99997F);
            this.lblDIA_CHI.Multiline = true;
            this.lblDIA_CHI.Name = "lblDIA_CHI";
            this.lblDIA_CHI.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblDIA_CHI.SizeF = new System.Drawing.SizeF(1317.73F, 70F);
            this.lblDIA_CHI.StylePriority.UseFont = false;
            this.lblDIA_CHI.StylePriority.UsePadding = false;
            this.lblDIA_CHI.StylePriority.UseTextAlignment = false;
            this.lblDIA_CHI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCONG_TY
            // 
            this.lblCONG_TY.AllowMarkupText = true;
            this.lblCONG_TY.AutoWidth = true;
            this.lblCONG_TY.Dpi = 254F;
            this.lblCONG_TY.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TTC].[TEN_CTY]")});
            this.lblCONG_TY.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONG_TY.LocationFloat = new DevExpress.Utils.PointFloat(372.2659F, 0F);
            this.lblCONG_TY.Multiline = true;
            this.lblCONG_TY.Name = "lblCONG_TY";
            this.lblCONG_TY.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblCONG_TY.SizeF = new System.Drawing.SizeF(1317.73F, 70F);
            this.lblCONG_TY.StylePriority.UseFont = false;
            this.lblCONG_TY.StylePriority.UsePadding = false;
            this.lblCONG_TY.StylePriority.UseTextAlignment = false;
            this.lblCONG_TY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AllowMarkupText = true;
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TTC].[FAX]")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1308.166F, 140F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(381.83F, 70F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.AllowMarkupText = true;
            this.xrLabel2.AutoWidth = true;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TTC].[DIEN_THOAI]")});
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(602.4546F, 140.0001F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(597.2314F, 70F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AllowMarkupText = true;
            this.lblDienThoai.AutoWidth = true;
            this.lblDienThoai.Dpi = 254F;
            this.lblDienThoai.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienThoai.LocationFloat = new DevExpress.Utils.PointFloat(372.2646F, 140F);
            this.lblDienThoai.Multiline = true;
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblDienThoai.SizeF = new System.Drawing.SizeF(230.19F, 70F);
            this.lblDienThoai.StylePriority.UseFont = false;
            this.lblDienThoai.StylePriority.UsePadding = false;
            this.lblDienThoai.StylePriority.UseTextAlignment = false;
            this.lblDienThoai.Text = "DT";
            this.lblDienThoai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblFax
            // 
            this.lblFax.AllowMarkupText = true;
            this.lblFax.AutoWidth = true;
            this.lblFax.Dpi = 254F;
            this.lblFax.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.LocationFloat = new DevExpress.Utils.PointFloat(1199.686F, 140F);
            this.lblFax.Multiline = true;
            this.lblFax.Name = "lblFax";
            this.lblFax.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblFax.SizeF = new System.Drawing.SizeF(108.48F, 70F);
            this.lblFax.StylePriority.UseFont = false;
            this.lblFax.StylePriority.UsePadding = false;
            this.lblFax.StylePriority.UseTextAlignment = false;
            this.lblFax.Text = "Fax";
            this.lblFax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNguoiLapBieu,
            this.lblNgay});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.HeightF = 152.4233F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lbNguoiLapBieu
            // 
            this.lbNguoiLapBieu.AllowMarkupText = true;
            this.lbNguoiLapBieu.AutoWidth = true;
            this.lbNguoiLapBieu.Dpi = 254F;
            this.lbNguoiLapBieu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoiLapBieu.LocationFloat = new DevExpress.Utils.PointFloat(1150F, 88.71164F);
            this.lbNguoiLapBieu.Multiline = true;
            this.lbNguoiLapBieu.Name = "lbNguoiLapBieu";
            this.lbNguoiLapBieu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lbNguoiLapBieu.SizeF = new System.Drawing.SizeF(603.25F, 63.71169F);
            this.lbNguoiLapBieu.StylePriority.UseFont = false;
            this.lbNguoiLapBieu.StylePriority.UseTextAlignment = false;
            this.lbNguoiLapBieu.Text = "Người lập biểu";
            this.lbNguoiLapBieu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblNgay
            // 
            this.lblNgay.AllowMarkupText = true;
            this.lblNgay.AutoWidth = true;
            this.lblNgay.Dpi = 254F;
            this.lblNgay.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.LocationFloat = new DevExpress.Utils.PointFloat(1150F, 25.00001F);
            this.lblNgay.Multiline = true;
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblNgay.SizeF = new System.Drawing.SizeF(603.25F, 63.71169F);
            this.lblNgay.StylePriority.UseFont = false;
            this.lblNgay.StylePriority.UseTextAlignment = false;
            this.lblNgay.Text = "NGAY";
            this.lblNgay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.NONlbNgay,
            this.lblCONG_TY,
            this.NONlblTIEU_DE,
            this.lblFax,
            this.lblDienThoai,
            this.xrLabel2,
            this.xrLabel1,
            this.lblDIA_CHI,
            this.xrPictureBox1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 489.8334F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // NONlbNgay
            // 
            this.NONlbNgay.Dpi = 254F;
            this.NONlbNgay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NONlbNgay.LocationFloat = new DevExpress.Utils.PointFloat(0F, 347.4563F);
            this.NONlbNgay.Multiline = true;
            this.NONlbNgay.Name = "NONlbNgay";
            this.NONlbNgay.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.NONlbNgay.SizeF = new System.Drawing.SizeF(1846F, 77.68954F);
            this.NONlbNgay.StylePriority.UseFont = false;
            this.NONlbNgay.StylePriority.UseTextAlignment = false;
            this.NONlbNgay.Text = "Ngày : 01/06/2020";
            this.NONlbNgay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "ImageSource", "[TTC].[LOGO]")});
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(8.074442E-05F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(372.2645F, 210F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // rptDSVangDauGioTheoDV
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader,
            this.ReportFooter,
            this.ReportHeader});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(111, 135, 185, 192);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Tag = "rptDSVangDauGioTheoDV";
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel NONlblTIEU_DE;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblDIA_CHI;
        private DevExpress.XtraReports.UI.XRLabel lblCONG_TY;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell Title_Stt;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblFax;
        private DevExpress.XtraReports.UI.XRLabel lblDienThoai;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblNgay;
        private DevExpress.XtraReports.UI.XRTableCell tiTo;
        private DevExpress.XtraReports.UI.XRTableCell tiSoLuongCN;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRLabel lbNguoiLapBieu;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tiPhongBan;
        private DevExpress.XtraReports.UI.XRLabel NONlbNgay;
    }
}