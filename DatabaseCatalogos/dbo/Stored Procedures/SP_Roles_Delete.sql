CREATE PROCEDURE SP_Roles_Delete
		--Parameters
			@Id varchar(15)


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Roles]
		WHERE 
			[Id] = @Id

END
