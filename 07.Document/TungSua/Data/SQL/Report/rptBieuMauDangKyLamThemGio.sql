ALTER PROCEDURE [dbo].[rptBieuMauDangKyLamThemGio]
    @ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
    @UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@Ngay Datetime = '20210301'
AS
BEGIN
SELECT T1.MS_CN, T1.HO_TEN, T1.TEN_XN, T1.TEN_TO 
FROM [dbo].[MGetListNhanSuToDate](@UName,@NNgu,@ID_DV,@ID_XN,@ID_TO,@Ngay) T1
ORDER BY T1.STT_XN, T1.STT_TO, T1.MS_CN
END