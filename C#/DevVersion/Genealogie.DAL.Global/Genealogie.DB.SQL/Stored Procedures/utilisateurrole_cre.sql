create PROCEDURE utilisateurrole_cre
 @idutilisateur int , @idrole int
AS
begin try
insert into utilisateurrole (idutilisateur,idrole) values (@idutilisateur,@idrole);
end try
begin catch
if @@error <> 2167
	THROW
end catch

