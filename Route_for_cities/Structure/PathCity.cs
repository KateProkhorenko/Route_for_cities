using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route_for_cities.Structure
{
    public struct PathCity
    {
        /// <summary>
        /// Property From the city
        /// </summary>
        public string From;
        /// <summary>
        /// Property To the city
        /// </summary>
        public string To;
        public PathCity(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
