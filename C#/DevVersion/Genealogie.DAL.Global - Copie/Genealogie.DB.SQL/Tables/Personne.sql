CREATE TABLE [dbo].[Personne] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [nom]             NVARCHAR (50) NULL,
    [prenom]          NVARCHAR (50) NULL,
    [datedenaissance] DATETIME2 (7) NULL,
    [datededeces]     DATETIME2 (7) NULL,
    [homme]           INT           NOT NULL,
    [idarbre]         INT           NOT NULL,
    [dateajout]       DATETIME2 (7) NOT NULL,
    [idpere]          INT           NULL,
    [idmere]          INT           NULL,
    CONSTRAINT [pk_personne] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_personne_mere] FOREIGN KEY ([idmere]) REFERENCES [dbo].[Personne] ([id]),
    CONSTRAINT [fk_personne_pere] FOREIGN KEY ([idpere]) REFERENCES [dbo].[Personne] ([id])
);


GO
CREATE NONCLUSTERED INDEX [i_personne_pere]
    ON [dbo].[Personne]([idpere] ASC);


GO
CREATE NONCLUSTERED INDEX [i_personne_mere]
    ON [dbo].[Personne]([idmere] ASC);

