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
    public partial class AdminPerformace : Form
    {
        int AdminID;
        public AdminPerformace(int id)
        {
            AdminID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void AdminPerformace_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string gymID = guna2TextBox1.Text, ownerID = guna2TextBox2.Text, sinceDate = guna2TextBox3.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $@"SELECT g.GymID,g.OwnerID ,COUNT(mg.MemberID) AS MemberCount, COUNT(mg.MemberID) * 5000 *12 AS FinancialData From Member m JOIN
                Member_Gym mg ON m.MemberID = mg.MemberID JOIN Gym g ON mg.GymID = g.GymID  ";
            if(!string.IsNullOrEmpty(sinceDate))
            {
                query += $" WHERE m.Joining_Date >= '{sinceDate}'"; 
            }
            query += " Group BY g.GymID, g.OwnerID HAVING 1=1 ";
            if (!string.IsNullOrEmpty(gymID))
            {
                query += $"AND g.GymID = {gymID}";
            }
            if (!string.IsNullOrEmpty(ownerID))
            {
                query += $"AND g.ownerID = {ownerID}";
            }
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

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
