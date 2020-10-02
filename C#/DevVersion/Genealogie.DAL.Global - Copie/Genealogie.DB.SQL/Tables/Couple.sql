CREATE TABLE [dbo].[Couple] (
    [idpersonne]   INT           NOT NULL,
    [idpartenaire] INT           NOT NULL,
    [datedebut]    DATETIME2 (7) NOT NULL,
    [datefin]      DATETIME2 (7) NULL,
    CONSTRAINT [pk_couple] PRIMARY KEY CLUSTERED ([idpersonne] ASC, [idpartenaire] ASC, [datedebut] ASC),
    CONSTRAINT [fk_couple_partenaire] FOREIGN KEY ([idpartenaire]) REFERENCES [dbo].[Personne] ([id]),
    CONSTRAINT [fk_couple_personne] FOREIGN KEY ([idpersonne]) REFERENCES [dbo].[Personne] ([id])
);

