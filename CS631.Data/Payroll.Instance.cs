using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Payroll
    {

        public Payroll Save()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO PAYROLLHISTORY 
                                (EmpID, PayDate, MonthHours, MonthSalary, FedTax, StateTax, OtherTax, NetPay) 
                                VALUES
                                (@EmpID, @PayDate, @MonthHours, @MonthSalary, @FedTax, @StateTax, @OtherTax, @NetPay);";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", this.EmpID);
            cmd.Parameters.AddWithValue("@PayDate", this.PayDate);
            cmd.Parameters.AddWithValue("@MonthHours", this.MonthHours);
            cmd.Parameters.AddWithValue("@MonthSalary", this.MonthSalary);
            cmd.Parameters.AddWithValue("@FedTax", this.FedTax);
            cmd.Parameters.AddWithValue("@StateTax", this.StateTax);
            cmd.Parameters.AddWithValue("@OtherTax", this.OtherTax);
            cmd.Parameters.AddWithValue("@NetPay", this.NetPay);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT LAST_INSERT_ID();";
            this.EmpID = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return this;
        }
/*
        public void Update()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"UPDATE employees set 
                                    EmpID = @EmpID, EmpMI = @EmpMI,
                                    EmpLName = @EmpLName, EmpTitle = @EmpTitle, 
                                    EmpBuilding = @EmpBuilding, EmpOffice = @EmpOffice,
                                    EmpPhone = @EmpPhone, EmpDept = @EmpDept,
                                    EmpDiv = @EmpDiv, EmpType = @EmpType,
                                    HourRate = @HourRate
 
                               WHERE EmpID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpFName", this.EmpFName);
            cmd.Parameters.AddWithValue("@EmpMI", (this.EmpMI==null ? " " : this.EmpMI));
            cmd.Parameters.AddWithValue("@EmpLName", this.EmpLName);
            cmd.Parameters.AddWithValue("@EmpTitle", this.EmpTitle);
            cmd.Parameters.AddWithValue("@EmpBuilding", this.EmpBuilding);
            cmd.Parameters.AddWithValue("@EmpOffice", this.EmpOffice);
            cmd.Parameters.AddWithValue("@EmpPhone", this.EmpPhone);
            cmd.Parameters.AddWithValue("@EmpDept", this.EmpDept);
            cmd.Parameters.AddWithValue("@EmpDiv", this.EmpDiv);
            cmd.Parameters.AddWithValue("@EmpType", this.EmpType);
            cmd.Parameters.AddWithValue("@HourRate", this.HourRate);

            cmd.Parameters.AddWithValue("@id", this.EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete()
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM employees WHERE EmpID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", this.EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
 * */

    }
}