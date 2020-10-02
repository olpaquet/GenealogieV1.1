create procedure Blocage_eff
@id int
AS
delete Blocage 
where id=@id
;
