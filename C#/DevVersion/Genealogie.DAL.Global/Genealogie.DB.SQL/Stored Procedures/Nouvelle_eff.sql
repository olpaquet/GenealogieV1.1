create procedure Nouvelle_eff
@id int
AS
delete Nouvelle 
where id=@id
;
