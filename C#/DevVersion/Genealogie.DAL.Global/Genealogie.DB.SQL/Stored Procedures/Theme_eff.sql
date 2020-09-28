create procedure Theme_eff
@id int
AS
delete Theme 
where id=@id
;
