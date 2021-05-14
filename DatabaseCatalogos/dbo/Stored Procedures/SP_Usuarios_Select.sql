CREATE PROCEDURE SP_Usuarios_Select
		--Parameters
			@Id int
			,@Loggin varchar(50) = null

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[Nombre],
			[ApellidoP],
			[ApellidoM],
			[Telefono],
			[Direccion],
			[Email],
			[Loggin],
			[Password],
			[Estado]			
		FROM 
			[dbo].[Usuarios]
		WHERE 
			[Id] = @Id
			or [Loggin] = @Loggin
END
