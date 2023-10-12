using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Group1_IOOP
{
    public partial class stdeditpro : Form
    {
        public static string name;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
        public stdeditpro(string n)
        {
            InitializeComponent();
            name = n;
        }

        private void stdeditpro_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand frt = new SqlCommand("select FirstName from Users where Username = '" + name + "'", con);
            SqlCommand lst = new SqlCommand("select LastName from Users where Username = '" + name + "'", con);
            SqlCommand em = new SqlCommand("select Email from Users where Username = '" + name + "'", con);
            SqlCommand add = new SqlCommand("select Address from Users where Username = '" + name + "'", con);
            SqlCommand cont = new SqlCommand("select Contact from Users where Username = '" + name + "'", con);
            SqlCommand pw = new SqlCommand("select Password from Users where Username = '" + name + "'", con);

            string FirstName = frt.ExecuteScalar().ToString();
            string LastName = lst.ExecuteScalar().ToString();
            string email = em.ExecuteScalar().ToString();
            string address = add.ExecuteScalar().ToString();
            string contact = cont.ExecuteScalar().ToString();
            string password = pw.ExecuteScalar().ToString();

            lblname.Text = FirstName + " " + LastName;
            txtbxEmail.Text = email;
            txtbxPhone.Text = contact;
            txtbxPassword.Text = password;
            txtbxline1.Text = address;
            txtbxUsername.Text = name;

            con.Close();          
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbxPassword.Text == txtbxConfirm.Text)
            {
                if (Regex.IsMatch(txtbxUsername.Text, @"^[a-zA-Z0-9_]+$"))
                {
                    if (Regex.IsMatch(txtbxEmail.Text, @"^[a-zA-Z0-9_@.]+$"))
                    {
                        if (Regex.IsMatch(txtbxPhone.Text, @"^+?\d{0,3}-?\d{5,9}"))
                        {
                            con.Open();
                            SqlCommand update = new SqlCommand("update Users set Email ='" + txtbxEmail.Text + "', Contact ='" + txtbxPhone.Text + "', Address ='" + txtbxline1.Text + "', Password ='" + txtbxPassword.Text + "', Username ='" + txtbxUsername.Text + "' where Username='" + name + "'", con);
                            update.ExecuteNonQuery();
                            MessageBox.Show("Details Updated");
                            con.Close();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Invalid Phone Number");
                    }
                    else
                        MessageBox.Show("Invalid Email Address");
                }
                else
                    MessageBox.Show("Invalid Username");     
            }
            else if (txtbxPassword.Text != txtbxConfirm.Text)
            {
                MessageBox.Show("Enter your password or Passwords does not match.");
            }
            else
                MessageBox.Show("Error");
                
        }
    }
}
