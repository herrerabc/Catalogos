CREATE PROCEDURE SP_Municipios_Delete
		--Parameters
			@Id int,
			@IdEstado int


AS
BEGIN
SET NOCOUNT ON;


		DELETE
		FROM 
			[dbo].[Municipios]
		WHERE 
			[Id] = @Id
		AND
			[IdEstado] = @IdEstado

END
