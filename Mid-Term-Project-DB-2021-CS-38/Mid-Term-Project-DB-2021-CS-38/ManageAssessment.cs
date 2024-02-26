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
    public partial class ManageAssessment : UserControl
    {
        public ManageAssessment()
        {
            InitializeComponent();
            loadAssessment();
            moveButtons();
        }
        private void moveButtons()
        {
            assessmentTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            assessmentTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            assessmentTableData.Columns["Edit"].DisplayIndex = assessmentTableData.Columns.Count - 1;
            assessmentTableData.Columns["Delete"].DisplayIndex = assessmentTableData.Columns.Count - 1;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into Assessment values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)", con);
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Today);
            cmd.Parameters.AddWithValue("@TotalMarks", txtTotalMarks.Text);
            cmd.Parameters.AddWithValue("@TotalWeightage", txtTotalWeightage.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Succesfully");
            txtTitle.ResetText();
            txtTotalMarks.ResetText();
            txtTotalWeightage.ResetText();
            loadAssessment();
        }

        private void assessmentTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (assessmentTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From Assessment Where Id=@Id", con);
                    int selectedrowindex = assessmentTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = assessmentTableData.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
                    int id = int.Parse(cellValue);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    loadAssessment();


                }
            }
            if (assessmentTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.assessmentTableData.Rows[e.RowIndex];
                string Title = row.Cells["Title"].Value.ToString();
                string tMarks = row.Cells["TotalMarks"].Value.ToString();
                string wMarks = row.Cells["TotalWeightage"].Value.ToString();
                string Id = row.Cells["Id"].Value.ToString();

                EditAssessment E = new EditAssessment(Title, tMarks, wMarks,Id);
                E.ShowDialog();
                loadAssessment();

            }
        }
        public void loadAssessment()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * From Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            assessmentTableData.DataSource = d;
            assessmentTableData.AllowUserToAddRows = false;
            assessmentTableData.Columns["Id"].Visible = false;

        }
    }
}
