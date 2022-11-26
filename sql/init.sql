CREATE TABLE Users (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Email varchar(100),
    Username varchar(100),
    Password varchar(100),
    FirstName varchar(100),
    LastName varchar(100),
    Role INT(1),
    CreatedAt TIMESTAMP,
    UpdatedAt TIMESTAMP
);