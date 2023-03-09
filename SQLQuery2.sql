CREATE TABLE [dbo].[Personals] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [FullName]        NVARCHAR (MAX) NULL,
    [PersonalTitle]   NVARCHAR (MAX) NULL,
    [PersonalComment] NVARCHAR (MAX) NULL,
    [Gender]          NVARCHAR (MAX) NULL,
    [Age]             INT            NOT NULL,
    [IsActive]        INT            NOT NULL,
    CONSTRAINT [PK_Personals] PRIMARY KEY CLUSTERED ([Id] ASC)
);