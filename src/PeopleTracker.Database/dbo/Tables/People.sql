CREATE TABLE [dbo].[People] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
    [LastName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([ID] ASC)
);

