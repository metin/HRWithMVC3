using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Building
    {

        public Building Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO buildings 
                                    (BuildingName, BuildingCode, YearAcquired, BuildingCost) 
                                VALUES
                                    (@name, @code, @year, @cost);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.BuildingName);
            cmd.Parameters.AddWithValue("@code", this.BuildingCode);
            cmd.Parameters.AddWithValue("@year", this.YearAcquired);
            cmd.Parameters.AddWithValue("@cost", this.BuildingCost);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.BuildingID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE buildings set 
                                    BuildingName = @name, BuildingCode = @code, 
                                    YearAcquired = @year, BuildingCost = @cost 
                                WHERE BuildingID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@name", this.BuildingName);
            cmd.Parameters.AddWithValue("@code", this.BuildingCode);
            cmd.Parameters.AddWithValue("@year", this.YearAcquired);
            cmd.Parameters.AddWithValue("@cost", this.BuildingCost);
            cmd.Parameters.AddWithValue("@id", this.BuildingID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM buildings WHERE BuildingID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.BuildingID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Room> Rooms()
        {
            return Room.FindByBuildingId(this.BuildingID);
        }

        public IEnumerable<Office> Offices()
        {
            return Office.FindByBuildingID(this.BuildingID);
        }
    }
}