CREATE TABLE [dbo].[Usuarios] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]    VARCHAR (50)  NOT NULL,
    [ApellidoP] VARCHAR (50)  NOT NULL,
    [ApellidoM] VARCHAR (50)  NOT NULL,
    [Telefono]  NUMERIC (10)  NULL,
    [Direccion] VARCHAR (120) NULL,
    [Email]     VARCHAR (50)  NULL,
    [Loggin]    VARCHAR (50)  NOT NULL,
    [Password]  VARCHAR (50)  NOT NULL,
    [Estado]    BIT           NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED ([Id] ASC)
);

