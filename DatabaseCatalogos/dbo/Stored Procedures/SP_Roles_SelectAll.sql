CREATE PROCEDURE SP_Roles_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[Id],
			[DescripcionRol]
		FROM 
			[dbo].[Roles]
END
