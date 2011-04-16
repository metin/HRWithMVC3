using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Division
    {

        public ICollection<Division> All()
        {
            List<Division> divisions = new List<Division>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Divisions;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Division p = null;
            while(dr.Read())
            {
                p = new Division();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                divisions.Add(p);
            }
            connection.Close();
            return divisions;
        }

        public Division FindByID(int id)
        {
            this.id = id;
            return this.Load();
        }
        public Division Load()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Divisions where id = @id;";
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
        public Division Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Divisions (name) VALUES(@name);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.name);
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
            cmd.CommandText = "UPDATE Divisions set name = @name WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.name);
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Divisions WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}