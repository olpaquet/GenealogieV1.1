create procedure mere_eff @id int
as
begin
update Personne set idmere=null where id=@id
end
