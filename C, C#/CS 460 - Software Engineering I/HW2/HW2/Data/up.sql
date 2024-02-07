CREATE TABLE [ShowType] 
(
  [ID]                  int           NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [ShowTypeIdentifier]  nvarchar(20)  NOT NULL
);

CREATE TABLE [AgeCertification] 
(
  [ID]                      int          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [CertificationIdentifier] nvarchar(20) NOT NULL
);

CREATE TABLE [Genre] 
(
  [ID]          int          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [GenreString] nvarchar(32) NOT NULL
);

CREATE TABLE [ProductionCountry] 
(
  [ID]                int          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [CountryIdentifier] nvarchar(64) NOT NULL
);

CREATE TABLE [Role] 
(
  [ID]       int          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [RoleName] nvarchar(32) NOT NULL
);

CREATE TABLE [Person] 
(
  [ID]                int          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [JustWatchPersonID] int          NOT NULL,
  [FullName]          nvarchar(50) NOT NULL
);

CREATE TABLE [Show] 
(
  [ID]                  int           NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [JustWatchShowID]     nvarchar(12)  NOT NULL,
  [Title]               nvarchar(128) NOT NULL,
  [Description]         nvarchar(MAX),
  [ShowTypeID]          int NOT NULL,
  [ReleaseYear]         int NOT NULL,
  [AgeCertificationID]  int,
  [Runtime]             int NOT NULL,
  [Seasons]             int,
  [ImdbID]              nvarchar(12),
  [ImdbScore]           float,
  [ImdbVotes]           float,
  [TmdbPopularity]      float,
  [TmdbScore]           float
);

CREATE TABLE [GenreAssignment] 
(
  [ID]      int   NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [ShowID]  int   NOT NULL,
  [GenreID] int   NOT NULL
);

CREATE TABLE [ProductionCountryAssignments] 
(
  [ID]                  int   NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [ShowID]              int   NOT NULL,
  [ProductionCountryID] int   NOT NULL
);

CREATE TABLE [Credit] 
(
  [ID]            int           NOT NULL IDENTITY(1, 1) PRIMARY KEY,
  [ShowID]        int           NOT NULL,
  [PersonID]      int           NOT NULL,
  [RoleID]        int           NOT NULL,
  [CharacterName] nvarchar(128)
);

ALTER TABLE [Show] ADD CONSTRAINT [Show_Fk_ShowType]         FOREIGN KEY ([ShowTypeID])         REFERENCES [ShowType] ([ID])         ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Show] ADD CONSTRAINT [Show_Fk_AgeCertification] FOREIGN KEY ([AgeCertificationID]) REFERENCES [AgeCertification] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [GenreAssignment] ADD CONSTRAINT [GenreAssignment_Fk_Show]  FOREIGN KEY ([ShowID])  REFERENCES [Show] ([ID])  ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [GenreAssignment] ADD CONSTRAINT [GenreAssignment_Fk_Genre] FOREIGN KEY ([GenreID]) REFERENCES [Genre] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [ProductionCountryAssignments] ADD CONSTRAINT [ProdCountryAssign_Fk_Show]              FOREIGN KEY ([ShowID])              REFERENCES [Show] ([ID])              ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [ProductionCountryAssignments] ADD CONSTRAINT [ProdCountryAssign_Fk_ProductionCountry] FOREIGN KEY ([ProductionCountryID]) REFERENCES [ProductionCountry] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Credit] ADD CONSTRAINT [Credit_Fk_Show]   FOREIGN KEY ([ShowID])   REFERENCES [Show] ([ID])   ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Credit] ADD CONSTRAINT [Credit_Fk_Person] FOREIGN KEY ([PersonID]) REFERENCES [Person] ([ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [Credit] ADD CONSTRAINT [Credit_Fk_Role]   FOREIGN KEY ([RoleID])   REFERENCES [Role] ([ID])   ON DELETE NO ACTION ON UPDATE NO ACTION;
