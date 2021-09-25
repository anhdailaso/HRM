ALTER PROCEDURE [dbo].[spUpdateThanhPho]
    @ID_TP BIGINT,
	@ID_QG BIGINT,
    @TEN_TP NVARCHAR(200),
	@TEN_TP_A NVARCHAR(200),
	@TEN_TP_H NVARCHAR(200),	
	@MS_TINH NVARCHAR(20)
AS


    BEGIN
        IF (@ID_TP = -1 )
            BEGIN
				INSERT  INTO dbo.THANH_PHO (TEN_TP, TEN_TP_A, TEN_TP_H, ID_QG, MS_TINH)
				VALUES (@TEN_TP,@TEN_TP_A,@TEN_TP_H,@ID_QG,@MS_TINH)
                
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.THANH_PHO
                SET     TEN_TP = @TEN_TP, TEN_TP_A = @TEN_TP_A, TEN_TP_H = @TEN_TP_H, ID_QG = @ID_QG, MS_TINH = @MS_TINH 
				WHERE   ID_TP = @ID_TP

				SELECT @ID_TP
            END	
    END	


