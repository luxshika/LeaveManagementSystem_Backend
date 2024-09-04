using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class AllocatedLeave
    {
        [Key]
        public int LeaveId { get; set; }

        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType? LeaveType { get; set; }

        [Required(ErrorMessage = "allocated number is required")]
        public double allocated {  get; set; }

        public double taken {  get; set; }

    }
}
