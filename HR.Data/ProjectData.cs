using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace HR.Data
{
    public class ProjectData : Base
    {
        public ProjectData()
        { 

        }

        public ICollection<Project> All()
        {
            List<Project> projects = new List<Project>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM projects;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Project p = null;
            

            while(dr.Read())
            {
                p = new Project();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                projects.Add(p);
            }
            connection.Close();

            return projects;
        }

        public Project FindById(int id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM projects where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Project p = null;

            while (dr.Read())
            {
                p = new Project();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
            }
            connection.Close();

            return p;
        }

        public Project Save(Project p)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO projects (name) VALUES(@name);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", p.name);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            p.id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return p;
        }

        public void Update(Project e)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE projects set name = @name WHERE id = @id;";
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
            cmd.CommandText = "DELETE FROM projects WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}