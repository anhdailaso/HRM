ALTER PROCEDURE [dbo].[spGetListHSBT]  
	@UName NVARCHAR(100) ='Admin',  
	@NNgu INT =0 
AS 
BEGIN  
	SELECT * FROM HSBT ORDER BY TEN_BAC_THO
	
END


