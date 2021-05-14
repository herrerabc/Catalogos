CREATE PROCEDURE SP_Usuarios_Update
		--Parameters

			@Id int,
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

		UPDATE [dbo].[Usuarios]
		SET
			[Nombre] = @Nombre,
			[ApellidoP] = @ApellidoP,
			[ApellidoM] = @ApellidoM,
			[Telefono] = @Telefono,
			[Direccion] = @Direccion,
			[Email] = @Email,
			[Loggin] = @Loggin,
			[Password] = @Password, 
			[Estado] = @Estado

		WHERE 
			[Id] = @Id


SELECT * FROM [dbo].[Usuarios] WHERE Id = @Id

END
