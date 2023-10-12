using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    public partial class RegStudent : Form
    {
        public static string username;
        public RegStudent(string n)
        {
            InitializeComponent();
            username = n;

            cmbbxLvl.SelectedIndex = 0;
            cmbbxSubj1.SelectedIndex = 0;
            cmbbxSubj2.SelectedIndex = 0;
            cmbbxSubj3.SelectedIndex = 0;
            cmbbxGender.SelectedIndex = 0;
        }
        public RegStudent()
        {
            InitializeComponent();
            cmbbxLvl.SelectedIndex = 0;
            cmbbxSubj1.SelectedIndex = 0;
            cmbbxSubj2.SelectedIndex = 0;
            cmbbxSubj3.SelectedIndex = 0;
            cmbbxGender.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbxName1.Text = String.Empty;
            txtbxEmail.Text = String.Empty;
            txtbxName2.Text = String.Empty;
            txtbxID.Text = String.Empty;
            txtbxPhoneNum.Text = String.Empty;
            cmbbxLvl.SelectedIndex = 0;
            cmbbxSubj1.SelectedIndex = 0;
            cmbbxSubj2.SelectedIndex = 0;
            cmbbxSubj3.SelectedIndex = 0;
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbbxLvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxLvl.Text == "4" || cmbbxLvl.Text == "5")
            {
                cmbbxSubj1.Items.Clear();
                cmbbxSubj1.Items.Add("None");
                cmbbxSubj1.Items.Add("Chinese");
                cmbbxSubj1.Items.Add("English");
                cmbbxSubj1.Items.Add("Malay");
                cmbbxSubj1.Items.Add("Mathematics");
                cmbbxSubj1.Items.Add("Biology");
                cmbbxSubj1.Items.Add("Chemistry");
                cmbbxSubj1.Items.Add("Physics");
                cmbbxSubj2.Items.Clear();
                cmbbxSubj2.Items.Add("None");
                cmbbxSubj2.Items.Add("Chinese");
                cmbbxSubj2.Items.Add("English");
                cmbbxSubj2.Items.Add("Malay");
                cmbbxSubj2.Items.Add("Mathematics");
                cmbbxSubj2.Items.Add("Biology");
                cmbbxSubj2.Items.Add("Chemistry");
                cmbbxSubj2.Items.Add("Physics");
                cmbbxSubj3.Items.Clear();
                cmbbxSubj3.Items.Add("None");
                cmbbxSubj3.Items.Add("Chinese");
                cmbbxSubj3.Items.Add("English");
                cmbbxSubj3.Items.Add("Malay");
                cmbbxSubj3.Items.Add("Mathematics");
                cmbbxSubj3.Items.Add("Biology");
                cmbbxSubj3.Items.Add("Chemistry");
                cmbbxSubj3.Items.Add("Physics");
            }
            else if (cmbbxLvl.Text == "1" || cmbbxLvl.Text == "2" || cmbbxLvl.Text == "3")
            {
                cmbbxSubj1.Items.Clear();
                cmbbxSubj1.Items.Add("None");
                cmbbxSubj1.Items.Add("Chinese");
                cmbbxSubj1.Items.Add("English");
                cmbbxSubj1.Items.Add("Malay");
                cmbbxSubj1.Items.Add("Mathematics");
                cmbbxSubj1.Items.Add("Science");
                cmbbxSubj2.Items.Clear();
                cmbbxSubj2.Items.Add("None");
                cmbbxSubj2.Items.Add("Chinese");
                cmbbxSubj2.Items.Add("English");
                cmbbxSubj2.Items.Add("Malay");
                cmbbxSubj2.Items.Add("Mathematics");
                cmbbxSubj2.Items.Add("Science");
                cmbbxSubj3.Items.Clear();
                cmbbxSubj3.Items.Add("None");
                cmbbxSubj3.Items.Add("Chinese");
                cmbbxSubj3.Items.Add("English");
                cmbbxSubj3.Items.Add("Malay");
                cmbbxSubj3.Items.Add("Mathematics");
                cmbbxSubj3.Items.Add("Science");
            }
        }

        private void cmbbxSubj1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbbxLvl.Text == "1" || cmbbxLvl.Text == "2" || cmbbxLvl.Text == "3") && (cmbbxSubj1.Text == "Biology" || cmbbxSubj1.Text == "Chemistry" || cmbbxSubj1.Text == "Physics"))
            {
                MessageBox.Show("This level does not have Biology, Chemistry, and Physics as subjects.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
            else if ((cmbbxLvl.Text == "4" || cmbbxLvl.Text == "5") && (cmbbxSubj1.Text == "Science" || cmbbxSubj2.Text == "Science" || cmbbxSubj3.Text == "Science"))
            {
                MessageBox.Show("This level does not have Science as a subject.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
        }

        private void cmbbxSubj2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbbxLvl.Text == "1" || cmbbxLvl.Text == "2" || cmbbxLvl.Text == "3") && (cmbbxSubj1.Text == "Biology" || cmbbxSubj1.Text == "Chemistry" || cmbbxSubj1.Text == "Physics"))
            {
                MessageBox.Show("This level does not have Biology, Chemistry, and Physics as subjects.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
            else if ((cmbbxLvl.Text == "4" || cmbbxLvl.Text == "5") && (cmbbxSubj1.Text == "Science" || cmbbxSubj2.Text == "Science" || cmbbxSubj3.Text == "Science"))
            {
                MessageBox.Show("This level does not have Science as a subject.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
        }

        private void cmbbxSubj3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbbxLvl.Text == "1" || cmbbxLvl.Text == "2" || cmbbxLvl.Text == "3") && (cmbbxSubj1.Text == "Biology" || cmbbxSubj1.Text == "Chemistry" || cmbbxSubj1.Text == "Physics"))
            {
                MessageBox.Show("This level does not have Biology, Chemistry, and Physics as subjects.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
            else if ((cmbbxLvl.Text == "4" || cmbbxLvl.Text == "5") && (cmbbxSubj1.Text == "Science" || cmbbxSubj2.Text == "Science" || cmbbxSubj3.Text == "Science"))
            {
                MessageBox.Show("This level does not have Science as a subject.", "Error: Please check again");
                cmbbxSubj1.Text = "None";
            }
        }

        private void RegStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool gender;
            if (cmbbxGender.Text == "Male")
                gender = true;
            else
                gender = false;
            //if (txtbxID.Text == @"^\d{6}\-\d{2}\-\d{4}$" && txtbxPhoneNum.Text == @"^+?\d{0,3}-?\d{5,9}" && txtbxEmail.Text == @"^[^@\s]+@[^@\s]+.[^@\s]+$")
            if (Regex.IsMatch(txtbxID.Text, @"^\d{6}\-\d{2}\-\d{4}$") && Regex.IsMatch(txtbxPhoneNum.Text, @"^+?\d{0,3}-?\d{5,9}") && txtbxEmail.Text.Contains("@") && txtbxEmail.Text.Contains(".com"))
            {
                StudentRecord obj = new StudentRecord(txtbxName1.Text, txtbxName2.Text, txtbxID.Text, txtbxEmail.Text, gender, txtbxPhoneNum.Text, cmbbxSubj1.Text, cmbbxSubj2.Text, cmbbxSubj3.Text, cmbbxLvl.Text, txtbxAddress.Text);
                txtbxName1.Text = String.Empty;
                txtbxEmail.Text = String.Empty;
                txtbxName2.Text = String.Empty;
                txtbxID.Text = String.Empty;
                txtbxPhoneNum.Text = String.Empty;
                txtbxAddress.Text = String.Empty;
                cmbbxLvl.SelectedIndex = 0;
                cmbbxSubj1.SelectedIndex = 0;
                cmbbxSubj2.SelectedIndex = 0;
                cmbbxSubj3.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Please follow the format provided.", "Error: Input format error");
        }
    }
}
