
create PROCEDURE utilisateur_cre
 @id int out, @login nvarchar(100), @nom nvarchar(100), @prenom nvarchar(100), 
 @email nvarchar(400), @datedenaissance datetime2, @homme int, @cartedepayement nvarchar(50), 
 @motdepasse nvarchar(50), @presel nvarchar(510), @postsel nvarchar(510),
 @roles nvarchar(max) = null
AS
begin
	begin try
		begin transaction
		declare @mp varbinary(64);
		set @mp = dbo.ConstruireHMotdepasse(@motdepasse,@presel,@postsel);
		insert into utilisateur (login,nom,prenom,email,datedenaissance,homme,cartedepayement,motdepasse,presel,postsel) values (@login,@nom,@prenom,@email,@datedenaissance,@homme,@cartedepayement,@mp,@presel,@postsel);
		--save transaction ut

		--begin transaction ut
		--declare @i int = 1/0
		set @id = @@IDENTITY
		declare @nb int 
		select @nb = (select dbo.nbentrees( @roles, ','))
		declare @compteur int = 1
		declare @jj int = 0

		--exec utilisateurrole_cre @id, 1
		while @compteur <= @nb
		
		begin
			set @jj = (select dbo.entree(@roles, @compteur, ','))
			--set @jj = 1;

			
			exec utilisateurrole_cre @id, @jj
			set @compteur = @compteur + 1
		end
		
		commit
	end try
	begin catch

	--[10:44] Michaël Person
    

declare @ErrorMessage nvarchar(max),@ErrorSeverity int,@ErrorState int;
select @ErrorMessage = ERROR_MESSAGE()+' Line '+ cast(ERROR_LINE() as nvarchar(5))
,@ErrorSeverity = ERROR_SEVERITY(),
@ErrorState = ERROR_STATE();
--if @@trancount >0rollbacktransaction;
set @id = 0
rollback
print concat('coucou=>',@ErrorMessage)
raiserror(@ErrorMessage,@ErrorSeverity,@ErrorState);




		--rollback transaction ut
		
		declare @flute nvarchar(max)
		select @flute = @@ERROR
		--throw
		--raiserror(@flute)

		raiserror('flute',1,1)
		--raiserror(error_message(),1,1)
		set @id = 0
	end catch
end
