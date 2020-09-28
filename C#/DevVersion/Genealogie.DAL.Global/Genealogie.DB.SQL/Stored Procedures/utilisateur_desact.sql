create procedure utilisateur_desact
@id int
AS
update utilisateur set actif = 0
where id=@id
;
