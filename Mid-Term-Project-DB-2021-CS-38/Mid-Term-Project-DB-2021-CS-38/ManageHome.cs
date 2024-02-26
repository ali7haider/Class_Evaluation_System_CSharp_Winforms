using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageHome : UserControl
    {
        public ManageHome()
        {
            InitializeComponent();
            setText();
            
        }
        public void setText()
        {
            lblTotalStudent.Text = setTotalStudents().ToString();
            lblTotalActiveStudents.Text = setTotalActiveStudents().ToString();
            lblTotalRubrics.Text = setTotalRubrics().ToString();
            lblTotalClos.Text = setTotalClos().ToString();
        }
        private int setTotalStudents()
        {
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Student", con);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        private int setTotalActiveStudents()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Student WHERE Status=5", con);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        private int setTotalClos()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Clo", con);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        private int setTotalRubrics()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Rubric", con);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        
    }
}
