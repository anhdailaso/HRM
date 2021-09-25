ALTER FUNCTION [dbo].[fnGetSoNgayTruChuNhat](@TuNgay DATE, @DenNgay DATE)  
RETURNS int   
AS   
BEGIN  
    DECLARE @ret Int, @FirstDate DATETIME, @LastDate DATETIME
	SET @FirstDate = @TuNgay
	SET @LastDate = @DenNgay
	
    SET @ret = 0
    WHILE @FirstDate <= @LastDate
	BEGIN
		IF DATENAME(dw, @FirstDate) != 'Sunday'
			SET @ret = @ret + 1
		SET @FirstDate = @FirstDate + 1
	END
    RETURN @ret;  
END; 
