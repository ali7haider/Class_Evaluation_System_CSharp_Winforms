
namespace Mid_Term_Project_DB_2021_CS_38
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.HomePanel = new System.Windows.Forms.Panel();
            this.StudentPanel = new System.Windows.Forms.Panel();
            this.UserController = new System.Windows.Forms.Panel();
            this.btnAssessment = new System.Windows.Forms.Button();
            this.btnCLO = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnRubric = new System.Windows.Forms.Button();
            this.btnAssessmentComponent = new System.Windows.Forms.Button();
            this.btnMarkEvaluation = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.manageHome1 = new Mid_Term_Project_DB_2021_CS_38.ManageHome();
            this.manageAssessmentComponent1 = new Mid_Term_Project_DB_2021_CS_38.ManageAssessmentComponent();
            this.manageStudent1 = new Mid_Term_Project_DB_2021_CS_38.ManageStudent();
            this.manageReports1 = new Mid_Term_Project_DB_2021_CS_38.ManageReports();
            this.manageMarkEvalaution1 = new Mid_Term_Project_DB_2021_CS_38.ManageMarkEvalaution();
            this.manageAssessment1 = new Mid_Term_Project_DB_2021_CS_38.ManageAssessment();
            this.manageRubric1 = new Mid_Term_Project_DB_2021_CS_38.ManageRubric();
            this.attendance1 = new Mid_Term_Project_DB_2021_CS_38.ManageAttendance();
            this.manageClo1 = new Mid_Term_Project_DB_2021_CS_38.ManageClo();
            this.HomePanel.SuspendLayout();
            this.StudentPanel.SuspendLayout();
            this.UserController.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomePanel
            // 
            this.HomePanel.Controls.Add(this.StudentPanel);
            this.HomePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePanel.Location = new System.Drawing.Point(330, 3);
            this.HomePanel.Name = "HomePanel";
            this.HomePanel.Size = new System.Drawing.Size(818, 847);
            this.HomePanel.TabIndex = 1;
            // 
            // StudentPanel
            // 
            this.StudentPanel.Controls.Add(this.UserController);
            this.StudentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentPanel.Location = new System.Drawing.Point(0, 0);
            this.StudentPanel.Name = "StudentPanel";
            this.StudentPanel.Size = new System.Drawing.Size(818, 847);
            this.StudentPanel.TabIndex = 0;
            // 
            // UserController
            // 
            this.UserController.Controls.Add(this.manageHome1);
            this.UserController.Controls.Add(this.manageAssessmentComponent1);
            this.UserController.Controls.Add(this.manageStudent1);
            this.UserController.Controls.Add(this.manageReports1);
            this.UserController.Controls.Add(this.manageMarkEvalaution1);
            this.UserController.Controls.Add(this.manageAssessment1);
            this.UserController.Controls.Add(this.manageRubric1);
            this.UserController.Controls.Add(this.attendance1);
            this.UserController.Controls.Add(this.manageClo1);
            this.UserController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserController.Location = new System.Drawing.Point(0, 0);
            this.UserController.Name = "UserController";
            this.UserController.Size = new System.Drawing.Size(818, 847);
            this.UserController.TabIndex = 0;
            // 
            // btnAssessment
            // 
            this.btnAssessment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnAssessment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssessment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssessment.FlatAppearance.BorderSize = 0;
            this.btnAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssessment.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssessment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAssessment.Image = ((System.Drawing.Image)(resources.GetObject("btnAssessment.Image")));
            this.btnAssessment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssessment.Location = new System.Drawing.Point(3, 468);
            this.btnAssessment.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnAssessment.Name = "btnAssessment";
            this.btnAssessment.Size = new System.Drawing.Size(309, 56);
            this.btnAssessment.TabIndex = 26;
            this.btnAssessment.Text = "  Assessment";
            this.btnAssessment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssessment.UseVisualStyleBackColor = false;
            this.btnAssessment.Click += new System.EventHandler(this.btnAssessment_Click);
            // 
            // btnCLO
            // 
            this.btnCLO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnCLO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCLO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCLO.FlatAppearance.BorderSize = 0;
            this.btnCLO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLO.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCLO.Image = ((System.Drawing.Image)(resources.GetObject("btnCLO.Image")));
            this.btnCLO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCLO.Location = new System.Drawing.Point(3, 346);
            this.btnCLO.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btnCLO.Name = "btnCLO";
            this.btnCLO.Size = new System.Drawing.Size(309, 53);
            this.btnCLO.TabIndex = 25;
            this.btnCLO.Text = "  CLOs";
            this.btnCLO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCLO.UseVisualStyleBackColor = false;
            this.btnCLO.Click += new System.EventHandler(this.btnCLO_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnStudent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnStudent.Image")));
            this.btnStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.Location = new System.Drawing.Point(3, 224);
            this.btnStudent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(309, 56);
            this.btnStudent.TabIndex = 24;
            this.btnStudent.Text = "  Students";
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(3, 163);
            this.btnHome.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(309, 56);
            this.btnHome.TabIndex = 23;
            this.btnHome.Text = "  Home";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.btnCLO, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnStudent, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnHome, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnAttendance, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btnRubric, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btnAssessment, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.btnAssessmentComponent, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.btnMarkEvaluation, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.btnReport, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 50);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 50, 3, 20);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 11;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(315, 777);
            this.tableLayoutPanel3.TabIndex = 0;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(3, 712);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 63);
            this.button1.TabIndex = 38;
            this.button1.Text = "  Exit";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAttendance.FlatAppearance.BorderSize = 0;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAttendance.Image = ((System.Drawing.Image)(resources.GetObject("btnAttendance.Image")));
            this.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAttendance.Location = new System.Drawing.Point(3, 285);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(309, 56);
            this.btnAttendance.TabIndex = 32;
            this.btnAttendance.Text = "  Attendance";
            this.btnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnRubric
            // 
            this.btnRubric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.btnRubric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRubric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRubric.FlatAppearance.BorderSize = 0;
            this.btnRubric.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRubric.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRubric.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRubric.Image = ((System.Drawing.Image)(resources.GetObject("btnRubric.Image")));
            this.btnRubric.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRubric.Location = new System.Drawing.Point(3, 407);
            this.btnRubric.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnRubric.Name = "btnRubric";
            this.btnRubric.Size = new System.Drawing.Size(309, 56);
            this.btnRubric.TabIndex = 34;
            this.btnRubric.Text = "  Rubric";
            this.btnRubric.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRubric.UseVisualStyleBackColor = false;
            this.btnRubric.Click += new System.EventHandler(this.btnRubric_Click);
            // 
            // btnAssessmentComponent
            // 
            this.btnAssessmentComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssessmentComponent.FlatAppearance.BorderSize = 0;
            this.btnAssessmentComponent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssessmentComponent.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnAssessmentComponent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAssessmentComponent.Image = ((System.Drawing.Image)(resources.GetObject("btnAssessmentComponent.Image")));
            this.btnAssessmentComponent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAssessmentComponent.Location = new System.Drawing.Point(3, 529);
            this.btnAssessmentComponent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnAssessmentComponent.Name = "btnAssessmentComponent";
            this.btnAssessmentComponent.Size = new System.Drawing.Size(309, 56);
            this.btnAssessmentComponent.TabIndex = 35;
            this.btnAssessmentComponent.Text = "  Component";
            this.btnAssessmentComponent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssessmentComponent.UseVisualStyleBackColor = true;
            this.btnAssessmentComponent.Click += new System.EventHandler(this.btnAssessmentComponent_Click);
            // 
            // btnMarkEvaluation
            // 
            this.btnMarkEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMarkEvaluation.FlatAppearance.BorderSize = 0;
            this.btnMarkEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkEvaluation.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.btnMarkEvaluation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMarkEvaluation.Image = ((System.Drawing.Image)(resources.GetObject("btnMarkEvaluation.Image")));
            this.btnMarkEvaluation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarkEvaluation.Location = new System.Drawing.Point(3, 590);
            this.btnMarkEvaluation.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnMarkEvaluation.Name = "btnMarkEvaluation";
            this.btnMarkEvaluation.Size = new System.Drawing.Size(309, 56);
            this.btnMarkEvaluation.TabIndex = 31;
            this.btnMarkEvaluation.Text = "  Mark Evaluation";
            this.btnMarkEvaluation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMarkEvaluation.UseVisualStyleBackColor = true;
            this.btnMarkEvaluation.Click += new System.EventHandler(this.btnMarkEvaluation_Click);
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(3, 651);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(309, 56);
            this.btnReport.TabIndex = 36;
            this.btnReport.Text = "  Reports";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 137);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(321, 847);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.41008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.58992F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.HomePanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1151, 853);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 853);
            this.panel1.TabIndex = 1;
            // 
            // manageHome1
            // 
            this.manageHome1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageHome1.Location = new System.Drawing.Point(0, 0);
            this.manageHome1.Name = "manageHome1";
            this.manageHome1.Size = new System.Drawing.Size(818, 847);
            this.manageHome1.TabIndex = 11;
            // 
            // manageAssessmentComponent1
            // 
            this.manageAssessmentComponent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageAssessmentComponent1.Location = new System.Drawing.Point(0, 0);
            this.manageAssessmentComponent1.Name = "manageAssessmentComponent1";
            this.manageAssessmentComponent1.Size = new System.Drawing.Size(818, 847);
            this.manageAssessmentComponent1.TabIndex = 10;
            // 
            // manageStudent1
            // 
            this.manageStudent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageStudent1.Location = new System.Drawing.Point(0, 0);
            this.manageStudent1.Name = "manageStudent1";
            this.manageStudent1.Size = new System.Drawing.Size(818, 847);
            this.manageStudent1.TabIndex = 9;
            // 
            // manageReports1
            // 
            this.manageReports1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageReports1.Location = new System.Drawing.Point(0, 0);
            this.manageReports1.Name = "manageReports1";
            this.manageReports1.Size = new System.Drawing.Size(818, 847);
            this.manageReports1.TabIndex = 8;
            // 
            // manageMarkEvalaution1
            // 
            this.manageMarkEvalaution1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageMarkEvalaution1.Location = new System.Drawing.Point(0, 0);
            this.manageMarkEvalaution1.Name = "manageMarkEvalaution1";
            this.manageMarkEvalaution1.Size = new System.Drawing.Size(818, 847);
            this.manageMarkEvalaution1.TabIndex = 7;
            // 
            // manageAssessment1
            // 
            this.manageAssessment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageAssessment1.Location = new System.Drawing.Point(0, 0);
            this.manageAssessment1.Name = "manageAssessment1";
            this.manageAssessment1.Size = new System.Drawing.Size(818, 847);
            this.manageAssessment1.TabIndex = 5;
            // 
            // manageRubric1
            // 
            this.manageRubric1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageRubric1.Location = new System.Drawing.Point(0, 0);
            this.manageRubric1.Name = "manageRubric1";
            this.manageRubric1.Size = new System.Drawing.Size(818, 847);
            this.manageRubric1.TabIndex = 3;
            // 
            // attendance1
            // 
            this.attendance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendance1.Location = new System.Drawing.Point(0, 0);
            this.attendance1.Name = "attendance1";
            this.attendance1.Size = new System.Drawing.Size(818, 847);
            this.attendance1.TabIndex = 2;
            // 
            // manageClo1
            // 
            this.manageClo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageClo1.Location = new System.Drawing.Point(0, 0);
            this.manageClo1.Name = "manageClo1";
            this.manageClo1.Size = new System.Drawing.Size(818, 847);
            this.manageClo1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 853);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1100, 900);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assessment System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.HomePanel.ResumeLayout(false);
            this.StudentPanel.ResumeLayout(false);
            this.UserController.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HomePanel;
        private System.Windows.Forms.Button btnAssessment;
        private System.Windows.Forms.Button btnCLO;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel StudentPanel;
        private System.Windows.Forms.Button btnMarkEvaluation;
        private System.Windows.Forms.Panel UserController;
        private ManageClo manageClo1;
        private System.Windows.Forms.Button btnAttendance;
        private ManageAttendance attendance1;
        private ManageRubric manageRubric1;
        private System.Windows.Forms.Button btnRubric;
        private ManageAssessment manageAssessment1;
        private System.Windows.Forms.Button btnAssessmentComponent;
        private System.Windows.Forms.Button btnReport;
        private ManageMarkEvalaution manageMarkEvalaution1;
        private ManageReports manageReports1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ManageStudent manageStudent1;
        private System.Windows.Forms.Button button1;
        private ManageAssessmentComponent manageAssessmentComponent1;
        private ManageHome manageHome1;
    }
}

