CREATE PROCEDURE SP_Usuarios_Delete
		--Parameters
			@Id int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Usuarios]
		WHERE 
			[Id] = @Id

END
