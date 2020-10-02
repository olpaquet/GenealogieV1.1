create procedure Abonnement_desact
@id int
AS
update Abonnement set actif = 0
where id=@id
;
