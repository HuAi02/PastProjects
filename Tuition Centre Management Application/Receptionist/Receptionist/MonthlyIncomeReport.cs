using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Group1_IOOP
{
    public partial class MonthlyIncomeReport : Form
    {
        public MonthlyIncomeReport()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        //Refresh the program with new program 
        private void Refreshbt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MonthlyReport", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        // Claculate Monthly Income Report
        private void Calculatebt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            string subname = String.Empty;
            string month = String.Empty;
            //Translating inputs into query-frindly variables
            switch (SpecificSubjecttb.Text)
            {
                case "Mathematics":
                    subname = "C-MATH-L";
                    break;
                case "Science":
                    subname = "C-SC-L";
                    break;
                case "Biology":
                    subname = "C-BIO-L";
                    break;
                case "Physics":
                    subname = "C-PHY-L";
                    break;
                case "Chemistry":
                    subname = "C-CHEM-L";
                    break;
                case "Chinese":
                    subname = "C-CN-L";
                    break;
                case "Malay":
                    subname = "C-BM-L";
                    break;
                case "English":
                    subname = "C-EN-L";
                    break;
            }
            switch (SpecificLeveltb.Text)
            {
                case "1":
                    subname = subname + "1";
                    break;
                case "2":
                    subname = subname + "2";
                    break;
                case "3":
                    subname = subname + "3";
                    break;
                case "4":
                    subname = subname + "4";
                    break;
                case "5":
                    subname = subname + "5";
                    break;
            }
            // Claculation.
            SqlCommand cmd = new SqlCommand("SELECT Charges from class where ClassID = '" + subname + "'", con);
            SqlCommand cmd2 = new SqlCommand("SELECT StudentCount from MonthlyReport where ClassID = '" + subname + "' and Month = '"+SpecificMonthtb.Text+"'", con);
            int val1 = Convert.ToInt32(cmd2.ExecuteScalar());
            int val2 = Convert.ToInt32(cmd.ExecuteScalar());
            int total = val1 * val2;

            MonthlyIncomeReporttb.Text = total.ToString();
            con.Close();
        }
        private void SpecificLeveltb_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Initialize & load data to datagrid
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM MonthlyReport", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void MonthlyIncomeReporttb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
