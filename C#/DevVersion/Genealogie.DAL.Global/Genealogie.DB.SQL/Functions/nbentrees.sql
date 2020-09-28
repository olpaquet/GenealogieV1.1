create  function nbentrees (@st nvarchar(max), @sep nvarchar(1))
returns int
as
begin
declare @pos int = 0

declare @ret int = 0;
if @st is null
	return @ret
set @pos = charindex(@sep,@sep, @pos + 1)
while @pos > 0

	begin
	set @ret = @ret + 1
	set @pos = charindex(@sep,@st, @pos + 1)
	end


return @ret
end

