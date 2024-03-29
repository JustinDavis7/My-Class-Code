CREATE TABLE [Country] (
    [ID]             INT           PRIMARY KEY IDENTITY(1, 1),
    [FullName]       NVARCHAR(50)  NOT NULL,
    [Abbreviation]   NVARCHAR(8)   NOT NULL,
    [FlagImageURL]   NVARCHAR(20)  NOT NULL
);

CREATE TABLE [Club] (
    [ID]             INT           PRIMARY KEY IDENTITY(1, 1),
    [Name]           NVARCHAR(50)  NOT NULL
);

CREATE TABLE [Position] (
    [ID]             INT           PRIMARY KEY IDENTITY(1, 1),
    [Name]           NVARCHAR(50)  NOT NULL
);

CREATE TABLE [Player] (
    [ID]             INT           PRIMARY KEY IDENTITY(1, 1),
    [FullName]       NVARCHAR(50)  NOT NULL,
    [CountryID]      INT           NOT NULL,
    [PositionID]     INT           NOT NULL,
    [Weight]         NVARCHAR(10),
    [Height]         NVARCHAR(10),
    [Age]            INT,
    [DateOfBirth]    DATETIME,
    [ClubTeamID]     INT
);

ALTER TABLE [Player] ADD CONSTRAINT [Player_Fk_Country]   FOREIGN KEY  ([CountryID])   REFERENCES  [Country]  ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Player] ADD CONSTRAINT [Player_Fk_Position]  FOREIGN KEY ([PositionID])   REFERENCES  [Position] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Player] ADD CONSTRAINT [Player_Fk_ClubTeam]  FOREIGN KEY ([ClubTeamID])   REFERENCES  [Club]     ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Table added for exam
CREATE TABLE [MatchResult] (
    [ID]             INT           PRIMARY KEY IDENTITY(1, 1),
    [FullTime]       DATETIME      NOT NULL,
    [HomeTeamID]     INT           NOT NULL,
    [AwayTeamID]     INT           NOT NULL,
    [HomeTeamGoals]  INT           NOT NULL,
    [AwayTeamGoals]  INT           NOT NULL
);
ALTER TABLE [MatchResult] ADD CONSTRAINT [MatchResult_Fk_CountryHome]   FOREIGN KEY  ([HomeTeamID])   REFERENCES  [Country]  ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [MatchResult] ADD CONSTRAINT [MatchResult_Fk_CountryAway]   FOREIGN KEY  ([AwayTeamID])   REFERENCES  [Country]  ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
