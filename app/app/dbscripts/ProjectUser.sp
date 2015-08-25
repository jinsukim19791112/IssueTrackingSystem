-- dbo.Users Table
drop table dbo.ProjectUser
GO

CREATE TABLE dbo.ProjectUser
(
Id int IDENTITY(1,1) PRIMARY KEY,
ProjectId int,
UserId int,
RoleId int,
UpdatedTimeStamp datetime2 
)

INSERT INTO ProjectUser (ProjectId, UserId, RoleId, UpdatedTimeStamp) VALUES(1, 1, 1,  GETDATE());
INSERT INTO ProjectUser (ProjectId, UserId, RoleId, UpdatedTimeStamp) VALUES(1, 2, 1, GETDATE());
INSERT INTO ProjectUser (ProjectId, UserId, RoleId, UpdatedTimeStamp) VALUES(1, 3, 1, GETDATE());
INSERT INTO ProjectUser (ProjectId, UserId, RoleId, UpdatedTimeStamp) VALUES(1, 4, 1, GETDATE());

SELECT * FROM ProjectUser
GO