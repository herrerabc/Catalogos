CREATE TABLE [dbo].[sepomex] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [idEstado]     SMALLINT      NOT NULL,
    [estado]       VARCHAR (100) NOT NULL,
    [idMunicipio]  SMALLINT      NOT NULL,
    [municipio]    VARCHAR (120) NOT NULL,
    [ciudad]       VARCHAR (120) NULL,
    [zona]         VARCHAR (30)  NOT NULL,
    [cp]           BIGINT        NOT NULL,
    [asentamiento] VARCHAR (120) NOT NULL,
    [tipo]         VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

