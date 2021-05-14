CREATE PROCEDURE SP_Colonias_SelectAll
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
END
