using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem_Backend.Models
{
    public class AllocatedSetup
    {
        [Key]
        public int Id {  get; set; }

        public int Start {  get; set; }

        public int End {  get; set; }
        public int CasualLeave {  get; set; }

        public int AnnualLeave { get; set; }

        public int SickLeave { get; set; }

        public int NopayLeave { get; set; } = 100;


    }
}
