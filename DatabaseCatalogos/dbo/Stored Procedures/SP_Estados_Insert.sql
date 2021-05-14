CREATE PROCEDURE SP_Estados_Insert
		--Parameters
			@Id int,
			@IdPais int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Estados]
		(
			[Id],
			[IdPais],
			[descripcion]

		)
		VALUES 
		(
			@Id,
			@IdPais,
			@descripcion

		)


END
