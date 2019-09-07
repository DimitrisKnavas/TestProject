CREATE PROCEDURE [dbo].[spCustomer_Update]
	@Id int,
	@FirstName NVARCHAR(250),
	@LastName NVARCHAR(250),
	@PhoneNumber VARCHAR(50),
	@HomeAddress NVARCHAR(250),
	@Email NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

	UPDATE dbo.Customer
	SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, HomeAddress = @HomeAddress, Email = @Email
	WHERE Id = @Id;
END
