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
    public partial class AdminRemoval : Form
    {
        int AdminID;
        public AdminRemoval(int id)
        {
            AdminID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AdminRemoval_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB Select GymID as ID, GymName as Name, GymLoc  As Gym_Location, RegStatus, OwnerID from PROJECT_DB.dbo.Gym";
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            int rowscount = guna2DataGridView1.Rows.Count;

            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[0];
                cell.Value = "Remove";
            }
            connection.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[0];
                cell.Value = "Remove";
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[1];
                int gymID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Delete From PROJECT_DB.dbo.Gym Where GymID = {gymID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Gym Removed");
            }
        }
    }
}
