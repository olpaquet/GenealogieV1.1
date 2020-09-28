create procedure messagedestination_lu @idconversation int, @iddestinataire int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update messagedestination set datelecture=@aujourdhui
where idconversation=@idconversation and iddestinataire=@iddestinataire and datelecture is null

