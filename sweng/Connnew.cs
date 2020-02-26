using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sweng
{
    class Connnew
    {

        public static MySqlConnection con = new MySqlConnection("server=localhost; database=posn; username=root; password=;");
        public static MySqlCommand poscmd = new MySqlCommand();
        public static MySqlDataReader dr;
        public static void DbSearch(string txt)
        {

            con.Close();
            poscmd.Connection = con;
            poscmd.CommandText = txt;
            con.Open();
            dr = poscmd.ExecuteReader();



        }

        public static void DbUpdate(string txt)
        {
            con.Close();
            poscmd.Connection = con;
            poscmd.CommandText = txt;
            con.Open();
            poscmd.ExecuteNonQuery();

            

        }
    }
}
