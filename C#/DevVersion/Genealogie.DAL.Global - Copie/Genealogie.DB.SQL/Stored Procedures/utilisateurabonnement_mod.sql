create PROCEDURE utilisateurabonnement_mod
@idabonne int,@idabonnement int,@dateabonnement datetime2,@cartedepayement nvarchar(100), @prix decimal
AS
update utilisateurabonnement
set dateabonnement=@dateabonnement,cartedepayement=@cartedepayement,prix=@prix
where idabonne=@idabonne and idabonnement=@idabonnement
;
