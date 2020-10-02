create procedure Arbre_eff
@id int
AS
delete Arbre 
where id=@id
;
