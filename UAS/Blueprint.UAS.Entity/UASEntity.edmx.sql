
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/24/2015 09:34:55
-- Generated from EDMX file: E:\Blueprint\UAS\Blueprint.UAS.Entity\UASEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Blueprint_UAS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DeptOrg]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeptSet] DROP CONSTRAINT [FK_DeptOrg];
GO
IF OBJECT_ID(N'[dbo].[FK_EmplDept]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmplSet] DROP CONSTRAINT [FK_EmplDept];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrgSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrgSet];
GO
IF OBJECT_ID(N'[dbo].[DeptSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeptSet];
GO
IF OBJECT_ID(N'[dbo].[EmplSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmplSet];
GO
IF OBJECT_ID(N'[dbo].[RuleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RuleSet];
GO
IF OBJECT_ID(N'[dbo].[AuthSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrgSet'
CREATE TABLE [dbo].[OrgSet] (
    [Code] nvarchar(20)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Seq] int  NOT NULL
);
GO

-- Creating table 'DeptSet'
CREATE TABLE [dbo].[DeptSet] (
    [Code] nvarchar(20)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Seq] int  NOT NULL,
    [Org_Code] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'EmplSet'
CREATE TABLE [dbo].[EmplSet] (
    [Code] nvarchar(20)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Seq] int  NOT NULL,
    [Dept_Code] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'RuleSet'
CREATE TABLE [dbo].[RuleSet] (
    [Code] nvarchar(20)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Seq] int  NOT NULL
);
GO

-- Creating table 'AuthSet'
CREATE TABLE [dbo].[AuthSet] (
    [Code] nvarchar(20)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Seq] int  NOT NULL
);
GO

-- Creating table 'EmplRule'
CREATE TABLE [dbo].[EmplRule] (
    [Empl_Code] nvarchar(20)  NOT NULL,
    [Rule_Code] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'RuleAuth'
CREATE TABLE [dbo].[RuleAuth] (
    [Rule_Code] nvarchar(20)  NOT NULL,
    [Auth_Code] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Code] in table 'OrgSet'
ALTER TABLE [dbo].[OrgSet]
ADD CONSTRAINT [PK_OrgSet]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Code] in table 'DeptSet'
ALTER TABLE [dbo].[DeptSet]
ADD CONSTRAINT [PK_DeptSet]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Code] in table 'EmplSet'
ALTER TABLE [dbo].[EmplSet]
ADD CONSTRAINT [PK_EmplSet]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Code] in table 'RuleSet'
ALTER TABLE [dbo].[RuleSet]
ADD CONSTRAINT [PK_RuleSet]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Code] in table 'AuthSet'
ALTER TABLE [dbo].[AuthSet]
ADD CONSTRAINT [PK_AuthSet]
    PRIMARY KEY CLUSTERED ([Code] ASC);
GO

-- Creating primary key on [Empl_Code], [Rule_Code] in table 'EmplRule'
ALTER TABLE [dbo].[EmplRule]
ADD CONSTRAINT [PK_EmplRule]
    PRIMARY KEY CLUSTERED ([Empl_Code], [Rule_Code] ASC);
GO

-- Creating primary key on [Rule_Code], [Auth_Code] in table 'RuleAuth'
ALTER TABLE [dbo].[RuleAuth]
ADD CONSTRAINT [PK_RuleAuth]
    PRIMARY KEY CLUSTERED ([Rule_Code], [Auth_Code] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Org_Code] in table 'DeptSet'
ALTER TABLE [dbo].[DeptSet]
ADD CONSTRAINT [FK_OrgDept]
    FOREIGN KEY ([Org_Code])
    REFERENCES [dbo].[OrgSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrgDept'
CREATE INDEX [IX_FK_OrgDept]
ON [dbo].[DeptSet]
    ([Org_Code]);
GO

-- Creating foreign key on [Dept_Code] in table 'EmplSet'
ALTER TABLE [dbo].[EmplSet]
ADD CONSTRAINT [FK_DeptEmpl]
    FOREIGN KEY ([Dept_Code])
    REFERENCES [dbo].[DeptSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeptEmpl'
CREATE INDEX [IX_FK_DeptEmpl]
ON [dbo].[EmplSet]
    ([Dept_Code]);
GO

-- Creating foreign key on [Empl_Code] in table 'EmplRule'
ALTER TABLE [dbo].[EmplRule]
ADD CONSTRAINT [FK_EmplRule_Empl]
    FOREIGN KEY ([Empl_Code])
    REFERENCES [dbo].[EmplSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Rule_Code] in table 'EmplRule'
ALTER TABLE [dbo].[EmplRule]
ADD CONSTRAINT [FK_EmplRule_Rule]
    FOREIGN KEY ([Rule_Code])
    REFERENCES [dbo].[RuleSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmplRule_Rule'
CREATE INDEX [IX_FK_EmplRule_Rule]
ON [dbo].[EmplRule]
    ([Rule_Code]);
GO

-- Creating foreign key on [Rule_Code] in table 'RuleAuth'
ALTER TABLE [dbo].[RuleAuth]
ADD CONSTRAINT [FK_RuleAuth_Rule]
    FOREIGN KEY ([Rule_Code])
    REFERENCES [dbo].[RuleSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Auth_Code] in table 'RuleAuth'
ALTER TABLE [dbo].[RuleAuth]
ADD CONSTRAINT [FK_RuleAuth_Auth]
    FOREIGN KEY ([Auth_Code])
    REFERENCES [dbo].[AuthSet]
        ([Code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RuleAuth_Auth'
CREATE INDEX [IX_FK_RuleAuth_Auth]
ON [dbo].[RuleAuth]
    ([Auth_Code]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------