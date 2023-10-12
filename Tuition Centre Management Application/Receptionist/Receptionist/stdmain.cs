using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{

    public partial class stdmain : Form
    {
        public static string UserID, Username;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public stdmain(string un)
        {
            InitializeComponent();
            UserID = un;
            this.Activated += new EventHandler(stdmain_Activated);
        }

        private void btnSch_Click(object sender, EventArgs e)
        {
            stdscd obj1 = new stdscd(Username);
            this.Hide();
            obj1.ShowDialog();
            obj1 = null;
            this.Show();
        }

        private void btnChgsub_Click(object sender, EventArgs e)
        {
            stdviewsub obj1 = new stdviewsub(Username, lbllvl.Text);
            this.Hide();
            obj1.ShowDialog();
            obj1 = null;
            this.Show();
        }

        private void lblEditpro_Click(object sender, EventArgs e)
        {
            stdeditpro obj1 = new stdeditpro(Username);
            this.Hide();
            obj1.ShowDialog();
            obj1 = null;
            this.Show();
        }

        private void stdmain_Activated(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand level = new SqlCommand("select Level from Users where UserID = '" + UserID + "'", con);
            SqlCommand frt = new SqlCommand("select FirstName from Users where UserID = '" + UserID + "'", con);
            SqlCommand lst = new SqlCommand("select LastName from Users where UserID = '" + UserID + "'", con);
            SqlCommand usn = new SqlCommand("select Username from Users where UserID = '" + UserID + "'", con);
            string FirstName = frt.ExecuteScalar().ToString();
            string LastName = lst.ExecuteScalar().ToString();
            lblname.Text = FirstName + " " + LastName;
            lbllvl.Text = level.ExecuteScalar().ToString();
            Username = usn.ExecuteScalar().ToString();
        }
    }
}
