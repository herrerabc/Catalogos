CREATE PROCEDURE SP_UsuariosRoles_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[IdUsuario],
			[IdRol]
		FROM 
			[dbo].[UsuariosRoles]
END
