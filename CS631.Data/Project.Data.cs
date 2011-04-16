using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Project
    {

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
                p.DateStarted = dr.GetDateTime("date_started");
                p.DateEnded = dr.GetDateTime("date_ended");
                p.Budget = dr.GetDecimal("budget");
                projects.Add(p);
            }
            connection.Close();
            return projects;
        }

        public Project FindById(int id)
        {
            this.id = id;
            return Load();
        }

        public Project Load()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM projects where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.id = dr.GetInt32("id");
                this.name = dr.GetString("name");
            }
            connection.Close();
            return this;
        }

        public Project Save()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO projects (name, date_started, date_ended, budget)" +
                              " VALUES(@name, " +
                              " @date_started, " +
                              " @date_eded, " +
                              " @budget );";
//            " STR_TO_DATE(@date_started, '%m/%d/%Y'), " +
//            " STR_TO_DATE(@date_eded, '%m/%d/%Y'), " +

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@date_started", this.DateEnded.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date_eded", this.DateEnded.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@budget", this.Budget);
            
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public Project Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = " UPDATE projects SET " + 
                              " name = @name, date_started = @date_started, date_ended = @date_eded, budget = @budget " +
                              " WHERE id = @id;";

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@date_started", this.DateEnded.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@date_eded", this.DateEnded.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@budget", this.Budget);
            cmd.Parameters.AddWithValue("@id", this.id);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            return this;
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM projects WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}