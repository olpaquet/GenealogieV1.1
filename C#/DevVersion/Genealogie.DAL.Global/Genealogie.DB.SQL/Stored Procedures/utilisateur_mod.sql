create PROCEDURE utilisateur_mod
@id int,@nom nvarchar(100),@prenom nvarchar(100),
@email nvarchar(400),@datedenaissance datetime2,@homme int, @cartedepayement nvarchar(50),
@roles nvarchar(max) 
AS
begin
begin try
begin transaction

update utilisateur
set nom=@nom,prenom=@prenom,email=@email,datedenaissance=@datedenaissance,homme=@homme, 
cartedepayement=@cartedepayement
where id=@id


/* effacer mauvais rôles*/
declare @idrole int


begin try
close c
deallocate c
end try
begin catch
end catch


declare c cursor for select idrole from utilisateurrole where idutilisateur = @id

open c
fetch c into @idrole

declare @dedans int
declare @position int

WHILE @@FETCH_STATUS = 0
BEGIN
	
	set @position = (select dbo.PositionDans(@roles, @idrole,','))
	
	if @position = 0 or @roles is null
		begin
		exec utilisateurrole_eff @id, @idrole
		end
	fetch c into @idrole
end
close c
deallocate c
/* ajouter rôles*/
declare @i int = 1
declare @nb int 
declare @xx int
set @nb = (select dbo.nbentrees(@roles, ','))
declare @role int
declare @xxx nvarchar(max)
while @i <= @nb
begin
	set @xxx = (select dbo.entree(@roles, @i, ','))
	--set @role = convert(int,@xxx)
	
	set @role = @xxx
	select @xx = count (*) from utilisateurrole where idutilisateur = @id and idrole = @role
	if @xx = 0
	exec utilisateurrole_cre @id, @role
	set @i = @i + 1
end


commit
end try
begin catch
/*DECLARE @ErrorMessage NVARCHAR(4000);  
    DECLARE @ErrorSeverity INT;  
    DECLARE @ErrorState INT;  
	declare @ErrorNumber int
  
    SELECT   
	@ErrorNumber = ERROR_NUMBER(),
        @ErrorMessage = ERROR_MESSAGE(),  
        @ErrorSeverity = ERROR_SEVERITY(),  
        @ErrorState = ERROR_STATE();  
rollback

raiserror(@ErrorMessage, @ErrorSeverity, @ErrorState,@ErrorNumber)*/
print concat('=>',error_number())
declare @ErrorMessage nvarchar(max),@ErrorSeverity int,@ErrorState int;
select @ErrorMessage = ERROR_MESSAGE()+' Line '+ cast(ERROR_LINE() as nvarchar(5))
,@ErrorSeverity = ERROR_SEVERITY(),
@ErrorState = ERROR_STATE();
--if @@trancount >0rollbacktransaction;
set @id = 0
rollback
print concat('coucou=>',@ErrorMessage)
raiserror(@ErrorMessage,@ErrorSeverity,@ErrorState);
--raiserror('flûte',1,1)
end catch

end

