--[spTienThuongXepLoaiTH]

ALTER PROCEDURE [dbo].[spTienThuongXepLoaiTH]
	@TuNgay DATE = '2021-03-01',
	@DenNgay DATE = '2021-03-31',
	@DVi BIGINT = -1,
	@XNghiep BIGINT = -1,
	@To BIGINT = -1,
	@UName NVARCHAR(50) = 'admin',
	@NNgu INT = 0
AS	

BEGIN


DECLARE @sSql  NVARCHAR(400)
SELECT * INTO #CN FROM dbo.MGetListNhanSuFormToDate(@UName,@NNgu,@DVi,@XNghiep,@To,@TuNgay,@DenNgay)

SELECT T2.ID_XN, T2.TEN_XN, T2.STT_XN, T2.STT_TO, T2.ID_TO, T2.TEN_TO, SUM(T1.TIEN_THUONG) TONG_TT , COUNT(t1.ID_CN) SO_CN
FROM TIEN_THUONG_XEP_LOAI T1 INNER JOIN #CN T2 ON T1.ID_CN = T2.ID_CN 
WHERE NGAY_TTXL BETWEEN @TuNgay AND @DenNgay
GROUP BY T2.ID_XN, T2.TEN_XN, T2.STT_XN, T2.STT_TO, T2.ID_TO, T2.TEN_TO
ORDER BY T2.STT_XN, T2.STT_TO, T2.TEN_TO

END	


--ID_XN	TEN_XN	STT_XN	STT_TO	ID_TO	TEN_TO	TONG_TT
--1	Văn phòng	1	1	1	Hành chánh	2165605.11