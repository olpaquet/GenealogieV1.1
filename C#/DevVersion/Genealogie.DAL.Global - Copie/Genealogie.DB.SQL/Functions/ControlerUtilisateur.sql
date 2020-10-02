
 CREATE FUNCTION ControlerUtilisateur 
(@login nvarchar(50), @motdepasse nVARCHAR(50), @option nvarchar(max) = null)
RETURNS int 
AS
BEGIN

	/*declare @presel nvarchar(255);
	declare @postsel nvarchar(255);*/
	--declare @epw varbinary(64);
	declare @u int;	
	declare @api int;

	if @option = 'API'
		set @api = 1

	if @api = 1
	begin
		select @u = count(*)
		from utilisateurapi 
		where login = @login and 
		dbo.ConstruireHMotdepasse(@motdepasse, presel, postsel) = motdepasse;
		/*if @u = null	
			return 0*/
		return @u;    
	end

	

	select @u = count(*)
	from utilisateur 
	where login = @login and 
	dbo.ConstruireHMotdepasse(@motdepasse, presel, postsel) = motdepasse;
	/*if @u = null	
		return 0*/
	return @u;    
END
