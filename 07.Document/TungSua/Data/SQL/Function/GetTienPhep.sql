---tổng cộng = tiền trợ cấp + tiền phép + trợ cấp khác
--SELECT * FROM [dbo].[GetTienPhep](GETDATE(),24)
ALTER FUNCTION [dbo].[GetTienPhep]
(
	@NgayThoiViec DateTime,
	@ID_CN Int
)

RETURNS @TienPhep TABLE (
	ID_CN BIGINT NULL,
	LUONG_TP FLOAT NULL,
	SO_NGAY_PHEP FLOAT NULL,
	TIEN_PHEP FLOAT NULL
)
AS	
BEGIN
    DECLARE @NgayBDTinhPhep DateTime
	DECLARE @NgayKTTinhPhep DATETIME
    DECLARE @NgayVaoLam DATETIME
	DECLARE @SoNgayNghi numeric(18, 2)
	DECLARE @SoThangLV Int
	DECLARE @PhepThamNien Int
	DECLARE @PhepCongThem Int
	DECLARE @PhepDuocHuong numeric(18, 2)
	DECLARE @LuongThang Int = 0
	DECLARE @SoPhepConLai numeric(18, 2)
	DECLARE @TienPhepConLai Int = 0
	SET @NgayVaoLam = (SELECT NGAY_VAO_LAM FROM dbo.CONG_NHAN WHERE ID_CN =@ID_CN)
	SELECT @SoNgayNghi = T1.SNN FROM (SELECT ID_CN,SUM(ISNULL(SO_GIO,(DATEDIFF(D,TU_NGAY,DEN_NGAY)+1)*8))/8 SNN 
	FROM KE_HOACH_NGHI_PHEP T1 INNER JOIN LY_DO_VANG T2 ON T1.ID_LDV = T2.ID_LDV 
	WHERE T2.PHEP = 1 And (Year(TU_NGAY) = YEAR(@NgayThoiViec) Or Year(DEN_NGAY) =  YEAR(@NgayThoiViec))
	GROUP BY ID_CN) T1
	IF YEAR(@NgayVaoLam) < YEAR(@NgayThoiViec)
		BEGIN
			SET @NgayBDTinhPhep = CONVERT(datetime,str(YEAR(@NgayThoiViec)) + '-01-01',101)
		END
	ELSE
		BEGIN
			IF DAY(@NgayVaoLam) < 15
				BEGIN
					SET @NgayBDTinhPhep = @NgayVaoLam - DAY(@NgayVaoLam) + 1
				END
			ELSE
				BEGIN
					SET @NgayBDTinhPhep = DATEADD(M,1,@NgayVaoLam) - DAY(@NgayVaoLam) + 1
				END		
		END
		
	IF DAY(@NgayThoiViec) < 15
		BEGIN
			SET @NgayKTTinhPhep = @NgayThoiViec - DAY(@NgayThoiViec) + 1
		END
	ELSE
		BEGIN
			SET @NgayKTTinhPhep = DATEADD(M,1,@NgayThoiViec) - DAY(@NgayThoiViec) + 1
		END

	SET @SoThangLV = dbo.fn_tinhthang_tungay_denngay(@NgayBDTinhPhep,@NgayKTTinhPhep)

	SET @PhepThamNien = FLOOR(DATEDIFF(M,@NgayVaoLam, @NgayThoiViec)/60) 

	SELECT @PhepCongThem = ISNULL(PHEP_CT,0) FROM CONG_NHAN WHERE ID_CN = @ID_CN

	SET @PhepDuocHuong =ROUND(((CONVERT(DECIMAL(16,2),12)+@PhepCongThem+@PhepThamNien)/12)*@SoThangLV,2) - @SoNgayNghi

	SELECT @LuongThang = ML + PC FROM [dbo].[funGetLuongKyHopDong](@ID_CN, @NgayThoiViec)

	SET @TienPhepConLai = ROUND(@PhepDuocHuong * (@LuongThang/26),0)
	
	INSERT INTO @TienPhep(ID_CN, LUONG_TP, SO_NGAY_PHEP, TIEN_PHEP)
	SELECT @ID_CN, @LuongThang,ISNULL(@PhepDuocHuong,0), ISNULL(@TienPhepConLai,0)

RETURN
END
