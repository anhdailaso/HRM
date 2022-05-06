ALTER PROCEDURE [dbo].[spGetComboThanhPho]
	@ID_QG BIGINT = -1,
	@Username NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@CoAll BIT=1
AS 
BEGIN
IF @CoAll = 1
BEGIN
-----------------------------------------------------------------------------------------------------------------
	SELECT * FROM (
	SELECT ID_TP,CASE @NNgu WHEN 0 THEN TEN_TP WHEN 1 THEN ISNULL(NULLIF(TEN_TP_A,''),TEN_TP) ELSE ISNULL(NULLIF(TEN_TP_H,''),TEN_TP) END AS TEN_TP 
	FROM dbo.THANH_PHO WHERE ID_QG =@ID_QG OR @ID_QG =-1
	UNION 
	SELECT -1,'< All >')T
	ORDER BY T.TEN_TP
-----------------------------------------------------------------------------------------------------------------
END
ELSE
BEGIN
-----------------------------------------------------------------------------------------------------------------
	SELECT ID_TP,CASE @NNgu WHEN 0 THEN TEN_TP WHEN 1 THEN ISNULL(NULLIF(TEN_TP_A,''),TEN_TP) ELSE ISNULL(NULLIF(TEN_TP_H,''),TEN_TP) END AS TEN_TP 
	FROM dbo.THANH_PHO WHERE ID_QG = @ID_QG OR @ID_QG = -1 ORDER BY TEN_TP
-----------------------------------------------------------------------------------------------------------------
 END	
END	
