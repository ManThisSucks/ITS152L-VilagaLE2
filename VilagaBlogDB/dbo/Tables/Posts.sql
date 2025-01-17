﻿CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY , 
    [UserId] INT NOT NULL, 
    [Title] NVARCHAR(150) NOT NULL, 
    [Body] TEXT NOT NULL, 
    [Date Created] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_Posts_Users] FOREIGN KEY (UserID) REFERENCES Users(Id) 
)
