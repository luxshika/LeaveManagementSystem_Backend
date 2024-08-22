﻿using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly LMSDbContext _teamcontext;
        public TeamRepository(LMSDbContext teamcontext)
        {
            _teamcontext = teamcontext;
        }

        public async Task<Team> CreateTeam(Team team)
        {
            try
            {
                var res = _teamcontext.Teams.Add(team);
                await _teamcontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> DeleteTeam(int id)
        {
            var team = await _teamcontext.Teams.Where(x => x.Teamid== id).FirstOrDefaultAsync();
            if (team == null)
            {
                return "Requested ID not available ";
            }
            _teamcontext.Teams.Remove(team);
            await _teamcontext.SaveChangesAsync();
            return " suceeded";


        }

        public Task<Team?> GetTeamByID(int id)
        {
            try
            {
                var res = _teamcontext.Teams.Where(x => x.Teamid == id).FirstOrDefault();

                return Task.FromResult(res);


            }
            catch (Exception)
            {

                throw;
            }

        }
        public Task<List<Team>> GetTeams()
        {
            try
            {
                var res = _teamcontext.Teams.ToListAsync();
                return res;

            }
            catch (Exception)
            {

                throw;
            }


        }
        public async Task<Team> UpdateTeam(Team teamRequest)
        {
            try
            {
                var res = _teamcontext.Teams.Update(teamRequest);
                await _teamcontext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {

                throw;
            }

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

