CREATE PROCEDURE [dbo].[spCustomer_Delete]
	@Id int
AS
BEGIN
    SET NOCOUNT ON;
	DELETE FROM dbo.Customer WHERE Id = @Id;
END
