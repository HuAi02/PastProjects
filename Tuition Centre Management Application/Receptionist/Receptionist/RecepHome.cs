using System;

namespace Group1_IOOP
{
    public partial class RecepHome : Form
    {
        public static string username, password;
        public RecepHome(string n, string p)
        {
            InitializeComponent();
            username = n;
            password = p;
            string greet = "Hello there,";
            string now = DateTime.Now.ToString("s");
            int hour = Convert.ToInt32(now.Substring(11,2));
            if (hour > 6 && hour < 12)
                greet = "Good morning,";
            else if (hour >= 0 && hour <= 6)
                greet = "Good day,";
            else if (hour >= 12 && hour < 19)
                greet = "Good afternoon,";
            else if (hour >= 19 && hour < 24)
                greet = ("Good evening,");
            lblWelcome.Text = greet + " " + username + ".";
        }
        public RecepHome()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNewStud_Click(object sender, EventArgs e)
        {
            RegStudent regStudent = new RegStudent(username);
            Hide();
            regStudent.ShowDialog();
            Show();
        }

        private void btnStudRecord_Click(object sender, EventArgs e)
        {
            StudRecord studRecord = new StudRecord(username);
            Hide();
            studRecord.ShowDialog();
            Show();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PayReceipt payReceipt = new PayReceipt();
            Hide();
            payReceipt.ShowDialog();
            Show();
        }

        private void btnRequests_Click(object sender, EventArgs e)
        {
            Requests requests = new Requests(username);
            Hide();
            requests.ShowDialog();
            Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            RecepProfile recepProfile = new RecepProfile(username, password);
            Hide();
            recepProfile.ShowDialog();
            Show();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}