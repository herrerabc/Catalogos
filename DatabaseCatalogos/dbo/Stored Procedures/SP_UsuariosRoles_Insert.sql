CREATE PROCEDURE SP_UsuariosRoles_Insert
		--Parameters
			@IdUsuario int,
			@IdRol varchar(15)


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[UsuariosRoles]
		(
			[IdUsuario],
			[IdRol]

		)
		VALUES 
		(
			@IdUsuario,
			@IdRol

		)


END
