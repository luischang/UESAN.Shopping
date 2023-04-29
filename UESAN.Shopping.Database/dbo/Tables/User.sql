CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NULL,
    [LastName]    NVARCHAR (50)  NULL,
    [DateOfBirth] DATE           NULL,
    [Country]     NVARCHAR (50)  NULL,
    [Address]     NVARCHAR (100) NULL,
    [Email]       NVARCHAR (100) NULL,
    [Password]    NVARCHAR (100) NULL,
    [IsActive]    BIT            NULL,
    [Type]        CHAR (1)       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

