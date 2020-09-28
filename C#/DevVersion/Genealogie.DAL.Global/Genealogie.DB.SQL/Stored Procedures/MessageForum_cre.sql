create PROCEDURE MessageForum_cre
 @id int out, @sujet nvarchar(100), @texte nvarchar(MAX), @idtheme int, @idpublicateur int, @datepublication datetime2
AS
insert into MessageForum (sujet,texte,idtheme,idpublicateur,datepublication) values (@sujet,@texte,@idtheme,@idpublicateur,@datepublication);
set @id = @@IDENTITY;
