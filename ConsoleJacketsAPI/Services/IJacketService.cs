using ConsoleJacketsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Services
{
    public interface IJacketService
    {
        List<Jacket> GetRecentJackets();

        List<Jacket> GetJackets();

        Jacket GetJacketById(string jacketId);
    }
}
