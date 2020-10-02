create PROCEDURE Conversation_cre
 @id int out, @sujet nvarchar(50), @texte nvarchar(max), @idemetteur int
AS
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
insert into Conversation (date, sujet, texte, idemetteur) values (@aujourdhui, @sujet, @texte, @idemetteur);
set @id = @@IDENTITY;
