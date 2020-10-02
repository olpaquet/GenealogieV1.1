create procedure Couple_eff
@idpersonne int,
@idpartenaire int
AS
delete Couple 
where idpersonne=@idpersonne and idpartenaire = @idpartenaire
;
