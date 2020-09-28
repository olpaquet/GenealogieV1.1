
create function PositionDans (@st nvarchar(max), @cherche nvarchar(max), @sep nvarchar(1) = ',')
returns int
as
begin
if @st is null 
	return 0

declare @max int = (select dbo.nbentrees(@st, @sep))

declare @i int = 1

while @i <= @max
begin
	if @cherche = (select dbo.entree(@st, @i, @sep))
		return @i
	set @i = @i + 1
end

return 0
end
