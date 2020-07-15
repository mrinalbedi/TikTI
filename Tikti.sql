create database TikTi

CREATE TABLE OrgRegistration(
    registrationID int not null identity primary key ,
    email nvarchar(max) not null,
    pwd nvarchar(max) not null,
    confirmPassword nvarchar(max) not null,
    contactFirstName nvarchar(30) not null,
    contactLastName nvarchar(30) not null,
    contactTitle nvarchar(30) not null,
    Department nvarchar(30) not null
);
