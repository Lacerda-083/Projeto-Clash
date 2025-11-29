
CREATE DATABASE ClashDB;
GO


USE ClashDB;
GO


CREATE TABLE Jogadores (
    Id INT IDENTITY(1,1) PRIMARY KEY,  
    Nick VARCHAR(100) NOT NULL,          
    Trofeus INT NOT NULL                 
);
GO
