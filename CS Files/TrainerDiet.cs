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
    public partial class TrainerDiet : Form
    {
        int TrainerID;
        public TrainerDiet(int id)
        {
            TrainerID = id;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void TrainerDiet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CreateDietPlan c1 = new CreateDietPlan();
            c1.Show();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string DietPlanID = guna2TextBox1.Text, type = guna2TextBox2.Text, purpose = guna2TextBox3.Text, creator = guna2TextBox4.Text;
            string calories = guna2TextBox5.Text,carbs = guna2TextBox6.Text, protein = guna2TextBox7.Text, fats = guna2TextBox8.Text, allergens = guna2TextBox9.Text, time = guna2TextBox10.Text, memberID = guna2TextBox11.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string sqlQuery = "SELECT Distinct a.DietPlanID, a.Name, a.Type, a.Purpose, a.createdBy,b.MemberID as Member, c.FoodID,c.name As FoodName, c.calories As Calories,c.carbs AS Carbs, c.protein as Protein, c.fat As Fats,  c.Allergens as Allergens, c.time FROM Project_DB.dbo.DietPlan a JOIN Project_DB.dbo.Member_Diet b ON a.DietPlanID = b.DietPlanID Join Project_DB.dbo.food c ON c.DietPlanID = b.DietPlanID WHERE 1=1";

            // Add conditions based on textbox values
            if (!string.IsNullOrEmpty(DietPlanID))
                sqlQuery += $" AND a.DietPlanID = {DietPlanID}";
            if (!string.IsNullOrEmpty(type))
                sqlQuery += $" AND Type = '{type}'";
            if (!string.IsNullOrEmpty(purpose))
                sqlQuery += $" AND Purpose = '{purpose}'";
            if (!string.IsNullOrEmpty(creator))
                sqlQuery += $" AND Creator = '{creator}'";
            if (!string.IsNullOrEmpty(calories))
                sqlQuery += $" AND c.Calories <= '{calories}'";
            if (!string.IsNullOrEmpty(carbs))
                sqlQuery += $" AND c.carbs <= '{carbs}'";
            if (!string.IsNullOrEmpty(protein))
                sqlQuery += $" AND c.Protein >= '{protein}'";
            if (!string.IsNullOrEmpty(fats))
                sqlQuery += $" AND c.Fat <= '{fats}'";
            if (!string.IsNullOrEmpty(allergens))
                sqlQuery += $" AND c.Allergens <> '{allergens}' OR c.Allergens IS NULL";
            if (!string.IsNullOrEmpty(time))
                sqlQuery += $" AND c.time = '{time}'";
            if (!string.IsNullOrEmpty(memberID))
                sqlQuery += $" And b.MemberID = {memberID}";
            command = new SqlCommand(sqlQuery, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            connection.Close();
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
