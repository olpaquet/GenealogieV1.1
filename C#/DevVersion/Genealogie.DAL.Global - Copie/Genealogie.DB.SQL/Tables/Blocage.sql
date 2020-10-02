CREATE TABLE [dbo].[Blocage] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [nom]         NVARCHAR (50) NOT NULL,
    [description] NVARCHAR (50) NOT NULL,
    [actif]       INT           DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_blocage] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_blocage_nom]
    ON [dbo].[Blocage]([nom] ASC);

