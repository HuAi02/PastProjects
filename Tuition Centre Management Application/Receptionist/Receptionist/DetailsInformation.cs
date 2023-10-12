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
    public partial class DetailsInformation : Form
    {
        public string ClassID;
        public DetailsInformation(string classid)
        {
            InitializeComponent();
            ClassID = classid;

        }
        private void DetailsInformation_Load(object sender, EventArgs e)
        {
            
            //Load the student list into the listbox
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myCS"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE (Subject1 = '" + ClassID + "' OR Subject2 = '" + ClassID + "' OR Subject3 = '" + ClassID + "')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listbxStuList.Items.Add(reader["UserID"].ToString());
            }
            con.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailsInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
