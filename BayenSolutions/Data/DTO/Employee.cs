using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DTO
{
    public class Employee : Person
    {
        public string Nickname { get; set; }
        public string PasswordHash { get; set; }
        public double Salary { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public string UniqueIdentificationNumber { get; set; }
       

        public override string ToString()
        {
            return base.ToString() + " " + Nickname + " " + PasswordHash + " " + Salary + " " + EmployeeRole.ToString() + " " + UniqueIdentificationNumber;
        }
    }
}
