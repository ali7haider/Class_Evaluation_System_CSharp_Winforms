using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageClo : UserControl
    {
        public ManageClo()
        {
            InitializeComponent();
            displayCLOs();
            moveButtons();
        }
        private void moveButtons()
        {
            CLOTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CLOTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            CLOTableData.Columns["Edit"].DisplayIndex = CLOTableData.Columns.Count - 1;
            CLOTableData.Columns["Delete"].DisplayIndex = CLOTableData.Columns.Count - 1;


        }
        private void displayCLOs()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * From Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            CLOTableData.DataSource = d;
            CLOTableData.AllowUserToAddRows = false;
            CLOTableData.Columns["Id"].Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert Into Clo values(@Name,@DateCreated,@DateUpdated)", con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                DateTime dateTimeVariable = DateTime.Today;
                cmd.Parameters.AddWithValue("@DateCreated", dateTimeVariable);
                cmd.Parameters.AddWithValue("@DateUpdated", dateTimeVariable);
                cmd.ExecuteNonQuery();
                MessageBox.Show("CLO Added Succesfully");
                txtName.ResetText();
                displayCLOs();
            }
        }

        private void CLOTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CLOTableData_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (CLOTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From Clo Where Name=@Name AND Id=@Id", con);
                    int selectedrowindex = CLOTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = CLOTableData.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["Name"].Value);
                    string ID = Convert.ToString(selectedRow.Cells["Id"].Value);
                    cmd.Parameters.AddWithValue("@Name", cellValue);
                    cmd.ExecuteNonQuery();
                    displayCLOs();

                }
            }
            if (CLOTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.CLOTableData.Rows[e.RowIndex];
                string Name = row.Cells["Name"].Value.ToString();
                string ID = row.Cells["Id"].Value.ToString();
                EditCLO E = new EditCLO(Name, ID);
                E.ShowDialog();
                displayCLOs();
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
