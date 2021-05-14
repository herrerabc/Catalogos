CREATE PROCEDURE SP_Estados_SelectAll
AS
BEGIN
SET NOCOUNT ON;
SELECT
			[Id],
			[IdPais],
			[descripcion]
		FROM 
			[dbo].[Estados]
END
