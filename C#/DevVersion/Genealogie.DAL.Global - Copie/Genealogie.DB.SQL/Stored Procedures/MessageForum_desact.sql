create procedure MessageForum_desact
@id int
AS
update MessageForum set actif = 0
where id=@id
;
