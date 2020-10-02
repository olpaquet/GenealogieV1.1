create procedure conversation_effacee @id int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update Conversation set dateeffacement = @aujourdhui where id = @id
