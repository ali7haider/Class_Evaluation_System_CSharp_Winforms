using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

      

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
            //clearForm();
            //displayStudent();
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private int checkingIfRegistrationNumberExist()
        {
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM Student WHERE RegistrationNumber='"+txtRegNo.Text+"'", con);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt;


        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int res = checkingIfRegistrationNumberExist();
            
            if (res == 0)
            {
                try
                {


                    int status = 5;
                    if (UnactiveRadio.Checked == true)
                    {
                        status = 6;
                    }
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("Insert Into Student values(@FirstName,@LastName,@Contact,@Email,@RegistrationNumber,@Status)", con);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", txtRegNo.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtSName.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added Succesfully");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("Error Registration Number Already Exist" );
            }
        }
    }
}
