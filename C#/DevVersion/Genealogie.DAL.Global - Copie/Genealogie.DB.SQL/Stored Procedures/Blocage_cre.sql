create PROCEDURE Blocage_cre
 @id int out, @nom nvarchar(100), @description nvarchar(100)
AS
insert into Blocage (nom,description) values (@nom,@description);
set @id = @@IDENTITY;
