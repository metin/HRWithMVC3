using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class ProjectMember
    {

        public static IEnumerable<ProjectMember> FindByProjectID(int id)
        {
            List<ProjectMember> milestones = new List<ProjectMember>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM empprojects where ProjID = @ProjID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            ProjectMember p = new ProjectMember();
            while (dr.Read())
            {
                p = new ProjectMember();
                p.EmpProj = dr.GetInt32("EmpProj");
                p.ProjID = dr.GetInt32("ProjID");
                p.EmpID = dr.GetInt32("EmpID");
                p.Role = dr.GetString("Role");
                p.TotalHours = dr.GetDecimal("TotalHours");
                p.StartDate = dr.GetDateTime("StartDate");

                milestones.Add(p);
            }
            c.Close();
            return milestones;
        }

        public static ProjectMember FindByID(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM empprojects where MilestoneID = @MilestoneID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@MilestoneID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            ProjectMember p = new ProjectMember();
            while (dr.Read())
            {
                p.EmpProj = dr.GetInt32("EmpProj");
                p.ProjID = dr.GetInt32("ProjID");
                p.EmpID = dr.GetInt32("EmpID");
                p.Role = dr.GetString("Role");
                p.TotalHours = dr.GetDecimal("TotalHours");
                p.StartDate = dr.GetDateTime("StartDate");
            }
            c.Close();
            return p;
        }

    }
}