create PROCEDURE utilisateurabonnement_cre
 @idabonne int, @idabonnement int, @dateabonnement datetime2, @cartedepayement nvarchar(100), @prix decimal
AS
insert into utilisateurabonnement (idabonne,idabonnement,dateabonnement,cartedepayement,prix) values (@idabonne,@idabonnement,@dateabonnement,@cartedepayement,@prix);

