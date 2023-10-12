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
using static System.Net.Mime.MediaTypeNames;


namespace Group1_IOOP
{
    public partial class Administeration : Form
    {
        SqlCommandBuilder cn;
        SqlDataAdapter sda;
        public Administeration()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_State_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Load sql data into the datagridview
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["UserID"].Frozen = true;
            con.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Peform a delete operation on the selected row
            DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", con);
                cmd.Parameters.AddWithValue("@UserID", dataGridView1.SelectedCells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Delete Successful");
                Form3_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Record not deleted");
            }
        }

        // Using Loop and postion of datagrid to register and update sql data 
        private void Update_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
                con.Open();
                SqlCommand cmd = new SqlCommand("update Users set UserName=@UserName,Password=@Password, Role=@Role, FirstName=@FirstName, LastName=@LastName, Level=@Level, ICPassport=@ICPassport, Email=@Email, Contact=@Contact, Address=@Address, Subject1=@Subject1, Subject2=@Subject2, Subject3=@Subject3, EnrolmentMonth1=@EnrolmentMonth1, EnrolmentMonth2=@EnrolmentMonth2, EnrolmentMonth3=@EnrolmentMonth3, Gender=@Gender where UserID=@UserID", con);

                cmd.Parameters.AddWithValue("@UserID", dataGridView1.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@UserName", dataGridView1.Rows[i].Cells[1].Value);
                cmd.Parameters.AddWithValue("@Password", dataGridView1.Rows[i].Cells[2].Value);
                cmd.Parameters.AddWithValue("@Role", dataGridView1.Rows[i].Cells[3].Value);
                cmd.Parameters.AddWithValue("@FirstName", dataGridView1.Rows[i].Cells[4].Value);
                cmd.Parameters.AddWithValue("@LastName", dataGridView1.Rows[i].Cells[5].Value);
                cmd.Parameters.AddWithValue("@Level", dataGridView1.Rows[i].Cells[6].Value);
                cmd.Parameters.AddWithValue("@ICPassport", dataGridView1.Rows[i].Cells[7].Value);
                cmd.Parameters.AddWithValue("@Email", dataGridView1.Rows[i].Cells[8].Value);
                cmd.Parameters.AddWithValue("@Contact", dataGridView1.Rows[i].Cells[9].Value);
                cmd.Parameters.AddWithValue("@Address", dataGridView1.Rows[i].Cells[10].Value);
                cmd.Parameters.AddWithValue("@Subject1", dataGridView1.Rows[i].Cells[11].Value);
                cmd.Parameters.AddWithValue("@Subject2", dataGridView1.Rows[i].Cells[12].Value);
                cmd.Parameters.AddWithValue("@Subject3", dataGridView1.Rows[i].Cells[13].Value);
                cmd.Parameters.AddWithValue("@EnrolmentMonth1", dataGridView1.Rows[i].Cells[14].Value);
                cmd.Parameters.AddWithValue("@EnrolmentMonth2", dataGridView1.Rows[i].Cells[15].Value);
                cmd.Parameters.AddWithValue("@EnrolmentMonth3", dataGridView1.Rows[i].Cells[16].Value);
                cmd.Parameters.AddWithValue("@Gender", dataGridView1.Rows[i].Cells[17].Value);


                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        // Load and refresh sql data in the datagrid
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Search engine that define specific role and UserID to ease malnuplating  operation in sql data.
        private void View_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand sda = new SqlCommand("SELECT * FROM Users where Role ='"+ SpecificRoletb.Text +"' AND UserId = '"+ SpecificUserIDtb.Text +"'", con);
            sda.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(sda);
            da1.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        // create a NULL-filled row to gives space for new input.
        private void Add_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            string temp = string.Empty;
            SqlCommand newcmd = new SqlCommand("select UserID from Users order by len(UserID) DESC, UserID DESC", con); //attempt to find the largest user id from database
            temp = newcmd.ExecuteScalar().ToString(); // convert sql command output to string
            string temp1 = temp.Substring(1); //get the numbers in id only
            int IDitself = Convert.ToInt32(temp1); //removing the prefix from user id
            IDitself += 1; // add one to the largest id number
            temp = temp.Substring(0, 1) + IDitself.ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(UserID, Username, Password, Role, FirstName, LastName, Level, ICPassport, Email, Contact, Address, Subject1, Subject2, Subject3, EnrolmentMonth1, EnrolmentMonth2, EnrolmentMonth3, Gender ) VALUES ('" + temp + "', NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
} 
    

