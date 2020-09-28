create procedure test_cre @id int out, @i int
as
begin 
BEGIN TRY
    BEGIN TRANSACTION 
        -- Do your stuff that might fail here
		insert into test (i) values (@i)
		set @id = @@IDENTITY
    COMMIT
END TRY
BEGIN CATCH
    /*IF @@TRANCOUNT > 0*/
        ROLLBACK 
		raiserror('flute',1,1)
	

	

        
END CATCH
end

