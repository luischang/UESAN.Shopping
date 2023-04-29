CREATE TABLE [dbo].[OrderDetail] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [OrdersId]  INT             NULL,
    [ProductId] INT             NULL,
    [Quantity]  INT             NULL,
    [Price]     DECIMAL (18, 2) NULL,
    [CreatedAt] DATETIME        NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetail_Orders] FOREIGN KEY ([OrdersId]) REFERENCES [dbo].[Orders] ([Id]),
    CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);

