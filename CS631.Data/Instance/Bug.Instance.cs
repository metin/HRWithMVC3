using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Bug
    {


        public Bug Save()
        {

            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO PROJBUGS 
                                (ProjID, Details, DateReported, DateClosed, Status, EmpID, Type) 
                               VALUES
                                (@ProjID, @Details, @DateReported, @DateClosed, @Status, @EmpID, @Type);";

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@Details", this.Details);
            cmd.Parameters.AddWithValue("@DateReported", this.DateReported);
            cmd.Parameters.AddWithValue("@DateClosed", this.DateClosed); 
            cmd.Parameters.AddWithValue("@Status", this.Status);
            cmd.Parameters.AddWithValue("@Type", this.Type);
            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.ProjID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public Bug Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE PROJBUGS SET 
                                    ProjID = @ProjID, Details = @Details, Type = @Type,
                                    DateReported = @DateReported, Status = @Status,
                                    EmpID = @EmpID, DateClosed = @DateClosed
                                WHERE BugID = @BugID;";

            cmd.Prepare();
            cmd.Parameters.AddWithValue("@ProjID", this.ProjID);
            cmd.Parameters.AddWithValue("@Details", this.Details);
            cmd.Parameters.AddWithValue("@DateReported", this.DateReported);
            cmd.Parameters.AddWithValue("@Status", this.Status);
            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            cmd.Parameters.AddWithValue("@Type", this.Type);
            cmd.Parameters.AddWithValue("@DateClosed", this.DateClosed); 

            cmd.Parameters.AddWithValue("@BugID", this.BugID);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            return this;
        }


        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM PROJBUGS WHERE BugID = @BugID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@BugID", this.BugID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}