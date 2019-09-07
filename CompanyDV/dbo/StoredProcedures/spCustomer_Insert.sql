CREATE PROCEDURE [dbo].[spCustomer_Insert]
	@Id int,
	@FirstName NVARCHAR(250),
	@LastName NVARCHAR(250),
	@PhoneNumber VARCHAR(50),
	@HomeAddress NVARCHAR(250),
	@Email NVARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;

	INSERT INTO dbo.Customer(FirstName, LastName, PhoneNumber, HomeAddress, Email)
	VALUES (@FirstName, @LastName, @PhoneNumber, @HomeAddress, @Email)

	SELECT @Id = SCOPE_IDENTITY();
END
