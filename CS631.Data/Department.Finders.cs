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
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                p.DeptHead = dr.GetInt32("DeptHead");
                p.DivId = dr.GetInt32("DivId");
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
            cmd.CommandText = "SELECT * FROM Departments where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department d = new Department();
            while (dr.Read())
            {
                d.id = dr.GetInt32("id");
                d.name = dr.GetString("name");
                d.DeptHead = dr.GetInt32("DeptHead");
                d.DivId = dr.GetInt32("DivId");
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
            cmd.CommandText = "SELECT * FROM Departments  where DivId = @DivId;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@DivId", DivId);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Department p = null;

            while (dr.Read())
            {
                p = new Department();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                p.DeptHead = dr.GetInt32("DeptHead");
                p.DivId = dr.GetInt32("DivId");
                Departments.Add(p);
            }
            c.Close();
            return Departments;
        }

    }
}