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
namespace DB_Milestone_2
{
    public partial class AdminHome : Form
    {
        public AdminHome(int AdminID)
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB SELECT Name, Email, Phone_Number, CNIC  FROM PROJECT_DB.dbo.Admin WHERE AdminID = '" + AdminID + "'";
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                string name = dataReader["Name"].ToString();
                string email = dataReader["Email"].ToString();
                string phone = dataReader["Phone_Number"].ToString();
                string cnic = dataReader["CNIC"].ToString();
                guna2TextBox1.Text = name;
                guna2TextBox2.Text = phone;
                guna2TextBox3.Text = "Islamabad";
                guna2TextBox4.Text = cnic;
                guna2TextBox5.Text = email;
            }
            guna2TextBox1.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
            guna2TextBox3.ReadOnly = true;
            guna2TextBox4.ReadOnly = true;
            guna2TextBox5.ReadOnly = true;
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
