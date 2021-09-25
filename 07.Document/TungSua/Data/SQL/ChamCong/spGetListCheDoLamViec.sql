ALTER PROCEDURE [dbo].[spGetListCheDoLamViec]
    @NgayApDung DATE,
    @NhomChamCong INT,  
	@UName NVARCHAR(100) ='Admin',  
	@NNgu INT =0 
AS 
BEGIN  
	SELECT 	ID_CDLV,
			ID_NHOM,
			CA,
			NGAY,
			GIO_BD,
			GIO_KT,
			PHUT_BD,
			PHUT_KT,
			SO_PHUT,
			TRU_DAU_GIO,
			TRU_CUOI_GIO,
			PHUT_VE_SOM,
			HE_SO_NGAY_THUONG,
			HE_SO_NGAY_CN,
			HE_SO_NGAY_LE,
			TANG_CA,
			TC_DEM,
			CA_DEM,
		    NGAY_HOM_SAU,
			CA_NGAY_HOM_SAU,
			PHUT_TRUOC_CA,
			KIEM_TRA,
			CHE_DO
	FROM CHE_DO_LAM_VIEC CDLV
	WHERE CDLV.ID_NHOM = @NhomChamCong AND CAST(CDLV.NGAY AS DATE) = @NgayApDung
	ORDER BY CA
END