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
    public partial class Requests : Form
    {
        public static string username;
        public Requests(string n)
        {
            InitializeComponent();
            username = n;
            this.Activated += new EventHandler(Requests_Activated);
        }
        public Requests()
        {
            InitializeComponent();
        }

        private void Requests_Load(object sender, EventArgs e)
        {
        }

        private void Requests_Activated(object sender, EventArgs e)
        {
            lstbxID.Items.Clear();
            lstbxName.Items.Clear();
            ArrayList ide = new ArrayList(Request.viewReqID());
            ArrayList nm = new ArrayList();
            foreach (var item1 in ide)
            {
                lstbxID.Items.Add(item1);
                nm.Add(Request.viewReq(item1.ToString()).ToString());
            }
            foreach (var item in nm)
            {
                lstbxName.Items.Add(item);
            }
            
            lstbxID.SelectedIndex = 0;
        }

        private void lstbxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxID.SelectedIndex = lstbxName.SelectedIndex;        
        }

        private void lstbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxName.SelectedIndex = lstbxID.SelectedIndex;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstbxID.Items.Clear();
            lstbxName.Items.Clear();
            ArrayList ide = new ArrayList(Request.searchReqID(txtbxSearch.Text));
            ArrayList nm = new ArrayList();
            foreach (var item1 in ide)
            {
                lstbxID.Items.Add(item1);
                nm.Add(Request.viewReq(item1.ToString()).ToString());
            }
            foreach (var item in nm)
            {
                lstbxName.Items.Add(item);
            }

            lstbxID.SelectedIndex = 0;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Hide();
            StudRequests studRequests = new StudRequests(lstbxID.Text);
            studRequests.ShowDialog();
            Show();
        }
    }
}
