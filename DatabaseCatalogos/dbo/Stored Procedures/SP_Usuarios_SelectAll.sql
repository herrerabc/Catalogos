CREATE PROCEDURE SP_Usuarios_SelectAll
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
END
