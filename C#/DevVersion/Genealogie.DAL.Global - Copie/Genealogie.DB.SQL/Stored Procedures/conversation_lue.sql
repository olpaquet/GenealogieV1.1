create procedure conversation_lue @id int
as
declare @aujourdhui datetime
set @aujourdhui = (select GETDATE())
update Conversation set dateeffacement = @aujourdhui where id = @id
