using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Project
    {


        public Project Save()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO projects 
                                (ProjName, StartDate, EndDate, ProjBudget, ProjDept) 
                               VALUES
                                (@ProjName, @StartDate, @EndDate, @ProjBudget, @ProjDept);"; 

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjName", this.ProjName);
            cmd.Parameters.AddWithValue("@StartDate", this.StartDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@EndDate", this.EndDate);
            cmd.Parameters.AddWithValue("@ProjBudget", this.ProjBudget);
            cmd.Parameters.AddWithValue("@ProjDept", this.ProjDept);
            
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.ProjID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public Project Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE projects SET 
                                    ProjName = @ProjName, StartDate = @StartDate, 
                                    EndDate = @EndDate, ProjBudget = @ProjBudget,
                                    ProjDept = @ProjDept
                                WHERE ProjID = @ProjID;";

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjName", this.ProjName);
            cmd.Parameters.AddWithValue("@StartDate", this.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", this.EndDate);
            cmd.Parameters.AddWithValue("@ProjBudget", this.ProjBudget);
            cmd.Parameters.AddWithValue("@ProjDept", this.ProjDept);
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            return this;
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM projects WHERE ProjID = @ProjID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Milestone> Milestones()
        {
            return Milestone.FindByProjectID(this.ProjID);
        }

        public IEnumerable<ProjectMember> Members(ProjectMember.MembershipStatus status)
        {
            return ProjectMember.FindByProjectID(this.ProjID, status);
        }
    }
}