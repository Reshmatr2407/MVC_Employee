using System.ComponentModel.DataAnnotations;

namespace MVC_Employee.DTOs
{
    public class EmployeePostReqDto
    {
        [Required(ErrorMessage = "Flag is required.")]
        [StringLength(10, ErrorMessage = "Flag cannot be longer than 10 characters.")]
        public string flag { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [StringLength(20, ErrorMessage = "Employee ID cannot be longer than 20 characters.")]
        public string empId { get; set; } // Change to string

        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(100, ErrorMessage = "Employee Name cannot be longer than 100 characters.")]
        public string empName { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [StringLength(50, ErrorMessage = "Designation cannot be longer than 50 characters.")]
        public string designation { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [StringLength(50, ErrorMessage = "Department cannot be longer than 50 characters.")]
        public string department { get; set; }
    }
}
