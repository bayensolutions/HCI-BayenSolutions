using BayenSolutions.Data.DAO.Exceptions;
using BayenSolutions.Data.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayenSolutions.Data.DAO.MySQL
{
    public class PersonDAOImpl : IPersonDAO
    {

        public List<Person> GetPersons()
        {
            List<Person> list = new List<Person>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL dohvatanjeSvihOsoba()";
                MySqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Person()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Place = new Place()
                        {
                            ZipCode=reader.GetString(4),
                            Name=reader.GetString(5),
                        }
                    }) ;
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in BillDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
        }

        public bool DeletePerson(Person person)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL brisanjeOsobe(?)";
                cmd.Parameters.AddWithValue("@IdOsoba", person.Id);
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in TableDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return result;
        }

        public int AddPerson(Person person)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = new MySqlCommand("dodavanjeOsobe", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pIme", MySqlDbType.String).Value = person.Name;
                cmd.Parameters.Add("@pPrezime", MySqlDbType.String).Value = person.Surname;
                cmd.Parameters.Add("@pTelefon", MySqlDbType.String).Value = person.Telephone;
                cmd.Parameters.Add("@pPoštanskiBroj", MySqlDbType.Int32).Value = person.Place.ZipCode;
                cmd.Parameters.Add("@pIndeks", MySqlDbType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int personId = Convert.ToInt32(cmd.Parameters["@pIndeks"].Value);
                return personId;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in TableDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
        }

        public bool UpdatePerson(Person person)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = new MySqlCommand("izmjenaOsobe", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pIdOsoba", MySqlDbType.Int32).Value = person.Id;
                cmd.Parameters.Add("@pIme", MySqlDbType.String).Value = person.Name;
                cmd.Parameters.Add("@pPrezime", MySqlDbType.String).Value = person.Surname;
                cmd.Parameters.Add("@pTelefon", MySqlDbType.String).Value = person.Telephone;
                cmd.Parameters.Add("@pPoštanskiBroj", MySqlDbType.Int32).Value = person.Place.ZipCode;
                result=cmd.ExecuteNonQuery()==1;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in TableDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
            return result;
        }

        public List<Person> GetClients()
        {
            List<Person> list = new List<Person>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL dohvatanjeSvihKlijenata()";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Person()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Telephone = reader.GetString(3),
                        Place = new Place()
                        {
                            ZipCode = reader.GetString(4),
                            Name = reader.GetString(5),
                        }
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in BillDAOImpl", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL dohvatanjeSvihZaposlenih()";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee(
                        id: reader.GetInt32(0),
                        name: reader.GetString(1),
                        surname: reader.GetString(2),
                        telephone: reader.GetString(3),
                        place: new Place()
                        {
                            ZipCode = reader.GetString(4),
                            Name = reader.GetString(5),
                        },
                        nickname: reader.GetString(6),
                        passwordHash: reader.GetString(7),
                        salary: reader.GetDouble(8),
                        employeeRole: (EmployeeRole)Enum.Parse(typeof(EmployeeRole), reader.GetInt32(9).ToString()),
                        uniqueIdentificationNumber: reader.GetString(10)
                    ));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new DataAccessException("Exception in GetEmployees method", ex);
            }
            finally
            {
                MySQLUtil.CloseQuietly(conn);
            }
        }



        public bool AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
