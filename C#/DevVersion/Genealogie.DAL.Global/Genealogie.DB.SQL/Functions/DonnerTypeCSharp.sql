create function DonnerTypeCSharp
(@typesql nvarchar(max), @estnullable int)
returns nvarchar(max)
as
begin
declare @ret nvarchar(max)
select @ret = CASE
		WHEN @typesql in ('nvarchar','varchar') THEN 'string'  
		when @typesql = 'money' then 'decimal'
		when @typesql = 'datetime' then 'DateTime'  
		ELSE @typesql
	end

if @estnullable = 1 and @ret in ('int','DateTime','decimal')
		set @ret = concat(@ret,'?');
return @ret
end
