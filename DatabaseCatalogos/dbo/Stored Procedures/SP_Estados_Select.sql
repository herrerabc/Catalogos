CREATE PROCEDURE SP_Estados_Select
		--Parameters
			@Id int

AS
BEGIN
SET NOCOUNT ON;
		SELECT
			[Id],
			[IdPais],
			[descripcion]
		FROM 
			[dbo].[Estados]
		WHERE 
			[Id] = @Id
END
