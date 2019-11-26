using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleJacketsAPI.Domain;

namespace ConsoleJacketsAPI.Services
{
    public class JacketService : IJacketService
    {
        private readonly List<Jacket> _jackets;

        public JacketService()
        {
            _jackets = new List<Jacket>()
            {
                new Jacket
                {
                    Id = 1,
                    JacketOwner = "Lui Han Peng",
                    JacketID = "AZRX",
                    Location = "Japan"
                },
                new Jacket
                {
                    Id = 2,
                    JacketOwner = "Ayodeji Adedipe",
                    JacketID = "AZEF",
                    Location = "Nigeria"
                },
                new Jacket
                {
                    Id = 3,
                    JacketOwner = "Simon Arslan",
                    JacketID = "QHRT",
                    Location = "USA"
                },
                new Jacket
                {
                    Id = 4,
                    JacketOwner = "Pagoda Chan",
                    JacketID = "OPLL",
                    Location = "China"
                },
                new Jacket
                {
                    Id = 5,
                    JacketOwner = "Feyi Quan Chu",
                    JacketID = "FFIP",
                    Location = "Germany"
                }
            };
        }

        public Jacket GetJacketById(string jacketId)
        {
            return _jackets.SingleOrDefault(x => x.JacketID == jacketId);
        }

        public List<Jacket> GetJackets()
        {
            return _jackets;
        }

        public List<Jacket> GetRecentJackets()
        {
            return _jackets.TakeLast(3).Reverse().ToList();
        }
    }
}
