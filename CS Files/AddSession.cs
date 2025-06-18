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
    public partial class AddSession : Form
    {
        int memberID;
        public AddSession(int id)
        {
            memberID = id;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string TrainerID = guna2TextBox1.Text, Purpose = guna2TextBox2.Text;
            string dateTime = guna2DateTimePicker1.Text;
            if (IsValid(TrainerID) && IsValid(Purpose) && IsValid(dateTime))
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                string query = "USE PROJECT_DB SELECT COUNT(1) FROM PROJECT_DB.dbo.Trainer WHERE TrainerID = '" + TrainerID+"'";
                command = new SqlCommand(query, connection);
                if (command.ExecuteScalar() == null)
                {
                    return;
                }
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    //Trainer Exists
                    query = "USE PROJECT_DB Insert into PROJECT_DB.dbo.Appointment values('" + memberID + "','"+TrainerID+"','"+Purpose+"','"+dateTime+"')";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Session Booked");
                }
                else
                {
                    MessageBox.Show("Trainer doesn't exist");                }

                connection.Close();
            }
            else
            {
                MessageBox.Show("Incomplete Infomation");
            }
        }
        private bool IsValid(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
