using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Room
    {

        public static ICollection<Room> FindAll()
        {
            List<Room> rooms = new List<Room>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM rooms;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            c.Open();
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
            c.Close();
            return rooms;
        }

        public static Room FindById(int id)
        {

            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM rooms where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Room r = new Room();
            while (dr.Read())
            {
                r.Id = dr.GetInt32("id");
                r.Code = dr.GetString("code");
                r.BuildingId = dr.GetInt32("building_id");
            }
            c.Close();
            return r;
        }

        public static IEnumerable<Room> FindByBuildingId(int buidingId)
        {
            List<Room> rooms = new List<Room>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM rooms where building_id = @buidling_id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@buidling_id", buidingId);
            cmd.CommandType = System.Data.CommandType.Text;
            
            MySqlDataReader dr = cmd.ExecuteReader();
            Room r = null;

            while (dr.Read())
            {
                r = new Room();
                r.Id = dr.GetInt32("id");
                r.BuildingId = dr.GetInt32("building_id");
                r.Code = dr.GetString("code");
                rooms.Add(r);
            }
            c.Close();
            return rooms;
        }

        public static ICollection<Room> FindByDepartment(int departmentId)
        {
            List<Room> rooms = new List<Room>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM rooms where department_id;";
            cmd.CommandType = System.Data.CommandType.Text;
            c.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Room p = null;

            while (dr.Read())
            {
                p = new Room();
                p.Id = dr.GetInt32("id");
                p.BuildingId = dr.GetInt32("building_id");
                p.Code = dr.GetString("code");
                rooms.Add(p);
            }
            c.Close();
            return rooms;
        }

    }
}