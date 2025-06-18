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
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
            label1.Visible = false;
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, email = guna2TextBox2.Text, phone = guna2TextBox3.Text, cnic = guna2TextBox6.Text, address = guna2TextBox4.Text;
            string password = guna2TextBox5.Text;
            if (IsValid(name) && IsValid(email) && IsValid(phone) && IsValid(cnic) && IsValid(address) && IsValid(password))
            {
                string query = "USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Admin (NAME, Email, Pass, Phone_Number, CNIC) VALUES( '" + name + "','" + email + "','" + password + "','" + phone + "','" + cnic +"')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();

                EmailSender e1 = new EmailSender();
                e1.SendEmail(name, password, email);
                this.Hide();
                string query2 = "USE PROJECT_DB Select AdminID from PROJECT_DB.dbo.Admin where Name = '" + name + "' and pass = '" + password + "'";
                command = new SqlCommand(query2, connection);
                if (command.ExecuteScalar() == null)
                {
                    return;
                }
                object result = command.ExecuteScalar();
                int AdminID = Convert.ToInt32(result);
                Admin m1 = new Admin(AdminID);
                connection.Close();
                m1.Show();
            }
            else
            {

                label1.Visible = true;
                Timer timer = new Timer();
                timer.Interval = 5000;
                timer.Tick += (s, args) =>
                {
                    label1.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }

        }
        private bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogIn a1 = new AdminLogIn();
            a1.Show();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = true;
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
