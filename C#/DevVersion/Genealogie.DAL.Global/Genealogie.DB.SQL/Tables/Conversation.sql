CREATE TABLE [dbo].[Conversation] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [date]           DATETIME2 (7)  NOT NULL,
    [sujet]          NVARCHAR (50)  NULL,
    [texte]          NVARCHAR (MAX) NULL,
    [idemetteur]     INT            NOT NULL,
    [dateeffacement] DATETIME2 (7)  DEFAULT (NULL) NULL,
    CONSTRAINT [pk_conversation] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_conversation_emetteur] FOREIGN KEY ([idemetteur]) REFERENCES [dbo].[Utilisateur] ([id])
);

