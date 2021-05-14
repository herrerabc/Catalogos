CREATE PROCEDURE SP_Colonias_Select
		--Parameters
			@Id int,
			@IdEstado int,
			@IdMunicipio int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[IdEstado],
			[IdMunicipio],
			[cp],
			[Descripcion]
		FROM 
			[dbo].[Colonias]
		WHERE 
			[Id] = @Id
		AND
			[IdEstado] = @IdEstado
		AND
			[IdMunicipio] = @IdMunicipio
END
