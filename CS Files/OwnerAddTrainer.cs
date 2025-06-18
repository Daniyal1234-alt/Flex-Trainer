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
    public partial class OwnerAddTrainer : Form
    {
        int Ownerid, Gymid; 
        public OwnerAddTrainer(int id, int id2)
        {
            Ownerid = id;
            Gymid = id2;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;

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
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int TrainerID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Update PROJECT_DB.dbo.Trainer SET RegBit = 1 Where TrainerID = {TrainerID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Trainer Added");
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                DataGridViewCell selectedCell = guna2DataGridView1.Rows[e.RowIndex].Cells[2];
                int TrainerID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Delete From PROJECT_DB.dbo.Trainer Where TrainerID = {TrainerID}";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Trainer Denied");
            }
        }

        private void OwnerAddTrainer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB Select TrainerID as ID, Name , Specialties , RegBit As Status from PROJECT_DB.dbo.Trainer Where regBit = {0}";
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
    }
}
