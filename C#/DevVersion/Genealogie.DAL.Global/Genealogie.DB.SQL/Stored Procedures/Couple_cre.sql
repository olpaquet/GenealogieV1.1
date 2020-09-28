create PROCEDURE Couple_cre
 @idpersonne int , @idpartenaire int, @datedebut datetime2, @datefin datetime2
AS
insert into Couple (idpersonne,idpartenaire,datedebut,datefin) values (@idpersonne,@idpartenaire,@datedebut,@datefin);

