namespace MVC_Employee.DTOs
{
    public class EmployeeReqDto
    {
        public string flag { get; set; }
        public string empId { get; set; } // Change to string

        public string empName { get; set; }

        public string designation { get; set; }
        public string department { get; set; }
    }
}
