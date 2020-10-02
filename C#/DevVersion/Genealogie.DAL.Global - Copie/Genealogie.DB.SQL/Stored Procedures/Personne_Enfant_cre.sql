create procedure Personne_Enfant_cre
@id int, @idenfant int
as
begin
declare @h int
set @h = (select homme from Personne where id=@id)
if @h=1
	update Personne set idpere = @id where id = @idenfant
else
	update Personne set idmere = @id where id = @idenfant
end
