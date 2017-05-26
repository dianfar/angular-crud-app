-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProducts]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT P.ProductId, P.Name, P.Quantity, P.Price, S.Name AS SupplierName, C.CategoryName FROM dbo.Product P inner join dbo.Supplier S ON P.SupplierId = S.SupplierId inner join dbo.Category C ON C.CategoryId = P.CategoryId
END
