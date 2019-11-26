using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Services
{
    public static class SecretCheck
    {
        public static bool IsValid(string Id, string secret)
        {
            var combination = Id;
            var calculatedSecret = "";
            List<string> codes = new List<string>();
            int offset = 20;
            foreach(char c in combination)
            {
                var code = (int)c - offset;
                codes.Add(code.ToString());
                offset++;
            }
            calculatedSecret = codes[1] + codes[3] + codes[0] + codes[2];
            var totaloffset = Convert.ToInt32(calculatedSecret) - 37;
            calculatedSecret = totaloffset.ToString();

            return (calculatedSecret == secret);
        }
    }
}
