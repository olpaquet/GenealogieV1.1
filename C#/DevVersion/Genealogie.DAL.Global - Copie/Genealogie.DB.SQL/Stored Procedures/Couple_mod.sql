create PROCEDURE Couple_mod
@idpersonne int,@idpartenaire int,@datedebut datetime2,@datefin datetime2
AS
update Couple
set datedebut=@datedebut,datefin=@datefin
where idpersonne=@idpersonne
;
