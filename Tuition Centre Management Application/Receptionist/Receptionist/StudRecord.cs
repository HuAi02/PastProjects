using System;
using System.Collections;
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
    public partial class StudRecord : Form
    {
        public static string username;
        public StudRecord(string n)
        {
            InitializeComponent();
            username = n;
            this.Activated += new EventHandler(StudRecord_Activated);
            }
        public StudRecord()
        {
            InitializeComponent();
        }

        private void StudRecord_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtbxSearch.Text != String.Empty)
            {
                lstbxID.Items.Clear();
                lstbxName.Items.Clear();
                ArrayList nm = new ArrayList(StudentRecord.viewRecordName(txtbxSearch.Text));
                foreach (var item in nm)
                {
                    lstbxName.Items.Add(item);
                }
                ArrayList ide = new ArrayList(StudentRecord.viewRecordID(txtbxSearch.Text));
                foreach (var item1 in ide)
                {

                    lstbxID.Items.Add(item1);
                }

            }
            else
            {
                lstbxID.Items.Clear();
                lstbxName.Items.Clear();
                ArrayList nm = new ArrayList(StudentRecord.viewRecordName());
                foreach (var item in nm)
                {
                    lstbxName.Items.Add(item);
                }
                ArrayList ide = new ArrayList(StudentRecord.viewRecordID());
                foreach (var item1 in ide)
                {

                    lstbxID.Items.Add(item1);
                }
            }
        }

        private void lstbxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxID.SelectedIndex = lstbxName.SelectedIndex;
        }

        private void lstbxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstbxName.SelectedIndex = lstbxID.SelectedIndex;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Hide();
            EditStudRecord editStudRecord = new EditStudRecord(lstbxID.Text);
            editStudRecord.ShowDialog();
            Show();
        }
        private void StudRecord_Activated(object sender, EventArgs e)
        {
            lstbxID.Items.Clear();
            lstbxName.Items.Clear();
            ArrayList nm = new ArrayList(StudentRecord.viewRecordName());
            ArrayList ide = new ArrayList(StudentRecord.viewRecordID());
            foreach (var item in nm)
            {
                lstbxName.Items.Add(item);
            }
            foreach (var item1 in ide)
            {
                lstbxID.Items.Add(item1);
            }
        }
    }
}
