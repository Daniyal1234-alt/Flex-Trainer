using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Milestone_2
{
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSignUp a1 = new AdminSignUp();
            a1.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string username = guna2TextBox1.Text, password = guna2TextBox2.Text;
            if (IsValid(username) && IsValid(password))
            {
                string query = "USE PROJECT_DB Select 1 from PROJECT_DB.dbo.Admin where Name = '" + username + "' and pass = '" + password + "'";
                SqlCommand command1 = new SqlCommand(query, connection);
                if (command1.ExecuteScalar() != null)
                {
                    string found = command1.ExecuteScalar().ToString();
                    if (found == "1")
                    {
                        label1.ForeColor = Color.Green;
                        label1.Visible = true;
                        Timer timer = new Timer();
                        timer.Interval = 3000;
                        timer.Tick += (s, args) =>
                        {
                            label1.Visible = false;
                            timer.Stop();
                            timer.Dispose();
                            this.Hide();
                            string query2 = "USE PROJECT_DB Select AdminID from PROJECT_DB.dbo.Admin where Name = '" + username + "' and pass = '" + password + "'";
                            command1 = new SqlCommand(query2, connection);
                            object result = command1.ExecuteScalar();
                            int AdminID = Convert.ToInt32(result);
                            Admin m1 = new Admin(AdminID);
                            m1.Show();
                        };
                        timer.Start();

                    }
                    else
                    {
                        label2.ForeColor = Color.Red;
                        label2.Visible = true;
                        Timer timer = new Timer();
                        timer.Interval = 3000;
                        timer.Tick += (s, args) =>
                        {
                            label2.Visible = false;
                            timer.Stop();
                            timer.Dispose();
                        };
                        timer.Start();
                    }

                }
                else
                {
                    label2.ForeColor = Color.Red;
                    label2.Visible = true;
                    Timer timer = new Timer();
                    timer.Interval = 3000;
                    timer.Tick += (s, args) =>
                    {
                        label2.Visible = false;
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                }

            }
            else
            {
                label2.ForeColor = Color.Red;
                label2.Visible = true;
                Timer timer = new Timer();
                timer.Interval = 3000;
                timer.Tick += (s, args) =>
                {
                    label2.Visible = false;
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
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
