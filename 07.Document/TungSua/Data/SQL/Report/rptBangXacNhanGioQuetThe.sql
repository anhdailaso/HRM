ALTER PROCEDURE [dbo].[rptBangXacNhanGioQuetThe]
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@DVi INT = -1,
	@XN INT = -1,
	@TO INT = -1,
	@TNGAY Date ='2021-03-01',
	@DNGAY Date ='2021-03-05'
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
	
	SET @Chuoi = 'CREATE TABLE ##TBReport (
			[ID_CN] Int NULL, [MS_CN] nvarchar(20) NOT NULL, [HO_TEN] nvarchar(100) NULL, [TEN_TO] nvarchar(100) NULL , 
			[TEN_XN] nvarchar(100)  NULL, [ID_XN] INT NULL , [ID_TO] INT NULL, ' 
	
	WHILE @NgayF <= @NgayT
		BEGIN
			SET @Chuoi = @Chuoi + ' [GD1_' + CAST(@NgayF as varchar) + '] DateTime  NULL , '
			SET @Chuoi = @Chuoi + ' [GV1_' + CAST(@NgayF as varchar) + '] DateTime  NULL , '
			SET @Chuoi = @Chuoi + ' [GD2_' + CAST(@NgayF as varchar) + '] DateTime  NULL , '
			SET @Chuoi = @Chuoi + ' [GV2_' + CAST(@NgayF as varchar) + '] DateTime  NULL , '

			SET @NgayF = @NgayF + 1
		END
	SET @Chuoi = @Chuoi + '[STT_TO] INT NULL, [STT_XN] INT NULL) '
	EXEC (@Chuoi)
	
	INSERT INTO ##TBReport (ID_CN, MS_CN, HO_TEN, TEN_XN, TEN_TO,  ID_TO, ID_XN, STT_XN, STT_TO)
	SELECT ID_CN, MS_CN, HO_TEN, TEN_XN, TEN_TO,  ID_TO, ID_XN, STT_XN, STT_TO
	FROM #CN
	
	DELETE FROM ##TBReport WHERE ID_CN IN (SELECT DISTINCT T1.ID_CN FROM KE_HOACH_NGHI_PHEP T1 INNER JOIN LY_DO_VANG T2 ON T1.ID_LDV = T2.ID_LDV
	WHERE T2.MS_LDV = 'T3' AND T1.TU_NGAY <= @TNGAY AND T1.DEN_NGAY >= @DNGAY)
	
	DECLARE @DSCotNG nvarchar(4000)
	DECLARE @DSCotNG2 nvarchar(4000)
	DECLARE @DSWhere nvarchar(4000)
	SET @DSCotNG = ''
	SET @DSCotNG2 = ''
	SET @DSWhere = ''
	WHILE @NgayBD <= @NgayKT
		BEGIN
			SET @NgayF = DAY(@NgayBD)

			SET @DSCotNG = @DSCotNG + ', CONVERT(nvarchar(10),GD1_' + CAST(@NgayF as varchar) + ',108) AS GD1_' + CAST(@NgayF as varchar) + ', 
			CONVERT(nvarchar(10),GV1_' + CAST(@NgayF as varchar) + ',108) AS GV1_' + CAST(@NgayF as varchar)

			SET @DSCotNG2 = @DSCotNG2 + ', CONVERT(nvarchar(10),GD2_' + CAST(@NgayF as varchar) + ',108) AS GD2_' + CAST(@NgayF as varchar) + ', 
			CONVERT(nvarchar(10),GV2_' + CAST(@NgayF as varchar) + ',108) AS GV2_' + CAST(@NgayF as varchar)

			SET @DSWhere = @DSWhere + 'OR ISNULL(GD2_' + CAST(@NgayF as varchar) + ',0) <> ''' + '' + ''' OR ISNULL(GV2_' + CAST(@NgayF as varchar) + ',0) <> ''' + '' + ''' '
			
			SET @Chuoi = 'UPDATE ##TBReport SET GD1_' + CAST(@NgayF as varchar) + ' = T2.GD, GV1_' + CAST(@NgayF as varchar) + ' = T2.GV FROM ##TBReport T1
			INNER JOIN (SELECT ID_CN, MIN(GIO_DEN) AS GD, MIN(GIO_VE) GV FROM DU_LIEU_QUET_THE WHERE NGAY = '''+ CONVERT(nvarchar(10),@NgayBD,101) + ''' GROUP BY ID_CN) T2 
			ON T1.ID_CN = T2.ID_CN'
			EXEC (@Chuoi)
			
			SET @Chuoi = 'UPDATE ##TBReport SET GD2_' + CAST(@NgayF as varchar) + ' = T2.GD, GV2_' + CAST(@NgayF as varchar) + ' = T2.GV 
			FROM ##TBReport T1
			INNER JOIN (SELECT DLQT.ID_CN, MAX(DLQT.GIO_DEN) AS GD, MAX(DLQT.GIO_VE) GV FROM DU_LIEU_QUET_THE DLQT
			INNER JOIN (SELECT ID_CN, COUNT(GIO_DEN) SLQT FROM DU_LIEU_QUET_THE WHERE NGAY = '''+ CONVERT(nvarchar(10),@NgayBD,101) + '''
			GROUP BY ID_CN HAVING COUNT(GIO_DEN) > 1) DLQT1 ON DLQT.ID_CN = DLQT1.ID_CN WHERE DLQT.NGAY = '''+ CONVERT(nvarchar(10),@NgayBD,101) + ''' GROUP BY DLQT.ID_CN) T2 
			ON T1.ID_CN = T2.ID_CN'
			EXEC (@Chuoi)

			SET @Chuoi = 'UPDATE ##TBReport SET GV1_' + CAST(@NgayF as varchar) + ' = NULL WHERE GD1_' + CAST(@NgayF as varchar) + ' = GV1_' + CAST(@NgayF as varchar) 
			EXEC (@Chuoi)
			SET @Chuoi = 'UPDATE ##TBReport SET GV2_' + CAST(@NgayF as varchar) + ' = NULL WHERE GD2_' + CAST(@NgayF as varchar) + ' = GV2_' + CAST(@NgayF as varchar) 
			EXEC (@Chuoi)
						
			SET @NgayBD = DATEADD(D,1,@NgayBD)
		END
	SET @DSCotNG = SUBSTRING(@DSCotNG,2,LEN(@DSCotNG)-1)
	SET @DSCotNG2 = SUBSTRING(@DSCotNG2,2,LEN(@DSCotNG2)-1)
	SET @DSWhere = SUBSTRING(@DSWhere,3,LEN(@DSWhere)-2)
	
	--SELECT * FROM ##TBReport WHERE MS_CN = 'IR-0173'
	
	SET @Chuoi = 'SELECT MS_CN, HO_TEN, TEN_XN, TEN_TO,  STT_XN, STT_TO, 1 STT_GIO, ' + @DSCotNG + ' FROM ##TBReport'
	SET @Chuoi = @Chuoi + ' UNION SELECT MS_CN, HO_TEN, TEN_XN, TEN_TO,  STT_XN, STT_TO, 2 STT_GIO, ' + @DSCotNG2 + ' FROM ##TBReport WHERE ' + @DSWhere
	SET @Chuoi = 'SELECT ROW_NUMBER() OVER (ORDER BY STT_XN, STT_TO, MS_CN, STT_GIO) AS STT, MS_CN, HO_TEN, TEN_XN, TEN_TO,  ' + @DSCotNG + ' FROM (' + @Chuoi + ') T1'
	print @Chuoi
	EXEC (@Chuoi)

	DROP TABLE ##TBReport
	
END
