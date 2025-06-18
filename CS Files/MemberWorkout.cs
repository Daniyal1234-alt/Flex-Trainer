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
    public partial class MemberWorkout : Form
    {
        List<int> trueIndex = new List<int>();
        int memberID = 0;
        public MemberWorkout(int memID)
        {
            InitializeComponent();
            memberID = memID;
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;

            this.guna2DataGridView2.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView2.ColumnHeadersHeight = 20;
            guna2DataGridView2.RowTemplate.Height = 35;

        }


        private void MemberWorkout_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // TODO: This line of code loads data into the 'pROJECT_DB.Workout' table. You can move, or remove it, as needed.
            this.guna2DataGridView1.AutoGenerateColumns = false;
            this.workoutTableAdapter.Fill(this.pROJECT_DB.Workout);
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select WorkoutID FROM PROJECT_DB.dbo.Member_Workout WHERE MemberID = '" + memberID + "'";
            command = new SqlCommand(query, connection);
            //SqlDataReader dataReader = command.ExecuteReader();
            //string id = dataReader["WorkoutID"].ToString();
            //int workoutID = Int32.Parse(dataReader["WorkoutID"].ToString());
            if (command.ExecuteScalar() == null)
            {
                return;
            }
            int workoutID = (int)command.ExecuteScalar();
            if (workoutID > 0)
            {
                string query2 = "USE PROJECT_DB Select a.WorkoutID, name, days, purpose, expLevel, createdBy FROM PROJECT_DB.dbo.Workout a Join Member_Workout b on a.WorkoutID = b.WorkoutID WHERE b.MemberID = '" + memberID + "'";
                command = new SqlCommand(query2, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dtRecord = new DataTable();
                dataAdapter.Fill(dtRecord);
                guna2DataGridView2.DataSource = dtRecord;
                int rowscount = guna2DataGridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {
                    DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[5];
                    cell.Value = "Show Exercises";
                }
                int rowscount2 = guna2DataGridView2.Rows.Count;
                for (int i = 0; i < rowscount2; i++)
                {
                    DataGridViewCell cell = guna2DataGridView2.Rows[i].Cells[0];
                    cell.Value = "Show Exercises";
                }
                for (int i = 0; i < rowscount; i++)
                {
                    DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[6];
                    cell.Value = "Adopt Workout";
                }
            }
            connection.Close();
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateWorkoutTrainer c1 = new CreateWorkoutTrainer();
            c1.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowscount = guna2DataGridView1.Rows.Count;
            if(e.ColumnIndex == 5)
            {
                int workoutID = e.RowIndex+1;
                DisplayExercises display = new DisplayExercises(workoutID);
                display.Show();
            }
            if(e.ColumnIndex == 6)
            {
                int workoutID = e.RowIndex + 1;
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                string query = "USE PROJECT_DB Insert into PROJECT_DB.dbo.Member_Workout Values (' "+memberID+"','"+workoutID+"')";
                command = new SqlCommand(query, connection);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Workout Added");
                connection.Close();
            }
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex, col = e.ColumnIndex;
            if(col == 0)
            {
                DataGridViewCell cell = guna2DataGridView2.Rows[row].Cells[1];
                string workoutID = cell.Value.ToString();
                int id = Int32.Parse(workoutID);
                DisplayExercises display = new DisplayExercises(id);
                display.Show();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MemberTrainer m1 = new MemberTrainer(memberID);
            m1.Show();
        }

        private void guna2DataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex, col = e.ColumnIndex;
            if (col == 0)
            {
                DataGridViewCell cell = guna2DataGridView2.Rows[row].Cells[1];
                string workoutID = cell.Value.ToString();
                int id = Int32.Parse(workoutID);
                DisplayExercises display = new DisplayExercises(id);
                display.Show();
            }
        }
    }
}
