-- Create Project SP
CREATE PROCEDURE [dbo].[CreateProject] 
(
	@Subject nvarchar(255),
	@Description nvarchar(1000),
	@Status int,
	@SourceRespository nvarchar(255),
	@ReleasedVersion nvarchar(255),
	@UpdatedTimeStamp datetime2,
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		BEGIN TRAN   
			INSERT INTO dbo.Project (Subject, Description, Status, SourceRespository, ReleasedVersion, UpdatedTimeStamp)
			VALUES(@Subject, @Description, @Status, @SourceRespository, @ReleasedVersion, @UpdatedTimeStamp)
		COMMIT TRAN;     
		SET @Result = 1
	END TRY

	BEGIN CATCH
		SET @Result = 0
	END CATCH

	SELECT @Result as Result
END