create function entree(@st nvarchar(max), @po int, @sep nvarchar(1) = ",")
returns nvarchar(max)
as
begin

	declare @ret nvarchar(max)
	

	declare @nb int = (select dbo.nbentrees(@st, @sep))
	if @nb = 1
		return @st

	/*if @nb > @po or @po <= 1 or @st = null
		RAISERROR ()*/
	

	declare @posmem int = 0
	

	declare @i int = 0
	if @st is null or @po = 0
		return null

	while @i <> @po and @i < @nb
	begin
	
		declare @pos int = charindex( @sep, @st,@posmem + 1);
		set @i = @i + 1
		
		
		
		
		if @i = @po
		begin
			if @pos = @posmem
				return ''
			if @pos <= @posmem
				return substring(@st, @posmem+1,len(@st) - (@posmem + 1) + 1)
				
			else
				return substring(@st, @posmem + 1, @pos - @posmem - 1)
				
			
			
		end
			
		set @posmem = @pos	


	end

	return null
	
end

