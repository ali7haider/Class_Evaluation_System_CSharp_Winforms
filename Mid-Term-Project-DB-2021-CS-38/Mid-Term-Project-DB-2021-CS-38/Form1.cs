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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            manageHome1.Show();
            manageHome1.BringToFront();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            attendance1.Hide();
            manageHome1.Hide();

            manageClo1.Hide();
            manageAssessment1.Hide();
            manageMarkEvalaution1.Hide();
            manageRubric1.Hide();
            manageStudent1.Show();
            manageStudent1.BringToFront();
          
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            manageAssessment1.Hide();
            attendance1.Hide();
            manageRubric1.Hide();
            manageReports1.Hide();
            manageMarkEvalaution1.Hide();
            manageHome1.setText();
            manageHome1.Show();
            manageHome1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manageClo1.Hide();
            attendance1.Hide();
            manageReports1.Hide();

            manageAssessment1.Hide();
            manageMarkEvalaution1.Hide();
            manageAssessmentComponent1.Hide();
            manageStudent1.Hide();
            manageRubric1.Hide();

            manageHome1.Show();
            manageHome1.BringToFront();
        }

        private void btnCLO_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            attendance1.Hide();
            manageReports1.Hide();
            manageHome1.Hide();

            manageRubric1.Hide();
            manageAssessment1.Hide();
            manageAssessmentComponent1.Hide();
            manageClo1.Show();
            manageClo1.BringToFront();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            manageMarkEvalaution1.Hide();
            manageReports1.Hide();
            manageHome1.Hide();

            manageRubric1.Hide();
            manageAssessment1.Hide();
            manageAssessmentComponent1.Hide();
            attendance1.Show();
            attendance1.BringToFront();
        }

        private void btnRubric_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            attendance1.Hide();
            manageAssessment1.Hide();
            manageReports1.Hide();
            manageHome1.Hide();

            manageAssessmentComponent1.Hide();
            manageRubric1.Show();
            manageRubric1.BringToFront();
            manageRubric1.loadData();
        }

        

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            attendance1.Hide();
            manageReports1.Hide();
            manageHome1.Hide();

            manageRubric1.Hide();
         
            manageAssessmentComponent1.Hide();

            manageMarkEvalaution1.Hide();
            manageAssessment1.Show();
            manageAssessment1.BringToFront();
        }

        private void btnAssessmentComponent_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            attendance1.Hide();
            manageRubric1.Hide();
            manageReports1.Hide();
            manageHome1.Hide();

            manageMarkEvalaution1.Hide();
            manageAssessment1.Hide();
            manageAssessmentComponent1.loadComboxes();
            manageAssessmentComponent1.Show();
            manageAssessmentComponent1.BringToFront();
        }

        private void btnMarkEvaluation_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            attendance1.Hide();
            manageHome1.Hide();

            manageRubric1.Hide();
            manageReports1.Hide();
            manageAssessment1.Hide();
            manageAssessmentComponent1.Hide();
            manageMarkEvalaution1.loadComboBoxes();
            manageMarkEvalaution1.Show();
            manageMarkEvalaution1.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            manageStudent1.Hide();
            manageClo1.Hide();
            attendance1.Hide();
            manageRubric1.Hide();
            manageHome1.Hide();

            manageAssessment1.Hide();
            manageAssessmentComponent1.Hide();
            
            manageMarkEvalaution1.Hide();
            manageReports1.Show();
            manageReports1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
