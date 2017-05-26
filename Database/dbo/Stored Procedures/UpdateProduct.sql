-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateProduct 
	@productId INT,
	@name NVARCHAR(50),
	@quantity INT,
	@price MONEY,
	@supplierId INT,
	@categoryId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Product SET NAME = @name, QUANTITY = @quantity, PRICE = @price, SUPPLIERID = @supplierId, CATEGORYID = @categoryId, LASTUPDATEDDATE = GETDATE() WHERE ProductId = @productId 
END
