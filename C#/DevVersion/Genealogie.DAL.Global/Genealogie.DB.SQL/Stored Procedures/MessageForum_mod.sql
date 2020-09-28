create PROCEDURE MessageForum_mod
@id int,@sujet nvarchar(100),@texte nvarchar(MAX),@idtheme int,@idpublicateur int,@datepublication datetime2
AS
update MessageForum
set sujet=@sujet,texte=@texte,idtheme=@idtheme,idpublicateur=@idpublicateur,datepublication=@datepublication
where id=@id
;
