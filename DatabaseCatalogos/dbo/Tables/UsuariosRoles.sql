CREATE TABLE [dbo].[UsuariosRoles] (
    [IdUsuario] INT          NOT NULL,
    [IdRol]     VARCHAR (15) NOT NULL,
    CONSTRAINT [PK_UsuariosRoles] PRIMARY KEY CLUSTERED ([IdRol] ASC, [IdUsuario] ASC),
    FOREIGN KEY ([IdRol]) REFERENCES [dbo].[Roles] ([Id]),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuarios] ([Id])
);

