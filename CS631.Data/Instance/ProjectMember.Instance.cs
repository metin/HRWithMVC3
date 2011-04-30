using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class ProjectMember
    {

        public ProjectMember Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO empprojects 
                                    (EmpID, ProjID, Role, TotalHours, StartDate) 
                                VALUES
                                    (@EmpID, @ProjID, @Role, @TotalHours, NOW());";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@Role", this.Role);
            cmd.Parameters.AddWithValue("@TotalHours", this.TotalHours);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.EmpProj = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE empprojects 
                                SET 
                                    EmpID = @EmpID, ProjID = @ProjID, Role = @Role, TotalHours = @TotalHours 
                                WHERE EmpProj = @EmpProj;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@Role", this.Role);
            cmd.Parameters.AddWithValue("@TotalHours", this.TotalHours);

            cmd.Parameters.AddWithValue("@EmpProj", this.EmpProj);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM empprojects WHERE EmpProj = @EmpProj;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpProj", this.EmpProj);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Finish()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE empprojects 
                                SET EndDate = NOW() 
                                WHERE EmpProj = @EmpProj;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpProj", this.EmpProj);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Employee EmployeeObj()
        {
            return Employee.FindById(this.EmpID);
        }

        public Project ProjectObj()
        {
            return Project.FindById(this.ProjID);
        }
    }
}