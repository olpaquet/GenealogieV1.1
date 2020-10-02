create procedure Blocage_desact
@id int
AS
update Blocage set actif = 0
where id=@id
;
