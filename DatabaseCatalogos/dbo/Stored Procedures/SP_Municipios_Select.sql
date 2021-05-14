CREATE PROCEDURE SP_Municipios_Select
		--Parameters
			@Id int,
			@IdEstado int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[IdEstado],
			[descripcion]
		FROM 
			[dbo].[Municipios]
		WHERE 
			[Id] = @Id
		AND
			[IdEstado] = @IdEstado
END
