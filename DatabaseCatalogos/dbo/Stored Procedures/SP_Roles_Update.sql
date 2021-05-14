CREATE PROCEDURE SP_Roles_Update
		--Parameters

			@Id varchar(15),
			@DescripcionRol varchar(100)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Roles]
		SET
			[Id] = @Id,
			[DescripcionRol] = @DescripcionRol

		WHERE 
			[Id] = @Id


END
