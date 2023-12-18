using EasyCRM.BAL.Interface;
using EasyCRM.DAL.Entity.DataModel;
using EasyCRM.DAL.Interface;
using EasyCRM.DAL.Repository;
using EasyCRM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.BAL.Service
{
    public class EngineersService : IEngineersService
    {
        private readonly IEngineersrepository _engineersrepository;
        public EngineersService(IEngineersrepository engineersrepository) 
        {
            _engineersrepository = engineersrepository;
        }

        public async Task<bool> CreateEngineer(EngineerVM engineerVM)
        {
            Engineer obj = new Engineer()
            {
               EngineerName = engineerVM.EngineerName,
               EngineerAddress = engineerVM.EngineerAddress,
               EngineerCity = engineerVM.EngineerCity,
               EngineerPhone = engineerVM.EngineerPhone,
            };
            return await _engineersrepository.CreateEngineer(obj);
        }

        public async Task DeleteEngineer(int id)
        {
            await _engineersrepository.DeleteEngineer(id);
        }

        public async Task<EngineerVM> GetEngineerById(int id)
        {
            Engineer engineer = await _engineersrepository.GetEngineerById(id);

            EngineerVM obj = new EngineerVM()
            {
                EngineerName = engineer.EngineerName,
                EngineerAddress = engineer.EngineerAddress,
                EngineerCity = engineer.EngineerCity,
                EngineerPhone= engineer.EngineerPhone,

            };
            return obj;
        }

        public async Task<List<EngineerVM>> GetEngineers()
        {
            List<Engineer> engineer = await _engineersrepository.GetEngineer();
            List<EngineerVM> obj = engineer.Select(x => new EngineerVM()
            {
               EngineerName = x.EngineerName,
               EngineerAddress = x.EngineerAddress, 
                EngineerCity = x.EngineerCity,
                EngineerPhone= x.EngineerPhone,
                EngineerId = x.EngineerId,

            }).ToList();

            return obj;
        }

        public async Task<List<EngineerVM>> GetEngineers(string filter_engineerName)
        {
            List<Engineer> engineer = await _engineersrepository.GetEngineer(filter_engineerName);
            List<EngineerVM> obj = engineer.Select(x => new EngineerVM()
            {
                EngineerName = x.EngineerName,
                EngineerAddress = x.EngineerAddress,
                EngineerCity = x.EngineerCity,
                EngineerPhone = x.EngineerPhone,
                EngineerId = x.EngineerId,

            }).ToList();

            return obj;
        }

        public async Task<bool> UpdateEngineer(EngineerVM engineerVM)
        {
            Engineer obj = new Engineer()
            {
               EngineerName = engineerVM.EngineerName,
               EngineerAddress = engineerVM.EngineerAddress,
               EngineerCity= engineerVM.EngineerCity,
               EngineerPhone = engineerVM.EngineerPhone,

            };
            return await _engineersrepository.UpdateEngineer(obj);
        }
    }
}
