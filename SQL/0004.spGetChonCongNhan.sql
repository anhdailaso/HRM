

ALTER PROCEDURE [dbo].[spGetChonCongNhan]
	@ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =-1,
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0
AS
BEGIN
SELECT  ID_TO,ID_DV,ID_XN,TEN_XN,TEN_TO INTO #TEMPT  FROM dbo.MGetToUser(@UName,@NNgu) WHERE (ID_DV =@ID_DV OR @ID_DV =-1) AND (ID_XN =@ID_XN OR @ID_XN = -1 )
SELECT convert(bit,0)as CHON, A.ID_CN,MS_CN,HO + ' '+A.TEN AS HO_TEN,TEN_TO,TEN_XN
  FROM dbo.CONG_NHAN A
INNER JOIN #TEMPT B ON B.ID_TO = A.ID_TO
WHERE A.ID_TO = @ID_TO OR @ID_TO = -1
END
