using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Building
    {

        public IEnumerable<Building> All()
        {
            List<Building> buildings = new List<Building>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM buildings;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Building p = null;
            
            while(dr.Read())
            {
                p = new Building();
                p.Id = dr.GetInt32("id");
                p.Code = dr.GetString("code");
                p.Name = dr.GetString("name");
                p.Year = dr.GetInt32("year");
                p.Cost = dr.GetDecimal("cost");
                buildings.Add(p);
            }
            connection.Close();
            return buildings;
        }

        public Building FindById(int id)
        {
            this.Id = id;
            return Load();
        }

        public Building Load()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM buildings where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Id = dr.GetInt32("id");
                this.Code = dr.GetString("code");
                this.Name = dr.GetString("name");
                this.Year = dr.GetInt32("year");
                this.Cost = dr.GetDecimal("cost");
            }
            connection.Close();
            return this;
        }

        public Building Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO buildings (name, code, year, cost) VALUES(@name, @code, @year, @cost);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.Name);
            cmd.Parameters.AddWithValue("@code", this.Code);
            cmd.Parameters.AddWithValue("@year", this.Year);
            cmd.Parameters.AddWithValue("@cost", this.Cost);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.Id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE buildings set name = @name, code = @code, year = @year, cost = @cost WHERE id = @id;";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@name", this.Name);
            cmd.Parameters.AddWithValue("@code", this.Code);
            cmd.Parameters.AddWithValue("@year", this.Year);
            cmd.Parameters.AddWithValue("@cost", this.Cost);

            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM buildings WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}