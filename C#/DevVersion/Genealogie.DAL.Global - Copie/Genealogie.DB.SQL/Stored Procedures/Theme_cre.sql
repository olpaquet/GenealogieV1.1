create PROCEDURE Theme_cre
 @id int out, @titre nvarchar(100), @description nvarchar(2000)
AS
insert into Theme (titre,description) values (@titre,@description);
set @id = @@IDENTITY;
