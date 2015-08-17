-- dbo.Project Table
DROP TABLE Project

CREATE TABLE Project
(
Id int IDENTITY(1,1) PRIMARY KEY,
Subject nvarchar(255),
Description nvarchar(1000),
Status int,
SourceRespository nvarchar(255),
ReleasedVersion nvarchar(255),
UpdatedTimeStamp datetime2,
StartTime datetime2,
EndTime datetime2,
)
GO

CREATE NONCLUSTERED INDEX IX_Project_Status 
    ON dbo.Project (Status); 
GO

INSERT INTO PROJECT (Subject, Description, Status, SourceRespository, ReleasedVersion, StartTime, EndTime, UpdatedTimeStamp)
VALUES('CRM', 'CRM', 1, 'http://github.com/crm.git', '1.00', GETDATE(), GETDATE(), GETDATE())

select * from Project
GO


