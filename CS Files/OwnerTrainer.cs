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
    public partial class OwnerTrainer : Form
    {
        int Ownerid, GymID;
        public OwnerTrainer(int id, int id2)
        {
            Ownerid = id;
            GymID = id2;
            InitializeComponent();
            this.guna2DataGridView1.DefaultCellStyle.Font = new Font("Lucida Bright", 16);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 20;
            this.guna2DataGridView1.ColumnHeadersHeight = 20;
            guna2DataGridView1.RowTemplate.Height = 35;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string TrainerID = guna2TextBox1.Text, TrainerName = guna2TextBox2.Text, NumberofClients = guna2TextBox3.Text, speciality = guna2TextBox4.Text, TrainerRating = guna2TextBox5.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string Query = $@"SELECT 
                T.TrainerID,
                T.NAME AS TrainerName,
                T.Email,
                T.Phone_Number AS PhoneNumber,
                T.Specialties,
                COUNT(MT.MemberID) AS NumberOfClients,
                AVG(MR.Rating) AS AverageRating
            FROM 
                PROJECT_DB.dbo.Trainer AS T
            INNER JOIN 
                Trainer_Gym AS TG ON T.TrainerID = TG.TrainerID
            INNER JOIN 
                Member_Trainer AS MT ON T.TrainerID = MT.TrainerID
            LEFT JOIN 
                Member_Rating AS MR ON T.TrainerID = MR.TrainerID
            WHERE 
                TG.GymID = {GymID} 
            GROUP BY 
                T.TrainerID,
                T.NAME,
                T.Email,
                T.Phone_Number,
                T.Specialties
            HAVING 1=1 
             ";
            if (!string.IsNullOrEmpty(TrainerID))
            {
                Query += $" AND T.TrainerID = {TrainerID}";
            }
            if (!string.IsNullOrEmpty(TrainerName))
            {
                Query += $" AND T.Name = '{TrainerName}'";
            }
            if (!string.IsNullOrEmpty(NumberofClients))
            {
                Query += $" AND COUNT(MT.MemberID) >= {NumberofClients} ";
            }
            if (!string.IsNullOrEmpty(speciality))
            {
                Query += $" AND  T.Specialties = '{speciality}'";
            }
            if (!string.IsNullOrEmpty(TrainerRating))
            {
                Query += $" AND AVG(MR.Rating) >= {TrainerRating}";
            }
            command = new SqlCommand(Query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dtRecord = new DataTable();
            dataAdapter.Fill(dtRecord);
            guna2DataGridView1.DataSource = dtRecord;
            connection.Close();
        }

        private void OwnerTrainer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}
