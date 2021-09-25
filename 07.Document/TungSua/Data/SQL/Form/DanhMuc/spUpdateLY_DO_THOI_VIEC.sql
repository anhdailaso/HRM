ALTER PROCEDURE [dbo].[spUpdateLY_DO_THOI_VIEC]
	@ID_LD_TV BIGINT ,
    @TEN_LD_TV NVARCHAR(250) ,
    @TEN_LD_TV_A NVARCHAR(250) ,
    @TEN_LD_TV_H NVARCHAR(250) ,
	@HE_SO Float
AS
    BEGIN
        IF ( @ID_LD_TV = -1 )
            BEGIN
                INSERT INTO dbo.[LY_DO_THOI_VIEC](TEN_LD_TV, TEN_LD_TV_A, TEN_LD_TV_H, HE_SO)
				VALUES(@TEN_LD_TV,@TEN_LD_TV_A,@TEN_LD_TV_H,@HE_SO)
				
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.[LY_DO_THOI_VIEC]
                SET     TEN_LD_TV = @TEN_LD_TV ,
						TEN_LD_TV_A = @TEN_LD_TV_A ,
                        TEN_LD_TV_H = @TEN_LD_TV_H,
						HE_SO = @HE_SO
                WHERE   ID_LD_TV = @ID_LD_TV

				SELECT @ID_LD_TV
            END	
    END	


