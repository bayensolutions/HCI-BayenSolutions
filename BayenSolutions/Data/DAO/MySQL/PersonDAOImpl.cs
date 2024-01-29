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
                    list.Add(new Employee()
                    {
                        Id= reader.GetInt32(0),
                        Name= reader.GetString(1),
                        Surname= reader.GetString(2),
                        Telephone= reader.GetString(3),
                        Place= new Place()
                        {
                            ZipCode = reader.GetString(4),
                            Name = reader.GetString(5),
                        },
                        Nickname= reader.GetString(6),
                        PasswordHash= reader.GetString(7),
                        Salary= reader.GetDouble(8),
                        EmployeeRole= new EmployeeRole()
                        {
                            Id= reader.GetInt32(9),
                            Role=reader.GetString(10),
                        },
                        UniqueIdentificationNumber= reader.GetString(11)
                    });
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
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                int index = AddPerson(employee);
                conn = MySQLUtil.GetMySQLConnection();
                cmd = new MySqlCommand("dodavanjeZaposlenog", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pIdOsoba", MySqlDbType.String).Value = index;
                cmd.Parameters.Add("@pKorisničkoIme", MySqlDbType.String).Value = employee.Nickname;
                cmd.Parameters.Add("@pOtisakLozinke", MySqlDbType.String).Value = employee.PasswordHash;
                cmd.Parameters.Add("@pPlata", MySqlDbType.Double).Value = employee.Salary;
                cmd.Parameters.Add("@pJMBG", MySqlDbType.String).Value = employee.UniqueIdentificationNumber;
                cmd.Parameters.Add("@pIdUloga", MySqlDbType.Int32).Value = employee.EmployeeRole.Id;
                cmd.ExecuteNonQuery();
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

        public bool DeleteEmployee(Employee employee)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = "CALL brisanjeZaposlenog(?)";
                cmd.Parameters.AddWithValue("@IdOsoba", employee.Id);
                result = cmd.ExecuteNonQuery() == 1;
                DeletePerson(employee);
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

        public bool UpdateEmployee(Employee employee)
        {
            bool result = false;
            MySqlConnection conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySQLUtil.GetMySQLConnection();
                cmd = new MySqlCommand("izmjenaZaposlenog", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pIdZaposlenog", MySqlDbType.Int32).Value = employee.Id;
                cmd.Parameters.Add("@pKorisničkoIme", MySqlDbType.String).Value = employee.Nickname;
                cmd.Parameters.Add("@pOtisakLozinke", MySqlDbType.String).Value = employee.PasswordHash;
                cmd.Parameters.Add("@pPlata", MySqlDbType.Double).Value = employee.Salary;
                cmd.Parameters.Add("@pJMBG", MySqlDbType.String).Value = employee.UniqueIdentificationNumber;
                cmd.Parameters.Add("@pIdUloga", MySqlDbType.Int32).Value = employee.EmployeeRole.Id;
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
    }
}
