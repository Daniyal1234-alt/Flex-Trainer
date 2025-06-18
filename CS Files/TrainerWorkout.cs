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
    public partial class TrainerWorkout : Form
    {
        int Trainer_ID; 
        public TrainerWorkout(int Id)
        {
            Trainer_ID = Id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void TrainerWorkout_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateWorkoutTrainer c1 = new CreateWorkoutTrainer();
            c1.Show();
        }

        private void guna2RadialGauge1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string memberID = guna2TextBox1.Text, Purpose = guna2TextBox2.Text, ExperienceLevel = guna2TextBox3.Text, creator = guna2TextBox4.Text, gym_id = guna2TextBox5.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select DISTINCT a.*, b.MemberID, mg.GymID from PROJECT_DB.dbo.Workout a LEFT JOIN PROJECT_DB.dbo.Member_Workout b ON a.WorkoutID =  b.WorkoutID JOIN Member_Gym mg ON b.MemberID = mg.MemberID WHERE 1=1 ";
            if (!string.IsNullOrEmpty(memberID))
              query += $" AND b.MemberID = '{memberID}'";
            if (!string.IsNullOrEmpty(Purpose))
                query += $" AND Purpose = '{Purpose}'";
            if (!string.IsNullOrEmpty(ExperienceLevel))
                query += $" AND expLevel = '{ExperienceLevel}'";
            if (!string.IsNullOrEmpty(creator))
                query += $" AND createdby = '{creator}'";
            if (!string.IsNullOrEmpty(gym_id))
                query += $" AND mg.GymID = {gym_id}";
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            connection.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
