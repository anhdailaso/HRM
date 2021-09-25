ALTER PROCEDURE [dbo].[spGetLuongTinhTroCapBHXH]
	@ID_CN  BIGINT = 308,
	@NGAY_TINH  DATE = '20210901',
	@LDV Nvarchar(10) = 'T1',
	@PTTC Float = 100,
	@SONV Int = 1,
	@SCON Int = 0
AS
BEGIN
	DECLARE @LUONGTT FLOAT
	DECLARE @LUONGBQ FLOAT
	DECLARE @SOTIENTC FLOAT
	
	--Tinh luong toi thieu
	SELECT @LUONGTT = [dbo].[funGetLuongToiThieu](@ID_CN,@NGAY_TINH)
	
	IF @LDV IN ('T1','T2','T4','T5','T6','T7','T8','T9') 
		BEGIN
			SELECT @LUONGBQ = [dbo].[funGetLuongBQ6Thang](@ID_CN,@NGAY_TINH)
			SET @SOTIENTC = ROUND((@LUONGBQ/26)*@SONV*@PTTC/100,-3)
		END
	ELSE 
		BEGIN
			IF @LDV IN ('T3') 
				BEGIN
					SELECT @LUONGBQ = [dbo].[funGetLuongBQ6ThangT3](@ID_CN,@NGAY_TINH)
					IF @SCON > 1
						BEGIN
							SET @SOTIENTC = @LUONGBQ * (ROUND(@SONV/30,0)+1)+(@LUONGTT * 2 * @SCON)
						END
					ELSE
						BEGIN
							SET @SOTIENTC = @LUONGBQ * ROUND(@SONV/30,0)+(@LUONGTT * 2 * @SCON)
						END
				END
			ELSE
				BEGIN
					SELECT @LUONGBQ = [dbo].[funGetLuongBQ6ThangT3](@ID_CN,@NGAY_TINH)
					SET @SOTIENTC = ROUND((@LUONGBQ/26)*@SONV*@PTTC/100,-3)
				END
		END
				
	SELECT @ID_CN ID_CN, @LUONGBQ LUONG_BQ, @LUONGTT LUONG_CB, @SOTIENTC TIEN_TC
END


