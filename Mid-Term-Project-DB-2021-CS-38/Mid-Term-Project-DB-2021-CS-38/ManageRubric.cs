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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageRubric : UserControl
    {
        public ManageRubric()
        {
            InitializeComponent();
            displayRubric();
           moveButtons();
        }
        private void moveButtons()
        {
            rubricTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rubricTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rubricTableData.Columns["Level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rubricTableData.Columns["Level"].DisplayIndex = rubricTableData.Columns.Count - 1;
            rubricTableData.Columns["Edit"].DisplayIndex = rubricTableData.Columns.Count - 1;
            rubricTableData.Columns["Delete"].DisplayIndex = rubricTableData.Columns.Count - 1;


        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManageRubric_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ManageRubric_Click(object sender, EventArgs e)
        {
            loadData();
        }
       
        public void loadData()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name,Id From Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxCLO.DataSource = dt;
            cmbxCLO.DisplayMember = "Name";
            cmbxCLO.ValueMember = "Id";

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            int CLOId=getCLOId(cmbxCLO.Text);
            int Id = get_id();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into Rubric values(@Id,@Details,@CloId)", con);
            cmd.Parameters.AddWithValue("@Details", txtRubricDetail.Text);
            cmd.Parameters.AddWithValue("@CloId", int.Parse(cmbxCLO.SelectedValue.ToString()));
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Succesfully");
            txtRubricDetail.ResetText();
            displayRubric();
            
        }
        private int get_id()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("Select max(ID) from  Rubric  ", con);
            cmd1.InitializeLifetimeService();
            decimal maxTotalAmount = Convert.ToDecimal(cmd1.ExecuteScalar());
            int id = int.Parse(maxTotalAmount.ToString());
            id = id + 1;
            return id;
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
        private void displayRubric()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT R.*,C.Name as [CLO Name] FROM Rubric R JOIN Clo C ON R.CloId=C.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            rubricTableData.DataSource = d;
            rubricTableData.AllowUserToAddRows = false;
            rubricTableData.Columns["Id"].Visible = false;
            rubricTableData.Columns["CloId"].Visible = false;


        }

        private void rubricTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (rubricTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From Rubric Where Id=@Id", con);
                    int selectedrowindex = rubricTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = rubricTableData.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["Id"].Value);
                    int id = int.Parse(cellValue);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    displayRubric();
                    
                   
                }
            }
            if (rubricTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.rubricTableData.Rows[e.RowIndex];
                string Details = row.Cells["Details"].Value.ToString();
                string CloId = row.Cells["CloId"].Value.ToString();
                string Id = row.Cells["Id"].Value.ToString();

                EditRubric E = new EditRubric(Details, CloId,Id);
                E.ShowDialog();
                displayRubric();
                
            }
            if (rubricTableData.Columns["Level"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.rubricTableData.Rows[e.RowIndex];
                string Details = row.Cells["Details"].Value.ToString();
                string CloId = row.Cells["CloId"].Value.ToString();
                string CloName = row.Cells["CLO Name"].Value.ToString();
                string Id = row.Cells["Id"].Value.ToString();
                RubricLevel R = new RubricLevel(CloName,CloId, Details, Id);
                R.ShowDialog();

            }
        }

        private void cmbxCLO_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
