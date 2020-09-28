create procedure utilisateurrole_eff
@idutilisateur int,@idrole int
AS
delete utilisateurrole 
where idutilisateur=@idutilisateur and idrole=@idrole
;

