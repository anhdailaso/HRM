ALTER PROCEDURE [dbo].[spUpdateDON_GIA_GIAY]
	@INSERT BIT,
	@NGAY_QD DATE,
    @HS_DG_GIAY FLOAT(50)
AS
    BEGIN
        IF (@INSERT = 1)
            BEGIN
                INSERT INTO dbo.DON_GIA_GIAY(NGAY_QD,HS_DG_GIAY)
				VALUES(@NGAY_QD, @HS_DG_GIAY)
            END	
        ELSE
            BEGIN
                UPDATE  dbo.DON_GIA_GIAY
                SET HS_DG_GIAY = @HS_DG_GIAY
                WHERE NGAY_QD = @NGAY_QD
            END	
    END	
