create procedure Message_eff
@id int
AS
delete Message 
where id=@id
;
