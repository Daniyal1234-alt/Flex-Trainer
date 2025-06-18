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
    public partial class DisplayFoods : Form
    {
        int DietPlanID;
        public DisplayFoods(int id)
        {
            DietPlanID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void DisplayFoods_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pROJECT_DBDataSet2.food' table. You can move, or remove it, as needed.
            this.foodTableAdapter.Fill(this.pROJECT_DBDataSet2.food);
           // guna2DataGridView1.AutoGenerateColumns = false;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "USE PROJECT_DB Select *  FROM PROJECT_DB.dbo.Food WHERE DietPlanID = '" + DietPlanID + "'";
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
    }
}
