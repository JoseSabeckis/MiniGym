
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/30/2020 17:34:37
-- Generated from EDMX file: C:\Users\joses\source\repos\MiniGym\MiniGym\MiniGymModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MiniGymDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProvinciaLocalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Localidades] DROP CONSTRAINT [FK_ProvinciaLocalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalidadPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas] DROP CONSTRAINT [FK_LocalidadPersona];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Localidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Localidades];
GO
IF OBJECT_ID(N'[dbo].[Provincias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provincias];
GO
IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Localidades'
CREATE TABLE [dbo].[Localidades] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [ProvinciaId] bigint  NOT NULL,
    [PersonaId] bigint  NOT NULL
);
GO

-- Creating table 'Provincias'
CREATE TABLE [dbo].[Provincias] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apellido] nvarchar(250)  NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Dni] nvarchar(9)  NOT NULL,
    [Telefono] nvarchar(25)  NULL,
    [Celular] nvarchar(25)  NOT NULL,
    [Email] nvarchar(250)  NULL,
    [Cuil] nvarchar(11)  NULL,
    [FechaNacimiento] datetime  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [LocalidadId] bigint  NOT NULL,
    [Calle] nvarchar(max)  NOT NULL,
    [Numero] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [PK_Localidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Provincias'
ALTER TABLE [dbo].[Provincias]
ADD CONSTRAINT [PK_Provincias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProvinciaId] in table 'Localidades'
ALTER TABLE [dbo].[Localidades]
ADD CONSTRAINT [FK_ProvinciaLocalidad]
    FOREIGN KEY ([ProvinciaId])
    REFERENCES [dbo].[Provincias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinciaLocalidad'
CREATE INDEX [IX_FK_ProvinciaLocalidad]
ON [dbo].[Localidades]
    ([ProvinciaId]);
GO

-- Creating foreign key on [LocalidadId] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [FK_LocalidadPersona]
    FOREIGN KEY ([LocalidadId])
    REFERENCES [dbo].[Localidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalidadPersona'
CREATE INDEX [IX_FK_LocalidadPersona]
ON [dbo].[Personas]
    ([LocalidadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------