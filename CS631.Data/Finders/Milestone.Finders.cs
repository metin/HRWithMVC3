using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Milestone
    {

        public static ICollection<Milestone> FindAll()
        {
            List<Milestone> milestones = new List<Milestone>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM projmilestones;";
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();
            Milestone p = null;
            while(dr.Read())
            {
                p = new Milestone();
                p.MilestoneID = dr.GetInt32("MilestoneID");
                p.ProjID = dr.GetInt32("ProjID");
                p.MilestoneDeliverable = dr.GetString("MilestoneDeliverable");
                p.MilestonePlannedDate = dr.GetDateTime("MilestonePlannedDate");
                p.MilestoneDeliveryDate = dr["MilestoneDeliveryDate"] as DateTime?;
                p.ToBeDelivered = dr["ToBeDelivered"] as string;
                milestones.Add(p);
            }
            c.Close();
            return milestones;
        }

        public static IEnumerable<Milestone> FindByProjectID(int id)
        {
            List<Milestone> milestones = new List<Milestone>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM projmilestones where ProjID = @ProjID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Milestone p = new Milestone();
            while (dr.Read())
            {
                p = new Milestone();
                p.MilestoneID = dr.GetInt32("MilestoneID");
                p.ProjID = dr.GetInt32("ProjID");
                p.MilestoneDeliverable = dr.GetString("MilestoneDeliverable");
                p.MilestonePlannedDate = dr.GetDateTime("MilestonePlannedDate");
                p.MilestoneDeliveryDate = dr["MilestoneDeliveryDate"] as DateTime?;
                p.ToBeDelivered = dr["ToBeDelivered"] as string;
                milestones.Add(p);
            }
            c.Close();
            return milestones;
        }

        public static Milestone FindByID(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM projmilestones where MilestoneID = @MilestoneID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@MilestoneID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Milestone p = new Milestone();
            while (dr.Read())
            {
                p.MilestoneID = dr.GetInt32("MilestoneID");
                p.ProjID = dr.GetInt32("ProjID");
                p.MilestoneDeliverable = dr.GetString("MilestoneDeliverable");
                p.MilestonePlannedDate = dr.GetDateTime("MilestonePlannedDate");
                p.MilestoneDeliveryDate = dr["MilestoneDeliveryDate"] as DateTime?;
                p.ToBeDelivered = dr["ToBeDelivered"] as string;
            }
            c.Close();
            return p;
        }


    }
}