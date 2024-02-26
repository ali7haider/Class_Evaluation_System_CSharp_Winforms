using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageStudent : UserControl
    {
        public ManageStudent()
        {
            InitializeComponent();
            displayStudent();
            moveButtons();



        }
        private void moveButtons()
        {
            studentTableData.Columns["Edit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            studentTableData.Columns["Delete"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            studentTableData.Columns["Edit"].DisplayIndex = studentTableData.Columns.Count - 1;
            studentTableData.Columns["Delete"].DisplayIndex = studentTableData.Columns.Count - 1;
            
        
        }
        private void displayStudent()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT S.Id,S.RegistrationNumber,S.FirstName,S.LastName,S.Contact,S.Email,L.Name as [Status]\r\nFROM STUDENT S\r\nJOIN Lookup L\r\nON S.Status=L.LookupId;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            studentTableData.DataSource = d;
            studentTableData.AllowUserToAddRows = false;
            studentTableData.Columns["Id"].Visible = false;

        }

        

        private void studentTableData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (studentTableData.Columns["Delete"].Index == e.ColumnIndex)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    SqlCommand cmd = new SqlCommand("Delete From Student Where RegistrationNumber=@RegistrationNumber", con);
                    int selectedrowindex = studentTableData.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = studentTableData.Rows[selectedrowindex];
                    string cellValue = Convert.ToString(selectedRow.Cells["RegistrationNumber"].Value);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", cellValue);
                    cmd.ExecuteNonQuery();
                    displayStudent();

                }
            }
            if (studentTableData.Columns["Edit"].Index == e.ColumnIndex)
            {
                DataGridViewRow row = this.studentTableData.Rows[e.RowIndex];
                string RegNo = row.Cells["RegistrationNumber"].Value.ToString();
                string FName = row.Cells["FirstName"].Value.ToString();
                string LName = row.Cells["LastName"].Value.ToString();
                string Contact = row.Cells["Contact"].Value.ToString();
                string Email = row.Cells["Email"].Value.ToString();
                string Status = row.Cells["Status"].Value.ToString();
                string Id = row.Cells["Id"].Value.ToString();
                if (Status=="Active")
                {
                    Status = "5";
                }
                else
                {
                    Status = "6";
                }
                EditStudent E = new EditStudent(RegNo, FName, LName, Contact, Email, Status,Id);
                E.ShowDialog();
                displayStudent();
            }
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            AddStudent S = new AddStudent();
            S.ShowDialog();
            displayStudent();
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
