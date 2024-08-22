namespace LeaveManagementSystem_Backend.Models
{
    public class UpdateLeaveStatusDto
    {
        
            public int NewStatus { get; set; }
            public required string RejectReason { get; set; }  
    }
}
