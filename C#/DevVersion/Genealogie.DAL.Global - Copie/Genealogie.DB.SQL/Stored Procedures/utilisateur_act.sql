create procedure utilisateur_act
@id int
AS
update utilisateur set actif = 1
where id=@id
;
