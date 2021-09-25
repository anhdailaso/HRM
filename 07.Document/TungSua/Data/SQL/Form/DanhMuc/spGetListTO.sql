ALTER PROCEDURE [dbo].[spGetListTO]
	@UName NVARCHAR(100) ='ADMIN',
	@NNgu INT =0
AS
BEGIN
SELECT DISTINCT ID_TO,TEN_TO INTO #TEMP  FROM dbo.MGetToUser(@UName,@NNgu)

SELECT DISTINCT T1.ID_TO,T1.MS_TO, T2.TEN_TO,T1.STT_TO,T1.ID_XN INTO #TO_TMP
FROM dbo.[TO] T1 INNER JOIN #TEMP T2 ON T1.ID_TO = T2.ID_TO
UNION
SELECT DISTINCT T1.ID_TO,T1.MS_TO,CASE @NNgu WHEN 0 THEN T1.TEN_TO WHEN 1 THEN ISNULL(NULLIF(T1.TEN_TO_A,''),T1.TEN_TO) ELSE ISNULL(NULLIF(T1.TEN_TO_H,''),T1.TEN_TO) END AS TEN_TO,T1.STT_TO,T1.ID_XN
FROM dbo.[TO] T1 LEFT JOIN dbo.NHOM_TO T2 ON T2.ID_TO = T1.ID_TO 
GROUP BY T1.ID_TO,T1.MS_TO ,CASE @NNgu WHEN 0 THEN T1.TEN_TO WHEN 1 THEN ISNULL(NULLIF(T1.TEN_TO_A,''),T1.TEN_TO) ELSE ISNULL(NULLIF(T1.TEN_TO_H,''),T1.TEN_TO) END ,T1.STT_TO,T1.ID_XN 
HAVING COUNT(T2.ID_TO) = 0 

SELECT T1.ID_TO,
	CASE @NNgu WHEN 0 THEN T3.TEN_DV WHEN 1 THEN ISNULL(NULLIF(T3.TEN_DV_A,''),T3.TEN_DV) ELSE ISNULL(NULLIF(T3.TEN_DV_H,''),T3.TEN_DV) END AS TEN_DV,
	CASE @NNgu WHEN 0 THEN T2.TEN_XN WHEN 1 THEN ISNULL(NULLIF(T2.TEN_XN_A,''),TEN_XN) ELSE ISNULL(NULLIF(T2.TEN_XN_H,''),TEN_XN) END AS TEN_XN,
       T1.MS_TO,T1.TEN_TO,T1.STT_TO, T2.ID_DV,T1.ID_XN
FROM dbo.#TO_TMP T1 INNER JOIN dbo.XI_NGHIEP T2 ON T2.ID_XN = T1.ID_XN INNER JOIN dbo.DON_VI T3 ON	T3.ID_DV = T2.ID_DV		
ORDER BY ISNULL(T3.STT_DV,9999), CASE @NNgu WHEN 0 THEN T3.TEN_DV WHEN 1 THEN ISNULL(NULLIF(T3.TEN_DV_A,''),T3.TEN_DV) ELSE ISNULL(NULLIF(T3.TEN_DV_H,''),T3.TEN_DV) END,
ISNULL(T2.STT_XN,9999), CASE @NNgu WHEN 0 THEN T2.TEN_XN WHEN 1 THEN ISNULL(NULLIF(T2.TEN_XN_A,''),TEN_XN) ELSE ISNULL(NULLIF(T2.TEN_XN_H,''),TEN_XN) END,
ISNULL(T1.STT_TO,9999), T1.TEN_TO
END

