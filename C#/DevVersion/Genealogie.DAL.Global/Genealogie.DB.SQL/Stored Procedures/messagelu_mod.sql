create PROCEDURE messagelu_mod
@idmessage int,@idlecteur int,@date datetime2
AS
update messagelu
set date=@date
where idmessage=@idmessage and idlecteur = @idlecteur
;
