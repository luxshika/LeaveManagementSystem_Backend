using LeaveManagementSystem_Backend.Models;

namespace LeaveManagementSystem_Backend.IRepository
{
    public interface ITeamRepository
    {
        Task<Team> CreateTeam(Team team);
        Task<List<Team>> GetTeams();
        Task<Team?> GetTeamByID(int id);
        Task<Team> UpdateTeam(Team teamRequest);
        Task<string> DeleteTeam(int id);
        Task AddEmployeeToTeamAsync(int teamId, int employeeId);
        Task RemoveEmployeeFromTeamAsync(int teamId, int employeeId);
    }
}
