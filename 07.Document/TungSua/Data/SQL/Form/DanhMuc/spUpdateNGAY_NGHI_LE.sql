ALTER PROCEDURE [dbo].[spUpdateNGAY_NGHI_LE]
	@INSERT BIT,
	@NGAY DATE,
    @LY_DO NVARCHAR(50)
AS
    BEGIN
        IF (@INSERT = 1)
            BEGIN
                INSERT INTO dbo.NGAY_NGHI_LE(NGAY,LY_DO)
				VALUES(@NGAY, @LY_DO)
            END	
        ELSE
            BEGIN
                UPDATE  dbo.NGAY_NGHI_LE
                SET LY_DO = @LY_DO
                WHERE NGAY = @NGAY
            END	
    END	
