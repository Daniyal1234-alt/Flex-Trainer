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

namespace DB_Milestone_2
{
    public partial class CreateDietPlan : Form
    {
        public CreateDietPlan()
        {
            InitializeComponent();
            guna2Button1.Visible = false;
            label1.Visible = false;
            label1.BackColor = Color.Green;
            label2.BackColor = Color.Red;
            label2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, type = guna2TextBox2.Text, purpose = guna2TextBox3.Text, created_by = guna2TextBox4.Text;
            if (IsValid(name) && IsValid(type) && IsValid(purpose) && IsValid(created_by))
            {
                guna2Button2.Visible = false;
                guna2Button1.Visible = true;
                string query = "USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.DietPlan Values ('" + name + "','" + type + "','" + purpose + "','" + created_by + "')";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                label1.Visible = true;
                Timer timer = new Timer();
                timer.Interval = 1500;
                timer.Tick += (s, args) =>
                {
                    label1.Visible = false;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
            else
            {
                label2.Visible = true;
                Timer timer = new Timer();
                timer.Interval = 1500;
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "SELECT TOP 1 DietPlanID FROM PROJECT_DB.dbo.DietPlan ORDER BY DietPlanID DESC";
            command = new SqlCommand(query, connection);
            if (command.ExecuteScalar() == null)
            {
                return;
            }
            object result = command.ExecuteScalar();
            int DietPlanID = Convert.ToInt32(result);
            AddFood m1 = new AddFood(DietPlanID);
            m1.Show();
        }
    }
}
