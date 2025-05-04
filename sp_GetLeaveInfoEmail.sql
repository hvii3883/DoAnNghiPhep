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
