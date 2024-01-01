using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DTO
{
    public class Place
    {
        public String ZipCode { get; set; }

        public String Name { get; set; }

        public override string ToString()
        {
            return ZipCode + " " + Name;
        }
    }
}
