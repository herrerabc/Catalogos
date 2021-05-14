CREATE PROCEDURE SP_UsuariosRoles_Update
		--Parameters

			@IdUsuario int,
			@IdRol varchar(15)


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[UsuariosRoles]
		SET
			[IdUsuario] = @IdUsuario,
			[IdRol] = @IdRol

		WHERE 
			[IdUsuario] = @IdUsuario AND 
			[IdRol] = @IdRol


END
