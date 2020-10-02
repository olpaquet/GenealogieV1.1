create PROCEDURE Nouvelle_cre
 @id int out, @titre nvarchar(100), @description nvarchar(2000), @idcreateur int, @datecreation datetime2
AS
insert into Nouvelle (titre,description,idcreateur,datecreation) values (@titre,@description,@idcreateur,@datecreation);
set @id = @@IDENTITY;
