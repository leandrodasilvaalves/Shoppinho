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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    CREATE TABLE [Lojas] (
        [Id] uniqueidentifier NOT NULL,
        [NomeFantasia] varchar(120) NOT NULL,
        [RazaoSocial] varchar(120) NOT NULL,
        [CNPJ] varchar(14) NOT NULL,
        [InscricaoEstadual] varchar(9) NULL,
        [DataCadastro] datetimeoffset NOT NULL,
        [UltimaAtualizacao] datetimeoffset NOT NULL,
        [Ativo] bit NOT NULL,
        CONSTRAINT [PK_Lojas] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    CREATE TABLE [Enderecos] (
        [Id] uniqueidentifier NOT NULL,
        [Logradouro] varchar(100) NULL,
        [Complemento] varchar(100) NULL,
        [Numero] varchar(100) NULL,
        [Cidade] varchar(80) NULL,
        [Estado] varchar(2) NULL,
        [Cep] varchar(100) NULL,
        [LojaId] uniqueidentifier NULL,
        CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Enderecos_Lojas_LojaId] FOREIGN KEY ([LojaId]) REFERENCES [Lojas] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    CREATE TABLE [Telefones] (
        [CodigoPais] varchar(100) NOT NULL,
        [DDD] int NOT NULL,
        [Numero] varchar(100) NOT NULL,
        [Whatsapp] bit NOT NULL,
        [LojaId] uniqueidentifier NULL,
        CONSTRAINT [PK_Telefones] PRIMARY KEY ([CodigoPais], [DDD], [Numero]),
        CONSTRAINT [FK_Telefones_Lojas_LojaId] FOREIGN KEY ([LojaId]) REFERENCES [Lojas] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    CREATE INDEX [IX_Enderecos_LojaId] ON [Enderecos] ([LojaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    CREATE INDEX [IX_Telefones_LojaId] ON [Telefones] ([LojaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220424193947_IniciarBanco')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220424193947_IniciarBanco', N'6.0.4');
END;
GO

COMMIT;
GO


