using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace Demo.Core.ApiKey
{
    public static class ApiKey
    {
        public static TMDbClient GetTMDbClient()
        {
            return new TMDbClient("2954778739480995cf5e744265900647");
        }
    }
}
