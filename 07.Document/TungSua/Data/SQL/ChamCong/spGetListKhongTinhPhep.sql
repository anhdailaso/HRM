ALTER PROCEDURE [dbo].[spGetListKhongTinhPhep]  
	@DNgay  DATE = '01011900',
    @ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
    @UName NVARCHAR(100) ='admin',
	@NNgu INT =0
AS 
BEGIN  
	SELECT T1.ID_CN, T2.MS_CN,T2.HO_TEN,T1.SO_THANG,T1.THANG_HT,T1.TONG_ST, T1.GHI_CHU
	FROM SO_THANG_KHONG_TP T1
	INNER JOIN (SELECT * FROM [dbo].[MGetListNhanSuToDate](@UName,@NNgu,@ID_DV,@ID_XN,@ID_TO,@DNgay)) T2
	        ON T1.ID_CN = T2.ID_CN
	WHERE LEFT(CONVERT(NVARCHAR,T1.THANG,112),6) = LEFT(CONVERT(NVARCHAR,@DNgay,112),6)
END