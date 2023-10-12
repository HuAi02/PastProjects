using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Group1_IOOP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receptionist obj1 = new Receptionist(txtbxUsername.Text, txtbxPassword.Text);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select Role from Users where Username = '" + obj1.Username.Trim() + "' and Password = '" + obj1.Password.Trim() + "'", con);
            string userRole;
            userRole = cmd2.ExecuteScalar().ToString();
            string userid;
            con.Close();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("select UserID from Users where Username = '" + obj1.Username.Trim() + "' and Password = '" + obj1.Password.Trim() + "'", con);
            userid = cmd3.ExecuteScalar().ToString();
            if (userRole.Trim() == "Student")
            {
                Hide();
                stdmain r1 = new stdmain(userid);
                r1.ShowDialog();
                Show();
            }
            else if (userRole.Trim() == "Receptionist")
            {
                Hide();
                RecepHome r = new RecepHome(txtbxUsername.Text, txtbxPassword.Text);
                r.ShowDialog();
                Show();
            }
                
            else if (userRole.Trim() == "Admin")
            {
                    
                Hide();
                MainMenu r = new MainMenu(userid);
                r.ShowDialog();
                Show();
            }
                
            else if (userRole.Trim() == "Tutor")
            {
                Hide();
                Home r = new Home(userid);
                r.ShowDialog();
                Show();
            }
            else
                MessageBox.Show("Wrong credentials", "Error");
            txtbxUsername.Text = String.Empty;
            txtbxPassword.Text = String.Empty;
        }

        private void button10000_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
