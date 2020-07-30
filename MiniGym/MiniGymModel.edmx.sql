
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/30/2020 18:50:11
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
IF OBJECT_ID(N'[dbo].[FK_PrestamoCuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas] DROP CONSTRAINT [FK_PrestamoCuota];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonaPrestamo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prestamos] DROP CONSTRAINT [FK_PersonaPrestamo];
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
IF OBJECT_ID(N'[dbo].[Prestamos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prestamos];
GO
IF OBJECT_ID(N'[dbo].[Cuotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas];
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

-- Creating table 'Prestamos'
CREATE TABLE [dbo].[Prestamos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CodigoCredito] nvarchar(max)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NULL,
    [CantidadCuotas] int  NOT NULL,
    [Notas] nvarchar(max)  NOT NULL,
    [EstadoPrestamo] bigint  NOT NULL,
    [PersonaId] bigint  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Cuotas'
CREATE TABLE [dbo].[Cuotas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [NumeroCuota] nvarchar(max)  NOT NULL,
    [ValorCuota] decimal(18,0)  NOT NULL,
    [ValorParcial] decimal(18,0)  NOT NULL,
    [EstadoCuota] bigint  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [Saldo] decimal(18,0)  NOT NULL,
    [PrestamoId] bigint  NOT NULL
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

-- Creating primary key on [Id] in table 'Prestamos'
ALTER TABLE [dbo].[Prestamos]
ADD CONSTRAINT [PK_Prestamos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [PK_Cuotas]
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

-- Creating foreign key on [PrestamoId] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [FK_PrestamoCuota]
    FOREIGN KEY ([PrestamoId])
    REFERENCES [dbo].[Prestamos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrestamoCuota'
CREATE INDEX [IX_FK_PrestamoCuota]
ON [dbo].[Cuotas]
    ([PrestamoId]);
GO

-- Creating foreign key on [PersonaId] in table 'Prestamos'
ALTER TABLE [dbo].[Prestamos]
ADD CONSTRAINT [FK_PersonaPrestamo]
    FOREIGN KEY ([PersonaId])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaPrestamo'
CREATE INDEX [IX_FK_PersonaPrestamo]
ON [dbo].[Prestamos]
    ([PersonaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------