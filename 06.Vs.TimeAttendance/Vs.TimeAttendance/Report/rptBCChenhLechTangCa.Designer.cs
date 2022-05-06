namespace Vs.TimeAttendance.Report
{
    partial class rptBCChenhLechTangCa
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.lblDIA_CHI = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCONG_TY = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel88 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.Title_Stt = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiMSoCN = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiHoTen = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiPhongBan = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiTo = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiGioDen = new DevExpress.XtraReports.UI.XRTableCell();
            this.tiGioDKT = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblDIA_CHI,
            this.lblCONG_TY,
            this.xrLabel88});
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Name = "ReportFooter";
            // 
            // lblDIA_CHI
            // 
            this.lblDIA_CHI.AllowMarkupText = true;
            this.lblDIA_CHI.AutoWidth = true;
            this.lblDIA_CHI.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DATA].[DIA_CHI_DV]")});
            this.lblDIA_CHI.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDIA_CHI.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 27.55906F);
            this.lblDIA_CHI.Multiline = true;
            this.lblDIA_CHI.Name = "lblDIA_CHI";
            this.lblDIA_CHI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDIA_CHI.SizeF = new System.Drawing.SizeF(1129F, 27.55906F);
            this.lblDIA_CHI.StylePriority.UseFont = false;
            this.lblDIA_CHI.StylePriority.UsePadding = false;
            this.lblDIA_CHI.StylePriority.UseTextAlignment = false;
            this.lblDIA_CHI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblCONG_TY
            // 
            this.lblCONG_TY.AllowMarkupText = true;
            this.lblCONG_TY.AutoWidth = true;
            this.lblCONG_TY.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DATA].[TEN_DV]")});
            this.lblCONG_TY.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCONG_TY.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblCONG_TY.Multiline = true;
            this.lblCONG_TY.Name = "lblCONG_TY";
            this.lblCONG_TY.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCONG_TY.SizeF = new System.Drawing.SizeF(1129F, 27.55906F);
            this.lblCONG_TY.StylePriority.UseFont = false;
            this.lblCONG_TY.StylePriority.UsePadding = false;
            this.lblCONG_TY.StylePriority.UseTextAlignment = false;
            this.lblCONG_TY.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel88
            // 
            this.xrLabel88.AllowMarkupText = true;
            this.xrLabel88.AutoWidth = true;
            this.xrLabel88.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Tel: \' + [TTC].[DIEN_THOAI] + \' - Fax: \' + [TTC].[FAX]")});
            this.xrLabel88.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel88.LocationFloat = new DevExpress.Utils.PointFloat(0F, 55.11808F);
            this.xrLabel88.Multiline = true;
            this.xrLabel88.Name = "xrLabel88";
            this.xrLabel88.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel88.SizeF = new System.Drawing.SizeF(1129F, 27.55906F);
            this.xrLabel88.StylePriority.UseFont = false;
            this.xrLabel88.StylePriority.UsePadding = false;
            this.xrLabel88.StylePriority.UseTextAlignment = false;
            this.xrLabel88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(821.6497F, 29.52756F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.Title_Stt,
            this.tiMSoCN,
            this.tiHoTen,
            this.tiPhongBan,
            this.tiTo,
            this.tiGioDen,
            this.tiGioDKT});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.81904681818500513D;
            // 
            // Title_Stt
            // 
            this.Title_Stt.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title_Stt.Multiline = true;
            this.Title_Stt.Name = "Title_Stt";
            this.Title_Stt.RowSpan = 2;
            this.Title_Stt.StylePriority.UseFont = false;
            this.Title_Stt.StylePriority.UseTextAlignment = false;
            this.Title_Stt.Text = "Stt";
            this.Title_Stt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.Title_Stt.Weight = 1.3332068143509246D;
            // 
            // tiMSoCN
            // 
            this.tiMSoCN.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiMSoCN.Multiline = true;
            this.tiMSoCN.Name = "tiMSoCN";
            this.tiMSoCN.StylePriority.UseFont = false;
            this.tiMSoCN.Text = "Họ và tên";
            this.tiMSoCN.Weight = 3.1036722745774048D;
            // 
            // tiHoTen
            // 
            this.tiHoTen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiHoTen.Multiline = true;
            this.tiHoTen.Name = "tiHoTen";
            this.tiHoTen.StylePriority.UseFont = false;
            this.tiHoTen.Text = "Mã thẻ";
            this.tiHoTen.Weight = 4.7066965380595347D;
            // 
            // tiPhongBan
            // 
            this.tiPhongBan.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiPhongBan.Multiline = true;
            this.tiPhongBan.Name = "tiPhongBan";
            this.tiPhongBan.StylePriority.UseFont = false;
            this.tiPhongBan.Text = "Bộ phận";
            this.tiPhongBan.Weight = 3.8520793880519815D;
            // 
            // tiTo
            // 
            this.tiTo.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiTo.Multiline = true;
            this.tiTo.Name = "tiTo";
            this.tiTo.StylePriority.UseFont = false;
            this.tiTo.Text = "Tổng hợp tăng ca";
            this.tiTo.Weight = 8.13912291390636D;
            // 
            // tiGioDen
            // 
            this.tiGioDen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiGioDen.Multiline = true;
            this.tiGioDen.Name = "tiGioDen";
            this.tiGioDen.StylePriority.UseFont = false;
            this.tiGioDen.Text = "WORKING DAY";
            this.tiGioDen.Weight = 3.5136643932723675D;
            // 
            // tiGioDKT
            // 
            this.tiGioDKT.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiGioDKT.Multiline = true;
            this.tiGioDKT.Name = "tiGioDKT";
            this.tiGioDKT.StylePriority.UseFont = false;
            this.tiGioDKT.Text = "Ký xác nhận";
            this.tiGioDKT.Weight = 3.5311423291533623D;
            // 
            // rptBCChenhLechTangCa
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.ReportFooter});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 100, 100);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.1";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lblDIA_CHI;
        private DevExpress.XtraReports.UI.XRLabel lblCONG_TY;
        private DevExpress.XtraReports.UI.XRLabel xrLabel88;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell Title_Stt;
        private DevExpress.XtraReports.UI.XRTableCell tiMSoCN;
        private DevExpress.XtraReports.UI.XRTableCell tiHoTen;
        private DevExpress.XtraReports.UI.XRTableCell tiPhongBan;
        private DevExpress.XtraReports.UI.XRTableCell tiTo;
        private DevExpress.XtraReports.UI.XRTableCell tiGioDen;
        private DevExpress.XtraReports.UI.XRTableCell tiGioDKT;
    }
}
