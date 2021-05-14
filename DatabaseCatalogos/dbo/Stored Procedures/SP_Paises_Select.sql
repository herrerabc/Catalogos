CREATE PROCEDURE SP_Paises_Select
		--Parameters
			@Id int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[descripcion]
		FROM 
			[dbo].[Paises]
		WHERE 
			[Id] = @Id
END
