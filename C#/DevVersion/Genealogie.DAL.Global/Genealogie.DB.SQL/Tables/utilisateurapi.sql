CREATE TABLE [dbo].[utilisateurapi] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [login]      NVARCHAR (50)  NOT NULL,
    [motdepasse] VARBINARY (64) NOT NULL,
    [presel]     NVARCHAR (255) NOT NULL,
    [postsel]    NVARCHAR (255) NOT NULL,
    [dom]        NVARCHAR (MAX) NULL,
    CONSTRAINT [pk_utilisateurapi] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_utilisateurapi_login]
    ON [dbo].[utilisateurapi]([login] ASC);

