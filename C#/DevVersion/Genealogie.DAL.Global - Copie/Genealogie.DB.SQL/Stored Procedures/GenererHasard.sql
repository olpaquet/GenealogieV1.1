
create procedure GenererHasard @nombredecaracteres int, @ret  nvarchar(max) out
as
begin
DECLARE @compteur int;  

set @compteur = 1
while @compteur <= @nombredecaracteres
	begin
	
	set @ret = CONCAT(@ret,char(50+rand() * 100))
	set @compteur = @compteur + 1
	end

end
