CREATE PROCEDURE SP_Roles_Insert
		--Parameters
			@Id varchar(15),
			@DescripcionRol varchar(100)


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Roles]
		(
			[Id],
			[DescripcionRol]

		)
		VALUES 
		(
			@Id,
			@DescripcionRol

		)


END
