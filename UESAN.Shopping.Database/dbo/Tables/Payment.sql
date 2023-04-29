CREATE TABLE [dbo].[Payment] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [OrdersId]      INT             NULL,
    [TotalAmount]   DECIMAL (18, 2) NULL,
    [PaymentMethod] CHAR (10)       NULL,
    [Status]        CHAR (1)        NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payment_Orders] FOREIGN KEY ([OrdersId]) REFERENCES [dbo].[Orders] ([Id])
);

