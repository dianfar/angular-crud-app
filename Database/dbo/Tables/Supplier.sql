CREATE TABLE [dbo].[Supplier] (
    [SupplierId]  INT            NOT NULL,
    [Name]        NCHAR (10)     NOT NULL,
    [Address]     NVARCHAR (MAX) NOT NULL,
    [ContactName] NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([SupplierId] ASC)
);

