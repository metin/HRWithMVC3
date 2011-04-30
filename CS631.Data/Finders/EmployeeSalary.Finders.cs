using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class EmployeeSalary
    {


        public static EmployeeSalary FindLatestByEmpID(int EmpID)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * 
                                FROM EMPSALARIES 
                                WHERE EmpID = @EmpID
                                ORDER BY SalaryStartDate DESC
                                LIMIT 1;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            EmployeeSalary d = new EmployeeSalary();
            while (dr.Read())
            {
                d.EmpID = dr.GetInt32("EmpID");
                d.AnnualSalary = dr.GetDecimal("AnnualSalary");
                d.SalaryStartDate = dr.GetDateTime("SalaryStartDate");
            }
            c.Close();
            return d;
        }

        public static ICollection<EmployeeSalary> FindAllByEmpID(int EmpID)
        {
            List<EmployeeSalary> salaries = new List<EmployeeSalary>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = @"SELECT * 
                                FROM EMPSALARIES 
                                WHERE EmpID = @EmpID
                                ORDER BY SalaryStartDate DESC;"; 
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            EmployeeSalary p = null;

            while (dr.Read())
            {
                p = new EmployeeSalary();
                p.EmpID = dr.GetInt32("EmpID");
                p.AnnualSalary = dr.GetDecimal("AnnualSalary");
                p.SalaryStartDate = dr.GetDateTime("SalaryStartDate");
                salaries.Add(p);
            }
            c.Close();
            return salaries;
        }

    }
}