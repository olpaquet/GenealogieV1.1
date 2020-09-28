create procedure Abonnement_eff
@id int
AS
delete Abonnement 
where id=@id
;
