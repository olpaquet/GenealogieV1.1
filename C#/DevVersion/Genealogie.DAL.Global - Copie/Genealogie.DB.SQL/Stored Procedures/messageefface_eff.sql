create procedure messageefface_eff
@idmessage int,@ideffaceur int
AS
delete messageefface 
where idmessage=@idmessage and ideffaceur=@ideffaceur
;
