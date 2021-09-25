--SELECT * FROM dbo.CONG_NHAN

----hệ số của lý thôi việc .... HS_LUONG là lương trợ cấp tiền trợ cấp s
--SELECT * FROM [dbo].[GetTienTroCap](GETDATE(),25,4)
ALTER FUNCTION [dbo].[GetTienTroCap]
(
	@NgayThoiViec DateTime,
	@ID_CN Int,
	@ID_LD_TV INT
)

RETURNS @TroCap TABLE (
	ID_CN BIGINT NULL,
	LUONG_TRO_CAP FLOAT NULL,
	TIEN_TRO_CAP FLOAT NULL
)
AS	
BEGIN
    DECLARE @NgayHetQDTroCap DateTime
	DECLARE @NgayTinhTroCap DateTime
	DECLARE @NgayLayLuong DATETIME
    DECLARE @NgayVaoLam DateTime
	DECLARE @SoNgayLV Int = 0
	DECLARE @SoNamTra Float = 0
	DECLARE @SoThangTra Int = 0
	DECLARE @LuongTT Int = 0
	DECLARE @LuongTinhPC Int = 0
	DECLARE @TienTroCap Int = 0
	SET @NgayVaoLam = (SELECT NGAY_VAO_LAM FROM dbo.CONG_NHAN WHERE ID_CN =@ID_CN)
	SET @NgayHetQDTroCap = CONVERT(datetime,'20081231',102)

	IF @NgayThoiViec > @NgayHetQDTroCap 
		BEGIN
			SET @NgayTinhTroCap = @NgayHetQDTroCap
		END
	ELSE
		BEGIN
			SET @NgayTinhTroCap = @NgayThoiViec	
		END
	
	IF @NgayVaoLam > @NgayHetQDTroCap
		BEGIN
			SET @LuongTinhPC = 0
			SET @TienTroCap = 0
		END
	ELSE
		BEGIN
			SET @SoNgayLV = DATEDIFF(DAY,@NgayVaoLam,@NgayTinhTroCap)
			SET @SoNamTra = FLOOR(@SoNgayLV/365)
			SET @SoThangTra = (@SoNgayLV - (@SoNamTra*365))/30

			IF @SoThangTra > 0 AND @SoThangTra <= 6 
				BEGIN
					SET @SoNamTra = @SoNamTra + 0.5
				END
			ELSE
				BEGIN
					SET @SoNamTra = @SoNamTra + 1
				END

			SET @LuongTT = [dbo].[funGetLuongToiThieu](@ID_CN,@NgayThoiViec)

			IF DAY(@NgayThoiViec) > 15 
				BEGIN
					SET @NgayLayLuong =@NgayThoiViec 
				END
			ELSE
				BEGIN
					SET @NgayLayLuong =@NgayThoiViec - DAY(@NgayThoiViec)
				END
			DECLARE @cnt INT = 0
			DECLARE @LuongThang Int
			DECLARE @Luong6Thang Int = 0
			DECLARE @SoThangTinh Int = 0
			WHILE @cnt < 6
			BEGIN
				SET @LuongThang = 0
				SELECT @LuongThang = ML + PC FROM [dbo].[funGetLuongKyHopDong](@ID_CN, @NgayLayLuong)
				IF ISNULL(@LuongThang,0) > 0
					BEGIN
						SET @Luong6Thang = @Luong6Thang + @LuongThang
						SET @SoThangTinh = @SoThangTinh + 1
					END
				SET @NgayLayLuong = DATEADD(M,-1,@NgayLayLuong)
				SET @cnt = @cnt + 1
			END
			IF @SoThangTinh > 0
				BEGIN
					SET @LuongTinhPC = ROUND(@Luong6Thang/@SoThangTinh,0)
				END
			ELSE
				BEGIN
					SET @LuongTinhPC = 0
				END
			SET @TienTroCap = @SoNamTra * @LuongTinhPC * (SELECT HE_SO FROM dbo.LY_DO_THOI_VIEC WHERE ID_LD_TV = @ID_LD_TV)
		END
	INSERT INTO @TroCap(ID_CN, LUONG_TRO_CAP, TIEN_TRO_CAP)
	SELECT @ID_CN, @LuongTinhPC, @TienTroCap
RETURN
END
