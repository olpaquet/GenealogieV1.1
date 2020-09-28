create procedure Blocage_act
@id int
AS
update Blocage set actif = 1
where id=@id
;
