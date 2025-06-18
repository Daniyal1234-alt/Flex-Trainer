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
    public partial class TrainerRating : Form
    {
        int TrainerID;
        public TrainerRating(int id)
        {
            TrainerID = id;
            InitializeComponent();
            guna2RatingStar1.ReadOnly = true;
        }

        private void TrainerRating_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = $"USE PROJECT_DB SELECT SUM(Rating) AS TotalRating, COUNT(*) AS TotalRatings FROM PROJECT_DB.dbo.Member_Rating WHERE TrainerID = {TrainerID}";
            command = new SqlCommand(query, connection);
            int avgRating = Int32.Parse(command.ExecuteScalar().ToString());
            guna2RatingStar1.Value = avgRating;

        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
