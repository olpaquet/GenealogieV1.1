create PROCEDURE Abonnement_mod
@id int,@nom nvarchar(100),@description nvarchar(2000),@duree int,@prix decimal,@nombremaxarbres int,@nombremaxpersonnes int
AS
update Abonnement
set nom=@nom,description=@description,duree=@duree,prix=@prix,nombremaxarbres=@nombremaxarbres,nombremaxpersonnes=@nombremaxpersonnes
where id=@id
;
