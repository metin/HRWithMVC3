using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Milestone
    {


        public Milestone Save()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO projmilestones 
                                (ProjID, MilestonePlannedDate, MilestoneDeliverable, MilestoneDeliveryDate, ToBeDelivered) 
                               VALUES
                                (@ProjID, @MilestonePlannedDate, @MilestoneDeliverable, @MilestoneDeliveryDate, @ToBeDelivered);"; 

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@MilestonePlannedDate", this.MilestonePlannedDate);
            cmd.Parameters.AddWithValue("@MilestoneDeliverable", this.MilestoneDeliverable);
            cmd.Parameters.AddWithValue("@MilestoneDeliveryDate", this.MilestoneDeliveryDate);
            cmd.Parameters.AddWithValue("@ToBeDelivered", this.ToBeDelivered);
            
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.ProjID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public Milestone Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE projmilestones SET 
                                    ProjID = @ProjID, MilestonePlannedDate = @MilestonePlannedDate, 
                                    MilestoneDeliverable = @MilestoneDeliverable, MilestoneDeliveryDate = @MilestoneDeliveryDate,
                                    ToBeDelivered = @ToBeDelivered
                                WHERE MilestoneID = @MilestoneID;";

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@MilestonePlannedDate", this.MilestonePlannedDate);
            cmd.Parameters.AddWithValue("@MilestoneDeliverable", this.MilestoneDeliverable);
            cmd.Parameters.AddWithValue("@MilestoneDeliveryDate", this.MilestoneDeliveryDate);
            cmd.Parameters.AddWithValue("@ToBeDelivered", this.ToBeDelivered);
            cmd.Parameters.AddWithValue("@MilestoneID", this.MilestoneID);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            return this;
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM projmilestones WHERE MilestoneID = @MilestoneID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@MilestoneID", this.MilestoneID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}