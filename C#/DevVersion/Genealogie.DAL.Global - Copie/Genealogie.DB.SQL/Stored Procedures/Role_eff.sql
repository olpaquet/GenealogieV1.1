create procedure Role_eff
@id int
AS
delete Role 
where id=@id
;
