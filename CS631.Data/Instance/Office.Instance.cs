using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Office
    {


        public Office Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO offices 
                                    (BuildingID, OfficeNumber, Area, DeptID, RoomType) 
                                VALUES
                                    (@BuildingID, @OfficeNumber, @Area, @DeptID, @RoomType) ;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@BuildingID", this.BuildingID);
            cmd.Parameters.AddWithValue("@OfficeNumber", this.OfficeNumber);
            cmd.Parameters.AddWithValue("@Area", this.Area);
            cmd.Parameters.AddWithValue("@DeptID", this.DeptID);
            cmd.Parameters.AddWithValue("@RoomType", this.RoomType);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.OfficeID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE offices 
                                SET BuildingID = @BuildingID, OfficeNumber = @OfficeNumber, 
                                    Area=@Area, DeptID=@DeptID, RoomType=@RoomType 
                                WHERE
                                    OfficeID = @OfficeID ;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@BuildingID", this.BuildingID);
            cmd.Parameters.AddWithValue("@OfficeNumber", this.OfficeNumber);
            cmd.Parameters.AddWithValue("@Area", this.Area);
            cmd.Parameters.AddWithValue("@DeptID", this.DeptID);
            cmd.Parameters.AddWithValue("@RoomType", this.RoomType);
            cmd.Parameters.AddWithValue("@OfficeID", this.OfficeID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM offices WHERE OfficeID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.OfficeID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}