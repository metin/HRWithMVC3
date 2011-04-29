using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Department
    {

        public static ICollection<Department> FindAll()
        {
            List<Department> Departments = new List<Department>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM Departments;" ;
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department p = null;
            
            while(dr.Read())
            {
                p = new Department();
                p.DeptID = dr.GetInt32("DeptID");
                p.DeptName = dr.GetString("DeptName");
                p.DeptHead = dr.GetInt32("DeptHead");
                p.DivID = dr.GetInt32("DivID");
                Departments.Add(p);
            }
            c.Close();
            return Departments;
        }

        public static Department FindById(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM Departments where DeptID = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department d = new Department();
            while (dr.Read())
            {
                d.DeptID = dr.GetInt32("DeptID");
                d.DeptName = dr.GetString("DeptName");
                d.DeptHead = dr.GetInt32("DeptHead");
                d.DivID = dr.GetInt32("DivId");
            }
            c.Close();
            return d;
        }

        public static ICollection<Department> FindByDivisionID(int DivId)
        {
            List<Department> Departments = new List<Department>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM Departments  where DivID = @DivID;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@DivID", DivId);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department p = null;

            while (dr.Read())
            {
                p = new Department();
                p.DeptID = dr.GetInt32("DeptID");
                p.DeptName = dr.GetString("DeptName");
                p.DeptHead = dr.GetInt32("DeptHead");
                p.DivID = dr.GetInt32("DivId");
                Departments.Add(p);
            }
            c.Close();
            return Departments;
        }

    }
}