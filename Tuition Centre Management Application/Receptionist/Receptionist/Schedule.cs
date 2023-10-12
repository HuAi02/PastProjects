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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Group1_IOOP
{
    public partial class stdscd : Form
    {
        public static string name;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public stdscd(string n)
        {
            InitializeComponent();
            name = n;
        }


        private void stdscd_Load(object sender, EventArgs e)
        {
            ArrayList schedule = new ArrayList();
            schedule = Student.viewSch(name);
            listbxSch.Items.Add("Subject               Day                Time" + "\n");
            foreach (var item in schedule)
            {
                listbxSch.Items.Add(item); 
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChgsub_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand level = new SqlCommand("select Level from  Users where Username = '" + name + "'", con);
            string l = level.ExecuteScalar().ToString();
            stdviewsub obj1 = new stdviewsub(name, l);
            con.Close();
            this.Hide();
            obj1.ShowDialog();
            obj1 = null;
            this.Show();
        }
    }
}
