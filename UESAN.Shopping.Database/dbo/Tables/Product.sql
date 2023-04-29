CREATE TABLE [dbo].[Product] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (100)  NULL,
    [ImageUrl]    NVARCHAR (MAX)  NULL,
    [Stock]       INT             NULL,
    [Price]       DECIMAL (18, 2) NULL,
    [Discount]    INT             NULL,
    [CategoryId]  INT             NULL,
    [IsActive]    BIT             NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);

