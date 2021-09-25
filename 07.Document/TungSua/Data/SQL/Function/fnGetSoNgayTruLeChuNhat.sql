CREATE FUNCTION [dbo].[fnGetSoNgayTruLeChuNhat](@TuNgay DATE, @DenNgay DATE)  
RETURNS int   
AS   
BEGIN  
    DECLARE @ret Int, @FirstDate DATETIME, @LastDate DATETIME
	DECLARE @NL Int
	SET @FirstDate = @TuNgay
	SET @LastDate = @DenNgay
	
    SET @ret = 0
    WHILE @FirstDate <= @LastDate
	BEGIN
		SET @NL = 0
		SELECT @NL = ID_NNL FROM NGAY_NGHI_LE WHERE NGAY = @FirstDate
		IF @NL = 0  
			BEGIN
				IF DATENAME(dw, @FirstDate) != 'Sunday'
					SET @ret = @ret + 1
			END
		SET @FirstDate = @FirstDate + 1
	END
    RETURN @ret;  
END; 
