using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Room
    {

        public ICollection<Room> All()
        {
            List<Room> rooms = new List<Room>();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM rooms;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Room p = null;
            
            while(dr.Read())
            {
                p = new Room();
                p.Id = dr.GetInt32("id");
                p.BuildingId = dr.GetInt32("building_id");
                p.Code = dr.GetString("code");
                rooms.Add(p);
            }
            connection.Close();
            return rooms;
        }

        public Room FindById(int id)
        {
            this.Id = id;
            return Load();
        }

        public Room Load()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM rooms where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.Id = dr.GetInt32("id");
                this.Code = dr.GetString("code");
                this.BuildingId = dr.GetInt32("building_id");
            }
            connection.Close();
            return this;
        }

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