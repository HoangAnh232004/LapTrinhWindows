Create Database QuanLySinhVien
Use QuanLySinhVien
CREATE TABLE Faculty (
    FacultyID INT NOT NULL PRIMARY KEY,
	
    FacultyName NVARCHAR(200) NOT NULL
);

CREATE TABLE Student (
    StudentID NVARCHAR(20) NOT NULL PRIMARY KEY,
    FullName NVARCHAR(200) NOT NULL,
    AverageScore FLOAT NOT NULL,
    FacultyID INT NOT NULL,
    FOREIGN KEY (FacultyID) REFERENCES Faculty(FacultyID)
);

INSERT INTO Faculty (FacultyID, FacultyName)
VALUES 
(1, N'Computer Science'),
(2, N'Mathematics'),
(3, N'Physics'),
(4, N'Literature');


INSERT INTO Student (StudentID, FullName, AverageScore, FacultyID)
VALUES 
(N'S001', N'Nguyen Van A', 8.5, 1),
(N'S002', N'Tran Thi B', 7.8, 2),
(N'S003', N'Le Van C', 9.2, 1),
(N'S004', N'Pham Thi D', 6.5, 3),
(N'S005', N'Doan Van E', 8.0, 4);


ALTER TABLE Faculty
ADD TongSoGS INT DEFAULT 0;
