using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class Holiday
    {
        public int Id { get; set; }

        //CompanyID
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }

        [Required(ErrorMessage = "HolidayTypeId is required")]
      
        public int HolidayTypeId { get; set; }

        [ForeignKey("HolidayTypeId")]
        public virtual HolidayType? HolidayType { get; set; }


        [Required(ErrorMessage = "HolidayDate is required")]
        public DateTime HolidayDate { get; set; }
        public string? Description { get; set; }

        public Guid CreatedUser { get; set; }
    }
}
