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
    public partial class AdminRequest : Form
    {
        int AdminID;
        public AdminRequest(int id)
        {
            AdminID = id;
            InitializeComponent();
            DataGridViewButtonColumn c = (DataGridViewButtonColumn)guna2DataGridView1.Columns["Accept"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.BackColor = Color.Green;
            c = (DataGridViewButtonColumn)guna2DataGridView1.Columns["Deny"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.BackColor = Color.Red;
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;

        }

        private void AdminRequest_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB Select GymID as ID, GymName as Name, GymLoc As Gym_Location, OwnerID from PROJECT_DB.dbo.Gym Where regStatus = {0}";
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            int rowscount = guna2DataGridView1.Rows.Count;
            
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[0];
                cell.Value = "Accept";
                cell = guna2DataGridView1.Rows[i].Cells[1];
                cell.Value = "Deny";
            }
            connection.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[0];
                cell.Value = "Accept";
                cell = guna2DataGridView1.Rows[i].Cells[1];
                cell.Value = "Deny";
            }
            if (e.RowIndex>=0 && e.ColumnIndex == 0)
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int gymID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Update PROJECT_DB.dbo.Gym SET RegStatus = 1, AdminID = {AdminID} Where GymID = {gymID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Gym Added");
            }
            else if(e.RowIndex>=0 && e.ColumnIndex == 1)
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int gymID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Delete From PROJECT_DB.dbo.Gym Where GymID = {gymID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Gym Denied");
            }
        }
    }
}
