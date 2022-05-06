ALTER PROCEDURE [dbo].[spUpdateKhenThuong]
	@ID_KTHUONG BIGINT,
	@ID_CN BIGINT,
	@SO_QUYET_DINH NVARCHAR(20),
	@NGAY_HIEU_LUC DATETIME,
	@NGAY_KY DATETIME,
	@ID_NK BIGINT,
	@NOI_DUNG NVARCHAR(250),
	@ID_KT_KL INT,
	@LOAI_KT INT,
	@GHI_CHU NVARCHAR(250),
    @Them BIT
AS
    BEGIN
        IF ( @Them = 1 )
---thêm
            BEGIN
			INSERT INTO dbo.KHEN_THUONG	
			        (
			          ID_CN ,
			          SO_QUYET_DINH ,
			          NGAY_HIEU_LUC ,
			          NGAY_KY ,
			          ID_NK ,
			          NOI_DUNG ,
			          ID_KT_KL ,
			          LOAI_KT ,
			          GHI_CHU
			        )
			VALUES  ( 
					  @ID_CN ,
			          @SO_QUYET_DINH ,
			          @NGAY_HIEU_LUC ,
			          @NGAY_KY ,
			          @ID_NK ,
			          @NOI_DUNG ,
			          @ID_KT_KL ,
			          @LOAI_KT ,
			          @GHI_CHU
			        )
                SELECT  SCOPE_IDENTITY()	 
            END	
        ELSE
            BEGIN
                UPDATE  dbo.KHEN_THUONG
                SET     
					SO_QUYET_DINH  =@SO_QUYET_DINH,
			          NGAY_HIEU_LUC =@NGAY_HIEU_LUC,
			          NGAY_KY =@NGAY_KY,
			          ID_NK =@ID_NK,
			          NOI_DUNG =@NOI_DUNG,
			          ID_KT_KL =@ID_KT_KL,
			          LOAI_KT =@LOAI_KT,
			          GHI_CHU =@GHI_CHU
				WHERE ID_KTHUONG =@ID_KTHUONG
				SELECT @ID_KTHUONG
            END	

    END