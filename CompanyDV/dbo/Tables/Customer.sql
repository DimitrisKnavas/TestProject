CREATE TABLE [dbo].[Customer]
(
  [Id]     INT       IDENTITY (1, 1) NOT NULL,
  [FirstName] NVARCHAR (250) NULL,
  [LastName]  NVARCHAR (250) NULL,
  [PhoneNumber]   VARCHAR (50) NULL,
  [HomeAddress]  NVARCHAR(250) NULL,
  [Email] NVARCHAR(250) NULL,
  PRIMARY KEY CLUSTERED ([Id] ASC)
)
