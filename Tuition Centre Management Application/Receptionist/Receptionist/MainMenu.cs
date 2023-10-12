using System.Configuration;
using System.Data.SqlClient;

namespace Group1_IOOP
{
    public partial class MainMenu : Form
    {
        public string userid;
        public MainMenu()
        {
            InitializeComponent();
        }

        public MainMenu(string usid)
        {
            InitializeComponent();
            userid = usid;
        }

        private Form activeForm = null;

        // open child form panel and initialize the process
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    
        //invoke monnthly income report form 
        private void button1_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new MonthlyIncomeReport());
        }

        //invoke monnthly income administeration form 
        private void button2_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Administeration());
        }

        //invoke profle edit form 
        private void button4_Click_1(object sender, EventArgs e)
        {
            openChildFormInPanel(new EditProfile(userid));
        }

        private void panelChildform_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Initilaze and get the userId of the user using this program 
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            string usr = String.Empty;
            SqlCommand cmd2 = new SqlCommand("select Username from Users where UserID ='" + userid + "'", con);
            string username = cmd2.ExecuteScalar().ToString();
            Usernamelb.Text = username;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Logout the user
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
    }
}