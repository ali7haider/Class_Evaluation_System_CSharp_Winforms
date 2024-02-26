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
using System.Xml.Linq;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageAttendance : UserControl
    {
        int saveOrUpdate = -1;
        public ManageAttendance()
        {
            
            InitializeComponent();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            int res = checkingIfDateExist();
            var con = Configuration.getInstance().getConnection();
            if (res == 0)
            {
                SqlCommand cmd = new SqlCommand("Select RegistrationNumber,FirstName + ' ' + LastName as [Student Name],Id  From Student Where Status=5", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                da.Fill(d);
                
                dataGridView1.DataSource = d;
                dataGridView1.Columns["Id"].Visible = false;
                saveOrUpdate = 0;
            }
            else
            {
                string name = dateTimeAttendance.Text.ToString();
                SqlCommand cmd = new SqlCommand("SELECT S.Id,L.Name as [Attendance],S.RegistrationNumber,S.FirstName + ' ' + S.LastName as [StudentName] From Student S\r\nJoin StudentAttendance SA\r\nOn S.Id=SA.StudentId\r\nJOIN ClassAttendance CA\r\nON CA.Id=SA.AttendanceId \r\nJOIN Lookup L\r\nON SA.AttendanceStatus=L.LookupId WHERE CA.AttendanceDate ='" + name+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable d = new DataTable();
                da.Fill(d);
                dataGridView1.DataSource = d;
                dataGridView1.Columns["Id"].Visible = false;

                saveOrUpdate = 1;
            }
            /*moveButtons();*/
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveOrUpdate == 0)
            {
                saveClassAttendance();
                saveStudentAttendance();

            }
            else if (saveOrUpdate==1)
            {
                updateStudentAttendance();
            }
        }
        private void saveClassAttendance()
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert Into ClassAttendance values(@AttendanceDate)", con);
            DateTime dateTimeVariable = dateTimeAttendance.Value.Date;
            cmd.Parameters.AddWithValue("@AttendanceDate", dateTimeAttendance.Text);
            cmd.ExecuteNonQuery();
            
            
        }
        private void saveStudentAttendance()
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            int dateId=getDateId();
            var con = Configuration.getInstance().getConnection();
            if (dataGridView1.RowCount> 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    SqlCommand cmd = new SqlCommand("Insert Into StudentAttendance values(@AttendanceId,@StudentId,@AttendaneStatus)", con);
                    DataGridViewRow selectedRow = dataGridView1.Rows[i];
                    string Attend = Convert.ToString(selectedRow.Cells["Mark"].Value);
                    string SId = Convert.ToString(selectedRow.Cells["Id"].Value);
                    int status = 1;
                    if (Attend=="Present")
                    {
                        status = 1;
                    }
                    else if (Attend=="Absent")
                    {
                        status = 2;
                    }
                    else if (Attend == "Leave")
                    {
                        status = 3;
                    }
                    else if (Attend == "Late")
                    {
                        status = 4;
                    }
                    
                    cmd.Parameters.AddWithValue("@AttendanceId", dateId);
                    cmd.Parameters.AddWithValue("@StudentId", int.Parse(SId));
                    cmd.Parameters.AddWithValue("@AttendaneStatus", status);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Attendance Saved and Marked");
                dataGridView1.DataSource = null;
            }
           

        }
        private void updateStudentAttendance()
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            int dateId = getDateId();
            var con = Configuration.getInstance().getConnection();
            if (dataGridView1.RowCount > 0)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[i];
                    string Attend = Convert.ToString(selectedRow.Cells["Mark"].Value);
                    
                    string sta = Convert.ToString(selectedRow.Cells["Attendance"].Value);
                    int status = -1;

                    if (sta == "Present")
                    {
                    status = 1;
                        
                    }
                    else if (sta == "Absent")
                    {
                         status = 2;
                    }
                    else if (sta == "Leave")
                    {
                        status =3;
                    }
                    else if (sta == "Late")
                    {
                        status = 4;
                    }
                    string SId = Convert.ToString(selectedRow.Cells["Id"].Value);
                    
                    SqlCommand cmd = new SqlCommand("UPDATE StudentAttendance SET AttendanceStatus=@AttendanceStatus Where StudentId='" + SId + "'", con);
                    
                    if (Attend == "Present")
                    {
                        status = 1;
                        
                    }
                    else if (Attend == "Absent")
                    {
                        status = 2;
                    }
                    else if (Attend == "Leave")
                    {
                        status = 3;
                    }
                    else if (Attend == "Late")
                    {
                        status = 4;
                    }
                    cmd.Parameters.AddWithValue("@AttendanceStatus", status);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Attendance Saved and Marked");
                dataGridView1.DataSource = null;
            }


        }
        private int getDateId()
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM ClassAttendance WHERE AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", dateTimeAttendance.Text);
            object data = cmd.ExecuteScalar();
            Int32 result = (Int32)data;
            cmd.ExecuteNonQuery();
            return result;
        }
        private int checkingIfDateExist()
        {
            dateTimeAttendance.Format = DateTimePickerFormat.Custom;
            dateTimeAttendance.CustomFormat = "yyyy/MM/dd";
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT Id FROM ClassAttendance WHERE AttendanceDate=@AttendanceDate", con);
            cmd.Parameters.AddWithValue("@AttendanceDate", dateTimeAttendance.Text);
            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            return cnt;
            




        }
    }
}
