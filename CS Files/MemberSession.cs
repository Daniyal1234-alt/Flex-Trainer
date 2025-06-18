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
    public partial class MemberSession : Form
    {
        int memberID;
        public MemberSession(int id)
        {
            memberID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void MemberSession_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select AppID FROM PROJECT_DB.dbo.Appointment WHERE MemberID = '" + memberID + "'";
            command = new SqlCommand(query, connection);
            //SqlDataReader dataReader = command.ExecuteReader();
            //string id = dataReader["WorkoutID"].ToString();
            //int workoutID = Int32.Parse(dataReader["WorkoutID"].ToString());
            if(command.ExecuteScalar()== null)
            {
                return;
            }
            int AppID = (int)command.ExecuteScalar();
            string query2 = "USE PROJECT_DB Select MemberID,TrainerID ,Purpose, Date_Time FROM PROJECT_DB.dbo.Appointment WHERE MemberID = '" + memberID + "'";
            command = new SqlCommand(query2, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddSession addSession = new AddSession(memberID);
            addSession.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
