namespace LeaveManagementSystem_Backend.Models
{
    public class Company
    {
        public int CompanyId { get; set; } 


        public required string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; } 
        public required string PhoneNumber { get; set; } 
        public required string Email { get; set; } 
        public string? Website { get; set; }  
        public int NumberOfEmployees { get; set; } 
        public string Description { get; set; } 
       


    }
}
