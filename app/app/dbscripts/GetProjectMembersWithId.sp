CREATE PROCEDURE [dbo].[GetProjectMembersWithId] 
(
	--Input Parameter
	@ProjectId int,
	@Result int=0 OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;  
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;  
	SET LOCK_TIMEOUT 20000;  

	BEGIN TRY  		
		Select ProjectUser.ProjectId,  Users.Name, Users.Email, Users.Dept, Constants.Name as Role
		FROM Users
		INNER JOIN ProjectUser
		ON Users.Id = ProjectUser.UserId
		INNER JOIN Constants
		ON ProjectUser.RoleId = Constants.Id
		Where ProjectUser.ProjectId = @ProjectId
		SET @Result = 1
		SELECT @Result AS Result
	END TRY

	BEGIN CATCH
		SET @Result = 0
		SELECT @Result AS Result
	END CATCH
END