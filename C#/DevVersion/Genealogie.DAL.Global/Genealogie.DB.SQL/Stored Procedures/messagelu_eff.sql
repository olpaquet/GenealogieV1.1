create procedure messagelu_eff
@idmessage int,@idlecteur int
AS
delete messagelu 
where idmessage=@idmessage and idlecteur=@idlecteur
;
