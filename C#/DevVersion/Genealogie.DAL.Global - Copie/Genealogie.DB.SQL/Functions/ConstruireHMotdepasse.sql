
CREATE FUNCTION ConstruireHMotdepasse 
(@motdepasse nVARCHAR(50), @presel nVARCHAR(255), @postsel nvarchar(255))
RETURNS VARBINARY(64)
AS
BEGIN
    RETURN HASHBYTES('SHA2_512',CONCAT(@presel,@motdepasse,@postsel))
END



