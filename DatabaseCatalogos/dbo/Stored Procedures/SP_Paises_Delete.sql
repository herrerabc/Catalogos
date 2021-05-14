CREATE PROCEDURE SP_Paises_Delete
		--Parameters
			@Id int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Paises]
		WHERE 
			[Id] = @Id

END
