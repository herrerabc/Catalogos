CREATE PROCEDURE SP_Municipios_Update
		--Parameters

			@Id int,
			@IdEstado int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Municipios]
		SET
			[Id] = @Id,
			[IdEstado] = @IdEstado,
			[descripcion] = @descripcion

		WHERE 
			[Id] = @Id AND 
			[IdEstado] = @IdEstado


END
