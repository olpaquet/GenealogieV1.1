CREATE TABLE [dbo].[Abonnement] (
    [id]                 INT             IDENTITY (1, 1) NOT NULL,
    [nom]                NVARCHAR (50)   NOT NULL,
    [description]        NVARCHAR (1000) NOT NULL,
    [duree]              INT             NOT NULL,
    [prix]               DECIMAL (18)    DEFAULT ((0.0)) NOT NULL,
    [nombremaxarbres]    INT             DEFAULT ((0)) NOT NULL,
    [nombremaxpersonnes] INT             DEFAULT ((0)) NOT NULL,
    [actif]              INT             DEFAULT ((1)) NOT NULL,
    CONSTRAINT [pk_abonnement] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iu_abonnement]
    ON [dbo].[Abonnement]([id] ASC, [nom] ASC);

