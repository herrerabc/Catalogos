CREATE PROCEDURE SP_Usuarios_Insert
		--Parameters
			@Nombre varchar(50),
			@ApellidoP varchar(50),
			@ApellidoM varchar(50),
			@Telefono numeric = NULL ,
			@Direccion varchar(120) = NULL ,
			@Email varchar(50) = NULL ,
			@Loggin varchar(50),
			@Password varchar(50),
			@Estado bit


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Usuarios]
		(
			[Nombre],
			[ApellidoP],
			[ApellidoM],
			[Telefono],
			[Direccion],
			[Email],
			[Loggin],
			[Password],
			[Estado]

		)
		VALUES 
		(
			@Nombre,
			@ApellidoP,
			@ApellidoM,
			@Telefono,
			@Direccion,
			@Email,
			@Loggin,
			@Password,
			@Estado

		)

DECLARE @Id int
SET @Id = @@IDENTITY
SELECT * FROM [dbo].[Usuarios] WHERE Id = @Id

END
