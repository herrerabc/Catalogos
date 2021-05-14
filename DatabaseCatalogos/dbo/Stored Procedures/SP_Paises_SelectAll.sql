CREATE PROCEDURE SP_Paises_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[Id],
			[descripcion]
		FROM 
			[dbo].[Paises]
END
