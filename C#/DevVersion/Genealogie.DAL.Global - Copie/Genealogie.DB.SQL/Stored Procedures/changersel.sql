create procedure changersel
@reponse int out,
@login nvarchar(50),
@motdepasse nvarchar(50),
@presel nvarchar(255),
@postsel nvarchar(255),
@options nvarchar(max)
as
begin
declare @pw varbinary(64)
declare @option nvarchar(max);

if @options = 'API'
	set @options = 1

	
select @reponse = dbo.ControlerUtilisateur(@login,@motdepasse,@options);
if @reponse = 0
	return @reponse;
select @pw = dbo.ConstruireHMotdepasse(@motdepasse, @presel,@postsel)
update utilisateur set motdepasse = @pw, presel = @presel, postsel = @postsel where login = @login
return 1

end
