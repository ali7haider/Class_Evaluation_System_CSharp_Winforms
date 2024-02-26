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
using System.Xml.Linq;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class EditAssessment : Form
    {
        int id = -1;
        public EditAssessment(string title,string tMarks,string wMarks,string Id)
        {
            InitializeComponent();
            txtTitle.Text = title;  
            txtTotalMarks.Text = tMarks;
            txtTotalWeightage.Text = wMarks;
            id = int.Parse(Id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Assessment SET Title=@Title,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage Where Id= '" + id + "'", con);
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", txtTotalWeightage.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Updated Succesfully");
            this.Close();
        }
    }
}
