using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_IOOP
{
    class DataProcess
    {
        DBAccess objDBConnection = new DBAccess();
        
        public void AddNewClassInformation(string classID, string tutorUserID, string subject, string schedule, string time, int charges)
        {
            DBAccess objDBConnection = new DBAccess();
            objDBConnection.createConn();
            SqlCommand cmd = new SqlCommand(" Insert INTO class([ClassID], [TutorUserID], [Subject], [Schedule], [Time], [Charges])values('" + classID + "','" + tutorUserID + "','" + subject + "','" + schedule + "','" + time + "','" + charges + "')", DBAccess.connection);
            cmd.ExecuteNonQuery();
            objDBConnection.closeConn();

            MessageBox.Show("Information of " + classID + " was added sucessfullly.");
        }
    }
}
        
