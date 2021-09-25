ALTER PROCEDURE [dbo].[spGetCongNhanTheoDieuKien]
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
	@TNGAY Date = '20210301',
	@DNGAY Date = '20210331',
	@CoAll BIT=1
AS
BEGIN
	SELECT * INTO #CN FROM dbo.MGetListNhanSuFormToDate(@UName,@NNgu, @ID_DV, @ID_XN, @ID_TO, @TNGAY, @DNGAY)

	IF @CoAll =0
		BEGIN
			SELECT ID_CN, MS_CN, HO_TEN AS TEN_CN, TEN_TO 
			FROM #CN
			ORDER BY MS_CN
		END
	ELSE
		BEGIN
			SELECT ID_CN, MS_CN, HO_TEN AS TEN_CN, TEN_TO
			FROM #CN
			UNION
			SELECT -1,'','< All >', ''
			ORDER BY MS_CN
		END
END