create procedure MessageForum_eff
@id int
AS
delete MessageForum 
where id=@id
;
