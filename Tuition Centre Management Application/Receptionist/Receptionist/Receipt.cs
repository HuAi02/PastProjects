using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Group1_IOOP
{
    internal class Receipt
    {
        private string userid, amount;

        public Receipt(string userid, string amount)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand newcmd1 = new SqlCommand("select count(*) as rownum from Receipt", con);
            string test = newcmd1.ExecuteScalar().ToString();
            string temp;
            if (test != "0")
            {
                SqlCommand newcmd = new SqlCommand("select ReceiptID from Receipt order by len(ReceiptID) DESC, ReceiptID DESC", con); //attempt to find the largest user id from database
                temp = newcmd.ExecuteScalar().ToString(); // convert sql command output to string
                string temp1 = temp.Substring(1); //get the numbers in id only
                int IDitself = Convert.ToInt32(temp1); //removing the prefix from user id
                IDitself += 1; // add one to the largest id number
                temp = temp.Substring(0, 1) + IDitself.ToString();
            }
            else
            {
                temp = "P1";
            }
            DateTime dt = DateTime.Now;
            string date = dt.ToString("d");
            SqlCommand cmd = new SqlCommand("insert into Receipt (ReceiptID, UserID, Date, Charges) values (@receiptid, @userid, '" + date + "', @amount)", con);
            cmd.Parameters.AddWithValue("@receiptid", temp);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@amount", amount);

            int count = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }
        public static ArrayList getnames()
        {
            ArrayList namelist = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand newcmd1 = new SqlCommand("select FirstName, LastName from Users where (Role = 'Student')", con);
            SqlDataReader rd = newcmd1.ExecuteReader();
            while (rd.Read())
            {
                namelist.Add(rd.GetString(0) + " " + rd.GetString(1));
            }
            con.Close();
            return namelist;
        }
        public static ArrayList getids()
        {
            ArrayList idlist = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand newcmd1 = new SqlCommand("select UserID from Users", con);
            SqlDataReader rd = newcmd1.ExecuteReader();
            while (rd.Read())
            {
                idlist.Add(rd.GetString(0));
            }
            con.Close();
            return idlist;
        }
    }
}