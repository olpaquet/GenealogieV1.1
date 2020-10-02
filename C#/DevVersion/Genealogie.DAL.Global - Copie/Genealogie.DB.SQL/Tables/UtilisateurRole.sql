CREATE TABLE [dbo].[UtilisateurRole] (
    [idutilisateur] INT NOT NULL,
    [idrole]        INT NOT NULL,
    CONSTRAINT [pk_utilisateurrole] PRIMARY KEY CLUSTERED ([idutilisateur] ASC, [idrole] ASC),
    CONSTRAINT [fk_utilisateurrole_role] FOREIGN KEY ([idrole]) REFERENCES [dbo].[Role] ([id]),
    CONSTRAINT [fk_utilisateurrole_utilisateur] FOREIGN KEY ([idutilisateur]) REFERENCES [dbo].[Utilisateur] ([id])
);

