CREATE PROCEDURE SP_Municipios_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[Id],
			[IdEstado],
			[descripcion]
		FROM 
			[dbo].[Municipios]
END
