create procedure utilisateurabonnement_eff
@idabonne int,@idabonnement int
AS
delete utilisateurabonnement 
where idabonne=@idabonne and idabonnement=@idabonnement
;
