create PROCEDURE messageefface_mod
@idmessage int,@ideffaceur int,@date datetime2
AS
update messageefface
set date=@date
where idmessage=@idmessage and ideffaceur=@ideffaceur
;
