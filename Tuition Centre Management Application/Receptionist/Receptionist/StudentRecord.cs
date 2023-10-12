using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Group1_IOOP
{
    internal class StudentRecord
    {
        private string name, userid, id, email, phonenum, sub1, sub2, sub3;
        private bool gender;
        private int level;

        public string Name { get => name; set => name = value; }
        public string Userid { get => userid; set => userid = value; }
        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Phonenum { get => phonenum; set => phonenum = value; }
        public string Sub1 { get => sub1; set => sub1 = value; }
        public string Sub2 { get => sub2; set => sub2 = value; }
        public string Sub3 { get => sub3; set => sub3 = value; }
        public bool Gender { get => gender; set => gender = value; }
        public int Level { get => level; set => level = value; }
        public StudentRecord(string name1, string name2, string id, string email, bool gender, string phonenum, string subj1, string subj2, string subj3, string lvl, string address)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand newcmd1 = new SqlCommand("select count(*) as rownum from Users", con);
            string test = newcmd1.ExecuteScalar().ToString();
            string temp;
            if (test != "0")
            {
                SqlCommand newcmd = new SqlCommand("select UserID from Users order by len(UserID) DESC, UserID DESC", con); //attempt to find the largest user id from database
                temp = newcmd.ExecuteScalar().ToString(); // convert sql command output to string
                string temp1 = temp.Substring(1); //get the numbers in id only
                int IDitself = Convert.ToInt32(temp1); //removing the prefix from user id
                IDitself += 1; // add one to the largest id number
                temp = temp.Substring(0, 1) + IDitself.ToString();
            }
            else
            {
                temp = "U1";
            }
            DateTime dt = DateTime.Now;
            string month = dt.ToString("MMM");

            int num = 1;

            SqlCommand cmd = new SqlCommand("insert into Users (UserID, Username, Password, Role, FirstName, LastName, ICPassport, Email, Gender, Contact, Subject1, Subject2, Subject3, Level, EnrolmentMonth1, EnrolmentMonth2, EnrolmentMonth3, Address) values (@userid, @username, '1234567890', 'Student', @name1, @name2, @id, @email, @gender, @contact, @subj1, @subj2, @subj3, @level, '" + month + "', '" + month + "', '" + month + "', @address)", con);

            string subname1 = String.Empty, subname2 = String.Empty, subname3 = String.Empty;
            switch (subj1)
            {
                case "None":
                    break;
                case "Chinese":
                    subname1 = "C-CN";
                    break;
                case "Malay":
                    subname1 = "C-BM";
                    break;
                case "English":
                    subname1 = "C-ENG";
                    break;
                case "Mathematics":
                    subname1 = "C-MATH";
                    break;
                case "Science":
                    subname1 = "C-SC";
                    break;
                case "Chemistry":
                    subname1 = "C-CHEM";
                    break;
                case "Biology":
                    subname1 = "C-BIO";
                    break;
                case "Physics":
                    subname1 = "C-PHY";
                    break;
            }
            switch (subj2)
            {
                case "None":
                    break;
                case "Chinese":
                    subname2 = "C-CN";
                    break;
                case "Malay":
                    subname2 = "C-BM";
                    break;
                case "English":
                    subname2 = "C-ENG";
                    break;
                case "Mathematics":
                    subname2 = "C-MATH";
                    break;
                case "Science":
                    subname2 = "C-SC";
                    break;
                case "Chemistry":
                    subname2 = "C-CHEM";
                    break;
                case "Biology":
                    subname2 = "C-BIO";
                    break;
                case "Physics":
                    subname2 = "C-PHY";
                    break;
            }
            switch (subj3)
            {
                case "None":
                    break;
                case "Chinese":
                    subname3 = "C-CN";
                    break;
                case "Malay":
                    subname3 = "C-BM";
                    break;
                case "English":
                    subname3 = "C-ENG";
                    break;
                case "Mathematics":
                    subname3 = "C-MATH";
                    break;
                case "Science":
                    subname3 = "C-SC";
                    break;
                case "Chemistry":
                    subname3 = "C-CHEM";
                    break;
                case "Biology":
                    subname3 = "C-BIO";
                    break;
                case "Physics":
                    subname3 = "C-PHY";
                    break;
            }
            if (subj1 != "None")
            {
                switch (lvl)
                {
                    case "1":
                        subname1 = subname1 + "-L1";
                        break;
                    case "2":
                        subname1 = subname1 + "-L2";
                        break;
                    case "3":
                        subname1 = subname1 + "-L3";
                        break;
                    case "4":
                        subname1 = subname1 + "-L4";
                        break;
                    case "5":
                        subname1 = subname1 + "-L5";
                        break;
                }
                if (subj2 != "None")
                {
                    switch (lvl)
                    {
                        case "1":
                            subname2 = subname2 + "-L1";
                            break;
                        case "2":
                            subname2 = subname2 + "-L2";
                            break;
                        case "3":
                            subname2 = subname2 + "-L3";
                            break;
                        case "4":
                            subname2 = subname2 + "-L4";
                            break;
                        case "5":
                            subname2 = subname2 + "-L5";
                            break;
                    }
                    if (subj3 != "None")
                    {
                        switch (lvl)
                        {
                            case "1":
                                subname3 = subname3 + "-L1";
                                break;
                            case "2":
                                subname3 = subname3 + "-L2";
                                break;
                            case "3":
                                subname3 = subname3 + "-L3";
                                break;
                            case "4":
                                subname3 = subname3 + "-L4";
                                break;
                            case "5":
                                subname3 = subname3 + "-L5";
                                break;
                        }
                    }
                }
            }

            cmd.Parameters.AddWithValue("@userid", temp);
            string username = string.Empty;
            SqlCommand usernameCheck = new SqlCommand("select Count(Username) from Users where Username like '" + name1.ToLower().Trim() + "%'", con);
            int count = Convert.ToInt32(usernameCheck.ExecuteScalar().ToString());
            count = Math.Abs(count);
            do
            {
                num = num + 1;
                count = count - 1;
            } while (count > 0);
            
            username = name1.ToLower().Trim() + num.ToString();
                
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@name1", name1);
            cmd.Parameters.AddWithValue("@name2", name2);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@contact", phonenum);
            cmd.Parameters.AddWithValue("@level", lvl);
            cmd.Parameters.AddWithValue("@address", address);
            if (subj1 != "None")
                cmd.Parameters.AddWithValue("@subj1", subname1);
            else
                cmd.Parameters.AddWithValue("@subj1", DBNull.Value);
            if (subj2 != "None")
                cmd.Parameters.AddWithValue("@subj2", subname2);
            else
                cmd.Parameters.AddWithValue("@subj2", DBNull.Value);
            if (subj3 != "None")
                cmd.Parameters.AddWithValue("@subj3", subname3);
            else
                cmd.Parameters.AddWithValue("@subj3", DBNull.Value);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            MessageBox.Show("Username: " + name1.ToLower().Trim() + num.ToString() + "\nDefault password: 1234567890", "Student added successfully");
            con.Close();
        }

        public StudentRecord(string userid)
        {
            ArrayList info = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName, ICPassport, Level, Email, Subject1, Subject2, Subject3, Gender, Contact from Users where UserID ='"+userid+"'", con);
            SqlDataReader rd = cmd.ExecuteReader();
            string subname1 = string.Empty, subname2 = string.Empty, subname3 = string.Empty;
            while (rd.Read())
            {
                this.userid = userid;
                this.name = rd.GetString(0) + " " + rd.GetString(1);
                this.id = rd.GetString(2);
                this.level = rd.GetInt32(3);
                this.email = rd.GetString(4);
                subname1 = rd.IsDBNull("Subject1") ? "None" : rd.GetString("Subject1");
                subname2 = rd.IsDBNull("Subject2") ? "None" : rd.GetString("Subject2");
                subname3 = rd.IsDBNull("Subject3") ? "None" : rd.GetString("Subject3");
                this.gender = rd.GetBoolean("Gender");
                this.phonenum = rd.GetString("Contact");
            }
            subname1 = subname1.Trim();
            subname2 = subname2.Trim();
            subname3 = subname3.Trim();
            if (subname1 != "None")
            {
                if (subname1 == "C-CN-L1" || subname1 == "C-CN-L2" || subname1 == "C-CN-L3" || subname1 == "C-CN-L4" || subname1 == "C-CN-L5")
                    sub1 = "Chinese";
                else if (subname1 == "C-BM-L1" || subname1 == "C-BM-L2" || subname1 == "C-BM-L3" || subname1 == "C-BM-L4" || subname1 == "C-BM-L5")
                    sub1 = "Malay";
                else if (subname1 == "C-ENG-L1" || subname1 == "C-ENG-L2" || subname1 == "C-ENG-L3" || subname1 == "C-ENG-L4" || subname1 == "C-ENG-L5")
                    sub1 = "English";
                else if (subname1 == "C-MATH-L1" || subname1 == "C-MATH-L2" || subname1 == "C-MATH-L3" || subname1 == "C-MATH-L4" || subname1 == "C-MATH-L5")
                    sub1 = "Mathematics";
                else if (subname1 == "C-SC-L1" || subname1 == "C-SC-L2" || subname1 == "C-SC-L3")
                    sub1 = "Science";
                else if (subname1 == "C-CHEM-L4" || subname1 == "C-CHEM-L5")
                    sub1 = "Chemistry";
                else if (subname1 == "C-BIO-L4" || subname1 == "C-BIO-L5")
                    sub1 = "Biology";
                else if (subname1 == "C-PHY-L4" || subname1 == "C-PHY-L5")
                    sub1 = "Physics";
            }
            else
                sub1 = "None";
            if (subname2 != "None")
            {
                if (subname2 == "C-CN-L1" || subname2 == "C-CN-L2" || subname2 == "C-CN-L3" || subname2 == "C-CN-L4" || subname2 == "C-CN-L5")
                    sub2 = "Chinese";
                else if (subname2 == "C-BM-L1" || subname2 == "C-BM-L2" || subname2 == "C-BM-L3" || subname2 == "C-BM-L4" || subname2 == "C-BM-L5")
                    sub2 = "Malay";
                else if (subname2 == "C-ENG-L1" || subname2 == "C-ENG-L2" || subname2 == "C-ENG-L3" || subname2 == "C-ENG-L4" || subname2 == "C-ENG-L5")
                    sub2 = "English";
                else if (subname2 == "C-MATH-L1" || subname2 == "C-MATH-L2" || subname2 == "C-MATH-L3" || subname2 == "C-MATH-L4" || subname2 == "C-MATH-L5")
                    sub2 = "Mathematics";
                else if (subname2 == "C-SC-L1" || subname2 == "C-SC-L2" || subname2 == "C-SC-L3")
                    sub2 = "Science";
                else if (subname2 == "C-CHEM-L4" || subname2 == "C-CHEM-L5")
                    sub2 = "Chemistry";
                else if (subname2 == "C-BIO-L4" || subname2 == "C-BIO-L5")
                    sub2 = "Biology";
                else if (subname2 == "C-PHY-L4" || subname2 == "C-PHY-L5")
                    sub2 = "Physics";
            }
            else
                sub2 = "None";
            if (subname3 != "None")
            {

                if (subname3 == "C-CN-L1" || subname3 == "C-CN-L2" || subname3 == "C-CN-L3" || subname3 == "C-CN-L4" || subname3 == "C-CN-L5")
                    sub3 = "Chinese";
                else if (subname3 == "C-BM-L1" || subname3 == "C-BM-L2" || subname3 == "C-BM-L3" || subname3 == "C-BM-L4" || subname3 == "C-BM-L5")
                    sub3 = "Malay";
                else if (subname3 == "C-ENG-L1" || subname3 == "C-ENG-L2" || subname3 == "C-ENG-L3" || subname3 == "C-ENG-L4" || subname3 == "C-ENG-L5")
                    sub3 = "English";
                else if (subname3 == "C-MATH-L1" || subname3 == "C-MATH-L2" || subname3 == "C-MATH-L3" || subname3 == "C-MATH-L4" || subname3 == "C-MATH-L5")
                    sub3 = "Mathematics";
                else if (subname3 == "C-SC-L1" || subname3 == "C-SC-L2" || subname3 == "C-SC-L3")
                    sub3 = "Science";
                else if (subname3 == "C-CHEM-L4" || subname3 == "C-CHEM-L5")
                    sub3 = "Chemistry";
                else if (subname3 == "C-BIO-L4" || subname3 == "C-BIO-L5")
                    sub3 = "Biology";
                else if (subname3 == "C-PHY-L4" || subname3 == "C-PHY-L5")
                    sub3 = "Physics";
            }
            else
                sub3 = "None";
            con.Close();
        }
        public static ArrayList viewRecordName()
        {
            ArrayList nm = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName from Users where (Role = 'Student')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nm.Add(reader.GetString(0) + " " + reader.GetString(1));
            }
            con.Close();
            return nm;
        }

        public static ArrayList viewRecordID()
        {
            ArrayList ide = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select UserID from Users where (Role = 'Student')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ide.Add(reader.GetString(0));
            }
            con.Close();
            return ide;
        }
        public static ArrayList viewRecordName(string keyword)
        {
            ArrayList nm = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select FirstName, LastName from Users where (Role = 'Student') and (FirstName like '" + keyword + "' or LastName like '" + keyword + "')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nm.Add(reader.GetString(0)+" "+reader.GetString(1));
            }
            con.Close();
            return nm;
        }

        public static ArrayList viewRecordID(string keyword)
        {
            ArrayList ide = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select UserID from Users where (Role = 'Student') and (FirstName like '" + keyword + "' or LastName like '" + keyword + "')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ide.Add(reader.GetString(0));
            }
            con.Close();
            return ide;
        }

        public static int editRecord(string keyword, string sub1, string sub2, string sub3, string level)
        {
            ArrayList newinfo = new ArrayList();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand check = new SqlCommand("select Level from Users where UserID = '" + keyword+"'", con);
            string subname1 = string.Empty, subname2 = string.Empty, subname3 = string.Empty;
            string[] subjects = { "None", "Chinese", "Malay", "English", "Mathematics", "Science", "Chemistry", "Biology", "Physics" };
            int oldlvl = Convert.ToInt32(check.ExecuteScalar().ToString());
            bool isProperInput1 = subjects.Contains(sub1);
            bool isProperInput2 = subjects.Contains(sub2);
            bool isProperInput3 = subjects.Contains(sub3);
            int[] levels = { 1, 2, 3, 4, 5 };
            bool isProperInput4 = levels.Contains(Convert.ToInt32(level));
            if (!isProperInput4)
                level = oldlvl.ToString();
            if (isProperInput1)
            {
                switch (sub1)
                {
                    case "None":
                        break;
                    case "Chinese":
                        subname1 = "C-CN";
                        break;
                    case "Malay":
                        subname1 = "C-BM";
                        break;
                    case "English":
                        subname1 = "C-ENG";
                        break;
                    case "Mathematics":
                        subname1 = "C-MATH";
                        break;
                    case "Science":
                        subname1 = "C-SC";
                        break;
                    case "Chemistry":
                        subname1 = "C-CHEM";
                        break;
                    case "Biology":
                        subname1 = "C-BIO";
                        break;
                    case "Physics":
                        subname1 = "C-PHY";
                        break;
                }
                if (sub1 != "None")
                {
                    switch (level)
                    {
                        case "1":
                            subname1 = subname1 + "-L1";
                            break;
                        case "2":
                            subname1 = subname1 + "-L2";
                            break;
                        case "3":
                            subname1 = subname1 + "-L3";
                            break;
                        case "4":
                            subname1 = subname1 + "-L4";
                            break;
                        case "5":
                            subname1 = subname1 + "-L5";
                            break;
                    }
                }  
            }
            else
                subname1 = "None";
            if (isProperInput2)
            {
                switch (sub2)
                {
                    case "None":
                        break;
                    case "Chinese":
                        subname2 = "C-CN";
                        break;
                    case "Malay":
                        subname2 = "C-BM";
                        break;
                    case "English":
                        subname2 = "C-ENG";
                        break;
                    case "Mathematics":
                        subname2 = "C-MATH";
                        break;
                    case "Science":
                        subname2 = "C-SC";
                        break;
                    case "Chemistry":
                        subname2 = "C-CHEM";
                        break;
                    case "Biology":
                        subname2 = "C-BIO";
                        break;
                    case "Physics":
                        subname2 = "C-PHY";
                        break;
                }
                if (sub2 != "None")
                {
                    switch (level)
                    {
                        case "1":
                            subname2 = subname2 + "-L1";
                            break;
                        case "2":
                            subname2 = subname2 + "-L2";
                            break;
                        case "3":
                            subname2 = subname2 + "-L3";
                            break;
                        case "4":
                            subname2 = subname2 + "-L4";
                            break;
                        case "5":
                            subname2 = subname2 + "-L5";
                            break;
                    }
                }
            }
            else
                subname2 = "None";
            if (isProperInput3)
            {
                switch (sub3)
                {
                    case "None":
                        break;
                    case "Chinese":
                        subname3 = "C-CN";
                        break;
                    case "Malay":
                        subname3 = "C-BM";
                        break;
                    case "English":
                        subname3 = "C-ENG";
                        break;
                    case "Mathematics":
                        subname3 = "C-MATH";
                        break;
                    case "Science":
                        subname3 = "C-SC";
                        break;
                    case "Chemistry":
                        subname3 = "C-CHEM";
                        break;
                    case "Biology":
                        subname3 = "C-BIO";
                        break;
                    case "Physics":
                        subname3 = "C-PHY";
                        break;
                }
                if (sub3 != "None")
                {
                    switch (level)
                    {
                        case "1":
                            subname3 = subname3 + "-L1";
                            break;
                        case "2":
                            subname3 = subname3 + "-L2";
                            break;
                        case "3":
                            subname3 = subname3 + "-L3";
                            break;
                        case "4":
                            subname3 = subname3 + "-L4";
                            break;
                        case "5":
                            subname3 = subname3 + "-L5";
                            break;
                    }
                }
            }
            else
                subname3 = "None";
            SqlCommand cmd = new SqlCommand("update Users set Subject1 = '" + subname1 + "', Subject2 = '" + subname2 + "', Subject3 = '" + subname3 + "', Level = '" + level + "' where (UserID = '" + keyword + "')", con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        public static int delRecord(string keyword)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Users where (UserID = '"+ keyword + "')", con);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }
    }
}
