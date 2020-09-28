create procedure Theme_desact
@id int
AS
update Theme set actif = 0
where id=@id
;
