CREATE PROCEDURE sp_CreateDepartment
    @DeptNo int,
    @DeptName VARCHAR(100),
    @Location VARCHAR(100),
	@Capacity int 
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        INSERT INTO Department (DeptNo, DeptName, Location, Capacity)
        VALUES (@DeptNo, @DeptName, @Location, @Capacity);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
select * from Department;
EXEC sp_CreateDepartment 60, 'HR-Recruitment', 'Pune', 300;
 
 GO;

CREATE PROCEDURE sp_GetDepartments
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SELECT DeptNo, DeptName, Location, Capacity
        FROM Department;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
Exec sp_GetDepartments


 GO;
CREATE PROCEDURE sp_GetDepartmentById
    @DeptNo INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        SELECT DeptNo, DeptName, Location,Capacity
        FROM Department
        WHERE DeptNo = @DeptNo;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;

Exec sp_GetDepartmentById 10;
GO;
CREATE PROCEDURE sp_UpdateDepartment
    @DeptNo INT,
    @DeptName VARCHAR(100),
    @Location VARCHAR(100),
	@Capacity int
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        UPDATE Department
        SET DeptName = @DeptName,
            Location = @Location, 
			Capacity =@Capacity
        WHERE DeptNo = @DeptNo;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;

EXEC  sp_UpdateDepartment 60, 'HR-Recruitment', 'Pune', 360;
Select * from Department;

 GO;
CREATE PROCEDURE sp_DeleteDepartment
    @DeptNo INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        DELETE FROM Department
        WHERE DeptNo = @DeptNo;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;

Exec sp_DeleteDepartment 60;