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
    public partial class MemberDiet : Form
    {
        int memberID;
        public MemberDiet(int memId)
        {
            memberID = memId;
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

        private void MemberDiet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pROJECT_DBDataSet2.DietPlan' table. You can move, or remove it, as needed.
            //guna2DataGridView1.AutoGenerateColumns = false;
            this.dietPlanTableAdapter.Fill(this.pROJECT_DBDataSet2.DietPlan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            int rowcount1 = guna2DataGridView1.RowCount;
            for(int i =0;i<rowcount1; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[4];
                cell.Value = "Show Foods";
            }
            for (int i = 0; i < rowcount1; i++)
            {
                DataGridViewCell cell = guna2DataGridView1.Rows[i].Cells[5];
                cell.Value = "Adopt DietPlan";
            }
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select DietPlanID FROM PROJECT_DB.dbo.Member_Diet WHERE MemberID = '" + memberID + "'";
            command = new SqlCommand(query, connection);
            if (command.ExecuteScalar() != null)
            {
                int DietPlanID1 = (int)command.ExecuteScalar();
                string query2 = "USE PROJECT_DB Select a.DietPlanID, name, type, purpose, createdBy FROM PROJECT_DB.dbo.DietPlan a JOIN PROJECT_DB.dbo.Member_Diet b ON a.DietPlanID = b.DietPlanID Where b.MemberID = '"+memberID+"'";
                command = new SqlCommand(query2, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dtRecord = new DataTable();
                dataAdapter.Fill(dtRecord);
                guna2DataGridView2.DataSource = dtRecord;
                int rowscount2 = guna2DataGridView2.Rows.Count;
                for (int i = 0; i < rowscount2; i++)
                {
                    DataGridViewCell cell = guna2DataGridView2.Rows[i].Cells[0];
                    cell.Value = "Show Foods";
                }
            }
            
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateDietPlan c1 = new CreateDietPlan();
            c1.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 4)
            {
                int DietPlanID_2 = e.RowIndex + 1;
                DisplayFoods d1 = new DisplayFoods(DietPlanID_2);
                d1.Show();
            }
            if(e.RowIndex != -1 && e.ColumnIndex == 5)
            {
                int DietPlanID_2 = e.RowIndex + 1;
                SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
                connection.Open();
                SqlCommand command;
                string query = "USE PROJECT_DB Insert into PROJECT_DB.dbo.Member_Diet Values (' " + memberID + "','" + DietPlanID_2 + "')";
                command = new SqlCommand(query, connection);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("DietPlan Added");
                connection.Close();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                int row = e.RowIndex;
                DataGridViewCell cell = guna2DataGridView2.Rows[row].Cells[1];
                string dietplanid = cell.Value.ToString();
                if (dietplanid != "")
                {
                    int id = Int32.Parse(dietplanid);
                    DisplayFoods display = new DisplayFoods(id);
                    display.Show();
                }
                
            }
        }
    }
}
