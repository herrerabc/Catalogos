CREATE PROCEDURE SP_Municipios_Insert
		--Parameters
			@Id int,
			@IdEstado int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Municipios]
		(
			[Id],
			[IdEstado],
			[descripcion]

		)
		VALUES 
		(
			@Id,
			@IdEstado,
			@descripcion

		)


END
