ALTER PROCEDURE [dbo].[spKiemTraKHDiCa]
	@sBTam NVARCHAR(200) ='TMPPRORUNadmin',
	@ID_CN BIGINT = 111,
	@TuNgay DATETIME = '08/25/2021',
	@DenNgay DATETIME = '08/27/2021'
AS 
	BEGIN
	
	--PRINT @TNGAY
	--PRINT @DNGAY
	--- kiểm tra 3 trường hợp
	--1 từ ngày không nằm trong dữ liệu
	--2 đến ngày không nằm trong dữ liệu
	--3 dữ liệu hông nằm trong từ đến
	CREATE TABLE #BTTG (
	[ID_CN] BIGINT NULL,
	[StartTime] DATETIME NULL,
	[EndTime] DATETIME NULL
) 
	DECLARE @sSql nvarchar(4000)
	set @sSql = 'INSERT INTO #BTTG (StartTime, EndTime )  SELECT  CONVERT(DATE,TU_NGAY,111),CONVERT(DATE,DEN_NGAY,111)  FROM ' + @sBTam
	EXEC (@sSql)

	--SELECT * FROM #BTTG
	SELECT COUNT(*) FROM #BTTG
	WHERE ( @TuNgay >=  StartTime AND @TuNgay <= EndTime) OR (@DenNgay >= StartTime AND @DenNgay <= EndTime) OR (StartTime >= @TuNgay AND StartTime <= @DenNgay) OR @TuNgay = StartTime
	
	END