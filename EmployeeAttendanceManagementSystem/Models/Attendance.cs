using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceManagementSystem.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required(ErrorMessage = "EmployeeId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeId must be a positive number.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Attendance Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Check-in time is required.")]
        [DataType(DataType.Time)]
        [Display(Name = "Check-In Time")]
        public TimeSpan CheckInTime { get; set; }

        [Required(ErrorMessage = "Check-out time is required.")]
        [DataType(DataType.Time)]
        [Display(Name = "Check-Out Time")]
       
        public TimeSpan CheckOutTime { get; set; }


    }
}
