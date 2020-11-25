CREATE TABLE [dbo].[Usuario] (
    [IdUsuario] BIGINT          IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (50)    NOT NULL,
    [Email]     VARCHAR (150)   NOT NULL,
    [DtNasc]    DATETIME        NOT NULL,
    [Token]     VARCHAR(MAX)    NOT NULL,
    [Ativo] BIT NOT NULL DEFAULT 1, 
    [Senha] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);