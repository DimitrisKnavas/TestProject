CREATE PROCEDURE [dbo].[spCustomer_GetCustomer]
	@id int 
AS
BEGIN
    SET NOCOUNT ON;
	SELECT Id, FirstName, LastName, PhoneNumber, HomeAddress, Email
	FROM dbo.Customer
	WHERE Id = @id;
END
