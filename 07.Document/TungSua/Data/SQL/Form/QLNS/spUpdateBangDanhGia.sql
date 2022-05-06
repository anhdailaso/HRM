ALTER PROCEDURE [dbo].[spUpdateBangDanhGia]
	 @ID_DG BIGINT,
	 @ID_CN  BIGINT,
	 @NGAY_DANH_GIA  DATE,
	 @NGUOI_DANH_GIA  nvarchar(100),
	 @NOI_DUNG  nvarchar(255),
	 @Them BIT,
	 @BT NVARCHAR(100) ='sbtBangDanhGiaadmin'
AS 
BEGIN
	CREATE TABLE #TEMPT_DG (
		[ID_NDDG] [BIGINT] ,
		[DIEM] [FLOAT] NULL,
		[XEP_LOAI] [NVARCHAR](20) NULL,
		[GHI_CHU] [NVARCHAR](255) NULL
	) ON [PRIMARY]
	DECLARE @sSql nvarchar(1000)
	set @sSql = 'INSERT INTO #TEMPT_DG SELECT ID_NDDG, DIEM, XEP_LOAI, GHI_CHU FROM ' + @BT 
	EXEC (@sSql)
	set @sSql = 'DROP TABLE ' + @BT
	EXEC (@sSql)
	IF (@Them = 1)
		BEGIN
			--Đối với trường hợp thêm thì thêm vào bảng đánh giá rồi lấy id thêm vào bảng đánh giá chi tiết
			-----------------------------------------------------------------------------------------------
			INSERT INTO dbo.BANG_DANH_GIA(ID_CN ,NGAY_DANH_GIA ,NGUOI_DANH_GIA ,NOI_DUNG)
			VALUES  (@ID_CN,@NGAY_DANH_GIA,@NGUOI_DANH_GIA,@NOI_DUNG)
			SET @ID_DG = (SELECT SCOPE_IDENTITY())
			-----------------------------------------------------------------------------------------------
			INSERT INTO dbo.BANG_DANH_GIA_CHI_TIET
					(ID_DG ,ID_NDDG ,DIEM ,GHI_CHU ,XEP_LOAI)
			SELECT @ID_DG, ID_NDDG ,DIEM ,GHI_CHU ,XEP_LOAI FROM #TEMPT_DG
		END
-----------------------------------------------------------------------------------------------
	ELSE
		BEGIN
		--update bảng đánh giá
		-----------------------------------------------------------------------------------------------
		UPDATE dbo.BANG_DANH_GIA
		SET	NGAY_DANH_GIA =@NGAY_DANH_GIA ,NGUOI_DANH_GIA =@NGUOI_DANH_GIA ,NOI_DUNG =@NOI_DUNG
		WHERE ID_DG =@ID_DG
		-----------------------------------------------------------------------------------------------

		--delete rồi inser vào
		-----------------------------------------------------------------------------------------------
		DELETE dbo.BANG_DANH_GIA_CHI_TIET WHERE ID_DG =@ID_DG
		-----------------------------------------------------------------------------------------------

		--insert vào bảng đánh giá chi tiết
		-----------------------------------------------------------------------------------------------
		INSERT INTO dbo.BANG_DANH_GIA_CHI_TIET
				(ID_DG ,ID_NDDG ,DIEM ,GHI_CHU ,XEP_LOAI)
		SELECT @ID_DG, ID_NDDG ,DIEM ,GHI_CHU ,XEP_LOAI FROM #TEMPT_DG
		-----------------------------------------------------------------------------------------------
		END
		-----------------------------------------------------------------------------------------------
		SELECT @ID_DG
-----------------------------------------------------------------------------------------------
END


