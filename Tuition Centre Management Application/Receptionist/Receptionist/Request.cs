using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_IOOP
{
    internal class Request
    {
        private string reqid, oldsub, newsub, name;

        public string Reqid { get => reqid; set => reqid = value; }
        public string Oldsub { get => oldsub; set => oldsub = value; }
        public string Newsub { get => newsub; set => newsub = value; }
        public string Name { get => name; set => name = value; }

        public Request(string reqid, string name)
        {
            this.reqid = reqid;
            this.name = name;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select OldSubj, NewSubj from Request where (RequestID = '" + reqid + "')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.oldsub = reader.GetString(0);
                this.newsub = reader.GetString(1);
            }
            con.Close();
        }

        public static ArrayList viewReqID()
        {
            ArrayList ide = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select RequestID from Request", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ide.Add(reader.GetString(0));
            }
            con.Close();
            return ide;
        }

        public static string viewReq(string requestid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName from Users where UserID in (select UserID from Request where (RequestID = '" + requestid + "'))", con);
            SqlDataReader reader = cmd.ExecuteReader();
            string name = string.Empty;
            while (reader.Read())
            {
                name = reader.GetString(0) + " " + reader.GetString(1);
            }
            con.Close();
            return name;
        }

        public static ArrayList searchReqID(string keyword)
        {
            ArrayList ide = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select RequestID from Request where (RequestID like '" + keyword + "' or UserID in (select UserID from Users where (FirstName like '" + keyword + "' or LastName like '" + keyword + "')))", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ide.Add(reader.GetString(0));
            }
            con.Close();
            return ide;
        }

        public static void acceptReq(string requestid, string oldsub, string newsub)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select Subject1, Subject2, Subject3 from Users where UserID in (select UserID from Request where RequestID = '" + requestid + "')", con);
            SqlDataReader subjects = cmd.ExecuteReader();
            ArrayList subs = new ArrayList();
            while (subjects.Read())
            {
                string sub1 = subjects.IsDBNull("Subject1") ? "None" : subjects.GetString("Subject1");
                string sub2 = subjects.IsDBNull("Subject2") ? "None" : subjects.GetString("Subject2");
                string sub3 = subjects.IsDBNull("Subject3") ? "None" : subjects.GetString("Subject3");
                subs.Add(sub1);
                subs.Add(sub2);
                subs.Add(sub3);
                MessageBox.Show(sub1 + sub2 + sub3);
            }
            MessageBox.Show(subs[0].ToString() + subs[1].ToString() + subs[2].ToString());
            
            SqlCommand delete = new SqlCommand("delete from Request where (RequestID = '" + requestid + "')", con);
            subjects.Close();
            int count = delete.ExecuteNonQuery();
            if (subs[0].ToString() == oldsub)
            {
                SqlCommand change1 = new SqlCommand("update Users set Subject1 = '" + newsub + "'", con);
                change1.ExecuteNonQuery();
                MessageBox.Show("Request has been accepted.", "Success");
            }
            else if (subs[1].ToString() == oldsub)
            {
                SqlCommand change2 = new SqlCommand("update Users set Subject2 = '" + newsub + "'", con);
                change2.ExecuteNonQuery();
                MessageBox.Show("Request has been accepted.", "Success");
            }
            else if (subs[2].ToString() == oldsub)
            {
                SqlCommand change3 = new SqlCommand("update Users set Subject3 = '" + newsub + "'", con);
                change3.ExecuteNonQuery();
                MessageBox.Show("Request has been accepted.", "Success");
            }
            else
                MessageBox.Show("This request is incorrect or outdated.", "Error: Please check again");
        }

        public static void rejectreq(string requestid)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand delete = new SqlCommand("delete from Request where (RequestID = '" + requestid + "')", con);
            int count = delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Request has been rejected.", "Success");
        }
    }
}
