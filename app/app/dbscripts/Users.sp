-- dbo.Users Table
drop table dbo.Users
GO

CREATE TABLE dbo.Users
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
Password nvarchar(255),
Email nvarchar(255),
Mobile nvarchar(255),
Org nvarchar(255),
Dept nvarchar(255),
Status bit,
ImageUrl nvarchar(255),
UpdatedTimeStamp datetime2 
)
GO

CREATE NONCLUSTERED INDEX IX_Users_Status 
    ON dbo.Users (Status); 
GO

INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl, UpdatedTimeStamp) VALUES('Jinsu Kim', '12345', 'dhammi@hanmail.net', 1, '010-1111-1234', 'JIRA', 'DEV', '', GETDATE());
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl, UpdatedTimeStamp) VALUES('Jina Kim', '12345', 'jina@hanmail.net', 1, '010-1111-1234', 'JIRA', 'DEV', '', GETDATE());
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl, UpdatedTimeStamp) VALUES('Suhyen Kim', '12345', 'suhyen@hanmail.net', 1, '010-1111-1234', 'JIRA', 'DEV', '', GETDATE());
INSERT INTO Users (Name, Password, Email, Status, Mobile, Org, Dept, ImageUrl, UpdatedTimeStamp) VALUES('Jungeun Myoung', '12345', 'mje@hanmail.net', 1, '010-1111-1234', 'JIRA', 'DEV', '', GETDATE());
SELECT * FROM Users

GO