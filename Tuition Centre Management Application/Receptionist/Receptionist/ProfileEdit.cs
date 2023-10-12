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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    public partial class ProfileEdit : Form
    {
        public string username, password;
        public ProfileEdit(string n, string p)
        {
            InitializeComponent();
            username = n;
            password = p;
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbxPassword.Text == txtbxConfirm.Text)
            {
                if (Regex.IsMatch(txtbxPhoneNum.Text, @"^+?\d{0,3}-?\d{5,9}") && txtbxEmail.Text.Contains("@") && txtbxEmail.Text.Contains(".com"))
                    Receptionist.editProfile(lblID.Text, txtbxConfirm.Text, txtbxEmail.Text, txtbxPhoneNum.Text, txtbxAddress.Text);
                else
                    MessageBox.Show("Please follow the format provided.", "Error: Invalid input format");
            }
            else
            {
                MessageBox.Show("Your passwords do not match.", "Error: Mismatched passwords");
                txtbxPassword.Text = string.Empty;
                txtbxConfirm.Text = string.Empty;
            }
        }

        private void ProfileEdit_Load(object sender, EventArgs e)
        {
            ArrayList original = new ArrayList(Receptionist.showdetails(username, password));
            lblName.Text = original[0].ToString();
            txtbxEmail.Text = original[1].ToString();
            txtbxPhoneNum.Text = original[2].ToString();
            txtbxAddress.Text = original[3].ToString();
            lblID.Text = original[4].ToString();
        }
    }
}
