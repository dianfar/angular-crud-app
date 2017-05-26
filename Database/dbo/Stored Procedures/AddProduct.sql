-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddProduct] 
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
	INSERT INTO dbo.Product VALUES (@name, @quantity, @price, @supplierId, @categoryId, GETDATE())
END
