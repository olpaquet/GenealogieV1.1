CREATE TABLE [dbo].[Role] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [nom]         NVARCHAR (50)   NOT NULL,
    [description] NVARCHAR (1000) NOT NULL,
    [actif]       INT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_role] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_role]
    ON [dbo].[Role]([nom] ASC);

