ALTER PROCEDURE [dbo].[spGetListXI_NGHIEP]
	@Username NVARCHAR(100) ='admin',
	@NNgu INT =0
AS
BEGIN
SELECT  T1.ID_XN,T1.TEN_XN,T1.ID_DV,T1.TEN_DV,T1.STT_DV INTO #DSXN  FROM dbo.MGetToUser(@Username,@NNgu) T1
SELECT DISTINCT T1.ID_XN,T1.ID_DV,T2.TEN_DV,T1.MS_XN, T2.TEN_XN,T1.STT_XN,T1.GOP_PB,T1.GOP_TH,T2.STT_DV
FROM dbo.XI_NGHIEP T1 INNER JOIN #DSXN T2 ON T1.ID_XN = T2.ID_XN
UNION
SELECT DISTINCT T1.ID_XN,T1.ID_DV,CASE @NNgu WHEN 0 THEN T2.TEN_DV WHEN 1 THEN ISNULL(NULLIF(T2.TEN_DV_A,''),T2.TEN_DV) ELSE ISNULL(NULLIF(T2.TEN_DV_H,''),T2.TEN_DV) END AS  TEN_DV,
 T1.MS_XN,CASE @NNgu WHEN 0 THEN T1.TEN_XN WHEN 1 THEN ISNULL(NULLIF(T1.TEN_XN_A,''),T1.TEN_XN) ELSE ISNULL(NULLIF(T1.TEN_XN_H,''),T1.TEN_XN) END AS TEN_XN,T1.STT_XN,T1.GOP_PB,T1.GOP_TH,T2.STT_DV
FROM dbo.XI_NGHIEP T1 LEFT JOIN dbo.DON_VI T2 ON T2.ID_DV = T1.ID_DV
WHERE NOT EXISTS (SELECT * FROM dbo.[TO] B WHERE B.ID_XN = T1.ID_XN)
ORDER BY STT_XN	
END 

