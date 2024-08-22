using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public  Employee Employee { get; set; } = null!;
        [ForeignKey("TeamId")]
        public  Team Team { get; set; } = null!;
    }
}
