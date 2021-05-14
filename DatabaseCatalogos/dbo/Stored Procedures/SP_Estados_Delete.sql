CREATE PROCEDURE SP_Estados_Delete
		--Parameters
			@Id int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Estados]
		WHERE 
			[Id] = @Id

END
