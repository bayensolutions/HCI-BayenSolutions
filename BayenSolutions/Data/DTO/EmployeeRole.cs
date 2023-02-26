using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DTO
{
    public class EmployeeRole
    {
        public int Id { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return Id + " " + Role;
        }
    }
}
