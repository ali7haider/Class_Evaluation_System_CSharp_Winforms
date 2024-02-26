using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class EditStudent : Form
    {
        int id = -1;
        public EditStudent(string reg, string FName, string LName, string Contact, string Email,string status,string Id)
        {
            InitializeComponent();
            txtRegNo.Text = reg;
            txtFName.Text = FName;
            txtSName.Text = LName;
            txtContact.Text = Contact;
            txtEmail.Text = Email;
            id=int.Parse(Id);
            if (int.Parse(status)==5)
            {
                ActiveRadio.Checked = true;
            }
            else
            {
                UnactiveRadio.Checked = true;
            }
            /*txtRegNo.ReadOnly = true;*/
        }

        private void EditStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            int status = 5;
            if (UnactiveRadio.Checked == true)
            {
                status = 6;
            }
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET FirstName=@FirstName,LastName=@LastName,Contact=@Contact,Email=@Email,Status=@Status,RegistrationNumber=@RegistrationNumber Where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@RegistrationNumber", txtRegNo.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtSName.Text);
            cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Updated Succesfully");
            this.Close();
        }
    }
}
