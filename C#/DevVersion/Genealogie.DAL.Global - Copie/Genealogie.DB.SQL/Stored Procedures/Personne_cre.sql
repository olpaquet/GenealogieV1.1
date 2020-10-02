create PROCEDURE Personne_cre
 @id int out, @nom nvarchar(100), @prenom nvarchar(100), @datedenaissance datetime2, 
 @datededeces datetime2, @homme int, @idarbre int, @dateajout datetime2
AS
insert into Personne (nom,prenom,datedenaissance,datededeces,homme,idarbre,dateajout) 
values (@nom,@prenom,@datedenaissance,@datededeces,@homme,@idarbre,@dateajout);
set @id = @@IDENTITY;
