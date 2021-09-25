ALTER PROCEDURE [dbo].[rptBangLSPChiTietMHCNTheoChuyen]
	@UName NVARCHAR(100) ='admin',
	@NNgu INT =0,
	@DVi INT = -1,
	@XN INT = -1,
	@TO INT = -1,
	@CN INT = -1,
	@DH INT = -1,
	@MH INT = -1,
	@ORD INT = -1,
	@CHUYEN INT = 3,
	@TNGAY Date ='2021-03-01',
	@DNGAY Date ='2021-03-31'
AS 
BEGIN

	SELECT * INTO #CN FROM dbo.MGetListNhanSuFormToDate(@UName,@NNgu, @DVi, @XN, @TO, @TNGAY, @DNGAY)
	
	SELECT C.ID_CHUYEN, C.TEN_CHUYEN, T3.MS_CN, T3.HO_TEN, HH.ID_HH, HH.MS_HIEN_THI, T3.STT_XN, T3.TEN_XN, 
	T3.STT_TO, T3.TEN_TO, ROUND(SUM(T1.SO_LUONG * T2.DON_GIA_THUC_TE),0) THANH_TIEN INTO ##Tmp
	FROM PHIEU_CONG_DOAN T1 INNER JOIN QUI_TRINH_CONG_NGHE_CHI_TIET T2 ON T1.ID_CHUYEN_SD = T2.ID_CHUYEN AND T1.ID_ORD = T2.ID_ORD AND T1.ID_CD = T2.ID_CD 
	INNER JOIN #CN T3 ON T1.ID_CN = T3.ID_CN
	INNER JOIN DON_HANG_BAN_ORDER ORD ON T1.ID_ORD = ORD.ID_DHBORD
	INNER JOIN HANG_HOA HH ON ORD.ID_HH = HH.ID_HH
	INNER JOIN CHUYEN C ON T1.ID_CHUYEN = C.ID_CHUYEN
	WHERE (T1.NGAY BETWEEN @TNGAY AND @DNGAY) AND (ORD.ID_DHB = @DH OR @DH = -1) AND (ORD.ID_HH = @MH OR @MH = -1) 
	AND (ORD.ID_DHBORD = @ORD OR @ORD = -1) AND (T1.ID_CHUYEN = @CHUYEN OR @CHUYEN = -1) AND (T1.ID_CN = @CN OR @CN = -1)
	GROUP BY C.ID_CHUYEN, C.TEN_CHUYEN, T3.MS_CN, T3.HO_TEN, HH.ID_HH, HH.MS_HIEN_THI, T3.STT_XN, T3.TEN_XN, T3.STT_TO, T3.TEN_TO
	ORDER BY C.TEN_CHUYEN, T3.STT_XN, T3.STT_TO, T3.MS_CN
	
	DECLARE @MHHT nvarchar(100)
	DECLARE @Chuoi nvarchar(4000)
	SET @Chuoi = ''
	
	DECLARE mh_cursor CURSOR FOR  
	SELECT DISTINCT MS_HIEN_THI FROM ##Tmp ORDER BY MS_HIEN_THI
	OPEN mh_cursor
	FETCH NEXT FROM mh_cursor   
	INTO @MHHT
	WHILE @@FETCH_STATUS = 0  
		BEGIN  
			SET @Chuoi = @Chuoi + ',[' + @MHHT + ']'
			FETCH NEXT FROM mh_cursor   
			INTO @MHHT
		END   
	CLOSE mh_cursor  
	DEALLOCATE mh_cursor 
	
	SET @Chuoi = SUBSTRING(@Chuoi,2,LEN(@Chuoi)-1)
	
	SET @Chuoi = 'SELECT MS_CN, HO_TEN, TEN_XN, TEN_TO, ' + @Chuoi + ' INTO ##Tmp2 FROM (SELECT MS_CN, HO_TEN, TEN_XN, TEN_TO, MS_HIEN_THI, THANH_TIEN 
	FROM ##Tmp) ps 
	PIVOT(SUM (THANH_TIEN) FOR MS_HIEN_THI IN ('+ @Chuoi + ')) AS pvt'
	EXEC (@Chuoi)
	
	SELECT ROW_NUMBER() OVER (ORDER BY TEN_XN, TEN_TO, MS_CN) AS [Stt], * FROM ##Tmp2 
	
	DROP TABLE ##Tmp
	DROP TABLE ##Tmp2
END


