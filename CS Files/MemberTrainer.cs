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
    public partial class MemberTrainer : Form
    {
        int member_ID;
        public MemberTrainer(int memberID)
        {
            member_ID = memberID;
            InitializeComponent();
        }

        private void MemberTrainer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pROJECT_DB.Trainer' table. You can move, or remove it, as needed.
            this.trainerTableAdapter.Fill(this.pROJECT_DB.Trainer);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Invalid Information");
            }
            else
            {
                int TrainerID = Int32.Parse(guna2TextBox1.Text);
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                string query = "USE PROJECT_DB Select Count(*)  FROM PROJECT_DB.dbo.Member_Trainer WHERE MemberID = '" + member_ID + "'";
                command = new SqlCommand(query, connection);
                if (command.ExecuteScalar() == null)
                {
                    return;
                }
                int trainers = (int)command.ExecuteScalar();
                if (trainers != 0)
                {
                    MessageBox.Show("You already have a trainer");
                }
                else
                {
                    query = "USE PROJECT_DB Insert into PROJECT_DB.dbo.Member_Trainer values ('" + member_ID + "','" + TrainerID + "')";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Trainer Added");
                    this.Hide();
                }
            }

        }

        private void guna2RatingStar2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int rating = Int32.Parse(guna2RatingStar2.Value.ToString());
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select TrainerID  FROM PROJECT_DB.dbo.Member_Trainer WHERE MemberID = '" + member_ID + "'";
            command = new SqlCommand(query, connection);
            if (command.ExecuteScalar() == null)
            {
                return;
            }
            int trainerID = (int)command.ExecuteScalar();
            if (trainerID >= 1) {
                query = $"USE PROJECT_DB INSERT INTO PROJECT_DB.dbo.Member_Rating VALUES ({member_ID},{trainerID},{rating})";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Rating Done");

            }
            else
            {
                MessageBox.Show("You dont have a trainer");
            }
        }
    }
}
