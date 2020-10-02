create PROCEDURE Personne_mod
@id int,@nom nvarchar(100),@prenom nvarchar(100),@datedenaissance datetime2,@datededeces datetime2,@homme int,@idarbre int,@dateajout datetime2
AS
update Personne
set nom=@nom,prenom=@prenom,datedenaissance=@datedenaissance,datededeces=@datededeces,homme=@homme,idarbre=@idarbre,dateajout=@dateajout
where id=@id
;
