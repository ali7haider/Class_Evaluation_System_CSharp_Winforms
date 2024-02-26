using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class EditRubricLevel : Form
    {
        int id = -1;
        public EditRubricLevel(string details,string level,string Id)
        {
            InitializeComponent();
            txtLevelDetail.Text = details;    
            txtMeasurmentLevel.Text = level;
            id = int.Parse(Id);
        }

        private void EditRubricLevel_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE RubricLevel SET Details=@Details,MeasurementLevel=@MeasurementLevel Where Id='" + id + "'", con);
            cmd.Parameters.AddWithValue("@Details", txtLevelDetail.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", txtMeasurmentLevel.Text);            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Succesfully");
            this.Close();
        }
    }
}
