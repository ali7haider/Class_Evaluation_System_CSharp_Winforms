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
    public partial class EditAssessmentComponent : Form
    {
        int id = -1;
        public EditAssessmentComponent(string Id,string Name,string RubricId,string TotalMarks,string AssessmentId)
        {
            InitializeComponent();
            loadComboxes();
            txtName.Text = Name;    
            cmbxRubricId.Text = RubricId;
            cmbxAssessmentId.Text= AssessmentId;
            txtTotalMarks.Text = TotalMarks;
            id=int.Parse(Id);
            
            

        }
        public void loadRubricDetails()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Details From Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxRubricId.DataSource = dt;
            cmbxRubricId.DisplayMember = "Details";
            cmbxRubricId.ValueMember = "Id";


        }
        public void loadComboxes()
        {
            loadAssessmentDetails();
            loadRubricDetails();
        }
        public void loadAssessmentDetails()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Title From Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxAssessmentId.DataSource = dt;
            cmbxAssessmentId.DisplayMember = "Title";
            cmbxAssessmentId.ValueMember = "Id";

        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE AssessmentComponent SET Name=@Name,RubricId=@RubricId,TotalMarks=@TotalMarks,DateUpdated=@DateUpdated,AssessmentId=@AssessmentId Where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name",   txtName.Text);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(cmbxRubricId.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Today);
            cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(cmbxAssessmentId.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Updated Succesfully");
            this.Close();
        }
        

        
    }
}
