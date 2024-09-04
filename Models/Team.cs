using Azure;

namespace LeaveManagementSystem_Backend.Models
{
    public class Team
    {
        public int Teamid {  get; set; }

        public required string TeamName { get; set; }


        public List<TeamMember> TeamMembers { get; } = new List<TeamMember>();
        //public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}
