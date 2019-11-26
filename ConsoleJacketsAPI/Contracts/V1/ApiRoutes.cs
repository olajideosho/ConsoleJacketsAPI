using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleJacketsAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Jackets
        {
            public const string GetRecent = Base + "/recent";
            public const string GetCount = Base + "/count";
            public const string GetById = Base + "/jackets/{jacketId}";
            public const string Upload = Base + "/upload";
        }
    }
}
