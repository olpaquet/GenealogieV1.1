create procedure Role_act
@id int
AS
update Role set actif = 1
where id=@id
;
