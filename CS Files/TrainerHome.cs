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
    public partial class TrainerHome : Form
    {
        public TrainerHome(int TrainerID)
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB SELECT Name, Email, Phone_Number, CNIC, Specialties, Gyms  FROM PROJECT_DB.dbo.Trainer WHERE TrainerID = '" + TrainerID + "'";
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                string name = dataReader["Name"].ToString();
                string email = dataReader["Email"].ToString();
                string phone = dataReader["Phone_Number"].ToString();
                string cnic = dataReader["CNIC"].ToString();
                string gyms = dataReader["Gyms"].ToString();
                string sp = dataReader["Specialties"].ToString();
                guna2TextBox1.Text = name;
                guna2TextBox2.Text = phone;
                guna2TextBox3.Text = "Islamabad";
                guna2TextBox4.Text = cnic;
                guna2TextBox5.Text = email;
                guna2TextBox6.Text = gyms;
                guna2TextBox7.Text = sp;
            }
            guna2TextBox1.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
            guna2TextBox3.ReadOnly = true;
            guna2TextBox4.ReadOnly = true;
            guna2TextBox5.ReadOnly = true;
            guna2TextBox6.ReadOnly = true;
            guna2TextBox7.ReadOnly = true;
        }

        private void TrainerHome_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string GymID = guna2TextBox8.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $@"IF EXISTS (SELECT 1 FROM Gym WHERE GymID = {GymID})
            BEGIN
                INSERT INTO Trainer_Gym (TrainerID, GymID)
                VALUES ({GymID}, {GymID});
            END";
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}
