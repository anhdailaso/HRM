ALTER FUNCTION [dbo].[fuKiemTraKeHoachNghiPhep]
( @ID_CN INT,@TU_NGAY DATE,@DEN_NGAY DATE)
RETURNS INT
AS
BEGIN
	DECLARE @resulst INT = 0;
	DECLARE @ngay DATE =@TU_NGAY;
	WHILE (@ngay <= @DEN_NGAY) 
	BEGIN
	SET @resulst = @resulst + (SELECT COUNT(*) FROM dbo.KE_HOACH_NGHI_PHEP WHERE (CONVERT(DATE,TU_NGAY) <= @ngay AND CONVERT(DATE, DEN_NGAY) >= @ngay) AND ID_CN =@ID_CN)
	SET @ngay = DATEADD(DAY, 1, @ngay);
	END
	RETURN @resulst;
END



