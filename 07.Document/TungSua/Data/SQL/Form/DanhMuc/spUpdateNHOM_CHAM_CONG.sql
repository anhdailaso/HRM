ALTER PROCEDURE [dbo].[spUpdateNHOM_CHAM_CONG]
	@ID_NHOM BIGINT,
    @TEN_NHOM NVARCHAR(250),
    @TEN_NHOM_A NVARCHAR(250),
    @TEN_NHOM_H NVARCHAR(250),
    @CA_TU_DONG BIT
AS
    BEGIN
        IF ( @ID_NHOM = -1 )
            BEGIN
                INSERT INTO dbo.[NHOM_CHAM_CONG](TEN_NHOM, TEN_NHOM_A, TEN_NHOM_H, CA_TU_DONG)
				VALUES(@TEN_NHOM,@TEN_NHOM_A,@TEN_NHOM_H, @CA_TU_DONG)
				
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.[NHOM_CHAM_CONG]
                SET     TEN_NHOM = @TEN_NHOM ,
						TEN_NHOM_A = @TEN_NHOM_A ,
                        TEN_NHOM_H = @TEN_NHOM_H,
                        CA_TU_DONG = @CA_TU_DONG
                WHERE   ID_NHOM = @ID_NHOM

				SELECT @ID_NHOM
            END	
    END	

