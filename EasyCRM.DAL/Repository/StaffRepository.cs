using EasyCRM.DAL.Entity;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _context;

        public StaffRepository(DataContext context) {

            _context = context;
        }

        public async Task<bool> CreateStaff(Staff staff)
        {
            await _context.Staffs.AddAsync(staff);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteStaff(int id)
        {
            Staff staff  = await GetStaffById(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetStaff()
        {
            var staff = _context.Staffs.AsQueryable();
            return await staff.ToListAsync();
        }

        public async Task<List<Staff>> GetStaff(string filter_staffName)
        {
            return await _context.Staffs.Where(x => x.StaffName.Contains(filter_staffName)).ToListAsync();
        }

        public async Task<Staff> GetStaffById(int id)
        {
            return await _context.Staffs.FirstOrDefaultAsync(r => r.StaffId == id);
        }

        public async Task<bool> UpdateStaff(Staff staff)
        {
            _context.ChangeTracker.Clear();
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
