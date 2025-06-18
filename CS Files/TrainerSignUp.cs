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
    public partial class TrainerSignUp : Form
    {
        public TrainerSignUp()
        {
            InitializeComponent();
            label1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainerLogIn t1 = new TrainerLogIn();
            t1.Show();
        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, email = guna2TextBox2.Text, phone = guna2TextBox3.Text, cnic = guna2TextBox6.Text, address = guna2TextBox4.Text;
            string password = guna2TextBox5.Text;
            string gyms = guna2TextBox7.Text, speciality = guna2TextBox8.Text;
            if (IsValid(name) && IsValid(email) && IsValid(phone) && IsValid(cnic) && IsValid(address) && IsValid(password) && IsValid(gyms) && IsValid(speciality))
            {
                string query = "USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Trainer (NAME, Email, Pass, Phone_Number, CNIC, Specialties, Gyms) VALUES( '" + name + "','" + email + "','" + password + "','" + phone + "','" + cnic + "','" + speciality + "','"+gyms+"')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();

                EmailSender e1 = new EmailSender();
                e1.SendEmail(name, password, email);
                this.Hide();
                string query2 = "USE PROJECT_DB Select TrainerID from PROJECT_DB.dbo.Trainer where Name = '" + name + "' and pass = '" + password + "'";
                command = new SqlCommand(query2, connection);
                if (command.ExecuteScalar() == null)
                {
                    return;
                }
                object result = command.ExecuteScalar();
                int TrainerID = Convert.ToInt32(result);
                string query3 = $"USE PROJECT_DB Select RegBit from PROJECT_DB.dbo.Trainer t where t.TrainerID = {TrainerID}";
                command = new SqlCommand(query3, connection);
                if (command.ExecuteScalar() == null)
                {
                    return;
                }
                bool regBit = (bool)command.ExecuteScalar();
                if(regBit == false)
                {
                    MessageBox.Show("You are not currently verified");
                    return;
                }
                Trainer m1 = new Trainer(TrainerID);
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
        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

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
    }
}
