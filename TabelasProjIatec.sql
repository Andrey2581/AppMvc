IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Produtos] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(200) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Documento] nvarchar(14) NOT NULL,
    [TipoPessoa] int NOT NULL,
    [Telefone] nvarchar(13) NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [PessoaId] uniqueidentifier NOT NULL,
    [Logradouro] nvarchar(200) NOT NULL,
    [Numero] nvarchar(50) NOT NULL,
    [Complemento] nvarchar(200) NOT NULL,
    [Cep] nvarchar(8) NOT NULL,
    [Bairro] nvarchar(100) NOT NULL,
    [Cidade] nvarchar(100) NOT NULL,
    [Estado] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Produtos_PessoaId] FOREIGN KEY ([PessoaId]) REFERENCES [Produtos] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Enderecos_PessoaId] ON [Enderecos] ([PessoaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230125182349_Initial', N'6.0.13');
GO

COMMIT;
GO

