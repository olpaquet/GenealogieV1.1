CREATE TABLE [dbo].[tmotdepasse] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [login]       NVARCHAR (50)  NOT NULL,
    [motdepasse]  NVARCHAR (50)  NOT NULL,
    [presel]      NVARCHAR (255) NOT NULL,
    [postsel]     NVARCHAR (255) NOT NULL,
    [hmotdepasse] VARBINARY (64) NOT NULL,
    CONSTRAINT [pk_tmotdepasse] PRIMARY KEY CLUSTERED ([id] ASC)
);

