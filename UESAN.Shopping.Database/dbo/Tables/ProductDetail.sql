CREATE TABLE [dbo].[ProductDetail] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ProductId] INT            NULL,
    [ImageUrl]  NVARCHAR (MAX) NULL,
    [IsActive]  BIT            NULL,
    [CreatedAt] DATETIME       NULL,
    CONSTRAINT [PK_ProductDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProductDetail_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

