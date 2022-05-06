ALTER PROCEDURE [dbo].[spGetComboPhuongXa]
	@ID_QUAN BIGINT = 18,
	@Username NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@CoAll BIT=1
AS
BEGIN
IF @CoAll = 1
BEGIN
-----------------------------------------------------------------------------------------------------------------
SELECT * FROM (
SELECT ID_PX,CASE @NNgu WHEN 0 THEN TEN_PX WHEN 1 THEN ISNULL(NULLIF(TEN_PX_A,''),TEN_PX) ELSE ISNULL(NULLIF(TEN_PX_H,''),TEN_PX) END AS TEN_PX 
FROM dbo.PHUONG_XA WHERE ID_QUAN = @ID_QUAN OR @ID_QUAN = -1
UNION 
SELECT -1,'< All >')T
ORDER BY T.TEN_PX
-----------------------------------------------------------------------------------------------------------------
END
ELSE
BEGIN
-----------------------------------------------------------------------------------------------------------------
SELECT ID_PX,CASE @NNgu WHEN 0 THEN TEN_PX WHEN 1 THEN ISNULL(NULLIF(TEN_PX_A,''),TEN_PX) ELSE ISNULL(NULLIF(TEN_PX_H,''),TEN_PX) END AS TEN_PX 
FROM dbo.PHUONG_XA WHERE ID_QUAN = @ID_QUAN OR @ID_QUAN = -1
ORDER BY TEN_PX
-----------------------------------------------------------------------------------------------------------------
 END	
END	