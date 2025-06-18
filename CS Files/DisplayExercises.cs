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
    public partial class DisplayExercises : Form
    {
        int Workout_ID;
        public DisplayExercises(int WorkoutID)
        {
            Workout_ID = WorkoutID;
            InitializeComponent();
        }

        private void DisplayExercises_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pROJECT_DB.Exercise' table. You can move, or remove it, as needed.
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select *  FROM PROJECT_DB.dbo.Exercise WHERE WorkoutID = '" + Workout_ID + "'";
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
    }
}
