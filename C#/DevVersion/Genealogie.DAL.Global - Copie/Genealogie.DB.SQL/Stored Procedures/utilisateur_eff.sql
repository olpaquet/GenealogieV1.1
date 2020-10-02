create procedure utilisateur_eff
@id int
AS
delete utilisateur 
where id=@id
;
