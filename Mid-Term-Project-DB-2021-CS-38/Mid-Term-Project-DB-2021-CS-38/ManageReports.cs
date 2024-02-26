using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.parser;
using System.Collections;
using System.Data.SqlClient;
using System.Xml.Linq;
using iTextSharp.xmp.impl;
using static System.Net.Mime.MediaTypeNames;
using Org.BouncyCastle.Ocsp;
using System.CodeDom;
using Org.BouncyCastle.Utilities.Collections;

namespace Mid_Term_Project_DB_2021_CS_38
{
    public partial class ManageReports : UserControl
    {
        public ManageReports()
        {
            InitializeComponent();
            loadAssessment();
            loadClo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            
        }
        public void loadAssessment()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Title From Assessment", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxAssessmentWise.DataSource = dt;
            cmbxAssessmentWise.DisplayMember = "Title";
            cmbxAssessmentWise.ValueMember = "Title";

        }
        public void loadClo()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Id,Name From Clo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbxCloWise.DataSource = dt;
            cmbxCloWise.DisplayMember = "Name";
            cmbxCloWise.ValueMember = "Id";

        }
        public DataTable GetDataTable()
        {

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Stu.RegistrationNumber,R.Details as [Rubric Details],A.Title as [Assessment Name],AC.Name as[Assessment Component],AC.TotalMarks, cast( RL.MeasurementLevel*AC.TotalMarks/4 as decimal(10,2)) as [Obtained Marks]     \r\nFROM StudentResult StuR\r\nJOIN Student Stu\r\nON Stu.Id=StuR.StudentId\r\nJOIN RubricLevel RL\r\nON StuR.RubricMeasurementId=RL.Id\r\nJOIn AssessmentComponent AC\r\nON AC.Id=StuR.AssessmentComponentId\r\nJOIN Assessment A\r\nON A.Id=AC.AssessmentId\r\nJOIN Rubric R\r\nON R.Id=RL.RubricId;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            return d;
        }

        private void btnAssessmentWise_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file extension to PDF
            saveFileDialog.DefaultExt = "pdf";

            // Set the filter to only show PDF files
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            // Show the dialog box and get the result
            DialogResult result = saveFileDialog.ShowDialog();

            // If the user clicked OK
            if (result == DialogResult.OK)
            {
                // Get the filename and path
                string filename = saveFileDialog.FileName;
                string assessment = cmbxAssessmentWise.Text;
                string query = "Select Stu.RegistrationNumber,Stu.FirstName + ' ' + Stu.LastName as Name,R.Details as Rubric,A.Title,sum(AC.TotalMarks) as [Total Marks],sum(cast(RL.MeasurementLevel * AC.TotalMarks / 4 as decimal(10, 2))) as [Obtained Marks] FROM StudentResult StuR JOIN Student Stu ON Stu.Id = StuR.StudentId JOIN RubricLevel RL ON StuR.RubricMeasurementId = RL.Id  JOIn AssessmentComponent AC ON AC.Id = StuR.AssessmentComponentId  JOIN Assessment A ON A.Id = AC.AssessmentId JOIN Rubric R ON R.Id = RL.RubricId  Where A.Title = '"+assessment+"'  Group by A.Title,Stu.RegistrationNumber,Stu.FirstName,Stu.LastName,R.Details";
                var connection = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Determine the number of columns in the resultset
                        int numColumns = reader.FieldCount;

                        // Create a PdfPTable object with the same number of columns as the resultset
                        PdfPTable table = new PdfPTable(numColumns);

                        // Add the column headers to the PdfPTable object
                        for (int i = 0; i < numColumns; i++)
                        {
                            table.AddCell(new PdfPCell(new Phrase(reader.GetName(i))));
                        }

                        // Iterate through the resultset and add each tuple to a new row in the PdfPTable object
                        while (reader.Read())
                        {
                            for (int i = 0; i < numColumns; i++)
                            {
                                table.AddCell(new PdfPCell(new Phrase(reader[i].ToString())));
                            }
                        }

                        // Add the PdfPTable object to the PDF document
                        Document document = new Document(PageSize.A4.Rotate());
                        string report = assessment + ".pdf";
                        PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                        document.Open();
                        iTextSharp.text.Font font10 = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
                        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        string heading = assessment + " Assessment Report \n";
                        iTextSharp.text.Font headingfont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                        Paragraph p = new Paragraph(new Chunk(heading, headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        p = new Paragraph(new Chunk("\n", headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        string date = DateTime.Today.ToString();
                        Paragraph da = new Paragraph(new Chunk(date, font10));
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(da);
                        Paragraph d = new Paragraph(new Chunk("   ", font10));
                        d.Alignment = Element.ALIGN_LEFT;
                        document.Add(d);
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Report Generated Succesfully");

                    }
                }
            }
        }
        private DataTable assessmentWise(string assessment)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("  Select Stu.RegistrationNumber,Stu.FirstName + ' ' + Stu.LastName as Name,R.Details as Rubric,A.Title,sum(AC.TotalMarks) as [Total Marks],sum(cast( RL.MeasurementLevel*AC.TotalMarks/4 as decimal(10,2))) as [Obtained Marks]\r\n  FROM StudentResult StuR\r\n  JOIN Student Stu\r\n  ON Stu.Id=StuR.StudentId\r\n  JOIN RubricLevel RL\r\n  ON StuR.RubricMeasurementId=RL.Id\r\n  JOIn AssessmentComponent AC\r\n  ON AC.Id=StuR.AssessmentComponentId\r\n  JOIN Assessment A\r\n  ON A.Id=AC.AssessmentId\r\n  JOIN Rubric R\r\n  ON R.Id=RL.RubricId\r\n  Where A.Title='" + assessment+"'\r\n  Group by A.Title,Stu.RegistrationNumber,Stu.FirstName,Stu.LastName,R.Details", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable d = new DataTable();
            da.Fill(d);
            return d;
        }

        private void btnAttendanceReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file extension to PDF
            saveFileDialog.DefaultExt = "pdf";

            // Set the filter to only show PDF files
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            // Show the dialog box and get the result
            DialogResult result = saveFileDialog.ShowDialog();

            // If the user clicked OK
            if (result == DialogResult.OK)
            {
                // Get the filename and path
                string filename = saveFileDialog.FileName;
                string assessment = cmbxAssessmentWise.Text;
                string query = "DECLARE @cols AS NVARCHAR(MAX), @query AS NVARCHAR(MAX)\r\nWITH DateList AS (\r\n  SELECT DISTINCT FORMAT(CC.AttendanceDate, 'dd/MM/yyyy') AS AttendanceDateFormatted\r\n  FROM ClassAttendance CC\r\n)\r\nSELECT @cols = STUFF((SELECT distinct ',' + QUOTENAME(AttendanceDateFormatted)\r\nFROM DateList\r\nFOR XML PATH(''), TYPE\r\n).value('.', 'NVARCHAR(MAX)')\r\n,1,1,'')\r\n\r\nSET @query = 'SELECT RegistrationNumber, Name, ' + @cols + '\r\nFROM\r\n(\r\nSELECT s.RegistrationNumber, s.FirstName as Name,\r\nFORMAT(ca.AttendanceDate, ''dd/MM/yyyy'') AS AttendanceDateFormatted,\r\nISNULL(L.Name, ''N/A'') AS AttendanceStatus\r\nFROM student s\r\nLEFT JOIN StudentAttendance sa ON s.Id = sa.StudentId\r\nJOIN ClassAttendance CA ON CA.Id = SA.AttendanceId\r\nLEFT JOIN Lookup L ON L.LookupId = SA.AttendanceStatus\r\n) AS source_table\r\nPIVOT\r\n(\r\nMAX(AttendanceStatus)\r\nFOR AttendanceDateFormatted IN (' + @cols + ')\r\n) AS pivot_table'\r\n\r\nEXECUTE(@query)\r\n";
                var connection = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Determine the number of columns in the resultset
                        int numColumns = reader.FieldCount;

                        // Create a PdfPTable object with the same number of columns as the resultset
                        PdfPTable table = new PdfPTable(numColumns);

                        // Add the column headers to the PdfPTable object
                        for (int i = 0; i < numColumns; i++)
                        {
                            table.AddCell(new PdfPCell(new Phrase(reader.GetName(i))));
                        }

                        // Iterate through the resultset and add each tuple to a new row in the PdfPTable object
                        while (reader.Read())
                        {
                            for (int i = 0; i < numColumns; i++)
                            {
                                table.AddCell(new PdfPCell(new Phrase(reader[i].ToString())));
                            }
                        }

                        // Add the PdfPTable object to the PDF document
                        Document document = new Document(PageSize.A4.Rotate());

                        PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                        document.Open();
                        iTextSharp.text.Font font10 = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
                        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        string heading = "Attendance Report \n";
                        iTextSharp.text.Font headingfont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                        Paragraph p = new Paragraph(new Chunk(heading, headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        p = new Paragraph(new Chunk("\n", headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        string date = DateTime.Today.ToString();
                        Paragraph da = new Paragraph(new Chunk(date, font10));
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(da);
                        Paragraph d = new Paragraph(new Chunk("   ", font10));
                        d.Alignment = Element.ALIGN_LEFT;
                        document.Add(d);
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Report Generated Succesfully");

                    }
                }
            }
        }

        private void btnAllAssessmnet_Click(object sender, EventArgs e)
        {
            string query = "Select Id,FirstName From Student";
            var connection = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Determine the number of columns in the resultset
                        int numColumns = reader.FieldCount;

                        // Create a PdfPTable object with the same number of columns as the resultset
                        PdfPTable table = new PdfPTable(numColumns);

                        // Add the column headers to the PdfPTable object
                        for (int i = 0; i < numColumns; i++)
                        {
                            table.AddCell(new PdfPCell(new Phrase(reader.GetName(i))));
                        }

                        // Iterate through the resultset and add each tuple to a new row in the PdfPTable object
                        while (reader.Read())
                        {
                            for (int i = 0; i < numColumns; i++)
                            {
                                table.AddCell(new PdfPCell(new Phrase(reader[i].ToString())));
                            }
                        }

                        // Add the PdfPTable object to the PDF document
                        Document document = new Document();
                        PdfWriter.GetInstance(document, new FileStream("output.pdf", FileMode.Create));
                        document.Open();
                        document.Add(table);
                        document.Close();
                    }
                
            }

        }

        private void btnAssessmentDetails_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file extension to PDF
            saveFileDialog.DefaultExt = "pdf";

            // Set the filter to only show PDF files
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            // Show the dialog box and get the result
            DialogResult result = saveFileDialog.ShowDialog();

            // If the user clicked OK
            if (result == DialogResult.OK)
            {
                // Get the filename and path
                string filename = saveFileDialog.FileName;
                string assessment = cmbxCloWise.Text;
                string query = "  Select Stu.RegistrationNumber,Stu.FirstName + ' '+ Stu.LastName as [Student Name],Clo.Name,sum(AC.TotalMarks) as [Total Marks],sum(cast( RL.MeasurementLevel*AC.TotalMarks/4 as decimal(10,2))) as [Obtained Marks]\r\n  FROM StudentResult StuR\r\n  JOIN Student Stu ON Stu.Id=StuR.StudentId\r\n  JOIN RubricLevel RL\r\n  ON StuR.RubricMeasurementId=RL.Id\r\n  JOIn AssessmentComponent AC \r\n  ON AC.Id=StuR.AssessmentComponentId\r\n  JOIN Assessment A\r\n  ON A.Id=AC.AssessmentId\r\n  JOIN Rubric R \r\n  ON R.Id=RL.RubricId\r\n  JOIN Clo\r\n  On Clo.Id=R.CloId\r\n  Where Clo.Id='"+ int.Parse(cmbxCloWise.SelectedValue.ToString()) +"'\r\n  Group By Stu.Id,Stu.RegistrationNumber,stu.FirstName,stu.LastName,Clo.Id,Clo.Name";
                    var connection = Configuration.getInstance().getConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Determine the number of columns in the resultset
                        int numColumns = reader.FieldCount;

                        // Create a PdfPTable object with the same number of columns as the resultset
                        PdfPTable table = new PdfPTable(numColumns);

                        // Add the column headers to the PdfPTable object
                        for (int i = 0; i < numColumns; i++)
                        {
                            table.AddCell(new PdfPCell(new Phrase(reader.GetName(i))));
                        }

                        // Iterate through the resultset and add each tuple to a new row in the PdfPTable object
                        while (reader.Read())
                        {
                            for (int i = 0; i < numColumns; i++)
                            {
                                table.AddCell(new PdfPCell(new Phrase(reader[i].ToString())));
                            }
                        }

                        // Add the PdfPTable object to the PDF document
                        Document document = new Document(PageSize.A4.Rotate());
                        string report = assessment + ".pdf";
                        PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));
                        document.Open();
                        iTextSharp.text.Font font10 = FontFactory.GetFont("Arial", 10, BaseColor.BLACK);
                        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        string heading = assessment + " Clo Report \n";
                        iTextSharp.text.Font headingfont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD);
                        Paragraph p = new Paragraph(new Chunk(heading, headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        p = new Paragraph(new Chunk("\n", headingfont));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        string date = DateTime.Today.ToString();
                        Paragraph da = new Paragraph(new Chunk(date, font10));
                        p.Alignment = Element.ALIGN_LEFT;
                        document.Add(da);
                        Paragraph d = new Paragraph(new Chunk("   ", font10));
                        d.Alignment = Element.ALIGN_LEFT;
                        document.Add(d);
                        document.Add(table);
                        document.Close();
                        MessageBox.Show("Report Generated Succesfully");

                    }
                }
            }
        }
    }
}
