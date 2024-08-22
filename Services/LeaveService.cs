using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.IServices;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LeaveManagementSystem_Backend.Services
{
    public class LeaveService : ILeaveService 
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IAllocatedLeaveRepository _allocatedLeaveRepository;
        private readonly IHolidayRepository _holidayRepository;

        public LeaveService(ILeaveRepository leaveRepository , IAllocatedLeaveRepository allocatedLeaveRepository, IHolidayRepository holidayRepository)
        {
            _leaveRepository = leaveRepository;
            _allocatedLeaveRepository = allocatedLeaveRepository;
            _holidayRepository = holidayRepository;
          
        }
        public async Task<Leave> CreateLeave(Leave leave)
        {
           

            var holidays = await _holidayRepository.GetHolidays();
          


            double leaveDays = (leave.EndDate - leave.BeginDate).TotalDays;
            for (var i = 0; i <= leaveDays; i++)
            {
                var checkDate = leave.BeginDate.AddDays(i);
                if (holidays.Any(h => h.HolidayDate.Date == checkDate.Date))
                {
                    throw new ArgumentException($"The leave date {checkDate.ToShortDateString()} is a holiday.");
                }
            }
            if (leave.EmployeeId.HasValue && leave.CoverPersonId.HasValue &&
                leave.EmployeeId.Value == leave.CoverPersonId.Value)
            {
                throw new ArgumentException("The cover person cannot be the same as the employee.");
            } 
            
            var res = await _leaveRepository.CreateLeave(leave);
            var allocatedLeave = await _allocatedLeaveRepository.GetAllocatedLeave(leave.EmployeeId, leave.LeaveTypeId);

          
            if (allocatedLeave == null)
            {
                throw new Exception("Allocated leave not found for the specified employee and leave type.");
            }
            
            allocatedLeave.taken += leaveDays;
            if(allocatedLeave.allocated < allocatedLeave.taken)
            {
                throw new ArgumentException("Your Allocated Leave days Finished! You Can't take the leave  ");
            }
            await _allocatedLeaveRepository.UpdateAllocatedLeave(allocatedLeave);
            return res;
        }
        
        public async Task<string> DeleteLeave(int id)
        {
            var res = await _leaveRepository.DeleteLeave(id);
            return res;
        }

        public async Task<Leave?> GetLeaveByID(int id)
        {
            var res = await _leaveRepository.GetLeaveByID(id);
            return res;
        }

        public async Task<List<Leave>> GetLeaves()
        {
            var res = await _leaveRepository.GetLeaves();
            return res;
        }

        public async Task<Leave> UpdateLeave(Leave leaveRequest)
        {
            var res = await _leaveRepository.UpdateLeave(leaveRequest);
            return res;
        }

        public async Task<bool> UpdateLeaveStatus(int id, int newStatus,string rejectreson)
        {
            var leave = await _leaveRepository.GetLeaveByID(id);
            if (leave == null)
            {
                return false;
            }
            leave.LeaveStatus = newStatus;
            leave.RejectReason = rejectreson;
            await _leaveRepository.UpdateLeave(leave);
            await UpdateRejectTaken(leave);


            return true;
        }
     
        private async Task UpdateRejectTaken(Leave leave)
        {
            var allocatedLeave = await _allocatedLeaveRepository.GetAllocatedLeave(leave.EmployeeId, leave.LeaveTypeId);
            double leaveDays = (leave.EndDate - leave.BeginDate).TotalDays;
            if (allocatedLeave == null)
            {
                throw new Exception("Allocated leave not found for the specified employee and leave type.");
            }
            if ((Enums.LeaveStatus)leave.LeaveStatus == Enums.LeaveStatus.Rejected)
            {
                allocatedLeave.taken -= leaveDays;
            }
            await _allocatedLeaveRepository.UpdateAllocatedLeave(allocatedLeave);
        }
        public async Task<List<Leave>> FilterLeave(int coverPersonId, DateTime beginDate, DateTime endDate)
        {
            var leaves = await _leaveRepository.GetLeaves(); 
            var filteredLeaves = leaves.Where(l => l.EmployeeId == coverPersonId &&
                                                   ((l.BeginDate.Date >= beginDate.Date && l.BeginDate.Date <= endDate.Date) &&
                                                    (l.EndDate.Date >= beginDate.Date && l.EndDate.Date <= endDate.Date) &&
                                                    (l.BeginDate.Date <= beginDate.Date && l.EndDate.Date >= endDate.Date))).ToList();
            return filteredLeaves;
        }
        public async Task<List<Leave>> GetFilterLeaves(string searchTerm, int pageNumber, int pageSize)
        {
            return await _leaveRepository.GetFilterLeaves(searchTerm, pageNumber, pageSize);
        }
        public async Task<int> GetLeaveCountWithStatusUnReadAsync()
        {
            return await _leaveRepository.GetLeaveCountByStatusAsync((int)Enums.LeaveStatus.UnRead);
        }

    }
}
