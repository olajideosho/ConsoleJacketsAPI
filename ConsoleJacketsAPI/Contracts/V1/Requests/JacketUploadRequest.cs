using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Contracts.V1.Requests
{
    public class JacketUploadRequest
    {
        public int IndexId { get; set; }
        public string Owner { get; set; }
        public string ID { get; set; }
        public string Secret { get; set; }
        public string Country { get; set; }
    }
}
