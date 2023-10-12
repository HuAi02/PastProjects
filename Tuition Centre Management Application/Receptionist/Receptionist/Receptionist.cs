using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_IOOP
{
    internal class Receptionist
    {
        private string username, password;

        public Receptionist(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public static string greetReceptionist(string username)
        {
            string name;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName from Users where Username = '" + username + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            name = reader.GetString(0) + " " + reader.GetString(1);
            return name;
        }

        public static ArrayList showdetails(string username, string password)
        {
            ArrayList list = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName, Email, Contact, Address, UserID from Users where (Username = '" + username + "' and Password = '" + password + "')", con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string name = rd.GetString(0).Trim() + " " + rd.GetString(1);
                list.Add(name);
                list.Add(rd.GetString(2));
                list.Add(rd.GetString(3));
                list.Add(rd.GetString(4));
                list.Add(rd.GetString(5));
            }
            return list;
        }

        public static void editProfile(string userid, string password, string email, string phonenum, string address)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            if (password != null)
            {
                SqlCommand cmd1 = new SqlCommand("update Users set Password = '" + password + "' where UserID = '" + userid + "'", con);
                cmd1.ExecuteNonQuery();
            }
            if (email != null)
            {
                SqlCommand cmd2 = new SqlCommand("update Users set Email = '" + email + "' where UserID = '" + userid + "'", con);
                cmd2.ExecuteNonQuery();
            }
            if (phonenum != null)
            {
                SqlCommand cmd3 = new SqlCommand("update Users set Contact = '" + phonenum + "' where UserID = '" + userid + "'", con);
                cmd3.ExecuteNonQuery();
            }
            if (address != null)
            {
                SqlCommand cmd4 = new SqlCommand("update Users set Address = '" + address + "' where UserID = '" + userid + "'", con);
                cmd4.ExecuteNonQuery();
            }
            MessageBox.Show("All changes saved.", "Success");
        }
    }
}
