using BayenSolutions.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BayenSolutions.Data.DAO
{
    public interface IPersonDAO
    {
        List<Person> GetPersons();

        int AddPerson(Person person);

        bool DeletePerson(Person person);

        bool UpdatePerson(Person person);

        List<Employee> GetEmployees();

        bool AddEmployee(Employee employee);

        bool DeleteEmployee(Employee employee);

        bool UpdateEmployee(Employee employee);

        List<Person> GetClients();
    }
}
