CREATE TABLE [dbo].[RateAll] (
    [Id] INT IDENTITY(1,1) NOT NULL,
    [UserId] NVARCHAR(128) NOT NULL,
    [AScore] INT NOT NULL,
    [BScore] INT NOT NULL,
    [CScore] INT NOT NULL,
    [Comment] NVARCHAR(MAX) NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
);
