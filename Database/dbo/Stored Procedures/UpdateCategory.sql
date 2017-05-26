-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE UpdateCategory
	-- Add the parameters for the stored procedure here
	@CategoryId INT,
	@CategoryName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId
END
