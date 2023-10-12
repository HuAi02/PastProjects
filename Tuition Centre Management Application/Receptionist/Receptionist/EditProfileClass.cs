using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Group1_IOOP
{
    internal class admin
    {
        private string username;
        private string password;
        private string email;
        private string userID;



        public admin(string n, string p, string e, string u)
        {
            Username = n;
            Password = p;
            Email = e;
            UserID = u;
        }
        public static void hello(string n, string p, string e)
        {
        }

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }

        public string Email { get => email; set => email = value; }
        public string UserID { get => userID; set => userID = value; }

        // generate a edit profile method.
        public static void updateprofile(string n, string p, string e, string u)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
         

            if (n != null)
            {
               SqlCommand cmd1 = new SqlCommand("update Users set Username = '" + n + "' where UserID = '" + u + "'", con);
                cmd1.ExecuteNonQuery();
               MessageBox.Show("update done.");
            }
            if (p != null)
            {
                SqlCommand cmd2 = new SqlCommand("update Users set Password = '" + p + "' where UserID = '" + u + "'", con);
                cmd2.ExecuteNonQuery();
            }
            if (e != null)
            {
                SqlCommand cmd3 = new SqlCommand("update Users set Email = '" + e + "' where UserID = '" + u + "'", con);
                cmd3.ExecuteNonQuery();
            }
            con.Close();
        }
        // get userID
        public static string user(string username)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd1 = new SqlCommand("select UserID from Users where username = '"+username+"'", con);
            string usr = cmd1.ExecuteScalar().ToString();
            return usr;
        }
    }
}
