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
    public partial class TrainerAppointment : Form
    {
        int TrainerID;
        public TrainerAppointment(int id)
        {
            TrainerID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void TrainerAppointment_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int appointmentID = Int32.Parse(selectedCell.Value.ToString());
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                string newdatetime = guna2DateTimePicker1.Text;
                connection.Open();
                SqlCommand command;
                string query = $"USE PROJECT_DB  Update PROJECT_DB.dbo.Appointment SET Date_Time = '{newdatetime}' Where AppID = {appointmentID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Appointment Resechudled");
            }
            else if(e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int appointmentID = Int32.Parse(selectedCell.Value.ToString());
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                string query = $"USE PROJECT_DB  Delete FROM PROJECT_DB.dbo.Appointment Where AppID = {appointmentID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Appointment Cancelled");
            }
            
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string memberID = guna2TextBox1.Text, date = guna2TextBox2.Text, day = guna2TextBox3.Text, purpose = guna2TextBox4.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB Select * from PROJECT_DB.dbo.Appointment a WHERE a.TrainerID = {TrainerID}";
            if (!string.IsNullOrEmpty(memberID))
                query += $" AND a.MemberID = {memberID}";
            if (!string.IsNullOrEmpty(date))
                query += $" AND a.Date_Time LIKE '%{date}%'";
            if (!string.IsNullOrEmpty(day))
                query += $" AND a.Date_Time LIKE '%{day}%'";
            if (!string.IsNullOrEmpty(purpose))
                query += $" AND Purpose = '{purpose}'";
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            int rowscount = guna2DataGridView1.Rows.Count;
            for (int i = 0; i < rowscount-1; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[0];
                cell.Value = "Resechudle";
                cell = guna2DataGridView1.Rows[i].Cells[1];
                cell.Value = "Cancel";
            }
            connection.Close();
        }
    }
}
