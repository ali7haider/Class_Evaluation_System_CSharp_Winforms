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
    public partial class ManageAssessmentComponent : UserControl
    {
        public ManageAssessmentComponent()
        {
            InitializeComponent();
          
            displayAssessmentComponent();
            moveButtons();
        }
        private void moveButtons()
        {
            assesmentComponentTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            assesmentComponentTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            assesmentComponentTableData.Columns["Edit"].DisplayIndex = assesmentComponentTableData.Columns.Count - 1;
            assesmentComponentTableData.Columns["Delete"].DisplayIndex = assesmentComponentTableData.Columns.Count - 1;


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into AssessmentComponent values(@Name,@RubricId,@TotalMarks,@DateCreated,@DateUpdated,@AssessmentId)", con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@RubricId", int.Parse(cmbxRubricId.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Today);
            cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Today);
            cmd.Parameters.AddWithValue("@AssessmentId", int.Parse(cmbxAssessmentId.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Succesfully");
            displayAssessmentComponent();
            txtName.ResetText();
            txtTotalMarks.ResetText();
        }
        private void displayAssessmentComponent()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select AC.Id,AC.AssessmentId,AC.RubricId,AC.Name as [Component Name],AC.TotalMarks,AC.DateCreated,AC.DateUpdated,A.Title as [Assessment Title],R.Details as [Rubric Details] From AssessmentComponent AC JOIN Assessment A ON A.Id=AC.AssessmentId JOIN Rubric R ON R.Id=AC.RubricId", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            assesmentComponentTableData.DataSource = d;
            assesmentComponentTableData.AllowUserToAddRows = false;
            assesmentComponentTableData.Columns["Id"].Visible = false;
            assesmentComponentTableData.Columns["AssessmentId"].Visible = false;

            assesmentComponentTableData.Columns["RubricId"].Visible = false;



        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageAssessmentComponent_Load(object sender, EventArgs e)
        {
            
            loadComboxes();
        }
        public void loadComboxes()
        {
            loadAssessmentDetails();
            loadRubricDetails();
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

        private void cmbxRubricId_TextChanged(object sender, EventArgs e)
        {
            /*updateRubricDetails(cmbxRubricId.Text);*/
            
        }
        /*private void updateRubricDetails(string Id)
        {
            int id=int.Parse(Id);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Details FROM Rubric WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            object data = cmd.ExecuteScalar();
            string result = (data).ToString();
            cmd.ExecuteNonQuery();
            txtRubricDetail.Text= result;
            
        }*/
        /*private void updateAssesmentDetails(string Id)
        {
            int id = int.Parse(Id);
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Title FROM Assessment WHERE Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            object data = cmd.ExecuteScalar();
            string result = (data).ToString();
            cmd.ExecuteNonQuery();
            txtAssessmentDetails.Text = result;

        }*/

        private void cmbxAssessmentId_TextChanged(object sender, EventArgs e)
        {
            /*updateAssesmentDetails(cmbxAssessmentId.Text);*/
        }

        private void assesmentComponentTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (assesmentComponentTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From AssessmentComponent Where Id=@Id", con);
                    int selectedrowindex = assesmentComponentTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = assesmentComponentTableData.Rows[selectedrowindex];
                    
                    string ID = Convert.ToString(selectedRow.Cells["Id"].Value);
                    cmd.Parameters.AddWithValue("@Name", int.Parse(ID));
                    cmd.ExecuteNonQuery();
                    displayAssessmentComponent();

                }
            }
            if (assesmentComponentTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.assesmentComponentTableData.Rows[e.RowIndex];
                string Id = row.Cells["Id"].Value.ToString();
                string Name = row.Cells["Component Name"].Value.ToString();
                string RubricId = row.Cells["RubricId"].Value.ToString();
                string TotalMarks = row.Cells["TotalMarks"].Value.ToString();
                string AssessmentId = row.Cells["AssessmentId"].Value.ToString();
                EditAssessmentComponent E = new EditAssessmentComponent(Id,Name, RubricId, TotalMarks, AssessmentId);
                E.ShowDialog();
                displayAssessmentComponent();
            }


        }
       
     

        
    }
}
