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
    public partial class OwnerMember : Form
    {
        int Ownerid, GymID;
        public OwnerMember(int id, int id2)
        {
            Ownerid = id;
            GymID = id2;

            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void OwnerMember_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
             string memberID = guna2TextBox1.Text, memberName = guna2TextBox2.Text, date_time = guna2TextBox3.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"SELECT m.* From Member m Join Member_Gym mg On m.MemberID = mg.MemberID Where mg.GymID = {GymID}";
            if (!string.IsNullOrEmpty(memberID))
            {
                query += $"AND mg.MemberID = {memberID}";
            }
            if (!string.IsNullOrEmpty(memberName))
            {
                query += $"AND mg.MemberName = '{memberName}'";
            }
            if (!string.IsNullOrEmpty(date_time))
            {
                DateTime dateTime = DateTime.Parse(date_time);
                query += $"AND m.JOINING_DATE  >= '{dateTime}'";
            }
            command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            connection.Close();

        }
    }
}
