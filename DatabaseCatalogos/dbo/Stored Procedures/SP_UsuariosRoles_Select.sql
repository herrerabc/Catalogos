CREATE PROCEDURE SP_UsuariosRoles_Select
		--Parameters
			@IdUsuario int,
			@IdRol varchar(15)

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[IdUsuario],
			[IdRol]
		FROM 
			[dbo].[UsuariosRoles]
		WHERE 
			[IdUsuario] = @IdUsuario
		AND
			[IdRol] = @IdRol
END
