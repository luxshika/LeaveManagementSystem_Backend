﻿using LeaveManagementSystem_Backend.DBContext;
using LeaveManagementSystem_Backend.IRepository;
using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Repository
{
    public class HolidayRepository:IHolidayRepository
    {
        private readonly LMSDbContext _holidayContext;
        public HolidayRepository(LMSDbContext holidayContext)
        {
            _holidayContext = holidayContext;
        }

        public async Task<Holiday> CreateHoliday(Holiday holiday)
        {
            try
            {
                var res = _holidayContext.Holidays.Add(holiday);
                await _holidayContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteHoliday(int id)
        {
            var holiday = await _holidayContext.Holidays.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (holiday == null)
            {
                return "Requested ID not available ";
            }
            _holidayContext.Holidays.Remove(holiday);
            await _holidayContext.SaveChangesAsync();
            return " suceeded";
        }

         public async Task<List<Holiday>> GetHolidayByID(int id)
        {
            try
            {
           
                var res = await _holidayContext.Holidays.Where(x => x.Id == id).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<List<Holiday>> GetHolidays()
        {
            try
            {
                var res = _holidayContext.Holidays.ToListAsync();
                return res;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<Holiday> UpdateHoliday(Holiday holidayRequest)
        {
            try
            {
                var res = _holidayContext.Holidays.Update(holidayRequest);
                await _holidayContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
