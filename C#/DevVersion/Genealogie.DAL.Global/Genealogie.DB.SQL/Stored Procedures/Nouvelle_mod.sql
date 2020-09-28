create PROCEDURE Nouvelle_mod
@id int,@titre nvarchar(100),@description nvarchar(2000),@idcreateur int,@datecreation datetime2
AS
update Nouvelle
set titre=@titre,description=@description,idcreateur=@idcreateur,datecreation=@datecreation
where id=@id
;
