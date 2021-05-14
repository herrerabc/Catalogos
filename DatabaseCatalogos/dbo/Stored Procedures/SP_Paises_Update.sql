CREATE PROCEDURE SP_Paises_Update
		--Parameters

			@Id int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Paises]
		SET
			[Id] = @Id,
			[descripcion] = @descripcion

		WHERE 
			[Id] = @Id


END
