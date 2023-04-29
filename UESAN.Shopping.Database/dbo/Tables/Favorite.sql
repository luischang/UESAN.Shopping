CREATE TABLE [dbo].[Favorite] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [UserId]    INT      NULL,
    [ProductId] INT      NULL,
    [CreatedAt] DATETIME NULL,
    CONSTRAINT [PK_Favorite] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Favorite_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_Favorite_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

