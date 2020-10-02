create PROCEDURE Role_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000)
AS
insert into Role (nom,description) values (@nom,@description);
set @id = @@IDENTITY;
