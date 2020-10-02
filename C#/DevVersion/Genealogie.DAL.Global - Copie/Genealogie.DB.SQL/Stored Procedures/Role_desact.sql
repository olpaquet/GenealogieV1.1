create procedure Role_desact
@id int
AS
update Role set actif = 0
where id=@id
;
