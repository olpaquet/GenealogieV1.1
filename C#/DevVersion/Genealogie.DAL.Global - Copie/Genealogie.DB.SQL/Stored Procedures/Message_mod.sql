create PROCEDURE Message_mod
@id int,@sujet nvarchar(100),@texte nvarchar(MAX),@idemetteur int,@idconversation int
AS
update Message
set sujet=@sujet,texte=@texte,idemetteur=@idemetteur,idconversation=@idconversation
where id=@id
;
