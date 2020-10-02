create procedure pere_eff @id int
as
begin
update Personne set idpere=null where id=@id
end
