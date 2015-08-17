-- dbo.Constants Table
DROP TABLE Constants

CREATE TABLE Constants
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
Group nvarchar(10),
Enabled bit not null
)

CREATE NONCLUSTERED INDEX IX_Project_Status 
    ON dbo.Constants (Enabled); 
GO

INSERT INTO Constants (Name, Enabled) VALUES('open','Status',1)
INSERT INTO Constants (Name, Enabled) VALUES('closed', 'Status',1)
INSERT INTO Constants (Name, Enabled) VALUES('resolved','Status',1)
INSERT INTO Constants (Name, Enabled) VALUES('won''t fix', 'Status',1)

select * from Constants
GO


