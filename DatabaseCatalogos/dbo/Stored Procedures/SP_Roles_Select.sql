CREATE PROCEDURE SP_Roles_Select
		--Parameters
			@Id varchar(15)

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[DescripcionRol]
		FROM 
			[dbo].[Roles]
		WHERE 
			[Id] = @Id
END
