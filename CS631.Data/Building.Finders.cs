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
                p.BuildingID = dr.GetInt32("BuildingID");
                p.BuildingCode = dr.GetString("BuildingCode");
                p.BuildingName = dr.GetString("BuildingName");
                p.YearAcquired = dr.GetInt32("YearAcquired");
                p.BuildingCost = dr.GetDecimal("BuildingCost");
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
            cmd.CommandText = "SELECT * FROM buildings where BuildingID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Building b = new Building();
            while (dr.Read())
            {
                b.BuildingID = dr.GetInt32("BuildingID");
                b.BuildingCode = dr.GetString("BuildingCode");
                b.BuildingName = dr.GetString("BuildingName");
                b.YearAcquired = dr.GetInt32("YearAcquired");
                b.BuildingCost = dr.GetDecimal("BuildingCost");
            }
            c.Close();
            return b;
        }

    }
}