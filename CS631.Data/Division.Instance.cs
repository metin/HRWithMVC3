using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Division
    {

        public Division Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Divisions (DivName, DivHead) VALUES(@name, @DivHead);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.DivName);
            cmd.Parameters.AddWithValue("@DivHead", this.DivHead.GetValueOrDefault());
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.DivID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE Divisions set 
                                DivName = @name, DivHead = @DivHead 
                                WHERE DivID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.DivName);
            cmd.Parameters.AddWithValue("@DivHead", this.DivHead.GetValueOrDefault());
            cmd.Parameters.AddWithValue("@id", this.DivID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Department> Departments()
        {
            return Department.FindByDivisionID(this.DivID);
        }

        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Divisions WHERE DivID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.DivID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}