using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Employee
    {
        public ICollection<Employee> All()
        { 
            List<Employee> l = new List<Employee>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM employees;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Employee e = null;
            while(dr.Read())
            {
                e = new Employee();
                e.id = dr.GetInt32("id");
                e.last_name = dr.GetString("last_name");
                e.first_name = dr.GetString("first_name");
                l.Add(e);
            }
            connection.Close();
            return l;
        }

        public Employee FindById(int id)
        {
            this.id = id;
            return Load();
        }

        public Employee Load()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM employees where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.id = dr.GetInt32("id");
                this.last_name = dr.GetString("last_name");
                this.first_name = dr.GetString("first_name");
            }
            connection.Close();
            return this;
        }

        public Employee Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO employees (first_name, last_name) VALUES(@first_name, @last_name);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@first_name", this.first_name);
            cmd.Parameters.AddWithValue("@last_name", this.last_name);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE employees set first_name = @first_name, last_name = @last_name WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@first_name", this.first_name);
            cmd.Parameters.AddWithValue("@last_name", this.last_name);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM employees WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}