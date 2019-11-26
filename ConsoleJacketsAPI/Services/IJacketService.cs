using ConsoleJacketsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Services
{
    public interface IJacketService
    {
        Task<List<Jacket>> GetRecentJacketsAsync();

        Task<List<Jacket>> GetJacketsAsync();

        Task<bool> UploadAsync(Jacket jacket);

        Task<Jacket> GetJacketByIdAsync(string jacketId);

        Task<int> GetCountAsync();
    }
}
