using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        public int? UserId { get; set; }
        public int LeaveTypeId { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType? LeaveType { get; set; }

        public string? LeaveFor { get; set; }
        public string? Session { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? LeaveDays { get; set; }
        public int LeaveStatus { get; set; } = 1;
        public string? LeaveReason { get; set; }
        public string? RejectReason { get; set; }
        public int? CoverPersonId { get; set; }

        [ForeignKey("CoverPersonId")]
        public virtual Employee? CoverPerson { get; set; }
        public int? CoverPersonStatus { get; set; }
        public int? Status { get; set; }
    }
}
