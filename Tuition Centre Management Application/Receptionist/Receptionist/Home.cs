using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Group1_IOOP
{
    public partial class Home : Form
    {
        public string UserID;
        public Home()
        {
            InitializeComponent();
        }

        public Home(string userid)
        {
            InitializeComponent();
            UserID = userid;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            //
            // View the details class information with student list
            //
            DetailsInformation detailsInformation = new DetailsInformation(dataGridView1.SelectedCells[0].Value.ToString());
            detailsInformation.label_Subject.Text = dataGridView1.SelectedCells[2].Value.ToString();
            detailsInformation.label_Charges.Text = dataGridView1.SelectedCells[5].Value.ToString();
            detailsInformation.label_Time.Text = dataGridView1.SelectedCells[4].Value.ToString();
            detailsInformation.ShowDialog();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            //
            // Load sql data into the datagridview
            //
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM class", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public static DataGridViewRow selectedrow;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //
            // Open the NewInformation form
            //
            NewInformation newInformation = new NewInformation();
            newInformation.ShowDialog();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //
            // Peform a delete operation on the selected row
            //
            DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM class WHERE ClassID = @ClassID", con);
                cmd.Parameters.AddWithValue("@ClassID", dataGridView1.SelectedCells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                Home_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Record not deleted");
            }
           
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //
            // Update the class information to the database
            //
            UpdateInformation updateInformation = new UpdateInformation();
            updateInformation.originalclassID = dataGridView1.SelectedCells[0].Value.ToString();
            updateInformation.textBox_ClassID.Text = dataGridView1.SelectedCells[0].Value.ToString();
            updateInformation.textBox_TutorUserID.Text = dataGridView1.SelectedCells[1].Value.ToString();
            updateInformation.textBox_Subject.Text = dataGridView1.SelectedCells[2].Value.ToString();
            updateInformation.textBox_Schedule.Text = dataGridView1.SelectedCells[3].Value.ToString();
            updateInformation.textBox_Time.Text = dataGridView1.SelectedCells[4].Value.ToString();
            updateInformation.textBox_Charges.Text = dataGridView1.SelectedCells[5].Value.ToString();
            updateInformation.ShowDialog();
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //
            // Refresh the data grid view
            //
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM class", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
            // Get the selected row
            //
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //
            // Preload the data grid view into background
            //
            Int32 selectedCellCount =
                dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0;
                        i < selectedCellCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(dataGridView1.SelectedCells[i].RowIndex
                            .ToString());
                        sb.Append(", Column: ");
                        sb.Append(dataGridView1.SelectedCells[i].ColumnIndex
                            .ToString());
                        sb.Append(Environment.NewLine);
                    }
                    sb.Append("Total: " + selectedCellCount.ToString());
                }
            }
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            // Close the application
            //
            DialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {

            }
            else
                e.Cancel = true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //
            // Logout the user
            //
            DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
                //Login login = new Login();
                //login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Logout Cancelled");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //
            // Direct to edit profile form
            //
            TutorEditProfile editProfile = new TutorEditProfile(UserID);
            editProfile.ShowDialog();    
        }
    }
}