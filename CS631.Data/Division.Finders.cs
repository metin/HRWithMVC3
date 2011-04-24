using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CS631.Data
{
    public partial class Division
    {

        public static IEnumerable<Division> FindAll()
        {
            List<Division> divisions = new List<Division>();
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open();
            cmd.CommandText = "SELECT * FROM Divisions;";
            cmd.CommandType = System.Data.CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();
            Division p = null;
            while(dr.Read())
            {
                p = new Division();
                p.id = dr.GetInt32("id");
                p.name = dr.GetString("name");
                divisions.Add(p);
            }
            c.Close();
            return divisions;
        }

        public static Division FindByID(int id)
        {
            MySqlConnection c = getConnection();
            MySqlCommand cmd = c.CreateCommand();
            c.Open(); 

            cmd.CommandText = "SELECT * FROM Divisions where id = @id;";
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            Division d = new Division();
            while (dr.Read())
            {
                d.id = dr.GetInt32("id");
                d.name = dr.GetString("name");
            }
            c.Close();
            return d;
        }


    }
}