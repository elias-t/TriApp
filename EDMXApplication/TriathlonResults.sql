
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/08/2019 11:03:24
-- Generated from EDMX file: C:\Projects\TriCalc\EDMXApplication\TriModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TriathlonResults];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Races_Formats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Races] DROP CONSTRAINT [FK_Races_Formats];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Athletes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Athletes];
GO
IF OBJECT_ID(N'[dbo].[FK_Results_Races]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Results] DROP CONSTRAINT [FK_Results_Races];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Athletes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Athletes];
GO
IF OBJECT_ID(N'[dbo].[Formats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formats];
GO
IF OBJECT_ID(N'[dbo].[Races]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Races];
GO
IF OBJECT_ID(N'[dbo].[Results]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Results];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Athletes'
CREATE TABLE [dbo].[Athletes] (
    [Athlete_id] int IDENTITY(1,1)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL
);
GO

-- Creating table 'Formats'
CREATE TABLE [dbo].[Formats] (
    [Format_id] int IDENTITY(1,1)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
	[Distance_Swim] decimal(5,2) NOT NULL,
	[Distance_Bike] decimal(5,2) NOT NULL,
	[Distance_Run] decimal(5,2) NOT NULL,
);
GO

-- Creating table 'Races'
CREATE TABLE [dbo].[Races] (
    [Race_id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Race_Format_id] int  NOT NULL,
    [Year] int  NOT NULL
);
GO

-- Creating table 'Results'
CREATE TABLE [dbo].[Results] (
    [Result_Id] int IDENTITY(1,1)  NOT NULL,
    [Result_Race_Id] int  NOT NULL,
    [Result_Athlete_Id] int  NOT NULL,
    [Time_Swim] time  NULL,
    [Time_T1] time  NULL,
    [Time_Bike] time  NULL,
    [Time_T2] time  NULL,
    [Time_Run] time  NULL,
    [Time_Total] time  NULL,
    [Team] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL,
    [Bib] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Athlete_id] in table 'Athletes'
ALTER TABLE [dbo].[Athletes]
ADD CONSTRAINT [PK_Athletes]
    PRIMARY KEY CLUSTERED ([Athlete_id] ASC);
GO

-- Creating primary key on [Format_id] in table 'Formats'
ALTER TABLE [dbo].[Formats]
ADD CONSTRAINT [PK_Formats]
    PRIMARY KEY CLUSTERED ([Format_id] ASC);
GO

-- Creating primary key on [Race_id] in table 'Races'
ALTER TABLE [dbo].[Races]
ADD CONSTRAINT [PK_Races]
    PRIMARY KEY CLUSTERED ([Race_id] ASC);
GO

-- Creating primary key on [Result_Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [PK_Results]
    PRIMARY KEY CLUSTERED ([Result_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Result_Athlete_Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Athletes]
    FOREIGN KEY ([Result_Athlete_Id])
    REFERENCES [dbo].[Athletes]
        ([Athlete_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Athletes'
CREATE INDEX [IX_FK_Results_Athletes]
ON [dbo].[Results]
    ([Result_Athlete_Id]);
GO

-- Creating foreign key on [Race_Format_id] in table 'Races'
ALTER TABLE [dbo].[Races]
ADD CONSTRAINT [FK_Races_Formats]
    FOREIGN KEY ([Race_Format_id])
    REFERENCES [dbo].[Formats]
        ([Format_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Races_Formats'
CREATE INDEX [IX_FK_Races_Formats]
ON [dbo].[Races]
    ([Race_Format_id]);
GO

-- Creating foreign key on [Result_Race_Id] in table 'Results'
ALTER TABLE [dbo].[Results]
ADD CONSTRAINT [FK_Results_Races]
    FOREIGN KEY ([Result_Race_Id])
    REFERENCES [dbo].[Races]
        ([Race_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Results_Races'
CREATE INDEX [IX_FK_Results_Races]
ON [dbo].[Results]
    ([Result_Race_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

--Update Time_Total
--UPDATE Results SET Time_Total = (SELECT CAST(CAST(time_swim as datetime)+CAST(time_t1 as datetime)+CAST(time_bike as datetime)+CAST(time_t2 as datetime)+CAST(time_run as datetime) as time) WHERE Result_Id=1)


-- Add rows.
--Formats
INSERT INTO Formats(Name, Distance_Swim, Distance_Bike, Distance_Run) VALUES('Sprint', 0.75, 20, 5)
INSERT INTO Formats(Name, Distance_Swim, Distance_Bike, Distance_Run) VALUES('Olympic', 1.5, 40, 10)
INSERT INTO Formats(Name, Distance_Swim, Distance_Bike, Distance_Run) VALUES('Half Ironman', 1.9, 90, 21.1)
INSERT INTO Formats(Name, Distance_Swim, Distance_Bike, Distance_Run) VALUES('Ironman', 3.8, 180, 42.2)
--Races
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('Copenhagen',4,2019)
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('Talin',4,	2018)
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('Almiraman',3,	2018)
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('St. Marys Loch',2,	2017)
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('St. Marys Loch',2,	2018)
INSERT INTO Races(Name,Race_Format_id, Year) VALUES('Eyemouth',1,	2016)
--Athletes
INSERT INTO Athletes(FirstName,LastName,DOB) VALUES('Elias', 'Theo', CONVERT(datetime,'1980/01/30'))
--Results
INSERT INTO Results(Result_Race_Id,Result_Athlete_Id,Time_Swim,Time_T1,Time_Bike,Time_T2,Time_Run,Time_Total,Team,City,Bib) 
VALUES(6,1,'00:13:00.0000000','00:01:30.0000000','00:40:00.0000000','00:01:00.0000000','00:25:00.0000000','01:20:30.0000000','ScienceTraining','Edinbrugh','131')