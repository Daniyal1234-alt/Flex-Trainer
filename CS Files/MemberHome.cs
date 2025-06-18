using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Milestone_2
{
    public partial class MemberHome : Form
    {
        int Member_ID;
        public MemberHome(int MemberID)
        {
            Member_ID = MemberID;
            InitializeComponent();
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB SELECT Name, Email, Phone_Number, CNIC, Joining_Date, Address FROM PROJECT_DB.dbo.member WHERE MemberID = '" + MemberID+"'";
            command = new SqlCommand(query, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                string name = dataReader["Name"].ToString();
                string email = dataReader["Email"].ToString();
                string phone = dataReader["Phone_Number"].ToString();
                string cnic = dataReader["CNIC"].ToString();
                string address = dataReader["Address"].ToString();
                DateTime joiningDate = Convert.ToDateTime(dataReader["Joining_Date"]);
                guna2TextBox1.Text = name;
                guna2TextBox2.Text = phone;
                guna2TextBox3.Text = address;
                guna2TextBox4.Text = cnic;
                guna2TextBox5.Text = email;
                guna2TextBox6.Text = joiningDate.ToString();
            }
            guna2TextBox1.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
            guna2TextBox3.ReadOnly = true;
            guna2TextBox4.ReadOnly = true;
            guna2TextBox5.ReadOnly = true;
            guna2TextBox6.ReadOnly = true;
        }

        private void MemberHome_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string gymname = guna2TextBox7.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB SELECT GymID FROM PROJECT_DB.dbo.Gym a where a.GymName = '{gymname}'";
            command = new SqlCommand(query, connection);
            SqlDataReader sql = command.ExecuteReader();
            if (sql.Read())
            {
                string Gym_ID = sql["GymID"].ToString();
                sql.Close();
                query = $"USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Member_Gym Values ('{Member_ID}','{Gym_ID}')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}
