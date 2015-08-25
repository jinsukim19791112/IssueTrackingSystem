CREATE TABLE Constants
(
Id int IDENTITY(1,1) PRIMARY KEY,
Name nvarchar(255),
Category nvarchar(10),
Enabled bit not null
)

CREATE NONCLUSTERED INDEX IX_Project_Status 
    ON dbo.Constants (Enabled); 
GO

INSERT INTO Constants (Name, Category, Enabled) VALUES('open','Status',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('closed', 'Status',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('resolved','Status',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('won''t fix', 'Status',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('in progress', 'Status',1)

INSERT INTO Constants (Name, Category, Enabled) VALUES('WEB','Dept',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('DB', 'Dept',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('Design','Dept',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('QA', 'Dept',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('PM', 'Dept',1)

INSERT INTO Constants (Name, Category, Enabled) VALUES('DEV','Role',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('PM', 'Role',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('QA','Role',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('BA', 'Role',1)
INSERT INTO Constants (Name, Category, Enabled) VALUES('Architect 'Role',1)

select * from Constants
GO
