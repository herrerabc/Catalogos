CREATE PROCEDURE SP_Colonias_Insert
		--Parameters
			@Id int,
			@IdEstado int,
			@IdMunicipio int,
			@cp bigint,
			@Descripcion varchar(120) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		INSERT INTO [dbo].[Colonias]
		(
			[Id],
			[IdEstado],
			[IdMunicipio],
			[cp],
			[Descripcion]

		)
		VALUES 
		(
			@Id,
			@IdEstado,
			@IdMunicipio,
			@cp,
			@Descripcion

		)


END
