CREATE DATABASE SchoolManagementDB
GO
USE SchoolManagementDB

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE
)

CREATE TABLE Lecturers (
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL
)

CREATE TABLE Courses (
    Id INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(50) NOT NULL,
    Code NVARCHAR(5) UNIQUE,
    Credits INT
)