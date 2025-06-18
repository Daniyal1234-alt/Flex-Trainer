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
    public partial class AddFood : Form
    {
        int DietPlanID;
        public AddFood(int Dietplanid)
        {
            DietPlanID = Dietplanid;
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label1.BackColor = Color.Green;
            label2.BackColor = Color.Red;
        }

        private void AddFood_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, calories = guna2TextBox2.Text, protein = guna2TextBox3.Text, fats = guna2TextBox4.Text, carbs = guna2TextBox5.Text, time = guna2TextBox6.Text, allergens = guna2TextBox7.Text;
            if (IsValid(name) && IsValid(calories) && IsValid(protein) && IsValid(fats)&&IsValid(carbs) && IsValid(time) && IsValid(allergens))
            {
                string query = $"USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.food Values ({DietPlanID}, '{name}','{calories}','{protein}','{fats}', '{carbs}', '{allergens}', '{time}')";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
