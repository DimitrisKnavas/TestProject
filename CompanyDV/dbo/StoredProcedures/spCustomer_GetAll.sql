CREATE PROCEDURE [dbo].[spCustomer_GetAll]
AS
BEGIN
    SET NOCOUNT ON;
	SELECT Id , FirstName, LastName, PhoneNumber, HomeAddress, Email
	FROM [dbo].[Customer]
END
