ALTER PROCEDURE [dbo].[rptHopDongLaoDong]
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@ID_CN BIGINT,
	@ID_SQD BIGINT
AS 
BEGIN

	
	SELECT CN.MS_CN, CN.HO + ' ' + TEN HO_TEN, CN.SO_CMND, CN.NGAY_CAP, TP.TEN_TP NOI_CAP, CN.NGAY_SINH, CN.DIA_CHI_THUONG_TRU, QG.TEN_QG,
	CASE WHEN CN.PHAI = 0 THEN N'Nữ' ELSE 'NAM' END GIOI_TINH, SO_HDLD, LHD.TEN_LHDLD, HDLD.NGAY_BAT_DAU_HD, HDLD.NGAY_HET_HD, CVU.TEN_CV, 
	LCV.TEN_LCV CONG_VIEC, HDLD.DIA_DIEM_LAM_VIEC, HDLD.CONG_VIEC, HDLD.MUC_LUONG_CHINH MUC_LUONG, HDLD.CHI_SO_PHU_CAP PHU_CAP,
	DV.TEN_DV, DV.DIA_CHI DC_DV, DV.DIEN_THOAI DT_DV, DV.FAX, NK.HO_TEN TEN_NK, NK.QUOC_TICH, NK.CHUC_VU CV_NK, NK.NGAY_SINH NS_NK, NK.DIA_CHI DC_NK, 
	NK.SO_CMND CM_NK, NK.CAP_NGAY NGAY_CAP_NK, NK.NOI_CAP NOI_CAP_NK
	FROM HOP_DONG_LAO_DONG HDLD INNER JOIN CONG_NHAN CN ON HDLD.ID_CN = CN.ID_CN
	INNER JOIN QUOC_GIA QG ON CN.ID_QG = QG.ID_QG
	INNER JOIN [TO] T ON CN.ID_TO = T.ID_TO INNER JOIN XI_NGHIEP XN ON T.ID_XN = XN.ID_XN INNER JOIN DON_VI DV ON XN.ID_DV = DV.ID_DV
	INNER JOIN LOAI_HDLD LHD ON HDLD.ID_LHDLD = LHD.ID_LHDLD
	INNER JOIN CHUC_VU CVU ON HDLD.ID_CV = CVU.ID_CV
	LEFT JOIN THANH_PHO TP ON CN.NOI_CAP = TP.ID_TP
	LEFT JOIN LOAI_CONG_VIEC LCV ON LCV.ID_LCV = CN.ID_LCV
	LEFT JOIN NGUOI_KY_GIAY_TO NK ON HDLD.NGUOI_KY_GIA_HAN = NK.ID_NK
	WHERE HDLD.ID_HDLD = @ID_SQD AND HDLD.ID_CN = @ID_CN
END


