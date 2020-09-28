CREATE TABLE [dbo].[UtilisateurAbonnement] (
    [idabonne]        INT           NOT NULL,
    [idabonnement]    INT           NOT NULL,
    [dateabonnement]  DATETIME2 (7) NOT NULL,
    [cartedepayement] NVARCHAR (50) NOT NULL,
    [prix]            DECIMAL (18)  DEFAULT ((0.0)) NOT NULL,
    CONSTRAINT [pk_utilisateurabonnement] PRIMARY KEY CLUSTERED ([idabonne] ASC, [idabonnement] ASC, [dateabonnement] ASC),
    CONSTRAINT [fk_utilisateurabonnement_abonne] FOREIGN KEY ([idabonne]) REFERENCES [dbo].[Utilisateur] ([id]),
    CONSTRAINT [fk_utilisateurabonnement_abonnement] FOREIGN KEY ([idabonnement]) REFERENCES [dbo].[Utilisateur] ([id])
);

