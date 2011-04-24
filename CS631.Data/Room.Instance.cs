using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Room
    {


        public Room Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO rooms (building_id, code) VALUES(@building_id, @code);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@code", this.Code);
            cmd.Parameters.AddWithValue("@building_id", this.BuildingId);
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
            cmd.CommandText = "UPDATE rooms set building_id = @building_id, code = @code WHERE id = @id;";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@code", this.Code);
            cmd.Parameters.AddWithValue("@building_id", this.BuildingId);

            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM rooms WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}