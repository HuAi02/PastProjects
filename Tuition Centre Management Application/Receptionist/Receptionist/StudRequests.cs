using System;
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
    public partial class StudRequests : Form
    {
        public static string reqid;
        public StudRequests()
        {
            InitializeComponent();
        }

        public StudRequests(string id)
        {
            InitializeComponent();
            reqid = id;
        }

        private void StudRequests_Load(object sender, EventArgs e)
        {
            lblName.Text = Request.viewReq(reqid);
            Request obj1 = new Request(reqid, lblName.Text);
            lblRequestID.Text = "#"+obj1.Reqid;
            lblSubjNew.Text = obj1.Newsub;
            lblSubjOld.Text = obj1.Oldsub;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Request.acceptReq(lblRequestID.Text.Substring(1), lblSubjOld.Text, lblSubjNew.Text);
            this.Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Request.rejectreq(lblRequestID.Text.Substring(1));
            this.Close();
        }
    }
}
