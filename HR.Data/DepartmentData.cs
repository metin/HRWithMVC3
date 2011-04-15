using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace HR.Data
{
    public class DepartmentData : Base
    {
        public DepartmentData()
        { 

        }

        public ICollection<Department> All()
        {
            List<Department> Departments = new List<Department>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Departments;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Department p = null;
            

            while(dr.Read())
            {
                p = new Department();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                Departments.Add(p);
            }
            connection.Close();

            return Departments;
        }

        public Department FindById(int id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Departments where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department p = null;

            while (dr.Read())
            {
                p = new Department();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
            }
            connection.Close();

            return p;
        }

        public Department Save(Department p)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Departments (name) VALUES(@name);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            p.id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return p;
        }

        public void Update(Department e)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Departments set name = @name WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", e.name);
            cmd.Parameters.AddWithValue("@id", e.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete(int id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Departments WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}