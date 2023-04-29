CREATE TABLE [dbo].[Orders] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [CreatedAt]   DATETIME        NULL,
    [UserId]      INT             NULL,
    [Status]      CHAR (1)        NULL,
    [TotalAmount] DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

