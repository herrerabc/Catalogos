CREATE TABLE [dbo].[Colonias] (
    [Id]          INT           NOT NULL,
    [IdEstado]    INT           NOT NULL,
    [IdMunicipio] INT           NOT NULL,
    [cp]          BIGINT        NOT NULL,
    [Descripcion] VARCHAR (120) NULL,
    CONSTRAINT [PK_Colonias] PRIMARY KEY CLUSTERED ([Id] ASC, [IdEstado] ASC, [IdMunicipio] ASC),
    CONSTRAINT [FK_Municipio_1_Colonia_1] FOREIGN KEY ([IdMunicipio], [IdEstado]) REFERENCES [dbo].[Municipios] ([Id], [IdEstado])
);

