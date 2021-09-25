ALTER PROCEDURE  [dbo].[spGetListNOI_DUNG_THUONG_KHAC_LUONG]
	@UName NVARCHAR(100) ='Admin',  
	@NNgu INT =0 
AS 
BEGIN  
	SELECT [ID_NDTKL], CASE @NNgu WHEN 0 THEN T1.TEN_THUONG WHEN 1 THEN ISNULL(NULLIF(T1.TEN_THUONG_A,''),TEN_THUONG) ELSE ISNULL(NULLIF(T1.TEN_THUONG_H,''),T1.TEN_THUONG) END AS [TEN_THUONG] 
	FROM NOI_DUNG_THUONG_KHAC_LUONG T1 ORDER BY CASE @NNgu WHEN 0 THEN T1.TEN_THUONG WHEN 1 THEN ISNULL(NULLIF(T1.TEN_THUONG_A,''),TEN_THUONG) 
	ELSE ISNULL(NULLIF(T1.TEN_THUONG_H,''),T1.TEN_THUONG) END 
END