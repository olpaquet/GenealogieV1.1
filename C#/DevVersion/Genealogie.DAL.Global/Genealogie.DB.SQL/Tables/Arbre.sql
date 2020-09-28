CREATE TABLE [dbo].[Arbre] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [nom]          NVARCHAR (50)   NOT NULL,
    [description]  NVARCHAR (1000) NOT NULL,
    [idcreateur]   INT             NOT NULL,
    [datecreation] DATETIME2 (7)   NOT NULL,
    [idblocage]    INT             NULL,
    [idbloqueur]   INT             NULL,
    [dateblocage]  DATETIME2 (7)   NULL,
    CONSTRAINT [pk_arbre] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_arbre_blocage] FOREIGN KEY ([idblocage]) REFERENCES [dbo].[Blocage] ([id]),
    CONSTRAINT [fk_arbre_bloqueur] FOREIGN KEY ([idbloqueur]) REFERENCES [dbo].[Utilisateur] ([id]),
    CONSTRAINT [fk_arbre_createur] FOREIGN KEY ([idcreateur]) REFERENCES [dbo].[Utilisateur] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_arbre_nom]
    ON [dbo].[Arbre]([nom] ASC, [idcreateur] ASC);


GO
CREATE NONCLUSTERED INDEX [i_arbre_createur]
    ON [dbo].[Arbre]([idcreateur] ASC);

