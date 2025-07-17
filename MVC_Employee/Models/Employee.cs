using System.ComponentModel.DataAnnotations;

namespace MVC_Employee.Models
{
    public class EmployeeModel
    {
        //[Required(ErrorMessage = "Employee Code is required.")]
        //[Range(1, int.MaxValue, ErrorMessage = "Employee Code must be a positive number.")]
        public int empId { get; set; }

        //[Required(ErrorMessage = "Employee Name is required.")]
        //[StringLength(100, ErrorMessage = "Employee Name cannot exceed 100 characters.")]
        public string empName { get; set; }

        //[Required(ErrorMessage = "Designation is required.")]
        //[StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters.")]
        public string designation { get; set; }

        //[Required(ErrorMessage = "Department is required.")]
        //[StringLength(50, ErrorMessage = "Department cannot exceed 50 characters.")]
        public string department { get; set; }
    }
}
