﻿using LeaveManagementSystem_Backend.Controllers;
using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Services
{
    public class AllocatedLeaveService : IAllocatedLeaveService
    {
        private readonly IAllocatedLeaveRepository _allocatedLeaveRepository;
        private readonly LMSDbContext _dbContext;

        public AllocatedLeaveService(IAllocatedLeaveRepository allocatedLeaveRepository, LMSDbContext dbContext)
        {
            _allocatedLeaveRepository = allocatedLeaveRepository;
            _dbContext = dbContext;
        }

        public async Task<AllocatedLeave> CreateAllocatedLeave(AllocatedLeave allocatedLeave)
        {
            return await _allocatedLeaveRepository.CreateAllocatedLeave(allocatedLeave);
        }

        public async Task<string> DeleteAllocatedLeave(int id)
        {
            return await _allocatedLeaveRepository.DeleteAllocatedLeave(id);
        }

        public async Task<AllocatedLeave?> GetAllocatedLeaveByID(int employeeId, int leaveTypeId)
        {
            return await _allocatedLeaveRepository.GetAllocatedLeave(employeeId, leaveTypeId);
        }
        public async Task<List<AllocatedLeave>> GetAllocatedLeaveEmployeeByID(int employeeId)
        {
            return await _allocatedLeaveRepository.GetAllocatedLeaveEmployeeByID(employeeId);
        }

        public async Task<List<AllocatedLeave>> GetAllocatedLeaves()
        {
            return await _allocatedLeaveRepository.GetAllocatedLeaves();
        }

        public async Task<AllocatedLeave> UpdateAllocatedLeave(AllocatedLeave allocatedleaveRequest)
        {
            return await _allocatedLeaveRepository.UpdateAllocatedLeave(allocatedleaveRequest);
        }

        public async Task AllocateAnnualLeave(Employee employee)
        {
            if (employee.ConfirmDate == null)
                return;

            DateTime joinDate = (DateTime)employee.JoinDate;
            DateTime currentDate = DateTime.Now;

            int yearsOfService = currentDate.Year - joinDate.Year;

            int leaveDays = 0;
            if (yearsOfService == 1)
            {
                 leaveDays = CalculateLeaveDays(joinDate, "AnnualLeave");

     
            }
           
            if (yearsOfService > 1)
            {
                
                leaveDays = 14;
            }
            var allocatedLeave = new AllocatedLeave
            {
                EmployeeId = employee.Id,
                LeaveTypeId = (int)Enums.LeaveTypes.AnnualLeave,
                allocated = leaveDays,
                taken = 0
            };

            await CreateAllocatedLeave(allocatedLeave);
        }

        public async Task AllocatedCasualLeave(Employee employee)
        {
            if (employee.ConfirmDate == null && employee == null)
                return;

            DateTime joinDate = (DateTime)employee.JoinDate;
            DateTime currentDate = DateTime.Now;

            int yearsOfService = currentDate.Year - joinDate.Year;

            double leaveDays;
            if (yearsOfService < 1)
            {
                int monthofService = currentDate.Month - joinDate.Month;
                leaveDays = monthofService/2.0;
            }
            else
            {
                leaveDays = 7;
            }

            var allocatedLeave = new AllocatedLeave
            {
                EmployeeId = employee.Id,
                LeaveTypeId = (int)Enums.LeaveTypes.CasualLeave,
                allocated = leaveDays,
                taken = 0
            };
            await CreateAllocatedLeave(allocatedLeave);
        }
        public async Task AllocatedSickLeave(Employee employee)
        {
            var allocatedLeave = new AllocatedLeave
            {
                EmployeeId = employee.Id,
                LeaveTypeId = (int)Enums.LeaveTypes.SickLeave,
                allocated = 20,
                taken = 0
            };
            await CreateAllocatedLeave(allocatedLeave);
        }
        public async Task AllocatedNoPayLeave(Employee employee)
        {
            var allocatedLeave = new AllocatedLeave
            {
                EmployeeId = employee.Id,
                LeaveTypeId = (int)Enums.LeaveTypes.NoPayLeave,
                allocated = 20,
                taken = 0
            };
            await CreateAllocatedLeave(allocatedLeave);
        }

        private int CalculateLeaveDays(DateTime joinDate, string leaveType)
        {
            var setup = _dbContext.AllocatedSetups
                                  .FirstOrDefault(s => joinDate.Month >= s.Start && joinDate.Month <= s.End);

            if (setup == null)
                throw new InvalidOperationException($"No AllocatedSetup found for join month: {joinDate.Month}");

            return leaveType switch
            {
                "AnnualLeave" => setup.AnnualLeave,
                "CasualLeave" => setup.CasualLeave,
                "SickLeave" => 20,
                "NopayLeave" => 20,
                _ => throw new ArgumentException($"Invalid leave type: {leaveType}")
            };
        }

        
    }
}

