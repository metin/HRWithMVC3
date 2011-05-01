using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Bug
    {

        public static ICollection<Bug> FindAll()
        {
            List<Bug> bugs = new List<Bug>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM PROJBUGS;";
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                bugs.Add(FillBug(dr));
            }
            c.Close();
            return bugs;
        }

        public static ICollection<Bug> FilterAll(string status, string type, int? ProjID)
        {
            List<Bug> bugs = new List<Bug>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM PROJBUGS WHERE 1=1 ";
            cmd.Prepare();
            if ((status != String.Empty) && (status != null))
            {
                cmd.CommandText += " AND Status = @Status";
                cmd.Parameters.AddWithValue("@Status", status);
            }
            if ((type != String.Empty) && (type != null))
            {
                cmd.CommandText += " AND Type = @Type";
                cmd.Parameters.AddWithValue("@Type", type);
            }
            if (ProjID.HasValue)
            {
                cmd.CommandText += " AND ProjID = @ProjID";
                cmd.Parameters.AddWithValue("@ProjID", ProjID);
            }
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bugs.Add(FillBug(dr));
            }
            c.Close();
            return bugs;
        }

        public static IEnumerable<Bug> FindByProjectID(int id)
        {
            List<Bug> bugs = new List<Bug>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM PROJBUGS where ProjID = @ProjID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Bug p = new Bug();
            while (dr.Read())
            {
                bugs.Add(FillBug(dr));
            }
            c.Close();
            return bugs;
        }

        public static Bug FindByID(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM PROJBUGS where BugID = @BugID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@BugID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Bug p = new Bug();
            while (dr.Read())
            {
                p = FillBug(dr);
            }
            c.Close();
            return p;
        }

        private static Bug FillBug(MySqlDataReader dr)
        {
            Bug b = new Bug();
            b.BugID = dr.GetInt32("BugID");
            b.ProjID = dr.GetInt32("ProjID"); 
            b.DateClosed = dr["DateClosed"] as DateTime?;
            b.DateReported = dr.GetDateTime("DateReported");
            b.Details = dr.GetString("Details");
            b.EmpID = dr["EmpID"] as int?;
            b.Type = dr["Type"] as string ;
            b.Status = dr["Status"] as string; 
            return b;
        }
    }
}