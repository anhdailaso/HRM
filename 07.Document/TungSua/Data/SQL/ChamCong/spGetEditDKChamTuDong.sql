ALTER PROCEDURE [dbo].[spGetEditDKChamTuDong]
    @DNgay DATETIME = '20210101',
    @ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
    @UName NVARCHAR(100) ='admin',
	@NNgu INT =0
AS
BEGIN
	SELECT * INTO #CN FROM [dbo].[MGetListNhanSuToDate](@UName, @NNgu, @ID_DV, @ID_XN, @ID_TO, @DNgay)

	SELECT T2.ID_CN, T2.MS_CN, T2.HO_TEN, T2.TEN_XN, T2.TEN_TO, CASE WHEN T1.NGAY = @DNgay THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END CHON 
	FROM #CN T2 LEFT JOIN (SELECT ID_CN, NGAY FROM DANG_KY_CHAM_TU_DONG 
	WHERE NGAY = (SELECT MAX(NGAY) FROM DANG_KY_CHAM_TU_DONG WHERE NGAY <= @DNgay)) T1 ON T1.ID_CN = T2.ID_CN
	ORDER BY T1.NGAY, T2.STT_XN, T2.STT_TO, T2.MS_CN, T2.HO_TEN
END