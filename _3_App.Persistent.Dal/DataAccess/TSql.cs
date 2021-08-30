namespace _3_1_App.Persistent.Dal.DataAccess
{
    public static class TSql
    {
        //###########################   EMPLOYEE  #########################
        //###########################   EMPLOYEE  #########################
        public static string GET_ALL_EMPLOYEES_AND_ALL_DEPENDENCIES(decimal id = 0)
        {
            var query = @"
            SELECT distinct e.Id as EmployeeId ,e.Name as EmployeeName, e.Email as EmployeeEmail,e.CreatedAt as EmployeeCreatedAt
            ,d.Id as DepartmentId, d.Name as DepartmentName,d.Description as DepartmentDescription ,d.CreatedAt as DepartmentCreatedAt
            ,t.Id as TaskId ,t.Name as TaskName, t.Description as TaskDescription , t.Status as TaskStatus ,t.CreatedAt as TaskDescription
            FROM Employees e
            JOIN Departments d ON e.DepartmentId=d.Id
            LEFT JOIN Duties t on e.Id=t.EmployeeId
            WHERE 1=1";
            if (id > 0)
                query += $" AND e.Id =@Id order by e.Id ";
            return query;
        }

        public static string GET_ALL_EMPLOYEE => @"SELECT * From dbo.Employees ";

        //GET_EMPLOYEE_AND_ALL_DEPENDENCIES_BY_ID
        public static string GET_EMPLOYEE_BY_ID => @"SELECT * From dbo.Employees e Where e.Id=@Id";
        public static string ADD_NEW_EMPLOYEE =>
        @"INSERT INTO dbo.Employees( Name , Email ,DepartmentId ,CreatedAt) 
        Values(@Name ,@Email, @DepartmentId ,@CreatedAt);
        SELECT e.Id , e.Name , e.Email ,e.DepartmentId ,e.CreatedAt From dbo.Employees e Where e.Id=CAST(SCOPE_IDENTITY() as decimal(18,0))";
        public static string UPDATE_EMPLOYEE =>
        @"UPDATE dbo.Employees SET Name=@Name , Email=@Email ,DepartmentId=@DepartmentId ,CreatedAt=@CreatedAt Where Id=@Id ; 
        SELECT e.Id , e.Name , e.Email ,e.DepartmentId ,e.CreatedAt From dbo.Employees e Where e.Id=@Id ;
        ";
        public static string DELETE_EMPLOYEE => @"DELETE FROM dbo.Employees Where Id=@Id ; SELECT @Id; ";
        public static string DELETE_EMPLOYEE_AND_DUTIES =>
            @"DELETE FROM dbo.Employees Where Id=@Id ; DELETE FROM dbo.Duties Where EmployeeId=@Id  SELECT @Id; ";

        public static string DELETE_EMPLOYEE_BY_DEPARTMENTID =>
        @"DELETE dbo.Employees Where DepartmentId=@Id ; SELECT @Id; ";

        //##########################  DEPARTMENT  #########################
        //##########################  DEPARTMENT  #########################

        public static string GET_ALL_DEPARTMENTS => @"SELECT * From dbo.Departments ";
        public static string GET_DEPARTMENT_BY_ID => @"SELECT * From dbo.Departments d Where d.Id=@Id";
        public static string ADD_NEW_DEPARTMENT =>
        @"INSERT INTO dbo.Departments(Name ,Description ,CreatedAt)
        Values(@Name ,@Description ,@CreatedAt);
        SELECT CAST(SCOPE_IDENTITY() as decimal(18,0))";

        public static string UPDATE_DEPARTMENT =>
        @"UPDATE dbo.Departments SET Name=@Name , Description=@Description ,CreatedAt=@CreatedAt Where Id=@Id ; SELECT @Id; ";
        public static string DELETE_DEPARTMENT => @"DELETE FROM dbo.Departments Where Id=@Id ; SELECT @Id; ";

        //this is for test trabsaction aspect
        public static string DELETE_DEPARTMENT_CASCADE_EMPLOYEES =>
            @"DELETE FROM dbo.Departments Where Id=@Id ; 
              DELETE dbo.Employees Where DepartmentId=@Id ; SELECT @Id;";


        //############################  DUTIES  ###########################
        //############################  DUTIES  ###########################
        public static string GET_ALL_DUTIES => @"SELECT * From dbo.Duties ";
        public static string GET_DUTY_BY_ID => @"SELECT * From dbo.Duties d Where d.Id=@Id";
        public static string ADD_NEW_DUTY =>
        @"INSERT INTO dbo.Duties (Name ,Description ,Status ,CreatedAt , EmployeeId)
        Values(@Name ,@Description ,@Status ,@CreatedAt , @EmployeeId);
        SELECT CAST(SCOPE_IDENTITY() as decimal(18,0))";

        public static string UPDATE_DUTY =>
        @"UPDATE dbo.Duties SET Name=@Name , Description=@Description , Status=@Status ,CreatedAt=@CreatedAt , EmployeeId=@EmployeeId
        Where Id=@Id ; SELECT @Id; ";
        public static string DELETE_DUTY => @"DELETE FROM dbo.Departments Where Id=@Id ; SELECT @Id; ";

        public static string DELETE_DUTY_BY_EMPLOYEEID =>
        @"DELETE dbo.Duties Where EmployeeId=@Id ; SELECT @Id; ";

    }
}
