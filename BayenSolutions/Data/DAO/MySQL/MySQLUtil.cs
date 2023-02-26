using MySql.Data.MySqlClient;
using BayenSolutions.Data.DAO.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BayenSolutions.Data.DAO.MySQL
{
    public class MySQLUtil
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public static MySqlConnection GetMySQLConnection()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conn;
        }


        public static void CloseQuietly(MySqlConnection conn)
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static void CloseQuietly(MySqlDataReader reader)
        {
            if (reader != null)
            {
                reader.Close();
            }
        }

        public static void CloseQuietly(MySqlDataReader reader, MySqlConnection conn)
        {
            CloseQuietly(reader);
            CloseQuietly(conn);
        }

    }
}