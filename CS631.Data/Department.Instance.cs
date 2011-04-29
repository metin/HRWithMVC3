using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Department
    {

        public Department Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO Departments 
                                    (DeptName, DeptHead, DivID) 
                                VALUES
                                    (@name, @DeptHead, @DivID);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.DeptName);
            cmd.Parameters.AddWithValue("@DeptHead", this.DeptHead.GetValueOrDefault());
            cmd.Parameters.AddWithValue("@DivID", this.DivID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.DeptID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE Departments 
                                SET 
                                    DeptName = @name, DeptHead = @DeptHead, DivID = @DivID 
                                WHERE DeptID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.DeptName);
            cmd.Parameters.AddWithValue("@DeptHead", this.DeptHead.GetValueOrDefault());
            cmd.Parameters.AddWithValue("@DivID", this.DivID);

            cmd.Parameters.AddWithValue("@id", this.DeptID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Departments WHERE DeptID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.DeptID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}