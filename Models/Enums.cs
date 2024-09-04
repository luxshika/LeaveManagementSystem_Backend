namespace LeaveManagementSystem_Backend.Models
{
    public class Enums
    {
        public enum LeaveStatus
        {  
            Applied = 1,
            Accepted = 2,
            Canceled = 3,
            Rejected = 4,
            InProgress = 5,
            Read = 6,
            UnRead = 7
        }
        public enum LeaveTypes
        {
            CasualLeave = 1,
            AnnualLeave = 2,
            SickLeave = 3,
            NoPayLeave = 4,
            SpecialLeave = 5,
            HalfDayLeave = 6,
            ShortLeave = 7
        }
    }
}
