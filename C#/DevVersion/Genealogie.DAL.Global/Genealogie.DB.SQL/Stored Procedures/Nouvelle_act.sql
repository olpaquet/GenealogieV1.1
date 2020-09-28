create procedure Nouvelle_act
@id int
AS
update Nouvelle set actif = 1
where id=@id
;
