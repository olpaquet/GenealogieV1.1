create PROCEDURE Message_cre
 @id int out, @sujet nvarchar(100), @texte nvarchar(MAX), @idemetteur int, @idconversation int
AS
insert into Message (sujet,texte,idemetteur,idconversation) values (@sujet,@texte,@idemetteur,@idconversation);
set @id = @@IDENTITY;
