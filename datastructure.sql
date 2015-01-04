CREATE TABLE Students
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Email varchar(255) NOT NULL,
Username varchar(255) NOT NULL,
Password varchar(255) NOT NULL,
)

CREATE TABLE Lecturers
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Name varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Email varchar(255) NOT NULL,
Username varchar(255) NOT NULL,
Password varchar(255) NOT NULL,
)

CREATE TABLE VisitorStatistics
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
UserSession varchar(255) NOT NULL,
IPAddress varchar(255) NOT NULL,
Country varchar(255) NOT NULL,
OperatingSystem varchar(255) NOT NULL,
Device varchar(255) NOT NULL,
BrowserName varchar(255) NOT NULL,
VisitTimeStamp varchar(255) NOT NULL,
)

CREATE TABLE Users
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Username varchar(255) NOT NULL,
Password varchar(255) NOT NULL,
Email varchar(255) NOT NULL,
Name varchar(255) NOT NULL,
Lastname varchar(255) NOT NULL,
LastLogin varchar(255) NULL,
UserRole varchar(255) NOT NULL,
)

CREATE TABLE PageHits
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
PageName varchar(255) NOT NULL,
Username varchar(255) NOT NULL,
Hit int NOT NULL,
LastVisitStamp varchar(255) NOT NULL,
)

CREATE TABLE Courses
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
CourseName varchar(255) NOT NULL,
CourseCredits int NOT NULL,
LecturerId int NOT NULL,
LecturerName varchar(255) NULL,
LecturerLastname varchar(255) NULL,
)

CREATE TABLE Search
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Keyword varchar(255) NOT NULL,
Hit int NOT NULL,
SearchTimeStamp varchar(255) NOT NULL,
)

CREATE TABLE StudentCourses
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Username varchar(255) NOT NULL,
CourseId int NOT NULL,
CourseName varchar(255) NULL,
CourseCredits int NULL,
LecturerId int NOT NULL,
LecturerName varchar(255) NULL,
LecturerLastname varchar(255) NULL,
)

CREATE TABLE StudentExam
(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
StudentName varchar(255) NULL,
Question varchar(255) NULL,
Answer varchar(255) NULL,
StudentAnswer varchar(255) NULL,
Correct varchar(255) NULL,
)
