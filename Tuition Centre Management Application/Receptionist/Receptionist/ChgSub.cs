using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Group1_IOOP
{
    public partial class stdviewsub : Form
    {
        public static string name;
        public static string level;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public stdviewsub(string n, string l)
        {
            InitializeComponent();
            name = n;
            level = l;
        }

        private void stdviewsub_Load(object sender, EventArgs e)
        {
            ArrayList schedule = new ArrayList();
            schedule = Student.viewSch(name);
            /*listbxTaken.Items.Add("Subject               Day                Time" + "\n");*/
            listbxTaken.Items.Add("Subject\t\tDay\t\tTime" + "\n");
            foreach (var item in schedule)
            {
                listbxTaken.Items.Add(item);
            }

            ArrayList pendingList = new ArrayList();
            pendingList = Student.viewPending(name);
            listbxPending.Items.Add("Request ID\tOldSubject\tNewSubject" + "\n");
            foreach (var item in pendingList)
            {
                listbxPending.Items.Add(item);
            }

            string query1 = "Select distinct RequestID from Request where UserID in (select UserID from Users where Username='" + name + "')";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
            DataSet dt = new DataSet();
            adapter.Fill(dt, "Request");
            cmbbxDelete.DisplayMember = "RequestID";
            cmbbxDelete.ValueMember = "RequestID";
            cmbbxDelete.DataSource = dt.Tables["Request"];
            con.Close();

            string query2 = "select distinct Subject from class where ClassID like '%" + level + "'";
            con.Open();
            SqlDataAdapter adapter2 = new SqlDataAdapter(query2, con);
            DataSet dt2 = new DataSet();
            adapter2.Fill(dt2, "Class");
            cmbbxChange.DisplayMember = "Subject";
            cmbbxChange.DataSource = dt2.Tables["Class"];
            con.Close();

            ArrayList sub = new ArrayList();
            sub = Student.chgsub(name);
            foreach (var item in sub)
            {
                cmbbxSubject.Items.Add(item);
            }
            cmbbxSubject.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbbxChange.Text == cmbbxSubject.Text)
            {
                MessageBox.Show("The same subjects are selected, please select a different subject.");
            }
            else
            {
                Student obj1 = new Student(name);
                MessageBox.Show(obj1.subrequest(cmbbxSubject.Text, cmbbxChange.Text, level));

                string query1 = "Select distinct RequestID from Request where UserID in (select UserID from Users where Username='" + name + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
                con.Open();
                DataSet dt = new DataSet();
                adapter.Fill(dt, "Request");
                cmbbxDelete.DisplayMember = "RequestID";
                cmbbxDelete.ValueMember = "RequestID";
                cmbbxDelete.DataSource = dt.Tables["Request"];
                con.Close();
                this.Refresh();

                listbxPending.Items.Clear();
                ArrayList pendingList = new ArrayList();
                pendingList = Student.viewPending(name);
                listbxPending.Items.Add("Request ID\tOldSubject\tNewSubject" + "\n");
                foreach (var item in pendingList)
                {
                    listbxPending.Items.Add(item);
                }
                this.Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student obj1 = new Student(name);
            MessageBox.Show(obj1.delrequest(cmbbxDelete.Text));

            string query1 = "Select distinct RequestID from Request where UserID in (select UserID from Users where Username='" + name + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
            con.Open();
            DataSet dt = new DataSet();
            adapter.Fill(dt, "Request");
            cmbbxDelete.DisplayMember = "RequestID";
            cmbbxDelete.ValueMember = "RequestID";
            cmbbxDelete.DataSource = dt.Tables["Request"];
            con.Close();
            this.Refresh();

            listbxPending.Items.Clear();
            ArrayList pendingList = new ArrayList();
            pendingList = Student.viewPending(name);
            listbxPending.Items.Add("Request ID\tOldSubject\tNewSubject" + "\n");
            foreach (var item in pendingList)
            {
                listbxPending.Items.Add(item);
            }
            this.Refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
