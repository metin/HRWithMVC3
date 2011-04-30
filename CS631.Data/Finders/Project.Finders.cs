using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Project
    {

        public static ICollection<Project> FindAll()
        {
            List<Project> projects = new List<Project>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM projects;" ;
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();
            Project p = null;
            while(dr.Read())
            {
                p = new Project();
                p.ProjID = dr.GetInt32("ProjID");
                p.ProjName = dr.GetString("ProjName");
                p.StartDate = dr.GetDateTime("StartDate");
                p.EndDate = dr["EndDate"] as DateTime?;
                p.ProjBudget = dr.GetDecimal("ProjBudget");
                p.ProjDept = dr.GetInt32("ProjDept");
                p.ProjManager = dr.GetInt32("ProjManager");
                projects.Add(p);
            }
            c.Close();
            return projects;
        }

        public static Project FindById(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM projects where ProjID = @ProjID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Project p = new Project();
            while (dr.Read())
            {
                p.ProjID = dr.GetInt32("ProjID");
                p.ProjName = dr.GetString("ProjName");
                p.StartDate = dr.GetDateTime("StartDate");
                p.EndDate = dr["EndDate"] as DateTime?;
                p.ProjBudget = dr.GetDecimal("ProjBudget");
                p.ProjDept = dr.GetInt32("ProjDept");
                p.ProjManager = dr.GetInt32("ProjManager");
            }
            c.Close();
            return p;
        }


    }
}