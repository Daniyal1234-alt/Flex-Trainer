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
    public partial class OwnerHome : Form
    {
        public OwnerHome(int OwnerID)
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB SELECT Name, Email, Phone_Number, CNIC, Gym_loc  FROM PROJECT_DB.dbo.Owner WHERE OwnerID = '" + OwnerID + "'";
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                string name = dataReader["Name"].ToString();
                string email = dataReader["Email"].ToString();
                string phone = dataReader["Phone_Number"].ToString();
                string cnic = dataReader["CNIC"].ToString();
                string gym_loc = dataReader["Gym_loc"].ToString();
                guna2TextBox1.Text = name;
                guna2TextBox2.Text = phone;
                guna2TextBox3.Text = "Islamabad";
                guna2TextBox4.Text = cnic;
                guna2TextBox5.Text = email;
                guna2TextBox6.Text = gym_loc;

            }
            guna2TextBox1.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
            guna2TextBox3.ReadOnly = true;
            guna2TextBox4.ReadOnly = true;
            guna2TextBox5.ReadOnly = true;
            guna2TextBox6.ReadOnly = true;
        }

        private void OwnerHome_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
