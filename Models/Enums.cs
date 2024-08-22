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
            AnnualLeave = 3,
            SickLeave = 4,
            NoPayLeave = 5,
            SpecialLeave = 6,
            HalfDayLeave = 7,
            ShortLeave = 8
        }
    }
}
