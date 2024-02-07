ALTER TABLE [Show] DROP CONSTRAINT [Show_Fk_ShowType];
ALTER TABLE [Show] DROP CONSTRAINT [Show_Fk_AgeCertification];

ALTER TABLE [GenreAssignment] DROP CONSTRAINT [GenreAssignment_Fk_Show];
ALTER TABLE [GenreAssignment] DROP CONSTRAINT [GenreAssignment_Fk_Genre];

ALTER TABLE [ProductionCountryAssignments] DROP CONSTRAINT [ProdCountryAssign_Fk_Show];
ALTER TABLE [ProductionCountryAssignments] DROP CONSTRAINT [ProdCountryAssign_Fk_ProductionCountry];

ALTER TABLE [Credit] DROP CONSTRAINT [Credit_Fk_Show];
ALTER TABLE [Credit] DROP CONSTRAINT [Credit_Fk_Person];
ALTER TABLE [Credit] DROP CONSTRAINT [Credit_Fk_Role];

DROP TABLE [ShowType];
DROP TABLE [AgeCertification];
DROP TABLE [Genre];
DROP TABLE [ProductionCountry];
DROP TABLE [Role];
DROP TABLE [Person];
DROP TABLE [Show];
DROP TABLE [GenreAssignment];
DROP TABLE [ProductionCountryAssignments];
DROP TABLE [Credit];
