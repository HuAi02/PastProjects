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
    public partial class UpdateInformation : Form
    {
        public string originalclassID;

        public UpdateInformation()
        {
            InitializeComponent();
        }

        private void UpdateInformation_Load(object sender, System.EventArgs e)
        {
            //
            // Load the data from the selected row into the textboxes
            //
        }
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            //
            // Update the class information to the database
            //
            string OriginalClassID = originalclassID;
            string ClassID = textBox_ClassID.Text;
            string TutorUserID = textBox_TutorUserID.Text;
            string Subject = textBox_Subject.Text;
            string Schedule = textBox_Schedule.Text;
            string Time = textBox_Time.Text;
            int Charges = Convert.ToInt32(textBox_Charges.Text);


            DialogResult dialog = MessageBox.Show("Are you sure you want to update this information?", "Update Information", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (ClassID != OriginalClassID)
                {
                    MessageBox.Show("Class ID cannot be changed.");
                }
                else
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM class WHERE ClassID = @ClassID", con);
                    cmd.Parameters.AddWithValue("@ClassID", ClassID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Update Successful");
                    DataProcess objDataProcess = new DataProcess();
                    objDataProcess.AddNewClassInformation(ClassID, TutorUserID, Subject, Schedule, Time, Charges);
                    reset();
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
        private void btnBack_Click(object sender, EventArgs e)
        {
            //
            // Close the form
            //
            this.Close();
        }
    }
}
