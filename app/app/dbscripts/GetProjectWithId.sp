CREATE PROCEDURE [dbo].[GetProjectWithId] 
(
	--Input Parameter
	@Id nvarchar(10),
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  		
		SELECT Id, Subject, Description, Status, SourceRespository, ReleasedVersion, UpdatedTimeStamp, StartTime, EndTime
		FROM dbo.Project WHERE Id = @Id
		SET @Result = 1
		SELECT @Result AS Result
	END TRY

	BEGIN CATCH
		SET @Result = 0
		SELECT @Result AS Result
	END CATCH
END