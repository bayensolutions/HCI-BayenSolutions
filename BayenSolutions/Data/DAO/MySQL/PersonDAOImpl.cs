using BayenSolutions.Data.DAO.Exceptions;
using BayenSolutions.Data.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DAO.MySQL
{
    public class PersonDAOImpl : IPersonDAO
    {
        public bool AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public int AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetClients()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersons()
        {
            // TODO
            List<Person> result = new List<Person>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;

            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL dohvatanjeSvihOsoba()";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Person()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Place = new Place()
                        {
                            ZipCOde = reader.GetString(4),
                            Name = reader.GetString(5)
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in PersonDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
