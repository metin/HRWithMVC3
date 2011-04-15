using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace HR.Data
{
    public class Base
    {
        private MySqlConnection _connection = null;
        public MySqlConnection connection {
            get {
                return _connection;
            } 
        }
        public Base()
        {
            _connection = new MySqlConnection();
            _connection.ConnectionString = "Server=localhost;Database=cs631;Uid=ODBC;Pwd=;";
            //MySqlCommand cmd = c.CreateCommand();
            //cmd.CommandText = "Select * from tbl1";
            //c.Open();
            //cmd.ExecuteReader();
            //c.Close();
        }
    }
}