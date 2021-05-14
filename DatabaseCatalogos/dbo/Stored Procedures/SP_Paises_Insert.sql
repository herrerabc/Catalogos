CREATE PROCEDURE SP_Paises_Insert
		--Parameters
			@Id int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Paises]
		(
			[Id],
			[descripcion]

		)
		VALUES 
		(
			@Id,
			@descripcion

		)


END
