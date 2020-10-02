create PROCEDURE Blocage_mod
@id int,@nom nvarchar(100),@description nvarchar(100)
AS
update Blocage
set nom=@nom,description=@description
where id=@id
;
