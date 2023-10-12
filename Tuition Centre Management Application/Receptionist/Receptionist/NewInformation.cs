using System;
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

namespace Group1_IOOP
{
    public partial class NewInformation : Form
    {
        public NewInformation()
        {
            InitializeComponent();
        }

        private void NewInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.class' table. You can move, or remove it, as needed.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
            // Save and add the new class information to the database
            //
            string ClassID = textBox_ClassID.Text;
            string TutorUserID = textBox_TutorUserID.Text;
            string Subject = textBox_Subject.Text;
            string Schedule = textBox_Schedule.Text;
            string Time = textBox_Time.Text;
            int Charges = Convert.ToInt32(textBox_Charges.Text);


            DialogResult dialog = MessageBox.Show("Are you sure you want to add this information?", "Add Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                //
                // Check if the class ID already exists
                //
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM class WHERE ClassID = @ClassID", con);
                cmd.Parameters.AddWithValue("@ClassID", ClassID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Class ID already exists.");
                }
                else
                {
                    DataProcess objDataProcess = new DataProcess();
                    objDataProcess.AddNewClassInformation(ClassID, TutorUserID, Subject, Schedule, Time, Charges);
                    reset();
                    MessageBox.Show("Add Successful");
                }

            }
            else if (dialog == DialogResult.No)
            {
                // Do nothing
            }
            this.Close();
        }

        private void reset()
        {
            textBox_ClassID.Text = "";
            textBox_TutorUserID.Text = "";
            textBox_Subject.Text = "";
            textBox_Schedule.Text = "";
            textBox_Time.Text = "";
            textBox_Charges.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
