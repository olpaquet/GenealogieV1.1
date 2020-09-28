create PROCEDURE Arbre_mod
@id int,@nom nvarchar(100),@description nvarchar(2000)
AS
update Arbre
set nom=@nom,description=@description
where id=@id
;
