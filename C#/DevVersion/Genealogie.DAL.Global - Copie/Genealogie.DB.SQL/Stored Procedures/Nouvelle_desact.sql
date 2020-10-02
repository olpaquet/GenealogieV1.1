create procedure Nouvelle_desact
@id int
AS
update Nouvelle set actif = 0
where id=@id
;
