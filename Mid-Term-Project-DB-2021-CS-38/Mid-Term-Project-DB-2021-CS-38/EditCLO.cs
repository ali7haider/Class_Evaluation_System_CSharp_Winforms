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
    public partial class EditCLO : Form
    {
        int idn;
        public EditCLO(string name,string ID)
        {
            InitializeComponent();
            txtName.Text = name;
            idn = int.Parse(ID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Clo SET Name=@Name,DateUpdated=@DateUpdated Where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Id", idn);
            cmd.Parameters.AddWithValue("@DateUpdated", dateTimeCLO.Value);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Updated Succesfully");
            this.Close();
        }
    }
}
