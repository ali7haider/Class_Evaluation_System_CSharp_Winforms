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

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class EditMarkEvaluation : Form
    {
        int ACID;
        int SID;
        int RMID;
        public EditMarkEvaluation(string SID,string ACID,string RMID)
        {
            InitializeComponent();
            this.ACID=int.Parse(ACID);
            this.SID=int.Parse(SID);    
            this.RMID=int.Parse(RMID);
            loadComboBoxes();
            setStudentId();
            setAssessment();
            setAssessmentComponent();
            setRubric();
            setRubricLevel();

            

        }
        public void loadComboBoxes()
        {
            loadStudentIds();
            loadRubrics();
            loadAssessment();
            loadAssessmentComponentIds();
            loadRubricLevel();

        }

        public void loadStudentIds()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,RegistrationNumber From Student Where Status=5", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxStudenId.DataSource = dt;
            cmbxStudenId.DisplayMember = "RegistrationNumber";
            cmbxStudenId.ValueMember = "Id";

        }
        public void loadRubrics()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Details From Rubric", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxRubric.DataSource = dt;
            cmbxRubric.DisplayMember = "Details";
            cmbxRubric.ValueMember = "Id";

        }
        public void loadAssessmentComponentIds(int assessmentId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Name From AssessmentComponent Where AssessmentId= '" + assessmentId + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxAssessmentComponent.DataSource = dt;
            cmbxAssessmentComponent.DisplayMember = "Name";
            cmbxAssessmentComponent.ValueMember = "Id";


        }
        public void loadAssessmentComponentIds()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Name From AssessmentComponent ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxAssessmentComponent.DataSource = dt;
            cmbxAssessmentComponent.DisplayMember = "Name";
            cmbxAssessmentComponent.ValueMember = "Id";


        }
        public void loadRubricLevel(int rubricId)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,MeasurementLevel From RubricLevel Where RubricId= '" + rubricId + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxRubricLevel.DataSource = dt;
            cmbxRubricLevel.DisplayMember = "MeasurementLevel";
            cmbxRubricLevel.ValueMember = "Id";


        }
        public void loadRubricLevel()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,MeasurementLevel From RubricLevel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxRubricLevel.DataSource = dt;
            cmbxRubricLevel.DisplayMember = "MeasurementLevel";
            cmbxRubricLevel.ValueMember = "Id";


        }
        public void loadAssessment()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Title From Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxAssessment.DataSource = dt;
            cmbxAssessment.DisplayMember = "Title";
            cmbxAssessment.ValueMember = "Id";

        }

       
        private void setStudentId()
        {
           
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT RegistrationNumber FROM Student WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", SID);
            object data = cmd.ExecuteScalar();
            string result = data.ToString();
            
            cmd.ExecuteNonQuery();
            cmbxStudenId.Text = result;
        }
        private void setAssessment()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Title FROM AssessmentComponent AC JOIN Assessment A ON A.Id=AC.AssessmentId WHERE AC.Id='"+ ACID+"'", con);
            object data = cmd.ExecuteScalar();
            string result = data.ToString();
            cmd.ExecuteNonQuery();
            cmbxAssessment.Text = result;
        }
        private void setAssessmentComponent()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Name FROM AssessmentComponent WHERE Id='" + ACID + "'", con);
            object data = cmd.ExecuteScalar();
            string result = data.ToString();
            cmd.ExecuteNonQuery();
            
            cmbxAssessmentComponent.Text = result;
        }
        private void setRubric()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT R.Details FROM Rubric R JOIN RubricLevel RL ON R.Id=RL.RubricId WHERE RL.Id='" + RMID + "'", con);
            object data = cmd.ExecuteScalar();
            string result = data.ToString();
            cmd.ExecuteNonQuery();
            cmbxRubric.Text = result;
        }
        private void setRubricLevel()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT MeasurementLevel FROM  RubricLevel  WHERE Id='" + RMID + "'", con);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            
            cmbxRubricLevel.Text = result.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE StudentResult SET StudentId=@StudentId,AssessmentComponentId=@AssessmentComponentId,RubricMeasurementId=@RubricMeasurementId WHERE StudentId='"+SID+ "' AND AssessmentComponentId='"+ACID+ "' AND RubricMeasurementId='"+RMID+"'", con);
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(cmbxStudenId.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(cmbxAssessmentComponent.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(cmbxRubricLevel.SelectedValue.ToString()));            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Succesfully");
            this.Close();
           
        }

        private void cmbxAssessment_TextChanged_1(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxAssessment.SelectedValue.ToString());
            loadAssessmentComponentIds(id);
        }

        private void cmbxRubric_TextChanged_1(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxRubric.SelectedValue.ToString());
            loadRubricLevel(id);
        }
    }
}
