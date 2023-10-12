using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    public partial class RecepProfile : Form
    {
        public string username, password;
        public RecepProfile(string n, string p)
        {
            InitializeComponent();
            username = n;
            password = p;

        }
        public RecepProfile()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ProfileEdit profileEdit = new ProfileEdit(username, password);
            Hide();
            profileEdit.ShowDialog();
            Show();
        }

        private void RecepProfile_Load(object sender, EventArgs e)
        {
            ArrayList name = new ArrayList(Receptionist.showdetails(username, password));
            lblName.Text = name[0].ToString();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
