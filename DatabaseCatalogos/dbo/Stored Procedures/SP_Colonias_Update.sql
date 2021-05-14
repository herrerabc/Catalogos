CREATE PROCEDURE SP_Colonias_Update
		--Parameters

			@Id int,
			@IdEstado int,
			@IdMunicipio int,
			@cp bigint,
			@Descripcion varchar(120) = NULL 


AS
BEGIN
SET NOCOUNT ON;

		UPDATE [dbo].[Colonias]
		SET
			[Id] = @Id,
			[IdEstado] = @IdEstado,
			[IdMunicipio] = @IdMunicipio,
			[cp] = @cp,
			[Descripcion] = @Descripcion

		WHERE 
			[Id] = @Id AND 
			[IdEstado] = @IdEstado AND 
			[IdMunicipio] = @IdMunicipio


END
