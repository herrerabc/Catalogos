CREATE PROCEDURE SP_Colonias_Delete
		--Parameters
			@Id int,
			@IdEstado int,
			@IdMunicipio int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Colonias]
		WHERE 
			[Id] = @Id
		AND
			[IdEstado] = @IdEstado
		AND
			[IdMunicipio] = @IdMunicipio

END
