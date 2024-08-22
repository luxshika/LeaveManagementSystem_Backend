namespace LeaveManagementSystem_Backend.Models
{
    public class Team
    {
        public int Teamid {  get; set; }

        public required string TeamName { get; set; }



        public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}
