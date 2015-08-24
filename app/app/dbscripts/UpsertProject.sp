-- Upsert Project SP
CREATE PROCEDURE [dbo].[UpsertProject] 
(
	@Id int,
	@Subject nvarchar(255),
	@Description nvarchar(1000),
	@Status int,
	@SourceRespository nvarchar(255),
	@ReleasedVersion nvarchar(255),
	@UpdatedTimeStamp datetime2,
	@StartTime datetime2,
	@EndTime datetime2,
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  
		BEGIN TRAN   
			MERGE dbo.Project AS T
			USING(SELECT 1 S) S
			ON T.Id = @Id
			WHEN MATCHED THEN UPDATE SET 
				Subject = @Subject,
				Description = @Description,
				Status = @Status,
				SourceRespository = @SourceRespository,
				ReleasedVersion = @ReleasedVersion,
				UpdatedTimeStamp = @UpdatedTimeStamp,
				StartTime = @StartTime,
				EndTime = @EndTime
			WHEN NOT MATCHED THEN
				INSERT (Subject, Description, Status, SourceRespository, ReleasedVersion, UpdatedTimeStamp, StartTime, EndTime)
				VALUES (@Subject, @Description, @Status, @SourceRespository, @ReleasedVersion, @UpdatedTimeStamp, @StartTime, @EndTime)
		COMMIT TRAN;     
		SET @Result = 1
	END TRY

	BEGIN CATCH
		SET @Result = 0
	END CATCH

	SELECT @Result as Result
END