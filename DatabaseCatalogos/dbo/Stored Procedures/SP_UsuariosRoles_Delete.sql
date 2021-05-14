CREATE PROCEDURE SP_UsuariosRoles_Delete
		--Parameters
			@IdUsuario int,
			@IdRol varchar(15)


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[UsuariosRoles]
		WHERE 
			[IdUsuario] = @IdUsuario
		AND
			[IdRol] = @IdRol

END
