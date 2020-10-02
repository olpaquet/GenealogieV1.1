CREATE TABLE [dbo].[messagedestination] (
    [idconversation] INT           NOT NULL,
    [iddestinataire] INT           NOT NULL,
    [datelecture]    DATETIME2 (7) DEFAULT (NULL) NULL,
    [dateeffacement] DATETIME2 (7) DEFAULT (NULL) NULL,
    CONSTRAINT [pk_messagedestination] PRIMARY KEY CLUSTERED ([idconversation] ASC, [iddestinataire] ASC),
    CONSTRAINT [fk_messagedestination_conversation] FOREIGN KEY ([idconversation]) REFERENCES [dbo].[Conversation] ([id]),
    CONSTRAINT [fk_messagedestination_destinataire] FOREIGN KEY ([iddestinataire]) REFERENCES [dbo].[Utilisateur] ([id])
);

