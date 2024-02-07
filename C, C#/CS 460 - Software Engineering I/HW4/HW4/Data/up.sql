-- If you want to create the DB from code run the next line
--CREATE DATABASE [ToDo];

-- And if you need to switch DB's run this
--USE [ToDo];

CREATE TABLE [Person]
(
    [ID]        INT          NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName]  NVARCHAR(50) NOT NULL
);

CREATE TABLE [ToDoItem]
(
    [ID]            INT             NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Name]          NVARCHAR(50)    NOT NULL,
    [Description]   NVARCHAR(500)   NOT NULL,
    [PersonID]      INT
);

CREATE TABLE [ItemTask]
(
    [ID]                    INT             NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Name]                  NVARCHAR(50)    NOT NULL,
    [Notes]                 NVARCHAR(500)   NOT NULL,
    [Complete]              BIT             NOT NULL,
    [Frequency]             INT             NOT NULL,
    [FirstCompletion]       DATETIME        NOT NULL,
    [ItemID]                INT,
    [CompletedID]           INT
);

CREATE TABLE [CompletedTask]
(
    [ID]                INT             NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    [Name]              NVARCHAR(50)    NOT NULL,
    [CompletionDate]    DATETIME        NOT NULL,
    [PersonID]          INT 
);

-- *************** Add foreign key relations using named constraints ********************
ALTER TABLE [ToDoItem]      ADD CONSTRAINT [Item_Fk_Person]      FOREIGN KEY ([PersonID])    REFERENCES [Person] ([ID])          ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [CompletedTask] ADD CONSTRAINT [CTask_Fk_Person]     FOREIGN KEY ([PersonID])    REFERENCES [Person] ([ID])          ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [ItemTask]      ADD CONSTRAINT [ITask_Fk_Item]       FOREIGN KEY ([ItemID])      REFERENCES [ToDoItem] ([ID])        ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE [ItemTask]      ADD CONSTRAINT [ITask_Fk_Completed]  FOREIGN KEY ([CompletedID]) REFERENCES [CompletedTask] ([ID])   ON DELETE NO ACTION ON UPDATE NO ACTION;