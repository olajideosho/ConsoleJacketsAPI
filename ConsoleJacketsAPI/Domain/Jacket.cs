using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Domain
{
    public class Jacket
    {
        [Key]
        public int Id { get; set; }
        public string JacketOwner { get; set; }
        public string JacketID { get; set; }
        public string Location { get; set; }

    }
}
