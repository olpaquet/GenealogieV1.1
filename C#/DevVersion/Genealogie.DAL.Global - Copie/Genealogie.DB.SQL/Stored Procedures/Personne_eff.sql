create procedure Personne_eff
@id int
AS
delete Personne 
where id=@id
;
