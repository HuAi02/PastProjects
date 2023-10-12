using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    public partial class EditStudRecord : Form
    {
        public static string userid;
        public EditStudRecord(string n)
        {
            InitializeComponent();
            userid = n;
        }
        public EditStudRecord()
        {
            InitializeComponent();
        }

        private void EditStudRecord_Load(object sender, EventArgs e)
        {
            StudentRecord obj1 = new StudentRecord(userid);
            lblName.Text = obj1.Name;
            lblUserID.Text = obj1.Id;
            lblUserEmail.Text = obj1.Email;
            lblUserPhoneNum.Text = obj1.Phonenum;
            if (obj1.Gender)
            {
                lblUserGender.Text = "Male";
            }
            else
            {
                lblUserGender.Text = "Female";
            }
            cmbbxLvl.Text = obj1.Level.ToString();

            cmbbxSubj1.Text = obj1.Sub1;
            cmbbxSubj2.Text = obj1.Sub2;
            cmbbxSubj3.Text = obj1.Sub3;

            cmbbxSubj1.Items.Clear();
            cmbbxSubj1.Items.Add("None");
            cmbbxSubj1.Items.Add("Chinese");
            cmbbxSubj1.Items.Add("English");
            cmbbxSubj1.Items.Add("Malay");
            cmbbxSubj1.Items.Add("Mathematics");
            cmbbxSubj2.Items.Clear();
            cmbbxSubj2.Items.Add("None");
            cmbbxSubj2.Items.Add("Chinese");
            cmbbxSubj2.Items.Add("English");
            cmbbxSubj2.Items.Add("Malay");
            cmbbxSubj2.Items.Add("Mathematics");
            cmbbxSubj3.Items.Clear();
            cmbbxSubj3.Items.Add("None");
            cmbbxSubj3.Items.Add("Chinese");
            cmbbxSubj3.Items.Add("English");
            cmbbxSubj3.Items.Add("Malay");
            cmbbxSubj3.Items.Add("Mathematics");
            if (cmbbxLvl.Text == "4" || cmbbxLvl.Text == "5")
            {
                cmbbxSubj1.Items.Add("Biology");
                cmbbxSubj1.Items.Add("Chemistry");
                cmbbxSubj1.Items.Add("Physics");
                cmbbxSubj2.Items.Add("Biology");
                cmbbxSubj2.Items.Add("Chemistry");
                cmbbxSubj2.Items.Add("Physics");
                cmbbxSubj3.Items.Add("Biology");
                cmbbxSubj3.Items.Add("Chemistry");
                cmbbxSubj3.Items.Add("Physics");
            }
            else if (cmbbxLvl.Text == "1" || cmbbxLvl.Text == "2" || cmbbxLvl.Text == "3")
            {
                cmbbxSubj3.Items.Add("Science");
            }
            lblStudentID.Text = "#" + userid;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = StudentRecord.delRecord(userid);
            if (count != 0)
                MessageBox.Show(lblName.Text + " was removed from the database.", "Deleted successfully");
            else
                MessageBox.Show("Deletion aborted.", "Error: Something went wrong");
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] input = {"Chinese","Malay","English","Mathematics","Science","Chemistry","Biology","Physics"};
            int[] lvls = { 1, 2, 3, 4, 5 };
            bool proper1 = input.Contains(cmbbxSubj1.Text);
            bool proper2 = input.Contains(cmbbxSubj2.Text);
            bool proper3 = input.Contains(cmbbxSubj3.Text);
            bool proper4 = lvls.Contains(Convert.ToInt32(cmbbxLvl.Text));
            if (proper1 && proper2 && proper3 && proper4)
            {
                int count = StudentRecord.editRecord(userid, cmbbxSubj1.Text, cmbbxSubj2.Text, cmbbxSubj3.Text, cmbbxLvl.Text);
                if (count != 0)
                    MessageBox.Show("Details of " + lblName.Text + " have been updated.", "Changes saved");
                else
                    MessageBox.Show("Changes not saved.", "Error: Something went wrong");
                this.Close();
            }
            else
                MessageBox.Show("Please select from the options provided.", "Error: Subject or level not found");
        }

        private void cmbbxLvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbxSubj1.Items.Clear();
            cmbbxSubj1.Items.Add("None");
            cmbbxSubj1.Items.Add("Chinese");
            cmbbxSubj1.Items.Add("English");
            cmbbxSubj1.Items.Add("Malay");
            cmbbxSubj1.Items.Add("Mathematics");
            cmbbxSubj2.Items.Clear();
            cmbbxSubj2.Items.Add("None");
            cmbbxSubj2.Items.Add("Chinese");
            cmbbxSubj2.Items.Add("English");
            cmbbxSubj2.Items.Add("Malay");
            cmbbxSubj2.Items.Add("Mathematics");
            cmbbxSubj3.Items.Clear();
            cmbbxSubj3.Items.Add("None");
            cmbbxSubj3.Items.Add("Chinese");
            cmbbxSubj3.Items.Add("English");
            cmbbxSubj3.Items.Add("Malay");
            cmbbxSubj3.Items.Add("Mathematics");
            if (cmbbxLvl.SelectedIndex == 3 || cmbbxLvl.SelectedIndex == 4)
            {
                
                cmbbxSubj1.Items.Add("Biology");
                cmbbxSubj1.Items.Add("Chemistry");
                cmbbxSubj1.Items.Add("Physics");
                cmbbxSubj2.Items.Add("Biology");
                cmbbxSubj2.Items.Add("Chemistry");
                cmbbxSubj2.Items.Add("Physics");
                cmbbxSubj3.Items.Add("Biology");
                cmbbxSubj3.Items.Add("Chemistry");
                cmbbxSubj3.Items.Add("Physics");
            }
            else if (cmbbxLvl.SelectedIndex == 0 || cmbbxLvl.SelectedIndex == 1 || cmbbxLvl.SelectedIndex == 2)
            {
                cmbbxSubj1.Items.Add("Science");
                cmbbxSubj2.Items.Add("Science");
                cmbbxSubj3.Items.Add("Science");
            }
            if (cmbbxSubj1.Text == "Biology" || cmbbxSubj1.Text == "Chemistry" || cmbbxSubj1.Text == "Physics" || cmbbxSubj2.Text == "Biology" || cmbbxSubj2.Text == "Chemistry" || cmbbxSubj2.Text == "Physics" || cmbbxSubj3.Text == "Biology" || cmbbxSubj3.Text == "Chemistry" || cmbbxSubj3.Text == "Physics")
            {
                MessageBox.Show("This level does not have Biology, Chemistry, and Physics as subjects.", "Error: Please check again");
                if (cmbbxSubj1.Text == "Biology" || cmbbxSubj1.Text == "Chemistry" || cmbbxSubj1.Text == "Physics")
                    cmbbxSubj1.Text = "None";
                if (cmbbxSubj2.Text == "Biology" || cmbbxSubj2.Text == "Chemistry" || cmbbxSubj2.Text == "Physics")
                    cmbbxSubj2.Text = "None";
                if (cmbbxSubj3.Text == "Biology" || cmbbxSubj3.Text == "Chemistry" || cmbbxSubj3.Text == "Physics")
                    cmbbxSubj3.Text = "None";
            }
            else if(cmbbxSubj1.Text.Trim() == "Science" || cmbbxSubj2.Text.Trim() == "Science" || cmbbxSubj3.Text.Trim() == "Science")
            {
            MessageBox.Show("This level does not have Science as a subject.", "Error: Please check again");
            if (cmbbxSubj1.Text == "Science")
                cmbbxSubj1.Text = "None";
            if (cmbbxSubj2.Text == "Science")
                cmbbxSubj2.Text = "None";
            if (cmbbxSubj3.Text == "Science")
                cmbbxSubj3.Text = "None";
            }
        }

        private void cmbbxSubj1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    } 
}
