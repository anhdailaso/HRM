ALTER PROCEDURE [dbo].[spUpdateTRINH_DO_VAN_HOA]
	@ID_TDVH BIGINT,
    @TEN_TDVH NVARCHAR(250),
    @TEN_TDVH_A NVARCHAR(250),
    @TEN_TDVH_H NVARCHAR(250),
	@ID_LOAI_TD BIGINT
AS
    BEGIN
        IF ( @ID_TDVH = -1 )
            BEGIN
                INSERT INTO dbo.[TRINH_DO_VAN_HOA](TEN_TDVH,TEN_TDVH_A,TEN_TDVH_H,ID_LOAI_TD)
				VALUES(@TEN_TDVH,@TEN_TDVH_A,@TEN_TDVH_H,@ID_LOAI_TD)
				
				SELECT SCOPE_IDENTITY()
            END	
        ELSE
            BEGIN
                UPDATE  dbo.[TRINH_DO_VAN_HOA]
                SET     TEN_TDVH = @TEN_TDVH ,
						TEN_TDVH_A = @TEN_TDVH_A ,
                        TEN_TDVH_H = @TEN_TDVH_H ,
						ID_LOAI_TD = @ID_LOAI_TD
                WHERE   ID_TDVH = @ID_TDVH

				SELECT @ID_TDVH
            END	
    END	


