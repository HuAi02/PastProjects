using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    internal class Student
    {
        private string username;
        private string Subject1;
        private string Subject2;
        private string Subject3;

        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public Student(string username)
        {
            this.username = username;
            Subject1 = "";
            Subject2 = "";
            Subject3 = "";
        }

        public static ArrayList viewSch(string username)
        {
            ArrayList sch = new ArrayList();
            ArrayList subject = new ArrayList();
            con.Open();
            SqlCommand classid = new SqlCommand("select Subject1, Subject2, Subject3 from Users where Username='" + username + "'", con);
            SqlDataReader classrd = classid.ExecuteReader();
            while (classrd.Read())
            {
                if (!classrd.IsDBNull(0))
                    subject.Add(classrd.GetString(0));
                else
                    subject.Add("None");
                if (!classrd.IsDBNull(1))
                    subject.Add(classrd.GetString(1));
                else
                    subject.Add("None");
                if (!classrd.IsDBNull(2))
                    subject.Add(classrd.GetString(2));
                else
                    subject.Add("None");
                /*subject.Add(classrd.GetString(0));
                subject.Add(classrd.GetString(1));
                subject.Add(classrd.GetString(2));*/
            }

            classrd.Close();

          
            SqlCommand subject1 = new SqlCommand("select Subject, Schedule, Time from class where ClassID='" + subject[0].ToString() + "'", con);
            SqlDataReader rd1 = subject1.ExecuteReader();
            int len1, len2;
            while (rd1.Read())
            {
                len1 = rd1.GetString(0).Length;
                len2 = rd1.GetString(1).Length;
                if (len1 <= 8 && len2 <= 8)
                    sch.Add(rd1.GetString(0) + "\t\t" + rd1.GetString(1)+"\t\t" + rd1.GetString(2));
                else if (len1 <= 8 && len2 > 8)
                    sch.Add(rd1.GetString(0) + "\t\t" + rd1.GetString(1) + "\t" + rd1.GetString(2));
                else if (len1 >8 && len2 <=8)
                    sch.Add(rd1.GetString(0) + "\t" + rd1.GetString(1) + "\t\t" + rd1.GetString(2));
                else
                    sch.Add(rd1.GetString(0) + "\t" + rd1.GetString(1) + "\t" + rd1.GetString(2));
            }
            rd1.Close();

            SqlCommand subject2 = new SqlCommand("select Subject, Schedule, Time from class where ClassID='" + subject[1].ToString() + "'", con);
            SqlDataReader rd2 = subject2.ExecuteReader();
            while (rd2.Read())
            {
                len1 = rd2.GetString(0).Length;
                len2 = rd2.GetString(1).Length;
                if (len1 <= 8 && len2 <= 8)
                    sch.Add(rd2.GetString(0) + "\t\t" + rd2.GetString(1) + "\t\t" + rd2.GetString(2));
                else if (len1 <= 8 && len2 > 8)
                    sch.Add(rd2.GetString(0) + "\t\t" + rd2.GetString(1) + "\t" + rd2.GetString(2));
                else if (len1 > 8 && len2 <= 8)
                    sch.Add(rd2.GetString(0) + "\t" + rd2.GetString(1) + "\t\t" + rd2.GetString(2));
                else
                    sch.Add(rd2.GetString(0) + "\t" + rd2.GetString(1) + "\t" + rd2.GetString(2));
            }
            rd2.Close();

            SqlCommand subject3 = new SqlCommand("select Subject, Schedule, Time from class where ClassID='" + subject[2].ToString() + "'", con);
            SqlDataReader rd3 = subject3.ExecuteReader();
            while (rd3.Read())
            {
                len1 = rd3.GetString(0).Length;
                len2 = rd3.GetString(1).Length;
                if (len1 <= 8 && len2 <= 8)
                    sch.Add(rd3.GetString(0) + "\t\t" + rd3.GetString(1) + "\t\t" + rd3.GetString(2));
                else if (len1 <= 8 && len2 > 8)
                    sch.Add(rd3.GetString(0) + "\t\t" + rd3.GetString(1) + "\t" + rd3.GetString(2));
                else if (len1 > 8 && len2 <= 8)
                    sch.Add(rd3.GetString(0) + "\t" + rd3.GetString(1) + "\t\t" + rd3.GetString(2));
                else
                    sch.Add(rd3.GetString(0) + "\t" + rd3.GetString(1) + "\t" + rd3.GetString(2));
            }
            con.Close();
            return sch;
        }

        public static ArrayList viewPending(string username)
        {

            ArrayList pendingsubj = new ArrayList();
            con.Open();
            SqlCommand classid = new SqlCommand("select UserID from Users where Username='" + username + "'", con);
            string id = classid.ExecuteScalar().ToString();

            SqlCommand subject = new SqlCommand("select RequestID, OldSubj, NewSubj from Request where UserID='" + id + "'", con);
            SqlDataReader rd = subject.ExecuteReader();
            string subname1 = "", subname2 = "";
            while (rd.Read())
            {
                subname1 = rd.GetString(1);
                subname2 = rd.GetString(2);

                if (subname1 != null)
                {
                    if (subname1 == "C-CN-L1" || subname1 == "C-CN-L2" || subname1 == "C-CN-L3" || subname1 == "C-CN-L4" || subname1 == "C-CN-L5")
                        subname1 = "Chinese";
                    else if (subname1 == "C-BM-L1" || subname1 == "C-BM-L2" || subname1 == "C-BM-L3" || subname1 == "C-BM-L4" || subname1 == "C-BM-L5")
                        subname1 = "Malay";
                    else if (subname1 == "C-ENG-L1" || subname1 == "C-ENG-L2" || subname1 == "C-ENG-L3" || subname1 == "C-ENG-L4" || subname1 == "C-ENG-L5")
                        subname1 = "English";
                    else if (subname1 == "C-MATH-L1" || subname1 == "C-MATH-L2" || subname1 == "C-MATH-L3" || subname1 == "C-MATH-L4" || subname1 == "C-MATH-L5")
                        subname1 = "Mathematics";
                    else if (subname1 == "C-SC-L1" || subname1 == "C-SC-L2" || subname1 == "C-SC-L3")
                        subname1 = "Science";
                    else if (subname1 == "C-CHEM-L4" || subname1 == "C-CHEM-L5")
                        subname1 = "Chemistry";
                    else if (subname1 == "C-BIO-L4" || subname1 == "C-BIO-L5")
                        subname1 = "Biology";
                    else if (subname1 == "C-PHY-L4" || subname1 == "C-PHY-L5")
                        subname1 = "Physics";
                }
                else
                    subname1 = "No such subject";

                if (subname2 != null)
                {
                    if (subname2 == "C-CN-L1" || subname2 == "C-CN-L2" || subname2 == "C-CN-L3" || subname2 == "C-CN-L4" || subname2 == "C-CN-L5")
                        subname2 = "Chinese";
                    else if (subname2 == "C-BM-L1" || subname2 == "C-BM-L2" || subname2 == "C-BM-L3" || subname2 == "C-BM-L4" || subname2 == "C-BM-L5")
                        subname2 = "Malay";
                    else if (subname2 == "C-ENG-L1" || subname2 == "C-ENG-L2" || subname2 == "C-ENG-L3" || subname2 == "C-ENG-L4" || subname2 == "C-ENG-L5")
                        subname2 = "English";
                    else if (subname2 == "C-MATH-L1" || subname2 == "C-MATH-L2" || subname2 == "C-MATH-L3" || subname2 == "C-MATH-L4" || subname2 == "C-MATH-L5")
                        subname2 = "Mathematics";
                    else if (subname2 == "C-SC-L1" || subname2 == "C-SC-L2" || subname2 == "C-SC-L3")
                        subname2 = "Science";
                    else if (subname2 == "C-CHEM-L4" || subname2 == "C-CHEM-L5")
                        subname2 = "Chemistry";
                    else if (subname2 == "C-BIO-L4" || subname2 == "C-BIO-L5")
                        subname2 = "Biology";
                    else if (subname2 == "C-PHY-L4" || subname2 == "C-PHY-L5")
                        subname2 = "Physics";
                }
                else
                    subname2 = "No such subject";

                int len1 = rd.GetString(0).Length;
                subname1 = subname1.Trim();
                subname2 = subname2.Trim();
                int len2 = subname1.Length;
                if (len1 <= 8 && len2 <= 8)
                    pendingsubj.Add(rd.GetString(0) + "\t\t" + subname1 + "\t\t" + subname2);
                else if (len1 <= 8 && len2 > 8)
                    pendingsubj.Add(rd.GetString(0) + "\t\t" + subname1 + "\t" + subname2);
                else if (len1 > 8 && len2 <= 8)
                    pendingsubj.Add(rd.GetString(0) + "\t" + subname1 + "\t\t" + subname2);
                else
                    pendingsubj.Add(rd.GetString(0) + "\t" + subname1 + "\t" + subname2);
                /*pendingsubj.Add(rd.GetString(0) + "                          " + subname1 + "                   " + subname2);*/
            } 

            con.Close();
            return pendingsubj;
        }

        public static ArrayList chgsub(string username)
        {
            ArrayList sch = new ArrayList();
            ArrayList subject = new ArrayList();
            con.Open();
            SqlCommand classid = new SqlCommand("select Subject1, Subject2, Subject3 from  Users where Username='" + username + "'", con);
            SqlDataReader classrd = classid.ExecuteReader();
            while (classrd.Read())
            {
                if (!classrd.IsDBNull(0))
                    subject.Add(classrd.GetString(0));
                else
                    subject.Add("None");
                if (!classrd.IsDBNull(1))
                    subject.Add(classrd.GetString(1));
                else
                    subject.Add("None");
                if (!classrd.IsDBNull(2))
                    subject.Add(classrd.GetString(2));
                else
                    subject.Add("None");
                /*subject.Add(classrd.GetString(1));
                subject.Add(classrd.GetString(1));
                subject.Add(classrd.GetString(2));*/
            }

            classrd.Close();


            SqlCommand subject1 = new SqlCommand("select Subject from class where ClassID='" + subject[0].ToString() + "'", con);
            SqlDataReader rd1 = subject1.ExecuteReader();
            while (rd1.Read())
            {
                sch.Add(rd1.GetString(0));
            }
            rd1.Close();

            SqlCommand subject2 = new SqlCommand("select Subject from class where ClassID='" + subject[1].ToString() + "'", con);
            SqlDataReader rd2 = subject2.ExecuteReader();
            while (rd2.Read())
            {
                sch.Add(rd2.GetString(0));
            }
            rd2.Close();

            SqlCommand subject3 = new SqlCommand("select Subject from class where ClassID='" + subject[2].ToString() + "'", con);
            SqlDataReader rd3 = subject3.ExecuteReader();
            while (rd3.Read())
            {
                sch.Add(rd3.GetString(0));
            }
            con.Close();
            return sch;
        }

        public string subrequest(string os, string ns, string l)
        {
            string subname1, subname2;
            subname1 = os;
            subname2 = ns;

            if (subname1 != null)
            {
                if (subname1 == "Chinese")
                    subname1 = "C-CN-L" + l;
                else if (subname1 == "Malay")
                    subname1 = "C-BM-L" + l;
                else if (subname1 == "English")
                    subname1 = "C-ENG-L" + l;
                else if (subname1 == "Mathematics")
                    subname1 = "C-MATH-L" + l;
                else if (subname1 == "Science")
                    subname1 = "C-SC-L" + l;
                else if (subname1 == "Chemistry")
                    subname1 = "C-CHEM-L" + l;
                else if (subname1 == "Biology")
                    subname1 = "C-BIO-L" + l;
                else if (subname1 == "Physics")
                    subname1 = "C-PHY-L"+ l;
            }
            else
                subname1 = "No such subject";

            if (subname2 != null)
            {
                if (subname2 == "Chinese")
                    subname2 = "C-CN-L" + l;
                else if (subname2 == "Malay")
                    subname2 = "C-BM-L" + l;
                else if (subname2 == "English")
                    subname2 = "C-ENG-L" + l;
                else if (subname2 == "Mathematics")
                    subname2 = "C-MATH-L" + l;
                else if (subname2 == "Science")
                    subname2 = "C-SC-L" + l;
                else if (subname2 == "Chemistry")
                    subname2 = "C-CHEM-L" + l;
                else if (subname2 == "Biology")
                    subname2 = "C-BIO-L" + l;
                else if (subname2 == "Physics")
                    subname2 = "C-PHY-L" + l;
            }
            else
                subname2 = "No such subject";

            string status;
            con.Open();
            DateTime time = DateTime.Now;

            SqlCommand cmd = new SqlCommand("insert into Request(RequestID, UserID, Date, OldSubj, NewSubj) values (@RequestID, @UserID, @Date, @OldSubj, @NewSubj)", con);
            SqlCommand cmd2 = new SqlCommand("select UserID from Users where Username='" + username + "'", con);
            SqlCommand newcmd1 = new SqlCommand("select count(*) as rownum from Request", con);

            string test = newcmd1.ExecuteScalar().ToString();
            string temp;
            if (test != "0")
            {
                SqlCommand newcmd = new SqlCommand("select RequestID from Request order by len(RequestID) DESC, RequestID DESC", con); //attempt to find the largest request id from database
                temp = newcmd.ExecuteScalar().ToString(); // convert sql command output to string
                string temp1 = temp.Substring(1); //get the numbers in id only
                int IDitself = Convert.ToInt32(temp1); //removing the prefix from user id
                IDitself += 1; // add one to the largest id number
                temp = temp.Substring(0, 1) + IDitself.ToString();
            }
            else
            {
                temp = "R1";
            }

            string id = cmd2.ExecuteScalar().ToString();
            cmd.Parameters.AddWithValue("@RequestID", temp.ToString());
            cmd.Parameters.AddWithValue("@UserID", id );
            cmd.Parameters.AddWithValue("@Date", time.ToString("d"));
            cmd.Parameters.AddWithValue("@OldSubj", subname1);
            cmd.Parameters.AddWithValue("@NewSubj", subname2);

            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                status = "Request Sent.";
            else
                status = "Please try again later.";
            con.Close();
            return status;

        }

        public string delrequest(string id)
        {
            string status;
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Request where RequestID ='"+ id +"'",con);
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
                status = "Request Deleted.";
            else
                status = "No request found.";
            con.Close();
            return status;
        }

    }
}
