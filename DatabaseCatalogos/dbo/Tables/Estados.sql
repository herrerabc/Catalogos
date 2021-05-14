CREATE TABLE [dbo].[Estados] (
    [Id]          INT          NOT NULL,
    [IdPais]      INT          NOT NULL,
    [descripcion] VARCHAR (70) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdPais]) REFERENCES [dbo].[Paises] ([Id])
);

