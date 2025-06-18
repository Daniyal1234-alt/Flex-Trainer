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
    public partial class OwnerAdmin : Form
    {
        int Ownerid, GymID;
        public OwnerAdmin(int id, int id2)
        {
            Ownerid = id;
            GymID = id2;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
            this.guna2DataGridView2.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView2.ColumnHeadersHeight = 20;
            guna2DataGridView2.RowTemplate.Height = 35;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string memberID = guna2TextBox1.Text, memberName = guna2TextBox2.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB  Select M.MemberID, m.Name, m.Joining_date As Date,m.Phone_Number As Phone, m.Address From PROJECT_DB.dbo.Member m Join PROJECT_DB.dbo.Member_Gym mg On m.MemberID = mg.MemberID Where mg.GymID = {GymID}";
            if (!string.IsNullOrEmpty(memberID))
            {
                query += $" AND m.memberID = {memberID}";
            }
            if (!string.IsNullOrEmpty(memberName))
            {
                query += $" AND m.Name = '{memberName}'";
            }
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string TrainerID = guna2TextBox4.Text, TrainerName = guna2TextBox3.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB  Select m.TrainerID, m.Name, m.Specialties ,m.email As Email From PROJECT_DB.dbo.Trainer m Join PROJECT_DB.dbo.Trainer_Gym mg On m.TrainerID = mg.TrainerID Where mg.GymID = {GymID}";
            if (!string.IsNullOrEmpty(TrainerID))
            {
                query += $" AND m.TrainerID = {TrainerID}";
            }
            if (!string.IsNullOrEmpty(TrainerName))
            {
                query += $" AND m.Name = '{TrainerName}'";
            }
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView2.DataSource = dtRecord;
            int rowscount = guna2DataGridView2.Rows.Count;

            for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
            {
                DataGridViewCell cell = guna2DataGridView2.Rows[i].Cells[0];
                cell.Value = "Remove";
            }
            connection.Close();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string memberID = guna2TextBox1.Text, memberName = guna2TextBox2.Text;
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
                int member_ID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Delete From PROJECT_DB.dbo.Member m Join PROJECT_DB.dbo.Member_Gym mg On m.MemberID = mg.MemberID Where mg.GymID = {GymID} And m.MemberID = {member_ID}";  
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Member Removed");
            }
        }

        

        private void OwnerAdmin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            string MemberID = guna2TextBox1.Text, MemberName = guna2TextBox2.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB Select mem.MemberID as ID, NAME as Name, Address , JOINING_DATE As Date from PROJECT_DB.dbo.Member mem join PROJECT_DB.dbo.Member_Gym g on mem.MemberID = g.MemberID where g.gymID = {GymID}";
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

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string TrainerID = guna2TextBox4.Text, TrainerName = guna2TextBox3.Text;
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
                DataGridViewCell selectedCell = guna2DataGridView2.Rows[e.RowIndex].Cells[1];
                int gymID = Int32.Parse(selectedCell.Value.ToString());
                string query = $"USE PROJECT_DB  Delete From PROJECT_DB.dbo.Trainer m Join PROJECT_DB.dbo.Trainer_Gym mg On m.TrainerID = mg.TrainerID Where mg.GymID = {gymID}";
                if (!string.IsNullOrEmpty(TrainerID))
                {
                    query += $"AND m.TrainerID = '{TrainerID}'";
                }
                if (!string.IsNullOrEmpty(TrainerName))
                {
                    query += $"AND m.TrainerName = '{TrainerName}'";
                }
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Trainer Removed");
            }
        }

       
    }
}

