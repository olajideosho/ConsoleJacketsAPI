using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleJacketsAPI.Data;
using ConsoleJacketsAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConsoleJacketsAPI.Services
{
    public class JacketService : IJacketService
    {
        private readonly DataContext _dataContext;

        public JacketService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> GetCountAsync()
        {
            return await _dataContext.Jackets.CountAsync();
        }

        public async Task<Jacket> GetJacketByIdAsync(string jacketId)
        {
            return await _dataContext.Jackets.SingleOrDefaultAsync(x => x.JacketID == jacketId);
        }

        public async Task<List<Jacket>> GetJacketsAsync()
        {
            return await _dataContext.Jackets.ToListAsync();
        }

        public async Task<List<Jacket>> GetRecentJacketsAsync()
        {
            //return await _dataContext.Jackets.TakeLast(3).Reverse().ToListAsync();
            return await _dataContext.Jackets.OrderByDescending(j => j.Id).Take(3).ToListAsync();
        }

        public async Task<bool> UploadAsync(Jacket jacket)
        {
            await _dataContext.Jackets.AddAsync(jacket);
            var uploaded = await _dataContext.SaveChangesAsync();
            return uploaded > 0;
        }
    }
}
