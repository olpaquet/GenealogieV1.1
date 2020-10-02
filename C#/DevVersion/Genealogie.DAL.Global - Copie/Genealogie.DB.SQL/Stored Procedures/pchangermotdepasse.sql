
create procedure pchangermotdepasse
 @xreponse  int out,
@xlogin nvarchar(50), @vieuxmotdepasse nvarchar(50), 
@motdepasse nvarchar(50), @xoption nvarchar(max)
as
begin
	declare @presel nvarchar(255);
	declare @postsel nvarchar(255);
	declare @epw varbinary(64);
	declare @u int;
	declare @id int;

	declare @api int

	if @xoption = 'API'
		set @api = 1
	
	if @api = 1
		select @id = id, @presel = presel, @postsel=postsel 
		from utilisateur 
		where login = @xlogin 
		and dbo.ConstruireHMotdepasse(@vieuxmotdepasse,presel,postsel) = motdepasse;
	else
		select @id = id, @presel = presel, @postsel=postsel 
		from utilisateurapi
		where login = @xlogin 
		and dbo.ConstruireHMotdepasse(@vieuxmotdepasse,presel,postsel) = motdepasse;
	
	if @id is null
		set @xreponse = 0;
	else 
	begin
		if @api = 1
		begin
			set @epw = dbo.ConstruireHMotdepasse(@motdepasse,@presel,@postsel);
			update utilisateurapi set motdepasse = @epw where id = @id;
			set @xreponse = 1
		end	
		else
		begin
			set @epw = dbo.ConstruireHMotdepasse(@motdepasse,@presel,@postsel);
			update utilisateur set motdepasse = @epw where id = @id;
			set @xreponse = 1
		end
	end
    
end
