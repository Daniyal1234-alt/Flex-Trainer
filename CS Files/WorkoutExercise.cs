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
    public partial class WorkoutExercise : Form
    {
        int Workout_ID;
        public WorkoutExercise(int WorkoutID)
        {
            Workout_ID = WorkoutID;
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string name = guna2TextBox1.Text, muscle = guna2TextBox2.Text, machine = guna2TextBox3.Text, rest = guna2TextBox4.Text, set = guna2TextBox5.Text, reps = guna2TextBox6.Text;
            if (IsValid(name) && IsValid(muscle) && IsValid(machine) && IsValid(rest)&&IsValid(set)&&IsValid(reps))
            {
                string query = "USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Exercise Values ('"+Workout_ID+"','" + name + "','" + muscle + "','" + machine + "','" + rest + "','" + set + "','"+reps+"')";
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

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
