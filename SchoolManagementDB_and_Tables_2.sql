use SchoolManagementDB

CREATE TABLE SchoolClasses (
    Id INT PRIMARY KEY IDENTITY,
    LectureId INT FOREIGN KEY REFERENCES Lecturers(Id),
    CourseId INT FOREIGN KEY REFERENCES Courses(Id),
    [Time] TIME
)

CREATE TABLE Enrollments (
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students(Id),
    ClassId INT FOREIGN KEY REFERENCES SchoolClasses(Id),
    Grade NVARCHAR(2)
)