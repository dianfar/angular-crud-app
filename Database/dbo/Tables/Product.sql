CREATE TABLE [dbo].[Product] (
    [ProductId]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NULL,
    [Quantity]        INT           NULL,
    [Price]           MONEY         NULL,
    [SupplierId]      INT           NULL,
    [CategoryId]      INT           NULL,
    [LastUpdatedDate] DATETIME      NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]),
    CONSTRAINT [FK_Product_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([SupplierId])
);

