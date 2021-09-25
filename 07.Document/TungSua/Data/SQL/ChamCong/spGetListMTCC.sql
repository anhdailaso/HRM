ALTER PROCEDURE [dbo].[spGetListMTCC]
	@DNgay  DATE = '20210101',
    @ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
    @UName NVARCHAR(100) ='admin',
	@NNgu INT =0
	 AS
BEGIN
	
	SELECT * INTO #CN FROM [dbo].[MGetListNhanSuToDate](@UName,@NNgu,@ID_DV,@ID_XN,@ID_TO,@DNgay)

	SELECT ID_CN, MS_CN, HO + ' ' + TEN HO_TEN, NGAY_VAO_CTY, MS_THE_CC 
    FROM #CN 
    ORDER BY MS_CN
END;