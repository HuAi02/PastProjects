using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Group1_IOOP
{
    public partial class EditProfile : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public string UserID;
        public string u;
        public EditProfile(string u)
        {
            InitializeComponent();
            UserID = u;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        //initialize and get UserID 
        private void AdminEdit_Load(object sender, EventArgs e)
        {

        }
            
        // Used the inputs to trigger the class method.
        private void button1_Click_1(object sender, EventArgs e)
        {
            admin obj1 = new admin(NewUsernametb.Text, NewPasswordtb.Text, NewGmailtb.Text, UserID);
            admin.updateprofile(obj1.Username, obj1.Password, obj1.Email, obj1.UserID);
        }

        private void NewGmail_TextChanged(object sender, EventArgs e)
        {

        }

        // Clear textboxes
        private void button2_Click_1(object sender, EventArgs e)
        {
            NewGmailtb.Clear();
            NewPasswordtb.Clear();
            NewUsernametb.Clear();
        }

        private void NewPassword_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
