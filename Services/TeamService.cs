using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly LMSDbContext _teamcontext;

        public TeamService(ITeamRepository teamRepository,LMSDbContext teamcontext)
        {
            _teamRepository = teamRepository;
            _teamcontext = teamcontext;
        }
        public async Task<Team> CreateTeam(Team team)
        {
            return await _teamRepository.CreateTeam(team);
        }

        public async Task<string> DeleteTeam(int id)
        {
            var res = await _teamRepository.DeleteTeam(id);
            return res;
        }

        public async Task<Team?> GetTeamByID(int id)
        {
            var res = await _teamRepository.GetTeamByID(id);
            return res;
        }

        public async Task<List<Team>> GetTeams()
        {
            var res = await _teamRepository.GetTeams();
            return res;
        }



        public async Task<Team> UpdateTeam(Team teamRequest)
        {
            var res = await _teamRepository.UpdateTeam(teamRequest);
            return res;
        }
        public async Task AddEmployeeToTeamAsync(int teamId, int employeeId)
        {
            var team = await _teamcontext.Teams.FindAsync(teamId);
            var employee = await _teamcontext.employees.FindAsync(employeeId);

            if (team != null && employee != null)
            {
                var teamMember = new TeamMember { TeamId = teamId, EmployeeId = employeeId };
                _teamcontext.TeamMembers.Add(teamMember);
                await _teamcontext.SaveChangesAsync();
            }
        }

        public async Task RemoveEmployeeFromTeamAsync(int teamId, int employeeId)
        {
            var teamMember = await _teamcontext.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == teamId && tm.EmployeeId == employeeId);

            if (teamMember != null)
            {
                _teamcontext.TeamMembers.Remove(teamMember);
                await _teamcontext.SaveChangesAsync();
            }
        }
    }
}

