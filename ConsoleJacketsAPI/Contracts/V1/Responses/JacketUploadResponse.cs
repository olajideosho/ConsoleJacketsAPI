using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Contracts.V1.Responses
{
    public class JacketUploadResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
