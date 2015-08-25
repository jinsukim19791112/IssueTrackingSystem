CREATE PROCEDURE [dbo].[GetUsers] 
(
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  		
		SELECT Id, Name, Email, Mobile, Org, Dept, Status, ImageUrl, UpdatedTimeStamp
		FROM dbo.Users WHERE Status = 1
		SET @Result = 1
		SELECT @Result AS Result
	END TRY

	BEGIN CATCH
		SET @Result = 0
		SELECT @Result AS Result
	END CATCH
END