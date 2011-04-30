using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Payroll
    {


        public static Payroll FindLatestByEmpID(int EmpID)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * 
                                FROM PAYROLLHISTORY 
                                WHERE EmpID = @EmpID
                                ORDER BY PayDate DESC
                                LIMIT 1;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Payroll d = new Payroll();
            while (dr.Read())
            {
                d.EmpID = dr.GetInt32("EmpID");
                d.PayDate = dr.GetDateTime("PayDate");
                d.MonthSalary = dr.GetDecimal("MonthSalary");
                d.MonthHours = dr["MonthHours"] as int?;
                d.FedTax = dr.GetDecimal("FedTax");
                d.StateTax = dr.GetDecimal("StateTax");
                d.OtherTax = dr["OtherTax"] as decimal?;
                d.NetPay = dr.GetDecimal("NetPay");
            }
            c.Close();
            return d;
        }

        public static ICollection<Payroll> FindAllByEmpID(int EmpID)
        {
            List<Payroll> salaries = new List<Payroll>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * 
                                FROM PAYROLLHISTORY 
                                WHERE EmpID = @EmpID
                                ORDER BY PayDate DESC;"; 
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Payroll d = null;

            while (dr.Read())
            {
                d = new Payroll();
                d.EmpID = dr.GetInt32("EmpID");
                d.PayDate = dr.GetDateTime("PayDate");
                d.MonthSalary = dr.GetDecimal("MonthSalary");
                d.MonthHours = dr["MonthHours"] as int?;
                d.FedTax = dr.GetDecimal("FedTax");
                d.StateTax = dr.GetDecimal("StateTax");
                d.OtherTax = dr["OtherTax"] as decimal?;
                d.NetPay = dr.GetDecimal("NetPay");
                salaries.Add(d);
            }
            c.Close();
            return salaries;
        }

    }
}