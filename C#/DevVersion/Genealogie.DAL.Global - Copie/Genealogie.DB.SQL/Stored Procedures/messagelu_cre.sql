create PROCEDURE messagelu_cre
 @idmessage int , @idlecteur int, @date datetime2
AS
insert into messagelu (idmessage,idlecteur,date) values (@idmessage,@idlecteur,@date);

