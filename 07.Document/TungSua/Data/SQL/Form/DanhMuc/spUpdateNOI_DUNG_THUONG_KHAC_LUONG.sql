ALTER PROCEDURE [dbo].[spUpdateNOI_DUNG_THUONG_KHAC_LUONG]
	@ID_NDTKL BIGINT,
    @TEN_THUONG NVARCHAR(250),
    @TEN_THUONG_A NVARCHAR(250),
    @TEN_THUONG_H NVARCHAR(250)
AS
    BEGIN
        IF ( @ID_NDTKL = -1 )
            BEGIN
                INSERT INTO dbo.[NOI_DUNG_THUONG_KHAC_LUONG](TEN_THUONG,TEN_THUONG_A,TEN_THUONG_H)
				VALUES(@TEN_THUONG,@TEN_THUONG_A,@TEN_THUONG_H)
				
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.[NOI_DUNG_THUONG_KHAC_LUONG]
                SET     TEN_THUONG = @TEN_THUONG ,
						TEN_THUONG_A = @TEN_THUONG_A ,
                        TEN_THUONG_H = @TEN_THUONG_H 
                WHERE   ID_NDTKL = @ID_NDTKL

				SELECT @ID_NDTKL
            END	
    END	
