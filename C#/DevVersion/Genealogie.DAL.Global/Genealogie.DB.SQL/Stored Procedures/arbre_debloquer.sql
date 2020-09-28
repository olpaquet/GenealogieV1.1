create procedure arbre_debloquer @id int
as
update Arbre set idblocage=null, dateblocage=null, idbloqueur=null where id = @id;
