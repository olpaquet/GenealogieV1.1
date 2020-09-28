CREATE TABLE [dbo].[MessageForum] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [sujet]           NVARCHAR (50)  NOT NULL,
    [texte]           NVARCHAR (MAX) NULL,
    [idtheme]         INT            NOT NULL,
    [idpublicateur]   INT            NOT NULL,
    [datepublication] DATETIME2 (7)  NULL,
    [actif]           INT            DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_messageforum] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_messageforum_publicateur] FOREIGN KEY ([idpublicateur]) REFERENCES [dbo].[Utilisateur] ([id]),
    CONSTRAINT [fk_messageforum_theme] FOREIGN KEY ([idtheme]) REFERENCES [dbo].[Theme] ([id])
);

