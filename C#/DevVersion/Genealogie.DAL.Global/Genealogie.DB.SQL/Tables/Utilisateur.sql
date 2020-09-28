CREATE TABLE [dbo].[Utilisateur] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [login]           NVARCHAR (50)  NOT NULL,
    [nom]             NVARCHAR (50)  NOT NULL,
    [prenom]          NVARCHAR (50)  NULL,
    [email]           NVARCHAR (200) NOT NULL,
    [datedenaissance] DATETIME2 (7)  NULL,
    [homme]           INT            NOT NULL,
    [cartedepayement] NVARCHAR (50)  NULL,
    [motdepasse]      VARBINARY (64) NOT NULL,
    [presel]          NVARCHAR (255) NOT NULL,
    [postsel]         NVARCHAR (255) NOT NULL,
    [actif]           INT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_utilisateur] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_utilisateur_login]
    ON [dbo].[Utilisateur]([login] ASC);

