create procedure arbre_bloquer @id int, @idblocage int, @dateblocage datetime2, @idbloqueur int
as
update Arbre set idblocage=@idblocage, dateblocage=@dateblocage, idbloqueur = @idbloqueur where id = @id
