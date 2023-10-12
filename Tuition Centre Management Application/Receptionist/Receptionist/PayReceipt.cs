using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Collections;

namespace Group1_IOOP
{
    public partial class PayReceipt : Form
    {
        public PayReceipt()
        {
            InitializeComponent();
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt downloaded", "Successful");
        }

        private void PayReceipt_Load(object sender, EventArgs e)
        {
            ArrayList names = new ArrayList(Receipt.getnames());
            
            foreach (var item in names)
            {
                cmbbxName.Items.Add(item.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList ids = new ArrayList(Receipt.getids());
            Receipt rec1 = new Receipt(ids[cmbbxName.SelectedIndex].ToString(), txtbxAmount.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
