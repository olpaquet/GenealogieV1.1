create PROCEDURE messageefface_cre
 @idmessage int , @ideffaceur int, @date datetime2
AS
insert into messageefface (idmessage,ideffaceur,date) values (@idmessage,@ideffaceur,@date);

