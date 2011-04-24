using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Building
    {

        public static IEnumerable<Building> FindAll()
        {
            List<Building> buildings = new List<Building>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM buildings;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            c.Open();
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
            c.Close();
            return buildings;
        }

        public static Building FindById(int id)
        {

            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM buildings where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Building b = new Building();
            while (dr.Read())
            {
                b.Id = dr.GetInt32("id");
                b.Code = dr.GetString("code");
                b.Name = dr.GetString("name");
                b.Year = dr.GetInt32("year");
                b.Cost = dr.GetDecimal("cost");
            }
            c.Close();
            return b;
        }

    }
}