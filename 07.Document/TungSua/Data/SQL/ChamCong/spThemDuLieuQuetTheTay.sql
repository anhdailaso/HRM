ALTER PROCEDURE [dbo].[spThemDuLieuQuetTheTay]
	@ID_NHOM INT = 1,
	@CA NVARCHAR(4) = '1',
	@NGAY_DEN DATETIME = '20210301',
    @GIO_DEN DATETIME = '07:30:00',
    @NGAY_VE DATETIME = '20210301',
    @GIO_VE DATETIME = '16:30:00',
	@sBT NVARCHAR(50) = 'BTKinkTayadmin'
AS	
BEGIN
	DECLARE @sSql  NVARCHAR(400)
	
	SET @sSql = 'UPDATE ' + @sBT + ' SET ID_NHOM = '+ STR(@CA) +', CA = ''' + @CA + ''', 
	NGAY_DEN = ''' + CONVERT(nvarchar(10),@NGAY_DEN,101) + ''', GIO_DEN = ''' + CONVERT(nvarchar(8),@GIO_DEN,108) + ''', 
	NGAY_VE = ''' + CONVERT(nvarchar(10),@NGAY_VE,101) + ''', GIO_VE = ''' + CONVERT(nvarchar(8),@GIO_VE,108) + '''
	WHERE CHON = 1'
	EXEC(@sSql)
	
	SET @sSql = 'UPDATE ' + @sBT + ' SET TEN_NHOM = T2.TEN_NHOM FROM ' + @sBT + ' T1 INNER JOIN NHOM_CHAM_CONG T2 ON T1.ID_NHOM = T2.ID_NHOM'
	EXEC(@sSql)
	
	--SET @sSql = 'SELECT * FROM ' + @sBT 
	--EXEC(@sSql)
--	CREATE TABLE #BT
--	(
--		[ID_CN] [bigint] NULL
--	)
----Lay ds cong nhan chon them gio---------------------------------------------------------------------------------------------------
--DECLARE @sSql  NVARCHAR(400)
--SET @sSql = 'INSERT INTO #BT(ID_CN) SELECT ID_CN FROM '+ @sBT +' WHERE CHON = 1'
--EXEC(@sSql)
--SET @sSql = 'DROP TABLE ' + @sBT 
--EXEC(@sSql)
----------------------------------------------------------------------------------------------------------------------------
--DELETE DU_LIEU_QUET_THE WHERE CONVERT(DATE,@Ngay) = CONVERT(DATE,NGAY) AND EXISTS (SELECT * FROM #BT WHERE dbo.DU_LIEU_QUET_THE.ID_CN = #BT.ID_CN)

--INSERT INTO dbo.DU_LIEU_QUET_THE
--(
--    ID_CN,
--    NGAY,
--    ID_NHOM,
--    CA,
--    NGAY_DEN,
--    GIO_DEN,
--    PHUT_DEN,
--    NGAY_VE,
--    GIO_VE,
--    PHUT_VE,
--    CHINH_SUA
--)
--SELECT ID_CN,@Ngay,@ID_NHOM,@CA,@NGAY_DEN,@GIO_DEN,@PHUT_DEN,@NGAY_VE,@GIO_VE,@PHUT_VE,1 FROM #BT
--------------------------------------------------------------------------------------------------------------------------


END	

