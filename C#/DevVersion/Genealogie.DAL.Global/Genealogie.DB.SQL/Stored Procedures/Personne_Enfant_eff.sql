create procedure Personne_Enfant_eff @id int, @idenfant int
as
begin
declare @h int
set @h = (select homme from Personne where id=@id)
if @h = 1
	update Personne set idpere = null where id = @idenfant;
else
	update Personne set idmere = null where id = @idenfant;
end
