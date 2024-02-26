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
    public partial class RubricLevel : Form
    {
        int rubricId = -1;
        public RubricLevel(string CloName,string CloId,string details,string id)
        {
            InitializeComponent();
            lblCLOName.Text = CloName;
            lblCLOId.Text = CloId;
            txtRubricDetails.Text = details;
            rubricId=int.Parse(id);
            moveButtons();
        }
        private void moveButtons()
        {
            rubricTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rubricTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rubricTableData.Columns["Edit"].DisplayIndex = rubricTableData.Columns.Count - 1;
            rubricTableData.Columns["Delete"].DisplayIndex = rubricTableData.Columns.Count - 1;


        }
        public void loadRubricLevel()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * From RubricLevel Where RubricId = '" + rubricId + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            rubricTableData.DataSource = d;
            rubricTableData.AllowUserToAddRows = false;
            rubricTableData.Columns["Id"].Visible = false;
            rubricTableData.Columns["RubricId"].Visible = false;


        }


        private void RubricLevel_Load(object sender, EventArgs e)
        {
            loadRubricLevel();
            moveButtons();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into RubricLevel values(@RubricId,@Details,@MeasurmentLevel)", con);
            cmd.Parameters.AddWithValue("@RubricId", rubricId);
            cmd.Parameters.AddWithValue("@Details", txtLevelDetail.Text);
            cmd.Parameters.AddWithValue("@MeasurmentLevel", txtMeasurmentLevel.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Succesfully");
            loadRubricLevel();


        }

        private void rubricTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (rubricTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From RubricLevel Where Id=@Id", con);
                    int selectedrowindex = rubricTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = rubricTableData.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
                    int id = int.Parse(cellValue);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    loadRubricLevel();


                }
            }
            if (rubricTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.rubricTableData.Rows[e.RowIndex];
                string Details = row.Cells["Details"].Value.ToString();
                string level = row.Cells["MeasurementLevel"].Value.ToString();
                string Id = row.Cells["Id"].Value.ToString();

                EditRubricLevel E = new EditRubricLevel(Details, level,Id);
                E.ShowDialog();
                loadRubricLevel();

            }
        }
    }
}
