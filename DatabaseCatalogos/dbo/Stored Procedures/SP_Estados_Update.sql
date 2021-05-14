CREATE PROCEDURE SP_Estados_Update
		--Parameters

			@Id int,
			@IdPais int,
			@descripcion varchar(70) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Estados]
		SET
			[Id] = @Id,
			[IdPais] = @IdPais,
			[descripcion] = @descripcion

		WHERE 
			[Id] = @Id


END
