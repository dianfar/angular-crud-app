CREATE TABLE [dbo].[Category] (
    [CategoryId]   INT           NOT NULL,
    [CategoryName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

