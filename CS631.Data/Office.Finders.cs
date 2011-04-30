using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Office
    {

        public static ICollection<Office> FindAll()
        {
            List<Office> rooms = new List<Office>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM offices;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            c.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Office p = null;
            
            while(dr.Read())
            {
                p = new Office();
                p.OfficeID = dr.GetInt32("OfficeID");
                p.OfficeNumber = dr.GetString("OfficeNumber");
                p.RoomType = dr.GetString("RoomType");
                p.Area = dr.GetDecimal("Area");
                p.BuildingID = dr.GetInt32("BuildingID");
                p.DeptID = dr.GetInt32("DeptID");
                rooms.Add(p);
            }
            c.Close();
            return rooms;
        }

        public static Office FindById(int id)
        {

            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM offices where OfficeID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Office p = new Office();
            while (dr.Read())
            {
                p.OfficeID = dr.GetInt32("OfficeID");
                p.OfficeNumber = dr.GetString("OfficeNumber");
                p.RoomType = dr.GetString("RoomType");
                p.Area = dr.GetDecimal("Area");
                p.BuildingID = dr.GetInt32("BuildingID");
                p.DeptID = dr.GetInt32("DeptID"); ;
            }
            c.Close();
            return p;
        }

        public static IEnumerable<Office> FindByBuildingID(int buidingId)
        {
            List<Office> rooms = new List<Office>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM offices where BuildingID = @BuildingID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@BuildingID", buidingId);
            cmd.CommandType = System.Data.CommandType.Text;
            
            MySqlDataReader dr = cmd.ExecuteReader();
            Office p = null;

            while (dr.Read())
            {
                p = new Office();
                p.OfficeID = dr.GetInt32("OfficeID");
                p.OfficeNumber = dr.GetString("OfficeNumber");
                p.RoomType = dr.GetString("RoomType");
                p.Area = dr.GetDecimal("Area");
                p.BuildingID = dr.GetInt32("BuildingID");
                p.DeptID = dr.GetInt32("DeptID"); ;
                rooms.Add(p);
            }
            c.Close();
            return rooms;
        }

        public static ICollection<Office> FindByDepartment(int departmentId)
        {
            List<Office> rooms = new List<Office>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM offices where DeptID=@DeptID;";
            cmd.CommandType = System.Data.CommandType.Text;
            c.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            Office p = null;

            while (dr.Read())
            {
                p = new Office();
                p.OfficeID = dr.GetInt32("OfficeID");
                p.OfficeNumber = dr.GetString("OfficeNumber");
                p.RoomType = dr.GetString("RoomType");
                p.Area = dr.GetDecimal("Area");
                p.BuildingID = dr.GetInt32("BuildingID");
                p.DeptID = dr.GetInt32("DeptID"); ;
                rooms.Add(p);
            }
            c.Close();
            return rooms;
        }

    }
}