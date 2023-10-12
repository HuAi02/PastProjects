using Group1_IOOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    public partial class TutorEditProfile : Form
    {
        public string originaluserID;
        public string username;

        public TutorEditProfile()
        {
            InitializeComponent();
        }
        public TutorEditProfile(string userid)
        {
            InitializeComponent();
            originaluserID = userid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            // Update the tutor user profile to the database
            //
            string UserID = originaluserID;
            string username = textBox_Username.Text;
            string password = textBox_Password.Text;
            string confirmPassword = textBox_CPassword.Text;
            string email = textBox_Email.Text;
            string contact = textBox_Contact.Text;
            string address = textBox_Address.Text;
            string subject = listBox_Subject.Text;

            DialogResult dialog = MessageBox.Show("Are you sure you want to update this profile information?", "Update Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (confirmPassword != password)
                {
                    MessageBox.Show("Password does not match the Confirm Password.");
                }
                else
                {
                    DBAccess objDBConnection = new DBAccess();
                    objDBConnection.createConn();
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Username = @Username, Password = @Password, Email = @Email, Contact = @Contact, Address = @Address, Subject1 = @Subject WHERE UserID = @UserID", DBAccess.connection);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.ExecuteNonQuery();
                    objDBConnection.closeConn();
                    MessageBox.Show("Update Successful");
                }
            }
            else if (dialog == DialogResult.No)
            {
                MessageBox.Show("Update Cancelled");
            }
            this.Close();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            //
            // Load the tutor user profile from the database
            //
            DBAccess objDBConnection = new DBAccess();
            objDBConnection.createConn();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", DBAccess.connection);
            cmd.Parameters.AddWithValue("@UserID", originaluserID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox_Username.Text = reader["Username"].ToString();
                textBox_Email.Text = reader["Email"].ToString();
                textBox_Contact.Text = reader["Contact"].ToString();
                textBox_Address.Text = reader["Address"].ToString();
                listBox_Subject.SelectedItem = reader["Subject1"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            //  Cancel the update
            //
            this.Close();
        }
    }
}
