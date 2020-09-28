create procedure messagedestination_efface @idconversation int, @iddestinataire int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update messagedestination set dateeffacement=@aujourdhui 
where idconversation=@idconversation and iddestinataire=@iddestinataire
and dateeffacement is null

