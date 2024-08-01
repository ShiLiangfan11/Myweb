-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Score] int NOT NULL CHECK (Score >= 0 AND Score <= 10), -- 评分，范围0-10
    [Comment] nvarchar(max) NOT NULL, -- 评论
    PRIMARY KEY (Id)
);
GO

-- Creating table 'RateDetails'
CREATE TABLE [dbo].[RateDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RatingId] int NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    PRIMARY KEY (Id),
    FOREIGN KEY (RatingId) REFERENCES Ratings(Id)
);
GO
