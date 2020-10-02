create PROCEDURE messagedestination_cre
 @idconversation int, @iddestinataire int
AS
insert into messagedestination (idconversation, iddestinataire) values (@idconversation,@iddestinataire);

