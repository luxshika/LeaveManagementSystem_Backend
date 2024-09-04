using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public List<TeamMember> TeamMembers { get; } = new List<TeamMember>();
       

        [Required(ErrorMessage = "EmployeeNumber is required")]
        public required string EmployeeNumber { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public required string Email { get; set; }
        //public int Status { get; set; }

        [Required(ErrorMessage = "NIC number is required")]
        public string? NicNo { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime? Dob { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }

        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position? Position { get; set; }
 
        public string? TelephoneNumber { get; set; }
        public string? MobileNumber { get; set; }
        public string? PermanentAddress { get; set; }
        public string? CurrentAddress { get; set; }
        public string? EmergencyContactName { get; set; }

        [Required(ErrorMessage = "Emergency Contact Number is required")]
        public string? EmergencyContactNumber { get; set; }
        public string? EmergencyContactRelationship { get; set; }

     
        public string? BankName { get; set; }

        
        public string? AccountNo { get; set; }
        public string? AccountHolder { get; set; }
        public string? Branch { get; set; }
        public string? TypeOfAccount { get; set; }
        public string? Profile { get; set; }

        public DateTime? JoinDate { get; set; }
        public DateTime? ConfirmDate { get; set; }

        public bool isActive { get; set; } = true;
       
    }
}
