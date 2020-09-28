create PROCEDURE Theme_mod
@id int,@titre nvarchar(100),@description nvarchar(2000)
AS
update Theme
set titre=@titre,description=@description
where id=@id
;
