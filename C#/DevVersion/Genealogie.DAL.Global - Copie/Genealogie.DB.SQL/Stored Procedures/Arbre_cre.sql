create PROCEDURE Arbre_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000), @idcreateur int, @datecreation datetime2
AS
insert into Arbre (nom,description,idcreateur,datecreation) values (@nom,@description,@idcreateur,@datecreation);
set @id = @@IDENTITY;
