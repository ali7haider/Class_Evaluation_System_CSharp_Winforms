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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageMarkEvalaution : UserControl
    {
        public ManageMarkEvalaution()
        {
            InitializeComponent();
            loadComboBoxes();
            displayStudentResult();
            moveButtons();
        }
        public void loadComboBoxes()
        {
            loadStudentIds();           
            loadRubrics();
            loadAssessment();
            
        }
        private void moveButtons()
        {
            studentResultTable.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            studentResultTable.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            studentResultTable.Columns["Edit"].DisplayIndex = studentResultTable.Columns.Count - 1;
            studentResultTable.Columns["Delete"].DisplayIndex = studentResultTable.Columns.Count - 1;


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
        public void loadAssessmentComponentIds(int assessmentId )
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Name From AssessmentComponent Where AssessmentId= '"+ assessmentId +"' ", con);
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

        private void cmbxAssessment_TextChanged(object sender, EventArgs e)
        {
            
            int id=int.Parse(cmbxAssessment.SelectedValue.ToString());
            loadAssessmentComponentIds(id);
        }

        private void cmbxRubric_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxRubric.SelectedValue.ToString());
            loadRubricLevel(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into StudentResult values(@StudentId,@AssessmentComponentId,@RubricMeasurementId,@EvaluationDate)", con);
            cmd.Parameters.AddWithValue("@StudentId", int.Parse(cmbxStudenId.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@AssessmentComponentId", int.Parse(cmbxAssessmentComponent.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@RubricMeasurementId", int.Parse(cmbxRubricLevel.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@EvaluationDate", DateTime.Today);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Succesfully");
            displayStudentResult();
            
        }
        private void displayStudentResult()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand(" SELECT SR.*,S.RegistrationNumber,S.FirstName + ' ' + S.LastName as [Student Name],Clo.Name as [Clo Name],R.Details as [Rubric],A.Title as [Assessment],AC.Name as [Component],AC.TotalMarks,cast( RL.MeasurementLevel*AC.TotalMarks/4 as decimal(10,2)) as [Obtained Marks] From StudentResult SR JOIn Student S ON S.Id=SR.StudentId JOIN AssessmentComponent AC ON AC.Id=SR.AssessmentComponentId JOIN RubricLevel RL ON RL.Id=SR.RubricMeasurementId join Assessment A on A.Id=AC.AssessmentId join Rubric R on R.Id=RL.RubricId join Clo on clo.Id=r.CloId\r\n", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            studentResultTable.DataSource = d;
            studentResultTable.AllowUserToAddRows = false;
            studentResultTable.Columns["StudentId"].Visible = false;
            studentResultTable.Columns["AssessmentComponentId"].Visible = false;
            studentResultTable.Columns["RubricMeasurementId"].Visible = false;



        }

        private void studentResultTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (studentResultTable.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From StudentResult Where StudentId=@StudentId AND AssessmentComponentId=@AssessmentComponentId AND RubricMeasurementId=@RubricMeasurementId ", con);
                    int selectedrowindex = studentResultTable.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = studentResultTable.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["StudentId"].Value);
                    string cellValue2 = Convert.ToString(selectedRow.Cells["AssessmentComponentId"].Value);
                    string cellValue3 = Convert.ToString(selectedRow.Cells["RubricMeasurementId"].Value);
                    int id = int.Parse(cellValue);
                    int ACID = int.Parse(cellValue2);
                    int RMID = int.Parse(cellValue3);
                    cmd.Parameters.AddWithValue("@StudentId", id);
                    cmd.Parameters.AddWithValue("@AssessmentComponentId", ACID);
                    cmd.Parameters.AddWithValue("@RubricMeasurementId", RMID);
                    cmd.ExecuteNonQuery();
                    displayStudentResult();


                }
            }
            if (studentResultTable.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.studentResultTable.Rows[e.RowIndex];
                string SID = row.Cells["StudentId"].Value.ToString();
                string ACID = row.Cells["AssessmentComponentId"].Value.ToString();
                string RMID = row.Cells["RubricMeasurementId"].Value.ToString();

                EditMarkEvaluation E = new EditMarkEvaluation(SID, ACID, RMID);
                E.ShowDialog();
                displayStudentResult();

            }
        }
    }
}
