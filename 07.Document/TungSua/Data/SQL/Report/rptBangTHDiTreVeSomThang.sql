ALTER PROCEDURE [dbo].[rptBangTHDiTreVeSomThang]
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@DVi INT = -1,
	@XN INT = -1,
	@TO INT = -1,
	@TNGAY Date ='2021-03-01',
	@DNGAY Date ='2021-03-31',
	@Loai int = 2
AS 
BEGIN
	DECLARE @NgayBD Date
	DECLARE @NgayKT Date
	
	SET @NgayBD = @TNGAY
	SET @NgayKT = @DNGAY
	
	SELECT * INTO #CN FROM dbo.MGetListNhanSuFormToDate(@UName,@NNgu, @DVi, @XN, @TO, @TNGAY, @DNGAY)

	DECLARE @Chuoi nvarchar(MAX)
	DECLARE @NgayF Int
	DECLARE @NgayT Int
	SET @NgayF = DAY(@NgayBD)
	SET @NgayT = DAY(@NgayKT)
	
	SET @Chuoi = 'CREATE TABLE ##TBReport ([ID_CN] Int NULL, [MS_CN] nvarchar(20) NOT NULL, [HO_TEN] nvarchar(100) NULL, 
		[TEN_TO] nvarchar(100) NULL, [TEN_XN] nvarchar(100)  NULL, ' 
	
	WHILE @NgayF <= @NgayT
		BEGIN
			SET @Chuoi = @Chuoi + ' [NG' + CAST(@NgayF as varchar) + 'DT] FLOAT  NULL  DEFAULT (0) , '
			SET @Chuoi = @Chuoi + ' [NG' + CAST(@NgayF as varchar) + 'VS] FLOAT  NULL  DEFAULT (0) , '
			SET @NgayF = @NgayF + 1
		END
			
	SET @Chuoi = @Chuoi + ' [SO_LAN_DT] FLOAT NULL  DEFAULT (0), [SO_PHUT_DT] FLOAT NULL  DEFAULT (0),
		[SO_LAN_VS] FLOAT NULL  DEFAULT (0), [SO_PHUT_VS] FLOAT NULL  DEFAULT (0),
		[TONG_LAN_DTVS] FLOAT NULL  DEFAULT (0), [TONG_PHUT_DTVS] FLOAT NULL  DEFAULT (0), 
		[STT_XN] INT  DEFAULT (999), [STT_TO] INT  DEFAULT (999))'
	EXEC (@Chuoi)
	PRINT @Chuoi
	--tao danh sach cham cong can bao cao
    INSERT INTO ##TBReport(ID_CN, STT_XN, STT_TO, TEN_XN, TEN_TO, MS_CN, HO_TEN) 
    SELECT  T1.ID_CN, T1.STT_XN, T1.STT_TO, T1.TEN_XN, T1.TEN_TO, T1.MS_CN, T1.HO_TEN
    FROM #CN T1 
    
    --lay du lieu cham cong thang
    SELECT T1.*, T3.SG_LV_QD INTO #CCCT FROM CHAM_CONG_CHI_TIET T1 INNER JOIN #CN T2 ON T1.ID_CN = T2.ID_CN
    INNER JOIN CHAM_CONG T3 ON T1.ID_CN = T3.ID_CN AND T1.NGAY = T3.NGAY
    WHERE T1.NGAY BETWEEN  @TNGAY AND @DNGAY
        
    --Lay danh sach di tre
	SELECT T1.ID_CN, T1.NGAY, T1.PBD_CC - T2.PBD_ND SPDT INTO #DSCNDT
	FROM (
	SELECT ID_CN, NGAY, ID_NHOM, CA, MIN(PHUT_DEN) PBD_CC FROM #CCCT 
		WHERE NGAY BETWEEN CONVERT(nvarchar(10),@NgayBD,101) AND CONVERT(nvarchar(10),@NgayKT,101) AND TANG_CA = 0 GROUP BY ID_CN, NGAY, ID_NHOM, CA
	) T1 INNER JOIN (
	SELECT ID_NHOM, CA, MIN(PHUT_BD+TRU_DAU_GIO) PBD_ND FROM CHE_DO_LAM_VIEC 
		WHERE NGAY = (SELECT MAX(NGAY) FROM CHE_DO_LAM_VIEC WHERE NGAY <= CONVERT(nvarchar(10),@NgayBD,101) AND TANG_CA = 0)
		GROUP BY ID_NHOM, CA
	) T2 ON T1.ID_NHOM = T2.ID_NHOM AND T1.CA = T2.CA 
	WHERE (T1.PBD_CC - T2.PBD_ND BETWEEN 1 AND 30)

    --Lay danh sach ve som
	SELECT T1.ID_CN, T1.NGAY, T2.PKT_ND - T1.PKT_CC SPVS INTO #DSCNVS
	FROM (
		SELECT ID_CN, NGAY, ID_NHOM, CA, MAX(PHUT_VE) PKT_CC 
		FROM #CCCT WHERE NGAY BETWEEN CONVERT(nvarchar(10),@NgayBD,101) AND CONVERT(nvarchar(10),@NgayKT,101) 
		AND TANG_CA = 0 GROUP BY ID_CN, NGAY, ID_NHOM, CA 
	) T1 INNER JOIN (
		SELECT ID_NHOM, CA, MAX(PHUT_KT-TRU_CUOI_GIO) PKT_ND FROM CHE_DO_LAM_VIEC WHERE NGAY = (SELECT MAX(NGAY) FROM CHE_DO_LAM_VIEC 
		WHERE NGAY <= CONVERT(nvarchar(10),@NgayBD,101)) AND TANG_CA = 0 GROUP BY ID_NHOM, CA 
	) T2 ON T1.ID_NHOM = T2.ID_NHOM AND T1.CA = T2.CA 
	WHERE (T2.PKT_ND - T1.PKT_CC BETWEEN 1 AND 30)

	--cap nhat di tre
	DECLARE @DSCot nvarchar(4000)
	SET @NgayF = 1
	SET @DSCot = ''

    WHILE @NgayF <= @NgayT
		BEGIN
			SET @DSCot = @DSCot + ', [' + CAST(@NgayF as varchar) + ']'
			SET @NgayF = @NgayF + 1
		END
	SET @DSCot = SUBSTRING(@DSCot,2,LEN(@DSCot)-1)
	

    SET @Chuoi = 'SELECT ID_CN AS [MA_SO], ' + @DSCot + ' INTO ##DSCNDT
        FROM ( SELECT ID_CN, SPDT, NGAY_THANG FROM ( SELECT ID_CN, DAY(NGAY) NGAY_THANG, SPDT FROM #DSCNDT) T1 ) I 
        PIVOT (SUM(SPDT) FOR NGAY_THANG IN (' + @DSCot + ')) AS J'
    EXEC (@Chuoi)
	
	SET @Chuoi = 'UPDATE ##TBReport SET '
	SET @NgayF = DAY(@NgayBD)
	DECLARE @DSCotNG nvarchar(4000)
	SET @DSCotNG = ''
	WHILE @NgayF <= @NgayT
	BEGIN
		SET @DSCotNG = @DSCotNG + ', NG' + CAST(@NgayF as varchar) + 'DT = ISNULL(T2.[' + CAST(@NgayF as varchar) + '],0)'
		SET @NgayF = @NgayF + 1
	END
	SET @DSCotNG = SUBSTRING(@DSCotNG,2,LEN(@DSCotNG)-1)
	
    SET @Chuoi = @Chuoi + @DSCotNG + ' FROM ##TBReport T1 INNER JOIN ##DSCNDT T2 ON T1.ID_CN = T2.MA_SO'
	EXEC (@Chuoi)
	
	--cap nhat ve som
    SET @Chuoi = 'SELECT ID_CN AS [MA_SO], ' + @DSCot + ' INTO ##DSCNVS
        FROM ( SELECT ID_CN, SPVS, NGAY_THANG FROM ( SELECT ID_CN, DAY(NGAY) NGAY_THANG, SPVS FROM #DSCNVS) T1 ) I 
        PIVOT (SUM(SPVS) FOR NGAY_THANG IN (' + @DSCot + ')) AS J'
    EXEC (@Chuoi)
	
	SET @Chuoi = 'UPDATE ##TBReport SET '
	SET @NgayF = DAY(@NgayBD)
	SET @DSCotNG = ''
	WHILE @NgayF <= @NgayT
	BEGIN
		SET @DSCotNG = @DSCotNG + ', NG' + CAST(@NgayF as varchar) + 'VS = ISNULL(T2.[' + CAST(@NgayF as varchar) + '],0)'
		SET @NgayF = @NgayF + 1
	END
	SET @DSCotNG = SUBSTRING(@DSCotNG,2,LEN(@DSCotNG)-1)
	
    SET @Chuoi = @Chuoi + @DSCotNG + ' FROM ##TBReport T1 INNER JOIN ##DSCNVS T2 ON T1.ID_CN = T2.MA_SO'
	EXEC (@Chuoi)
	
	UPDATE ##TBReport SET SO_LAN_DT = T2.SNDT, SO_PHUT_DT = T2.TSPDT
	FROM ##TBReport T1 INNER JOIN (SELECT ID_CN, COUNT(NGAY) SNDT, SUM(SPDT) TSPDT FROM #DSCNDT GROUP BY ID_CN) T2 ON T1.ID_CN = T2.ID_CN
	
	UPDATE ##TBReport SET SO_LAN_VS = T2.SNVS, SO_PHUT_VS = T2.TSPVS
	FROM ##TBReport T1 INNER JOIN (SELECT ID_CN, COUNT(NGAY) SNVS, SUM(SPVS) TSPVS FROM #DSCNVS GROUP BY ID_CN) T2 ON T1.ID_CN = T2.ID_CN
	
	UPDATE ##TBReport SET TONG_LAN_DTVS = ISNULL(SO_LAN_DT,0) + ISNULL(SO_LAN_VS,0), TONG_PHUT_DTVS = ISNULL(SO_PHUT_DT,0) + ISNULL(SO_PHUT_VS,0)
	
	
	SET @NgayF = DAY(@NgayBD)
	SET @DSCotNG = ''
	WHILE @NgayF <= @NgayT
	BEGIN
		SET @DSCotNG = @DSCotNG + ', NG' + CAST(@NgayF as varchar) + 'DT, NG' + CAST(@NgayF as varchar) + 'VS'
		SET @NgayF = @NgayF + 1
	END
	SET @DSCotNG = SUBSTRING(@DSCotNG,2,LEN(@DSCotNG)-1)
	
	SET @Chuoi = 'SELECT ROW_NUMBER() OVER (ORDER BY STT_XN, STT_TO, MS_CN) AS STT, MS_CN, HO_TEN, TEN_TO, TEN_XN, ' + @DSCotNG + ', SO_LAN_DT, 
		SO_PHUT_DT, SO_LAN_VS, SO_PHUT_VS, TONG_LAN_DTVS, TONG_PHUT_DTVS FROM ##TBReport'
--ĐI TRỄ LOAI =0	
	IF @Loai = 0 
		 SET @Chuoi = @Chuoi + ' WHERE SO_LAN_DT>0'
--VỀ SỚM LOAI = 1
	IF @Loai = 1
		SET @Chuoi = @Chuoi + ' WHERE SO_LAN_VS>0'
--Ca 2
	IF @Loai = 2
		SET @Chuoi = @Chuoi + ' WHERE SO_LAN_DT>0 OR SO_LAN_VS > 0'
	
	EXEC (@Chuoi)	
	
	DROP TABLE ##TBReport
	DROP TABLE ##DSCNDT
	DROP TABLE ##DSCNVS
END