ALTER PROCEDURE [dbo].[spGetCongNhanPhepThang]
	@FLAG BIT =1,
	@ID_DV BIGINT =-1,
	@ID_XN BIGINT =-1,
	@ID_TO BIGINT =1,
	@THANG DATETIME = '20210601',
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0
AS
BEGIN
	DECLARE @NgayTinhPhep Date
	DECLARE @NgayTinhPhepTT Date
	DECLARE @TuNgay Date
	DECLARE @DenNgay Date
	DECLARE @Chuoi nvarchar(4000)

	SET @NgayTinhPhep = CONVERT(DateTime,DATEADD(dd,-(DAY(@THANG))+15,@THANG),101)
	SET @NgayTinhPhepTT = DATEADD(M,-1,@NgayTinhPhep)
	SET @TuNgay = CONVERT(DateTime,DATEADD(dd,-(DAY(@THANG))+1,@THANG),101)
	SET @DenNgay = DATEADD(dd,-1,DATEADD(M, 1,@TuNgay))
	
	SELECT DISTINCT  * INTO #CN FROM dbo.MGetListNhanSuFormToDate(@UName,@NNgu, @ID_DV, @ID_XN, @ID_TO, @TuNgay, @DenNgay)
	
	
--@FLAG BIT =1, Khi sửa khi lưới chưa có dữ liệu thì lấy dữ liệu right join tự động tính những cột còn lại 
--@FLAG BIT =0, Load dữ truc tiep luoi

IF @FLAG = 1
BEGIN
	CREATE TABLE #TB  (
		ID_CN INT,
		MS_CN nvarchar(20),
		HO_TEN nvarchar(100), 
		NGAY_VAO_LAM datetime,
		PHEP_THAM_NIEN float,
		PHEP_UNG_TRUOC float,
		T_1 float, T_2 float, T_3 float, T_4 float, T_5 float, T_6 float, T_7 float, T_8 float, T_9 float, T_10 float, T_11 float, T_12 float,
		TT_1 float, TT_2 float, TT_3 float, TT_4 float, TT_5 float, TT_6 float, TT_7 float, TT_8 float, TT_9 float, TT_10 float, TT_11 float, TT_12 float,
		PHEP_DA_NGHI float,
		PHEP_TIEU_CHUAN float,
		SO_THANG_LV float,
		PHEP_CON_LAI float
	)
	
	--Tao danh sach tinh phep
	INSERT INTO #TB (ID_CN, MS_CN, HO_TEN, NGAY_VAO_LAM)	
	SELECT A.ID_CN, A.MS_CN, A.HO + ' ' + A.TEN AS HO_TEN,  A.NGAY_VAO_LAM
	FROM #CN A 

--lay du lieu thang cu
    UPDATE #TB SET T_1 = T2.T_1, T_2 = T2.T_2, T_3 = T2.T_3, T_4 = T2.T_4, T_5 = T2.T_5, 
		T_6 = T2.T_6, T_7 = T2.T_7, T_8 = T2.T_8, T_9 = T2.T_9, T_10 = T2.T_10, T_11 = T2.T_11, T_12 = T2.T_12, 
		TT_1 = T2.TT_1, TT_2 = T2.TT_2, TT_3 = T2.TT_3, TT_4 = T2.TT_4, TT_5 = T2.TT_5, TT_6 = T2.TT_6, 
		TT_7 = T2.TT_7, TT_8 = T2.TT_8, TT_9 = T2.TT_9, TT_10 = T2.TT_10, TT_11 = T2.TT_11, TT_12 = T2.TT_12, 
		PHEP_DA_NGHI = T2.PHEP_DA_NGHI, PHEP_UNG_TRUOC = T2.PHEP_UNG, PHEP_TIEU_CHUAN = T2.PHEP_TIEU_CHUAN 
		FROM #TB T1 INNER JOIN (SELECT ID_CN, T_1, T_2, T_3, T_4, T_5, T_6, T_7, T_8, T_9, T_10, T_11, T_12, TT_1, TT_2, TT_3, TT_4, TT_5, 
		TT_6, TT_7, TT_8, TT_9, TT_10, TT_11, TT_12, PHEP_TIEU_CHUAN, PHEP_DA_NGHI, PHEP_UNG 
		FROM PHEP_THANG WHERE THANG = (SELECT MAX(THANG) FROM PHEP_THANG WHERE THANG < @TuNgay )) T2 ON T1.ID_CN = T2.ID_CN
 --lay du lieu thang tinh
	SET @Chuoi = 'UPDATE #TB SET T_' + CAST(MONTH(@THANG) as varchar(2)) + ' = T2.SGP FROM #TB T1 INNER JOIN 
		(SELECT ID_CN, SUM(FLOOR(SG_VANG) + CASE WHEN ((SG_VANG - FLOOR(SG_VANG))*60) BETWEEN 15 AND 44 THEN 0.5 ELSE
		CASE WHEN ((SG_VANG - FLOOR(SG_VANG))*60) > 44  THEN 1 ELSE 0 END END) SGP 
		FROM CHAM_CONG_CHI_TIET_VANG T1 INNER JOIN LY_DO_VANG T2 ON T1.ID_LDV = T2.ID_LDV 
		WHERE NGAY BETWEEN ''' + CONVERT(nvarchar(10),@TuNgay,101) + ''' AND ''' + CONVERT(nvarchar(10),@DenNgay,101) + '''
		AND T2.MS_LDV = ''' + 'P' + ''' GROUP BY ID_CN) T2 ON T1.ID_CN = T2.ID_CN'
	EXEC (@Chuoi)
 --tinh tham nien
    SELECT T1.ID_CN, DATEDIFF(MONTH,T2.NK_HDLD,@DenNgay) + 
    CASE WHEN DAY(T2.NK_HDLD) >= 15 THEN 0 ELSE 1 END AS SOTHANG INTO #Tam
	FROM #CN T1 INNER JOIN (SELECT ID_CN, MIN(NGAY_BAT_DAU_HD) AS NK_HDLD FROM HOP_DONG_LAO_DONG GROUP BY ID_CN) T2 ON T1.ID_CN = T2.ID_CN 
    
    DELETE FROM #Tam WHERE SOTHANG < 60
    
    UPDATE #TB SET PHEP_THAM_NIEN = ISNULL(FLOOR(T2.SOTHANG/60),0) 
    FROM #TB T1 LEFT JOIN #Tam T2 ON T1.ID_CN = T2.ID_CN 

	--Tinh so thang lam viec
    UPDATE #TB SET SO_THANG_LV = DATEDIFF(M,CASE WHEN NGAY_VAO_LAM < CONVERT(datetime,STR(YEAR(@THANG),4) + '-01-01') 
		   THEN CONVERT(datetime,STR(YEAR(@THANG),4) + '-01-01') 
		   ELSE CONVERT(datetime,STR(YEAR(@THANG),4) + CASE WHEN DAY(NGAY_VAO_LAM) <= 15 THEN RIGHT('0' + LTRIM(STR(MONTH(NGAY_VAO_LAM),2)),2) 
			ELSE RIGHT('0' + LTRIM(STR(CASE WHEN MONTH(NGAY_VAO_LAM) = 12 THEN 1 ELSE MONTH(NGAY_VAO_LAM)+1 END,2)),2) END 
			+ RIGHT('0' + LTRIM(STR(1,2)),2)) END,@DenNgay) + 1
	
	--Tru so thang khong dc tinh phep
    UPDATE #TB SET SO_THANG_LV = ISNULL(T1.SO_THANG_LV,0) - ISNULL(T2.TONG_ST,0)
    FROM #TB T1 LEFT JOIN (SELECT ID_CN, TONG_ST FROM SO_THANG_KHONG_TP WHERE THANG = 
    (SELECT MAX(THANG) FROM SO_THANG_KHONG_TP WHERE THANG <= @TuNgay)) T2 ON T1.ID_CN = T2.ID_CN
    
    --Khong tinh phep cho nhung nguoi nghi viec trong thang < 15
    UPDATE #TB SET SO_THANG_LV = ISNULL(SO_THANG_LV,0) - CASE WHEN DAY(T2.NGAY_NGHI_VIEC) >= 15 THEN 0 ELSE 1 END 
    FROM #TB T1 INNER JOIN (SELECT ID_CN, NGAY_NGHI_VIEC FROM #CN WHERE NGAY_NGHI_VIEC BETWEEN @TuNgay AND @DenNgay
    AND ID_CN NOT IN (SELECT ID_CN FROM SO_THANG_KHONG_TP WHERE THANG = @TuNgay AND THANG_HT > 0)) T2 ON T1.ID_CN = T2.ID_CN
    
    --Tinh so phep da nghi den thang hien tai
    SET @Chuoi = 'UPDATE #TB SET PHEP_DA_NGHI = ISNULL(PHEP_DA_NGHI,0) + ISNULL(T_' + CAST(MONTH(@THANG) as varchar(2)) + ',0)'
	EXEC (@Chuoi)
    
    --Tinh so phep duoc huong den thang hien tai
    If Month(@THANG) = 1
		BEGIN 
			UPDATE #TB SET PHEP_TIEU_CHUAN = CASE WHEN ISNULL(T1.SO_THANG_LV,0) > 0 THEN 
			ROUND(((12+ISNULL(T2.PHEP_CT,0)+ISNULL(T1.PHEP_THAM_NIEN,0))*8)/(13-Month(@THANG)),0) ELSE 0 END 
            FROM #TB T1 INNER JOIN #CN T2 ON T1.ID_CN = T2.ID_CN 
        END
    Else
		BEGIN
			UPDATE #TB SET PHEP_TIEU_CHUAN = ROUND(((12+ISNULL(T2.PHEP_CT,0)+ISNULL(T1.PHEP_THAM_NIEN,0))*8)/12*ISNULL(SO_THANG_LV,0),1) 
            FROM #TB T1 INNER JOIN #CN T2 ON T1.ID_CN = T2.ID_CN 
        END
   
    --neu thang la thang 1 dau nam thi lay phep ton am cua thang 12 nam truoc lam phep ung truoc
    If Month(@THANG) = 1 
		BEGIN
			UPDATE #TB SET PHEP_UNG_TRUOC = ISNULL(T2.PHEP_TON,0) 
			FROM #TB T1 LEFT JOIN (SELECT ID_CN, PHEP_TON FROM PHEP_THANG WHERE THANG = CONVERT(datetime,STR(YEAR(@THANG)-1,4) + '-12-01')
			AND PHEP_TON < 0) T2 ON T1.ID_CN = T2.ID_CN
		END
    
    --cap nhat phep ton
		UPDATE #TB SET PHEP_CON_LAI = ISNULL(PHEP_TIEU_CHUAN,0) + ISNULL(PHEP_UNG_TRUOC,0) 
		- (ISNULL(PHEP_DA_NGHI,0) + ISNULL(TT_1,0) + ISNULL(TT_2,0) + ISNULL(TT_3,0) + ISNULL(TT_4,0) + ISNULL(TT_5,0) 
		+ ISNULL(TT_6,0) + ISNULL(TT_7,0) + ISNULL(TT_8,0) + ISNULL(TT_9,0) + ISNULL(TT_10,0) + ISNULL(TT_11,0) + ISNULL(TT_12,0))

		SELECT * FROM #TB ORDER BY MS_CN
END

ELSE
BEGIN
SELECT DISTINCT A.ID_CN, A.MS_CN,
       A.HO + ' ' + A.TEN AS HO_TEN,
       A.NGAY_VAO_LAM,
       B.PHEP_TN AS PHEP_THAM_NIEN,
       B.PHEP_UNG AS PHEP_UNG_TRUOC,
       T_1,
       T_2,
       T_3,
       T_4,
       T_5,
       T_6,
       T_7,
       T_8,
       T_9,
       T_10,
       T_11,
       T_12,
       TT_1,
       TT_2,
       TT_3,
       TT_4,
       TT_5,
       TT_6,
       TT_7,
       TT_8,
       TT_9,
       TT_10,
       TT_11,
       TT_12,B.PHEP_DA_NGHI,
	   B.PHEP_TIEU_CHUAN, 
	   B.SO_THANG_LV AS SO_THANG_LV,
	  B.PHEP_TON AS PHEP_CON_LAI
FROM #CN A
    INNER JOIN dbo.PHEP_THANG B
        ON B.ID_CN = A.ID_CN AND B.THANG=@THANG
WHERE A.ID_TO = @ID_TO OR @ID_TO = -1  ORDER BY A.MS_CN ASC
END

END
