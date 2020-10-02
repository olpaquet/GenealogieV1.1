create procedure MessageForum_act
@id int
AS
update MessageForum set actif = 1
where id=@id
;
