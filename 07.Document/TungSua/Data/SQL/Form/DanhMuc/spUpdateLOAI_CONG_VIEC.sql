ALTER PROCEDURE [dbo].[spUpdateLOAI_CONG_VIEC]
	@ID_LCV BIGINT,
    @TEN_LCV NVARCHAR(250),
    @TEN_LCV_A NVARCHAR(250),
    @TEN_LCV_H NVARCHAR(250),
	@DOC_HAI BIT,
	@PHEP_CT FLOAT,
	@ID_LT BIGINT
AS
    BEGIN
        IF ( @ID_LCV = -1 )
            BEGIN
                INSERT INTO dbo.[LOAI_CONG_VIEC](TEN_LCV,TEN_LCV_A,TEN_LCV_H,DOC_HAI,PHEP_CT,ID_LT)
				VALUES(@TEN_LCV,@TEN_LCV_A,@TEN_LCV_H,@DOC_HAI,@PHEP_CT,@ID_LT)
				
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.[LOAI_CONG_VIEC]
                SET     TEN_LCV = @TEN_LCV ,
						TEN_LCV_A = @TEN_LCV_A ,
                        TEN_LCV_H = @TEN_LCV_H ,
						DOC_HAI = @DOC_HAI,
						PHEP_CT = @PHEP_CT,
						ID_LT = @ID_LT
                WHERE   ID_LCV = @ID_LCV

				SELECT @ID_LCV
            END	
    END	


