CREATE PROCEDURE [dbo].[GetConstants] 
(
	--Input Parameter
	@Category nvarchar(10),
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  		
		SELECT Id, Name
		FROM dbo.Constants WHERE Category = @Category
		SET @Result = 1
		SELECT @Result AS Result
	END TRY

	BEGIN CATCH
		SET @Result = 0
		SELECT @Result AS Result
	END CATCH
END