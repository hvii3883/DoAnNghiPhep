create database HeThongNghiPhep
go
/****** Object:  Table [dbo].[Account]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NULL,
	[Role] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Employee]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Email] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[TotalLeaveDays] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LeaveRequest]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveRequest](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[EmpEmail] [nvarchar](100) NULL,
	[TypeID] [int] NULL,
	[FromDate] [date] NULL,
	[ToDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[LeaveType]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Email])
REFERENCES [dbo].[Account] ([Email])
GO
ALTER TABLE [dbo].[LeaveRequest]  WITH CHECK ADD FOREIGN KEY([EmpEmail])
REFERENCES [dbo].[Employee] ([Email])
GO
ALTER TABLE [dbo].[LeaveRequest]  WITH CHECK ADD FOREIGN KEY([TypeID])
REFERENCES [dbo].[LeaveType] ([TypeID])
GO

-- Them tai khoan Admin
INSERT INTO Account (Email, Password, Role) VALUES ('admin@example.com', '111', 1);

-- Them cac loai nghi phep
INSERT INTO LeaveType (TypeName) VALUES (N'Nghi om');
INSERT INTO LeaveType (TypeName) VALUES (N'Nghi phep');
INSERT INTO LeaveType (TypeName) VALUES (N'Nghi thai san');

UPDATE Account
SET Email = 'admin@gmail.com',
    Password = '111'
WHERE Email = 'admin@example.com';

ALTER TABLE LeaveRequest 
ADD Status INT DEFAULT 0;

ALTER TABLE LeaveRequest
ADD Reason NVARCHAR(MAX);

ALTER TABLE LeaveRequest
ADD ApprovedBy NVARCHAR(255),
    ApproveDate DATETIME NULL;

USE HeThongNghiPhep
GO

CREATE PROCEDURE Usp_GetLeaveInfoEmail
    @Email NVARCHAR(100)
AS
BEGIN
    SELECT 
        e.Email,
        e.FullName,
        e.TotalLeaveDays,
        ISNULL(SUM(DATEDIFF(DAY, r.FromDate, r.ToDate) + 1), 0) AS DaysTaken,
        e.TotalLeaveDays - ISNULL(SUM(DATEDIFF(DAY, r.FromDate, r.ToDate) + 1), 0) AS DaysRemaining
    FROM Employee e
    LEFT JOIN LeaveRequest r ON e.Email = r.EmpEmail AND r.Status = 1
    WHERE e.Email = @Email
    GROUP BY e.Email, e.FullName, e.TotalLeaveDays
END
