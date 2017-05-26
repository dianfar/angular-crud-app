-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[UpdateSupplier]
	-- Add the parameters for the stored procedure here
	@supplierId INT,
	@name nvarchar(50),
	@address nvarchar(max),
	@contactName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Supplier SET name=@name, address=@address, contactName=@contactName WHERE supplierId = @supplierId
END
