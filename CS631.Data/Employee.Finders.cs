using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Employee
    {
        public static IEnumerable<Employee> FindAll()
        { 
            List<Employee> l = new List<Employee>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();

            cmd.CommandText = "SELECT * FROM employees;" ;
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();
            Employee e = null;
            while(dr.Read())
            {
                e = new Employee();
                e.id = dr.GetInt32("id");
                e.EmpFName = dr.GetString("EmpFName");
                e.EmpMI = dr.GetString("EmpMI");
                e.EmpLName = dr.GetString("EmpLName");
                e.EmpTitle = dr.GetString("EmpTitle");
                e.EmpBuilding = dr.GetInt32("EmpBuilding");
                e.EmpOffice = dr.GetInt32("EmpOffice");
                e.EmpPhone = dr.GetInt32("EmpPhone");
                e.EmpDept = dr.GetInt32("EmpDept");
                e.EmpDiv = dr.GetInt32("EmpDiv");
                e.EmpType = dr.GetString("EmpType");
                e.HourRate = dr.GetInt32("HourRate");
                l.Add(e);
            }
            c.Close();
            return l;
        }

        public static Employee FindById(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open(); 
            cmd.CommandText = "SELECT * FROM employees where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Employee e = new Employee();
            while (dr.Read())
            {
                e.id = dr.GetInt32("id");
                e.EmpFName = dr.GetString("EmpFName");
                e.EmpMI = dr.GetString("EmpMI");
                e.EmpLName = dr.GetString("EmpLName");
                e.EmpTitle = dr.GetString("EmpTitle");
                e.EmpBuilding = dr.GetInt32("EmpBuilding");
                e.EmpOffice = dr.GetInt32("EmpOffice");
                e.EmpPhone = dr.GetInt32("EmpPhone");
                e.EmpDept = dr.GetInt32("EmpDept");
                e.EmpDiv = dr.GetInt32("EmpDiv");
                e.EmpType = dr.GetString("EmpType");
                e.HourRate = dr.GetInt32("HourRate");
            }
            c.Close();
            return e;
        }

    }
}