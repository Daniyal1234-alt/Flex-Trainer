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
    public partial class OwnerSignUp : Form
    {
        public OwnerSignUp()
        {
            InitializeComponent();
            label1.Visible = false;

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerLogin o1 = new OwnerLogin();
            o1.Show();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, email = guna2TextBox2.Text, phone = guna2TextBox3.Text, cnic = guna2TextBox6.Text, address = guna2TextBox4.Text;
            string password = guna2TextBox5.Text; string gym_location = guna2TextBox7.Text;
            if (IsValid(name) && IsValid(email) && IsValid(phone) && IsValid(cnic) && IsValid(address) && IsValid(password)&&IsValid(gym_location))
            {
                string query = "USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Owner (NAME, Email, Pass, Phone_Number, CNIC, Gym_loc) VALUES( '" + name + "','" + email + "','" + password + "','" + phone + "','" + cnic +"','"+gym_location+ "')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                EmailSender e1 = new EmailSender();
                e1.SendEmail(name, password, email);
                string query2 = "USE PROJECT_DB Select OwnerID from PROJECT_DB.dbo.Owner where Name = '" + name + "' and pass = '" + password + "'";
                command = new SqlCommand(query2, connection);
                object result = command.ExecuteScalar();
                int OwnerID = Convert.ToInt32(result);
                string query3 = $" USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Gym (GymName, GymLoc, OwnerID, AdminID, RegStatus) VALUES ('{gym_location}', 'Islamabad' , {OwnerID},{0},{0})";
                command = new SqlCommand(query3, connection);
                command.ExecuteNonQuery();
                string query4 = $"SELECT RegStatus FROM PROJECT_DB.dbo.Gym WHERE GymName = '{gym_location}'";
                command = new SqlCommand(query4, connection);
                bool regStatus = (bool)command.ExecuteScalar() ;
                if(regStatus == true) {
                    this.Hide();
                    string query5 = $"SELECT GymID FROM PROJECT_DB.dbo.Gym WHERE GymName = '{gym_location}'";
                    command = new SqlCommand(query5, connection);
                    int GymID = (int)command.ExecuteScalar();
                    OwnerMenu m1 = new OwnerMenu(OwnerID, GymID);
                    connection.Close();
                    m1.Show();
                }
                else
                {
                    MessageBox.Show("Your gym isn't verified. Contact: admin@flexer.com");
                }
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

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
