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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class EditRubric : Form
    {
        string currentId;
        public EditRubric(string details,string CloId,string Id)
        {
            InitializeComponent();
            loadData();
            currentId = Id;
            txtRubricDetail.Text = details;
            int id=int.Parse(CloId);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name From Clo Where Id = '" + id + "'", con);
            object data = cmd.ExecuteScalar();
            string result = (string)data;
            cmd.ExecuteNonQuery();
            cmbxCLO.Text = result;


        }
        public void loadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name From Clo", con);
            SqlDataAdapter da = new SqlDataAdapter("Select Name From Clo", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Name");
            cmbxCLO.DisplayMember = "Name";
            cmbxCLO.ValueMember = "Name";
            cmbxCLO.DataSource = ds.Tables["Name"];
            cmd.ExecuteNonQuery();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
        private int getCLOId(string CLO)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Clo WHERE Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", CLO);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            int id = getCLOId(cmbxCLO.Text);
            SqlCommand cmd = new SqlCommand("UPDATE Rubric SET Details=@Details,CloId=@CloId Where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", currentId);
            cmd.Parameters.AddWithValue("@Details", txtRubricDetail.Text);
            cmd.Parameters.AddWithValue("@CloId", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Succesfully");
            this.Close();
        }
    }
}
