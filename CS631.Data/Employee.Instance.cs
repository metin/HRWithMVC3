using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Employee
    {

        public Employee Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO employees 
                                (EmpFName, EmpMI, EmpLName, EmpTitle, EmpBuilding, EmpOffice, 
                                    EmpPhone, EmpDept, EmpDiv, EmpType, HourRate) 
                                VALUES
                                (@EmpFName, @EmpMI, @EmpLName, @EmpTitle, @EmpBuilding, @EmpOffice, 
                                    @EmpPhone, @EmpDept, @EmpDiv, @EmpType, @HourRate)";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpFName", this.EmpFName);
            cmd.Parameters.AddWithValue("@EmpMI", this.EmpMI);
            cmd.Parameters.AddWithValue("@EmpLName", this.EmpLName);
            cmd.Parameters.AddWithValue("@EmpTitle", this.EmpTitle);
            cmd.Parameters.AddWithValue("@EmpBuilding", this.EmpBuilding);
            cmd.Parameters.AddWithValue("@EmpOffice", this.EmpOffice);
            cmd.Parameters.AddWithValue("@EmpPhone", this.EmpPhone);
            cmd.Parameters.AddWithValue("@EmpDept", this.EmpDept);
            cmd.Parameters.AddWithValue("@EmpDiv", this.EmpDiv);
            cmd.Parameters.AddWithValue("@EmpType", this.EmpType);
            cmd.Parameters.AddWithValue("@HourRate", this.HourRate);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.id = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }

        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE employees set 
                                    EmpFName = @EmpFName, EmpMI = @EmpMI,
                                    EmpLName = @EmpLName, EmpTitle = @EmpTitle, 
                                    EmpBuilding = @EmpBuilding, EmpOffice = @EmpOffice,
                                    EmpPhone = @EmpPhone, EmpDept = @EmpDept,
                                    EmpDiv = @EmpDiv, EmpType = @EmpType,
                                    HourRate = @HourRate
 
                               WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpFName", this.EmpFName);
            cmd.Parameters.AddWithValue("@EmpMI", this.EmpMI);
            cmd.Parameters.AddWithValue("@EmpLName", this.EmpLName);
            cmd.Parameters.AddWithValue("@EmpTitle", this.EmpTitle);
            cmd.Parameters.AddWithValue("@EmpBuilding", this.EmpBuilding);
            cmd.Parameters.AddWithValue("@EmpOffice", this.EmpOffice);
            cmd.Parameters.AddWithValue("@EmpPhone", this.EmpPhone);
            cmd.Parameters.AddWithValue("@EmpDept", this.EmpDept);
            cmd.Parameters.AddWithValue("@EmpDiv", this.EmpDiv);
            cmd.Parameters.AddWithValue("@EmpType", this.EmpType);
            cmd.Parameters.AddWithValue("@HourRate", this.HourRate);

            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM employees WHERE id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.id);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

    }
}