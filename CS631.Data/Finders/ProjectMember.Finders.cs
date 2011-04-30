using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class ProjectMember
    {

        public static ProjectMember FindByID(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * 
                                FROM empprojects 
                                WHERE EmpProj = @EmpProj
                                LIMIT 1;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpProj", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            ProjectMember p = new ProjectMember();
            while (dr.Read())
            {
                p = FillProjectMember(dr);
            }
            c.Close();
            return p;
        }

        public static IEnumerable<ProjectMember> FindByProjectID(int id, MembershipStatus status)
        {
            List<ProjectMember> milestones = new List<ProjectMember>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * FROM empprojects where ProjID = @ProjID";
            if (status == MembershipStatus.Current)
            {
                cmd.CommandText += " AND EndDate IS NULL;";
            }
            else if (status == MembershipStatus.Ended)
            {
                cmd.CommandText += " AND EndDate IS NOT NULL;";
            }
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            ProjectMember p = new ProjectMember();
            while (dr.Read())
            {
                p = FillProjectMember(dr);
                milestones.Add(p);
            }
            c.Close();
            return milestones;
        }


        private static ProjectMember FillProjectMember(MySqlDataReader dr)
        {
            ProjectMember p = new ProjectMember();
            p = new ProjectMember();
            p.EmpProj = dr.GetInt32("EmpProj");
            p.ProjID = dr.GetInt32("ProjID");
            p.EmpID = dr.GetInt32("EmpID");
            p.Role = dr.GetString("Role");
            p.TotalHours = dr.GetDecimal("TotalHours");
            p.StartDate = dr.GetDateTime("StartDate");
            p.EndDate = dr["EndDate"] as DateTime?;
            return p;
        }

    }
}