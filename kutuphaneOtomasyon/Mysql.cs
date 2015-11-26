using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

/*
    Author: Furkan Ay
*/

namespace kutuphaneTakip
{
    class Mysql
    {
        private string server = "localhost";
        private string user = "root";
        private string password = "1234";
        private string database = "kutuphane";

        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public void Open()
        {
            conn = new MySqlConnection("server=" + this.server + ";uid=" + this.user
                + ";pwd=" + this.password + ";database=" + this.database);
            try
            {
                conn.Open();
            }
            catch (MySqlException myEx)
            {

                throw myEx;
            }

        }
        public void Close()
        {
            try
            {
                conn.Close();
            }
            catch (MySqlException myEx)
            {

                throw myEx;
            }
        }

        public MySqlDataReader Select(string query)
        {
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            return this.reader;
        }


    }
}
