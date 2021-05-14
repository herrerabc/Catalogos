CREATE TABLE [dbo].[Municipios] (
    [Id]          INT          NOT NULL,
    [IdEstado]    INT          NOT NULL,
    [descripcion] VARCHAR (70) NULL,
    CONSTRAINT [PK_Municipios] PRIMARY KEY CLUSTERED ([Id] ASC, [IdEstado] ASC),
    CONSTRAINT [FK__Municipio__IdEst__182C9B23] FOREIGN KEY ([IdEstado]) REFERENCES [dbo].[Estados] ([Id])
);

