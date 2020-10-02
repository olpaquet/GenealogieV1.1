create PROCEDURE Abonnement_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000), @duree int, @prix decimal, @nombremaxarbres int, @nombremaxpersonnes int
AS
insert into Abonnement (nom,description,duree,prix,nombremaxarbres,nombremaxpersonnes) values (@nom,@description,@duree,@prix,@nombremaxarbres,@nombremaxpersonnes);
set @id = @@IDENTITY;
