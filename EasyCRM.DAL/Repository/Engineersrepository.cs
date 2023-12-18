using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Repository
{
    public class Engineersrepository : IEngineersrepository
    {
        private readonly DataContext _context;
        public Engineersrepository(DataContext context) 
        {  
            _context = context; 
        }        

        public async Task<bool> CreateEngineer(Engineer engineer)
        {
            await _context.Engineers.AddAsync(engineer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteEngineer(int id)
        {
            Engineer engineer = await GetEngineerById(id);
            _context.Engineers.Remove(engineer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Engineer>> GetEngineer()
        {
            var engineers = _context.Engineers.AsQueryable();
            return await engineers.ToListAsync();
        }

        public async Task<List<Engineer>> GetEngineer(string filter_engineerName)
        {
            return await _context.Engineers.Where(x => x.EngineerName.Contains(filter_engineerName)).ToListAsync();
        }

        public async Task<Engineer> GetEngineerById(int id)
        {
            return await _context.Engineers.FirstOrDefaultAsync(r => r.EngineerId == id);
        }

        public async Task<bool> UpdateEngineer(Engineer engineer)
        {
            _context.ChangeTracker.Clear();
            _context.Engineers.Update(engineer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
