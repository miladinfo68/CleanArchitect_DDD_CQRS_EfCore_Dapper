namespace _3_1_App.Persistent.Dal.Persistence.ServiceDataModels
{
    public class EmployeeAndDependenciesModel
    {
        public decimal EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeCreatedAt { get; set; }

        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public string DepartmentCreatedAt { get; set; }

        public decimal TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskCreatedAt { get; set; }
        public byte TaskStatus { get; set; }
    }
}
