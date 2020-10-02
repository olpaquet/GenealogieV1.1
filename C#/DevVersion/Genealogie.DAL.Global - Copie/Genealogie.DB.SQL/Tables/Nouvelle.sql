CREATE TABLE [dbo].[Nouvelle] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [titre]        NVARCHAR (50)   NOT NULL,
    [description]  NVARCHAR (1000) NOT NULL,
    [idcreateur]   INT             NOT NULL,
    [datecreation] DATETIME2 (7)   NOT NULL,
    [actif]        INT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_nouvelle] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [fk_nouvelle_createur] FOREIGN KEY ([idcreateur]) REFERENCES [dbo].[Utilisateur] ([id])
);

