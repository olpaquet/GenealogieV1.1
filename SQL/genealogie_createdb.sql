/*
drop database Genealogie

go
*/
/*
create database Genealogie
go
*/
use Genealogie
go
/****DROPFK*/

alter table UtilisateurAbonnement drop constraint fk_utilisateurabonnement_abonne 
alter table UtilisateurAbonnement drop constraint fk_utilisateurabonnement_abonnement 
alter table Utilisateurrole drop constraint fk_utilisateurrole_role
alter table Utilisateurrole drop constraint fk_utilisateurrole_utilisateur
alter table Arbre drop constraint fk_arbre_bloqueur
alter table Arbre drop constraint fk_arbre_createur
alter table Arbre drop constraint fk_arbre_blocage
alter table couple drop constraint fk_couple_personne 
alter table couple drop constraint fk_couple_partenaire
alter table Personne drop constraint fk_personne_pere
alter table Personne drop constraint fk_personne_mere
/*alter table UtilisateurNouvelle drop constraint fk_utilisateurnouvelle_publicateur
alter table UtilisateurNouvelle drop constraint fk_utilisateurnouvelle_nouvelle*/
alter table Nouvelle drop constraint fk_nouvelle_createur 
alter table MessageForum drop constraint fk_messageforum_theme
alter table MessageForum drop constraint fk_messageforum_publicateur



alter table conversation drop constraint fk_conversation_emetteur

alter table messagedestination drop constraint fk_messagedestination_conversation
 alter table messagedestination drop constraint fk_messagedestination_destinataire

/****ENDDROPFK*/

/****VUE****/


/****SUPERVUE*/

drop view v_tables
go
CREATE view v_tables as
select 
--distinct type_desc
o.name nomtable, 
c.column_id idcol,
c.name nomcol,
t.name typecol,
c.max_length longueurmax, c.precision, c.scale, c.is_nullable estnullable
from sys.all_objects o join sys.all_columns c on o.object_id = c.object_id join sys.types t on c.user_type_id = t.user_type_id
where o.type_desc = 'USER_TABLE'
and o.schema_id = 1
--order by o.name, c.column_id

GO



/*****DROP*/
drop table Utilisateur
drop table Abonnement
drop table Role
drop table Arbre
drop table Blocage
drop table Nouvelle
drop table Personne
drop table Theme
drop table Conversation
drop table Couple
/*drop table MessageLu
drop table MessageEfface*/
drop table UtilisateurAbonnement

drop table UtilisateurRole

/*drop table UtilisateurNouvelle*/

drop table MessageForum

drop table messagedestination
drop table utilisateurapi


go

/***DROP*/



/***TABLES*/
create table utilisateurapi(
id int identity (1,1) not null,
login nvarchar(50) not null,
motdepasse varbinary(64) not null,
presel nvarchar(255) not null,
postsel nvarchar(255) not null,
dom nvarchar(max)
constraint pk_utilisateurapi primary key(id))
create unique index iu_utilisateurapi_login on utilisateurapi(login) 

 create table Utilisateur
 (
 id int identity (1,1) not null,
 login nvarchar(50) not null,
 nom nvarchar(50) not null,
 prenom nvarchar(50)  null,
 email nvarchar(200) not null,
 datedenaissance datetime2,
 homme int not null,
 cartedepayement nvarchar(50),
 motdepasse varbinary(64) not null,
 presel nvarchar(255) not null,
 postsel nvarchar(255) not null,
 actif int not null default 1
 constraint pk_utilisateur primary key (id)
 );
 go
 --comment on column utilisateur.id is 'Id';
 go

 
 create unique index iu_utilisateur_login on Utilisateur (login)

 go


 create table Abonnement(
 id int identity(1,1) not null,
 nom nvarchar(50) not null,
 description nvarchar(1000) not null,
 duree int not null,
 prix money not null default 0.0,
 nombremaxarbres int not null default 0,
 nombremaxpersonnes int not null default 0,
 actif int not null default 1
 constraint pk_abonnement primary key (id)
 )
 go
 create unique index iu_abonnement on Abonnement(id,nom)
 go

 create table UtilisateurAbonnement(
 idabonne int not null,
 idabonnement int not null,
 dateabonnement datetime2 not null,
 cartedepayement nvarchar(50) not null,
 prix money not null default 0.0
 constraint pk_utilisateurabonnement primary key(idabonne,idabonnement, dateabonnement)
 )
 
 create table Role(
 id int identity(1,1) not null,
 nom nvarchar(50) not null,
 description nvarchar(1000) not null,
 actif int not null default 1
 constraint pk_role primary key(id)
 )
 create unique index iu_role on Role(nom)

 go
 create table UtilisateurRole(
 idutilisateur int not null,
 idrole int not null
 constraint pk_utilisateurrole primary key(idutilisateur,idrole)
 )
 
 go

 create table Arbre(
 id int identity(1,1) not null,
 nom nvarchar(50) not null,
 description nvarchar(1000) not null,
 idcreateur int not null,
 datecreation datetime2 not null,
 idblocage int,
 idbloqueur int,
 dateblocage datetime2
 constraint pk_arbre primary key(id)
 )
 create unique index iu_arbre_nom on Arbre(nom,idcreateur)
 create index i_arbre_createur on Arbre(idcreateur)
 go
 
 
 create table Blocage(
 id int identity(1,1),
 nom nvarchar(50) not null,
 description nvarchar(50) not null,
 actif int not null default 1
 constraint pk_blocage primary key(id)
 )
 create unique index iu_blocage_nom on Blocage(nom)

 go
 
 create table Personne(
 id int identity (1,1) not null,
 nom nvarchar(50) ,
 prenom nvarchar(50),
 datedenaissance datetime2,
 datededeces datetime2,
 homme int not null,
 idarbre int not null,
 dateajout datetime2 not null,
 idpere int,
 idmere int
 constraint pk_personne primary key (id)
 )
create index i_personne_pere on Personne(idpere)
create index i_personne_mere on Personne(idmere)



 create table Couple(
 idpersonne int not null,
 idpartenaire int not null,
 datedebut datetime2 not null,
 datefin datetime2
 constraint pk_couple primary key (idpersonne, idpartenaire, datedebut)
 )
 
 create table Nouvelle(
 id int identity(1,1) not null,
 titre nvarchar(50) not null,
 description nvarchar(1000) not null,
 idcreateur int not null,
 datecreation datetime2 not null,
 actif int not null default 1
 constraint pk_nouvelle primary key(id)
 )

 

 create table Theme(
 id int identity(1,1) not null,
 titre nvarchar(50) not null,
 description nvarchar(1000) not null,
 actif int not null default 1
 constraint pk_theme primary key(id)
 )
 create unique index iu_theme_titre on Theme(titre)
 go
 create Table Conversation(
 id int identity(1,1) not null,
 date datetime2 not null,
 sujet nvarchar(50),
 texte nvarchar(max),
 idemetteur int not null,
 dateeffacement datetime2 default null
 constraint pk_conversation primary key (id)
 )
 go
 create table messagedestination(
 idconversation int not null,
 iddestinataire int not null,
 datelecture datetime2 default null,
 dateeffacement datetime2 default null
 constraint pk_messagedestination primary key (idconversation, iddestinataire)
 )

 
 
 
 /*
 create table UtilisateurNouvelle(
 idpublicateur int not null,
 idnouvelle int not null,
 datepublication datetime2 not null
 constraint pk_utilisateurnouvelle primary key(idpublicateur,idnouvelle)
 )*/
 
 create table MessageForum(
 id int identity(1,1) not null,
 sujet nvarchar(50) not null,
 texte nvarchar(max),
 idtheme int not null,
 idpublicateur int not null,
 datepublication datetime2,
 actif int not null default 1
 constraint pk_messageforum primary key(id)
 )

/* create table MessageLu(
 idmessage int not null,
 idlecteur int not null,
 date datetime2
 constraint pk_messagelu primary key (idmessage,idlecteur)
 )
 create table MessageEfface(
 idmessage int not null,
 ideffaceur int not null,
 date datetime2
 constraint pk_messageefface primary key (idmessage,ideffaceur)
 )
 */


 go
 

 /*****ENDTABLES*/


 /*****FOREIGNKEYS*/
 alter table UtilisateurAbonnement add constraint fk_utilisateurabonnement_abonne foreign key (idabonne) references utilisateur(id)
 alter table UtilisateurAbonnement add constraint fk_utilisateurabonnement_abonnement foreign key (idabonnement) references utilisateur(id)
 alter table Utilisateurrole add constraint fk_utilisateurrole_utilisateur foreign key(idutilisateur) references utilisateur(id)
 alter table Utilisateurrole add constraint fk_utilisateurrole_role foreign key(idrole) references Role(id)
  

 
 alter table Arbre add constraint fk_arbre_createur foreign key (idcreateur) references Utilisateur(id)
 alter table Arbre add constraint fk_arbre_bloqueur foreign key (idbloqueur) references Utilisateur(id)
 alter table Arbre add constraint fk_arbre_blocage foreign key(idblocage) references Blocage(id)


 alter table couple add constraint fk_couple_personne foreign key (idpersonne) references Personne(id)
 alter table couple add constraint fk_couple_partenaire foreign key (idpartenaire) references Personne(id)

 alter table Personne add constraint fk_personne_pere foreign key (idpere) references Personne(id)
 alter table Personne add constraint fk_personne_mere foreign key (idmere) references Personne(id)
 /*alter table UtilisateurNouvelle add constraint fk_utilisateurnouvelle_publicateur foreign key(idpublicateur) references Utilisateur(id)
 alter table UtilisateurNouvelle add constraint fk_utilisateurnouvelle_nouvelle foreign key(idnouvelle) references Nouvelle(id)*/

 alter table Nouvelle add constraint fk_nouvelle_createur foreign key (idcreateur) references Utilisateur(id)

 alter table MessageForum add constraint fk_messageforum_theme foreign key (idtheme) references Theme(id)
 alter table MessageForum add constraint fk_messageforum_publicateur foreign key (idpublicateur) references Utilisateur(id)




alter table conversation add constraint fk_conversation_emetteur foreign key (idemetteur) references utilisateur(id)

alter table messagedestination add constraint fk_messagedestination_conversation foreign key (idconversation) references conversation(id)
 alter table messagedestination add constraint fk_messagedestination_destinataire foreign key (iddestinataire) references utilisateur(id)

 /*****ENDFOREIGNKEYS*/

/*****fonctionnalités*/
drop procedure GenererHasard
go

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
GO  
go
drop function nbentrees
go
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

go
drop function entree 
go
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

go
drop function PositionDans

go

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
go

drop function ConstruireHMotdepasse
go

CREATE FUNCTION ConstruireHMotdepasse 
(@motdepasse nVARCHAR(50), @presel nVARCHAR(255), @postsel nvarchar(255))
RETURNS VARBINARY(64)
AS
BEGIN
    RETURN HASHBYTES('SHA2_512',CONCAT(@presel,@motdepasse,@postsel))
END



GO

 drop function ControlerUtilisateur
 

 go

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
go
drop procedure changersel
go
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
GO
drop procedure pchangermotdepasse
go

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
		from utilisateurapi
		where login = @xlogin 
		and dbo.ConstruireHMotdepasse(@vieuxmotdepasse,presel,postsel) = motdepasse;
	else
		select @id = id, @presel = presel, @postsel=postsel 
		from utilisateur
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
go



/***********CRUD*/
go
drop procedure utilisateurapi_cre
go

create PROCEDURE utilisateurapi_cre
 @id int out, @login nvarchar(100), 
 @motdepasse nvarchar(50),
 @dom nvarchar(max) = null
AS
begin

declare @presel nvarchar(255)
declare @postsel nvarchar(255)
exec GenererHasard 255, @presel out
exec GenererHasard 255, @postsel out	
		declare @mp varbinary(64);
		set @mp = dbo.ConstruireHMotdepasse(@motdepasse,@presel,@postsel);
		insert into utilisateurapi 
		(login,motdepasse,presel,postsel,dom) 
		values (@login,@mp,@presel,@postsel,@dom);
		--save transaction ut		
end
go


go	
drop procedure utilisateurrole_cre
go
create PROCEDURE utilisateurrole_cre
 @idutilisateur int , @idrole int
AS
begin try
insert into utilisateurrole (idutilisateur,idrole) values (@idutilisateur,@idrole);
end try
begin catch
if @@error <> 2167
	THROW
end catch

go
drop procedure utilisateurrole_mod
go
create PROCEDURE utilisateurrole_mod
@idutilisateur int,@idrole int
AS
/*update utilisateurrole
set idrole=@idrole
where idutilisateur=@idutilisateur

;*/
go
drop procedure utilisateurrole_eff
go
create procedure utilisateurrole_eff
@idutilisateur int,@idrole int
AS
delete utilisateurrole 
where idutilisateur=@idutilisateur and idrole=@idrole
;

go
drop procedure utilisateur_cre
go

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
go
drop procedure utilisateur_mod
go
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

go
drop procedure utilisateur_eff
go
create procedure utilisateur_eff
@id int
AS
delete utilisateur 
where id=@id
;
go
drop procedure utilisateur_act
go
create procedure utilisateur_act
@id int
AS
update utilisateur set actif = 1
where id=@id
;
go
drop procedure utilisateur_desact
go
create procedure utilisateur_desact
@id int
AS
update utilisateur set actif = 0
where id=@id
;
go


go	
drop procedure messagelu_cre
go
create PROCEDURE messagelu_cre
 @idmessage int , @idlecteur int, @date datetime2
AS
insert into messagelu (idmessage,idlecteur,date) values (@idmessage,@idlecteur,@date);

go
drop procedure messagelu_mod
go
create PROCEDURE messagelu_mod
@idmessage int,@idlecteur int,@date datetime2
AS
update messagelu
set date=@date
where idmessage=@idmessage and idlecteur = @idlecteur
;
go
drop procedure messagelu_eff
go
create procedure messagelu_eff
@idmessage int,@idlecteur int
AS
delete messagelu 
where idmessage=@idmessage and idlecteur=@idlecteur
;
go
/*
private const string CONST_MESSAGELU_REQ = "select idmessage,idlecteur,date from messagelu";
*/

go	
drop procedure messageefface_cre
go
create PROCEDURE messageefface_cre
 @idmessage int , @ideffaceur int, @date datetime2
AS
insert into messageefface (idmessage,ideffaceur,date) values (@idmessage,@ideffaceur,@date);

go
drop procedure messageefface_mod
go
create PROCEDURE messageefface_mod
@idmessage int,@ideffaceur int,@date datetime2
AS
update messageefface
set date=@date
where idmessage=@idmessage and ideffaceur=@ideffaceur
;
go
drop procedure messageefface_eff
go
create procedure messageefface_eff
@idmessage int,@ideffaceur int
AS
delete messageefface 
where idmessage=@idmessage and ideffaceur=@ideffaceur
;
go
/*
private const string CONST_MESSAGEEFFACE_REQ = "select idmessage,ideffaceur,date from messageefface";
*/

go	
drop procedure utilisateurabonnement_cre
go
create PROCEDURE utilisateurabonnement_cre
 @idabonne int, @idabonnement int, @dateabonnement datetime2, @cartedepayement nvarchar(100), @prix money
AS
insert into utilisateurabonnement (idabonne,idabonnement,dateabonnement,cartedepayement,prix) values (@idabonne,@idabonnement,@dateabonnement,@cartedepayement,@prix);

go
drop procedure utilisateurabonnement_mod
go
create PROCEDURE utilisateurabonnement_mod
@idabonne int,@idabonnement int,@dateabonnement datetime2,@cartedepayement nvarchar(100), @prix money
AS
update utilisateurabonnement
set dateabonnement=@dateabonnement,cartedepayement=@cartedepayement,prix=@prix
where idabonne=@idabonne and idabonnement=@idabonnement
;
go
drop procedure utilisateurabonnement_eff
go
create procedure utilisateurabonnement_eff
@idabonne int,@idabonnement int
AS
delete utilisateurabonnement 
where idabonne=@idabonne and idabonnement=@idabonnement
;
go
/*
private const string CONST_UTILISATEURABONNEMENT_REQ = "select idabonne,idabonnement,dateabonnement,cartedepayement from utilisateurabonnement";
*/
go
/*
private const string CONST_UTILISATEURROLE_REQ = "select idutilisateur,idrole from utilisateurrole";
*/

/*go	
drop procedure utilisateurnouvelle_cre
go
create PROCEDURE utilisateurnouvelle_cre
 @idpublicateur int , @idnouvelle int, @datepublication datetime2
AS
insert into utilisateurnouvelle (idpublicateur,idnouvelle,datepublication) values (@idpublicateur,@idnouvelle,@datepublication);
*/
/*go
drop procedure utilisateurnouvelle_mod
go
create PROCEDURE utilisateurnouvelle_mod
@idpublicateur int,@idnouvelle int,@datepublication datetime2
AS
update utilisateurnouvelle
set datepublication=@datepublication
where idpublicateur=@idpublicateur and idnouvelle=@idnouvelle
;
*/
/*go
drop procedure utilisateurnouvelle_eff
go
create procedure utilisateurnouvelle_eff
@idpublicateur int,@idnouvelle int
AS
delete utilisateurnouvelle 
where idpublicateur=@idpublicateur and idnouvelle=@idnouvelle
;
*/
go
/*
private const string CONST_UTILISATEURNOUVELLE_REQ = "select idpublicateur,idnouvelle,datepublication from utilisateurnouvelle";
*/

/***txable***Abonnement*/
go	
drop procedure Abonnement_cre
go
create PROCEDURE Abonnement_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000), @duree int, @prix money, @nombremaxarbres int, @nombremaxpersonnes int
AS
insert into Abonnement (nom,description,duree,prix,nombremaxarbres,nombremaxpersonnes) values (@nom,@description,@duree,@prix,@nombremaxarbres,@nombremaxpersonnes);
set @id = @@IDENTITY;
go
drop procedure Abonnement_mod
go
create PROCEDURE Abonnement_mod
@id int,@nom nvarchar(100),@description nvarchar(2000),@duree int,@prix money,@nombremaxarbres int,@nombremaxpersonnes int
AS
update Abonnement
set nom=@nom,description=@description,duree=@duree,prix=@prix,nombremaxarbres=@nombremaxarbres,nombremaxpersonnes=@nombremaxpersonnes
where id=@id
;
go
drop procedure Abonnement_eff
go
create procedure Abonnement_eff
@id int
AS
delete Abonnement 
where id=@id
;
go
drop procedure Abonnement_act
go
create procedure Abonnement_act
@id int
AS
update Abonnement set actif = 1
where id=@id
;
go
drop procedure Abonnement_desact
go
create procedure Abonnement_desact
@id int
AS
update Abonnement set actif = 0
where id=@id
;
go
/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnes from Abonnement
*/
/*
private const string CONST_ABONNEMENT_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnes from Abonnement";
*/
/***txable***Arbre*/
go	
drop procedure Arbre_cre
go
create PROCEDURE Arbre_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000), @idcreateur int, @datecreation datetime2
AS
insert into Arbre (nom,description,idcreateur,datecreation) values (@nom,@description,@idcreateur,@datecreation);
set @id = @@IDENTITY;
go
drop procedure Arbre_mod
go
create PROCEDURE Arbre_mod
@id int,@nom nvarchar(100),@description nvarchar(2000)
AS
update Arbre
set nom=@nom,description=@description
where id=@id
;
go
drop procedure Arbre_eff
go
create procedure Arbre_eff
@id int
AS
delete Arbre 
where id=@id
;
go


drop procedure arbre_debloquer
go
create procedure arbre_debloquer @id int
as
update Arbre set idblocage=null, dateblocage=null, idbloqueur=null where id = @id;
go
drop procedure arbre_bloquer
go
create procedure arbre_bloquer @id int, @idblocage int, @dateblocage datetime2, @idbloqueur int
as
update Arbre set idblocage=@idblocage, dateblocage=@dateblocage, idbloqueur = @idbloqueur where id = @id
go

/*
private const string CONST_ARBRE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocage from Arbre";
*/
/***txable***Blocage*/
go	
drop procedure Blocage_cre
go
create PROCEDURE Blocage_cre
 @id int out, @nom nvarchar(100), @description nvarchar(100)
AS
insert into Blocage (nom,description) values (@nom,@description);
set @id = @@IDENTITY;
go
drop procedure Blocage_mod
go
create PROCEDURE Blocage_mod
@id int,@nom nvarchar(100),@description nvarchar(100)
AS
update Blocage
set nom=@nom,description=@description
where id=@id
;
go
drop procedure Blocage_eff
go
create procedure Blocage_eff
@id int
AS
delete Blocage 
where id=@id
;
go
drop procedure Blocage_act
go
create procedure Blocage_act
@id int
AS
update Blocage set actif = 1
where id=@id
;
go
drop procedure Blocage_desact
go
create procedure Blocage_desact
@id int
AS
update Blocage set actif = 0
where id=@id
;
go
/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,description from Blocage
*/
/*
private const string CONST_BLOCAGE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,description from Blocage";
*/
/***txable***Conversation*/
go	
drop procedure Conversation_cre
go
create PROCEDURE Conversation_cre
 @id int out, @sujet nvarchar(50), @texte nvarchar(max), @idemetteur int
AS
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
insert into Conversation (date, sujet, texte, idemetteur) values (@aujourdhui, @sujet, @texte, @idemetteur);
set @id = @@IDENTITY;
go
--drop procedure Conversation_mod
go
/*create PROCEDURE Conversation_mod
@id int,@date datetime2
AS
update Conversation
set date=@date
where id=@id
;
*/
go
drop procedure conversation_effacee
go
create procedure conversation_effacee @id int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update Conversation set dateeffacement = @aujourdhui where id = @id
go
go
--drop procedure Conversation_eff
go
/*create procedure Conversation_eff
@id int
AS
delete Conversation 
where id=@id
*/
go
/*
private const string CONST_CONVERSATION_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,date from Conversation";
*/
/***txable***Couple*/
go	
drop procedure Couple_cre
go
create PROCEDURE Couple_cre
 @idpersonne int , @idpartenaire int, @datedebut datetime2, @datefin datetime2
AS
insert into Couple (idpersonne,idpartenaire,datedebut,datefin) values (@idpersonne,@idpartenaire,@datedebut,@datefin);

go
drop procedure Couple_mod
go
create PROCEDURE Couple_mod
@idpersonne int,@idpartenaire int,@datedebut datetime2,@datefin datetime2
AS
update Couple
set datedebut=@datedebut,datefin=@datefin
where idpersonne=@idpersonne
;
go
drop procedure Couple_eff
go
create procedure Couple_eff
@idpersonne int,
@idpartenaire int
AS
delete Couple 
where idpersonne=@idpersonne and idpartenaire = @idpartenaire
;
go
/*
private const string CONST_COUPLE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefin from Couple";
*/
/***txable***Message*/
go	
drop procedure Message_cre
go
create PROCEDURE Message_cre
 @id int out, @sujet nvarchar(100), @texte nvarchar(MAX), @idemetteur int, @idconversation int
AS
insert into Message (sujet,texte,idemetteur,idconversation) values (@sujet,@texte,@idemetteur,@idconversation);
set @id = @@IDENTITY;
go
drop procedure Message_mod
go
create PROCEDURE Message_mod
@id int,@sujet nvarchar(100),@texte nvarchar(MAX),@idemetteur int,@idconversation int
AS
update Message
set sujet=@sujet,texte=@texte,idemetteur=@idemetteur,idconversation=@idconversation
where id=@id
;
go
drop procedure Message_eff
go
create procedure Message_eff
@id int
AS
delete Message 
where id=@id
;
go
/*
private const string CONST_MESSAGE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversation from Message";
*/
/***txable***MessageForum*/
go	
drop procedure MessageForum_cre
go
create PROCEDURE MessageForum_cre
 @id int out, @sujet nvarchar(100), @texte nvarchar(MAX), @idtheme int, @idpublicateur int, @datepublication datetime2
AS
insert into MessageForum (sujet,texte,idtheme,idpublicateur,datepublication) values (@sujet,@texte,@idtheme,@idpublicateur,@datepublication);
set @id = @@IDENTITY;
go
drop procedure MessageForum_mod
go
create PROCEDURE MessageForum_mod
@id int,@sujet nvarchar(100),@texte nvarchar(MAX),@idtheme int,@idpublicateur int,@datepublication datetime2
AS
update MessageForum
set sujet=@sujet,texte=@texte,idtheme=@idtheme,idpublicateur=@idpublicateur,datepublication=@datepublication
where id=@id
;
go
drop procedure MessageForum_eff
go
create procedure MessageForum_eff
@id int
AS
delete MessageForum 
where id=@id
;
go
drop procedure MessageForum_act
go
create procedure MessageForum_act
@id int
AS
update MessageForum set actif = 1
where id=@id
;
go
drop procedure MessageForum_desact
go
create procedure MessageForum_desact
@id int
AS
update MessageForum set actif = 0
where id=@id
;
go
/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublication from MessageForum
*/
/*
private const string CONST_MESSAGEFORUM_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublication from MessageForum";
*/
/***txable***Nouvelle*/
/***txable***Nouvelle*/
go	
drop procedure Nouvelle_cre
go
create PROCEDURE Nouvelle_cre
 @id int out, @titre nvarchar(100), @description nvarchar(2000), @idcreateur int, @datecreation datetime2
AS
insert into Nouvelle (titre,description,idcreateur,datecreation) values (@titre,@description,@idcreateur,@datecreation);
set @id = @@IDENTITY;
go
drop procedure Nouvelle_mod
go
create PROCEDURE Nouvelle_mod
@id int,@titre nvarchar(100),@description nvarchar(2000),@idcreateur int,@datecreation datetime2
AS
update Nouvelle
set titre=@titre,description=@description,idcreateur=@idcreateur,datecreation=@datecreation
where id=@id
;
go
drop procedure Nouvelle_eff
go
create procedure Nouvelle_eff
@id int
AS
delete Nouvelle 
where id=@id
;
go
drop procedure Nouvelle_act
go
create procedure Nouvelle_act
@id int
AS
update Nouvelle set actif = 1
where id=@id
;
go
drop procedure Nouvelle_desact
go
create procedure Nouvelle_desact
@id int
AS
update Nouvelle set actif = 0
where id=@id
;
go
/*
select id,titre,description,idcreateur,datecreation from Nouvelle
*/
/*
private const string CONST_NOUVELLE_REQ = "select id,titre,description,idcreateur,datecreation from Nouvelle";
*/



/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,description from Nouvelle
*/
/*
private const string CONST_NOUVELLE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,description from Nouvelle";
*/
/***txable***Personne*/
go	
drop procedure Personne_cre
go
create PROCEDURE Personne_cre
 @id int out, @nom nvarchar(100), @prenom nvarchar(100), @datedenaissance datetime2, 
 @datededeces datetime2, @homme int, @idarbre int, @dateajout datetime2
AS
insert into Personne (nom,prenom,datedenaissance,datededeces,homme,idarbre,dateajout) 
values (@nom,@prenom,@datedenaissance,@datededeces,@homme,@idarbre,@dateajout);
set @id = @@IDENTITY;
go
drop procedure Personne_mod
go
create PROCEDURE Personne_mod
@id int,@nom nvarchar(100),@prenom nvarchar(100),@datedenaissance datetime2,@datededeces datetime2,@homme int,@idarbre int,@dateajout datetime2
AS
update Personne
set nom=@nom,prenom=@prenom,datedenaissance=@datedenaissance,datededeces=@datededeces,homme=@homme,idarbre=@idarbre,dateajout=@dateajout
where id=@id
;
go
drop procedure Personne_eff
go
create procedure Personne_eff
@id int
AS

update personne set idpere = null where idpere = @id;
update personne set idmere = null where idmere = @id;


delete Personne 
where id=@id
;
go
drop procedure pere_eff 
go
create procedure pere_eff @id int
as
begin
update Personne set idpere=null where id=@id
end
go
drop procedure mere_eff 
go
create procedure mere_eff @id int
as
begin
update Personne set idmere=null where id=@id
end
go
drop procedure Enfant_cre
go
create procedure Enfant_cre
@id int, @idenfant int
as
begin
declare @h int
set @h = (select homme from Personne where id=@id)
if @h=1
	update Personne set idpere = @id where id = @idenfant
else
	update Personne set idmere = @id where id = @idenfant
end
go
drop procedure Enfant_eff
go
create procedure Enfant_eff @id int, @idenfant int
as
begin
declare @h int
set @h = (select homme from Personne where id=@id)
if @h = 1
	update Personne set idpere = null where id = @idenfant;
else
	update Personne set idmere = null where id = @idenfant;
end
go
/*
private const string CONST_PERSONNE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,descriptionid,nom,prenom,datedenaissance,datededeces,idarbre,dateajout,idpere,idmere from Personne";
*/
/***txable***Role*/
go	
drop procedure Role_cre
go
create PROCEDURE Role_cre
 @id int out, @nom nvarchar(100), @description nvarchar(2000)
AS
insert into Role (nom,description) values (@nom,@description);
set @id = @@IDENTITY;
go
drop procedure Role_mod
go
create PROCEDURE Role_mod
@id int,@nom nvarchar(100),@description nvarchar(2000)
AS
update Role
set nom=@nom,description=@description
where id=@id
;
go
drop procedure Role_eff
go
create procedure Role_eff
@id int
AS
delete Role 
where id=@id
;
go
drop procedure Role_act
go
create procedure Role_act
@id int
AS
update Role set actif = 1
where id=@id
;
go
drop procedure Role_desact
go
create procedure Role_desact
@id int
AS
update Role set actif = 0
where id=@id
;
go
/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,descriptionid,nom,prenom,datedenaissance,datededeces,idarbre,dateajout,idpere,idmereid,nom,description from Role
*/
/*
private const string CONST_ROLE_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,descriptionid,nom,prenom,datedenaissance,datededeces,idarbre,dateajout,idpere,idmereid,nom,description from Role";
*/
/***txable***Theme*/
go	
drop procedure Theme_cre
go
create PROCEDURE Theme_cre
 @id int out, @titre nvarchar(100), @description nvarchar(2000)
AS
insert into Theme (titre,description) values (@titre,@description);
set @id = @@IDENTITY;
go
drop procedure Theme_mod
go
create PROCEDURE Theme_mod
@id int,@titre nvarchar(100),@description nvarchar(2000)
AS
update Theme
set titre=@titre,description=@description
where id=@id
;
go
drop procedure Theme_eff
go
create procedure Theme_eff
@id int
AS
delete Theme 
where id=@id
;
go
drop procedure Theme_act
go
create procedure Theme_act
@id int
AS
update Theme set actif = 1
where id=@id
;
go
drop procedure Theme_desact
go
create procedure Theme_desact
@id int
AS
update Theme set actif = 0
where id=@id
;
go
/*
select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,descriptionid,nom,prenom,datedenaissance,datededeces,idarbre,dateajout,idpere,idmereid,nom,descriptionid,titre,description from Theme
*/
/*
private const string CONST_THEME_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnesid,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocageid,nom,descriptionid,dateidpersonne,idpartenaire,datedebut,datefinid,sujet,texte,idemetteur,idconversationid,sujet,texte,idtheme,idpublicateur,datepublicationid,titre,descriptionid,nom,prenom,datedenaissance,datededeces,idarbre,dateajout,idpere,idmereid,nom,descriptionid,titre,description from Theme";
*/

/***txable***messagedestination*/
go	
drop procedure messagedestination_cre
go
create PROCEDURE messagedestination_cre
 @idconversation int, @iddestinataire int
AS
insert into messagedestination (idconversation, iddestinataire) values (@idconversation,@iddestinataire);

go

drop procedure messagedestination_lu
go
create procedure messagedestination_lu @idconversation int, @iddestinataire int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update messagedestination set datelecture=@aujourdhui
where idconversation=@idconversation and iddestinataire=@iddestinataire and datelecture is null

go
drop procedure messagedestination_efface
go
create procedure messagedestination_efface @idconversation int, @iddestinataire int
as
declare @aujourdhui datetime2
set @aujourdhui = (select GETDATE())
update messagedestination set dateeffacement=@aujourdhui 
where idconversation=@idconversation and iddestinataire=@iddestinataire
and dateeffacement is null

go
/*drop procedure messagedestination_mod
go
create PROCEDURE messagedestination_mod
@idconversation int,@iddestinataire int,@datelecture datetime2,@dateeffacement datetime2
AS
update messagedestination
set iddestinataire=@iddestinataire,datelecture=@datelecture,dateeffacement=@dateeffacement
where idconversation=@idconversation
;
*/
go
/*drop procedure messagedestination_eff
go
create procedure messagedestination_eff
@idconversation int
AS
delete messagedestination 
where idconversation=@idconversation
;
*/
go
/*
private const string CONST_MESSAGEDESTINATION_REQ = "select idconversation,iddestinataire,datelecture,dateeffacement from messagedestination";
*/
/***************************/
/*VUES*/
go
drop view VMessageRecu
go
create view VMessageRecu
AS
select 
c.id, c.date, c.sujet, c.texte, idemetteur, md.iddestinataire, 
md.datelecture, md.dateeffacement 
from conversation c
join messagedestination md on md.idconversation = c.id
go


drop view VPersonne
go
create view VPersonne
as
select p.*, a.idcreateur, a.idblocage, u.actif utilisateuractif
from personne p 
join arbre a on a.id = p.idarbre 
join utilisateur u on u.id = a.idcreateur
where a.dateblocage is null
go


/************SETUP******/
declare @id int
declare @iid int
exec role_cre @iid out, 'Administrateur','Voici un bel administrateur blond'
exec role_cre @iid out, 'Editeur de nouvelles','Pas de fake news svp'
exec role_cre @iid out, 'Maître du forum','Surveillant général'
exec Role_cre @iid out, 'Maître de messagerie', 'Surveillant général aussi'

exec Blocage_cre @iid out, 'Fake news', 'fake news interdites'
exec Blocage_cre @iid out, 'Supporter du Standard','je n''accepte que du mauve'


exec Abonnement_cre @iid out, 'Platinium', 'Tout, à vie!', 0, 999.9, 0,0
exec Abonnement_cre @iid out, 'Premium', 'un certain temps', 365, 400, 0,0
exec Abonnement_cre @iid out, 'Light', 'léger, peu de temps',365, 250, 5, 500


exec utilisateur_cre @id out, 'admin','admin',null,'adm@i.n',null,1,null,'1','presel','postsel', '1'
exec utilisateur_mod @id, 'admin',null,'adm@i.n',null,1,null,'1,3'


declare @dd datetime2
set @dd = (select GETDATE())
exec Nouvelle_cre @id out, 'C''est parti!', 'Super promotion à l''occasion de l''ouverture du site. Pour chaque abonnement platinium souscrit, nous vous dirons merci.', 1, @dd

set @dd = (select GETDATE())
exec utilisateur_cre @id out, 'sabrina','Salerno','Sabrina','sabrina@boysboys.boys',null,2,null,'1','presel','postsel', null
exec Arbre_cre @id out, 'mon premier arbre', 'Essayons', 2, @dd
set @dd = (select GETDATE())
exec Arbre_cre @id out, 'mon deuxième arbre', 'xxxEssayons', 2, @dd
--exec Arbre_bloquer 2,1,@dd
exec arbre_bloquer 2, 1, @dd, 1
declare @idarbre int
set @idarbre = 2
/*1*/exec Personne_cre @id out, 'de Belgique', 'Albert', null,null, 1, 2, @dd
/*2*/exec Personne_cre @id out, 'Rufio di Calabre', 'Paola', null,null, 2, 2, @dd

exec Couple_cre 1, 2, @dd, null
exec Couple_cre 2, 1, @dd,null
/*3*/exec Personne_cre @id out, 'de Belgique', 'Philippe', null,null,1,2, @dd
/*4*/exec Personne_cre @id out, 'd''Udekem d''Acoz', 'Mathilde', null,null,0,2, @dd
/*5*/exec Personne_cre @id out, 'de Belgique', 'Elisabeth', null,null,0,2, @dd
exec Enfant_cre 3,5
exec enfant_cre 4,5 

/*6*/exec Personne_cre @id out, 'Paquet', 'François', null, null, 1, 1, @dd
/*7*/exec Personne_cre @id out, 'Jooris', 'Nicole', null, null, 0, 1, @dd
/*8*/exec Personne_cre @id out, 'Paquet','Olivier',null,null,1,1,@dd
exec enfant_cre 6,8
exec enfant_cre 7,8
/*9*/exec Personne_cre @id out, 'Paquet','Florian',null,null,1,1,@dd
/*10*/exec Personne_cre @id out, 'Paquet','Nicolas',null,null,1,1,@dd
exec enfant_cre 8,9
exec enfant_cre 8,10
/*11*/exec Personne_cre @id out, 'Dendoncker','Catherine',null,null,0,1,@dd
exec enfant_cre 11,9
exec enfant_cre 11,10


exec Conversation_cre @id out, 'premier message', 'Salut Sabrina!', 1
exec messagedestination_cre @id, 2

exec utilisateurapi_cre @id out, 'ASP', 'boys boys boys, I''m looking for a good time', '-'

select id,date,sujet,texte,idemetteur,dateeffacement from Conversation where idemetteur = 1




/*@id int,@nom nvarchar(100),@prenom nvarchar(100),
@email nvarchar(400),@datedenaissance datetime2,@homme int, @cartedepayement nvarchar(50),
@roles nvarchar(max) */
--exec utilisateurrole_cre @id, @iid
select * from role
select * from utilisateur
select * from utilisateurrole

/*****ENDCRUD*/


select * from nouvelle
select * from couple
select * from personne
select * from arbre
select * from abonnement
select * from conversation
select * from vmessagerecu
select * from messagedestination
select * from utilisateurapi

select  motdepasse, dbo.ConstruireHMotdepasse('boys boys boys, I''m looking for a good time', presel,postsel) from utilisateurapi
select login, motdepasse,dbo.ConstruireHMotdepasse('1',presel,postsel) from utilisateur


