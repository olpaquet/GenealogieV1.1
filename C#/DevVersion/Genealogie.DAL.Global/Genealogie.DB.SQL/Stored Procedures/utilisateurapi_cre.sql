
create PROCEDURE utilisateurapi_cre
 @id int out, @login nvarchar(100), 
 @motdepasse nvarchar(50),
 @dom nvarchar(max) = null
AS
begin

declare @presel nvarchar(255)
declare @postsel nvarchar(255)
exec GenererHasard 255, @presel out
exec GenererHasard 255, @postsel out	
		declare @mp varbinary(64);
		set @mp = dbo.ConstruireHMotdepasse(@motdepasse,@presel,@postsel);
		insert into utilisateurapi 
		(login,motdepasse,presel,postsel,dom) 
		values (@login,@mp,@presel,@postsel,@dom);
		--save transaction ut		
end
