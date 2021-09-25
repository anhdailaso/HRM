ALTER PROCEDURE [dbo].[spUpdatePHUONG_XA]
	@ID_PX BIGINT,
	@MS_XA NVARCHAR(50),
	@TEN_PX NVARCHAR(250),
	@TEN_PX_A NVARCHAR(250),
	@TEN_PX_H NVARCHAR(250),
	@ID_QUAN BIGINT
AS   
    BEGIN
        IF ( @ID_PX = -1 )
            BEGIN
                INSERT INTO dbo.PHUONG_XA(ID_QUAN, TEN_PX, TEN_PX_A, TEN_PX_H, MS_XA)
				VALUES(@ID_QUAN, @TEN_PX, @TEN_PX_A, @TEN_PX_H, @MS_XA)
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.PHUONG_XA 
				SET ID_QUAN = @ID_QUAN,
					TEN_PX = @TEN_PX,
					TEN_PX_A = @TEN_PX_A,
					TEN_PX_H = @TEN_PX_H,
					MS_XA = @MS_XA
                WHERE   ID_PX = @ID_PX

				SELECT @ID_PX
            END	
    END	


