create procedure Theme_act
@id int
AS
update Theme set actif = 1
where id=@id
;
