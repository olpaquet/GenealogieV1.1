CREATE TABLE [dbo].[Theme] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [titre]       NVARCHAR (50)   NOT NULL,
    [description] NVARCHAR (1000) NOT NULL,
    [actif]       INT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_theme] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_theme_titre]
    ON [dbo].[Theme]([titre] ASC);

