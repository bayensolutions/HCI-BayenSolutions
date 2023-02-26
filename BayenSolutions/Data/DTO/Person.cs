using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DTO
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public Place Place { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Surname + " " + Telephone + " " + Place.ToString();
        }
    }
}

