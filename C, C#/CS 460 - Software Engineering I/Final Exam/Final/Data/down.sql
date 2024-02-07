ALTER TABLE [Player] DROP CONSTRAINT [Player_Fk_Country];
ALTER TABLE [Player] DROP CONSTRAINT [Player_Fk_Position];
ALTER TABLE [Player] DROP CONSTRAINT [Player_Fk_ClubTeam];

ALTER TABLE [MatchResult] DROP CONSTRAINT [MatchResult_Fk_CountryHome];
ALTER TABLE [MatchResult] DROP CONSTRAINT [MatchResult_Fk_CountryAway];

DROP TABLE [Player];
DROP TABLE [Position];
DROP TABLE [Country];
DROP TABLE [Club];

DROP TABLE [MatchResult];