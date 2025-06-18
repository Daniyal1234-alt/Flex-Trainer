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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string TrainerID = guna2TextBox1.Text, GymID = guna2TextBox2.Text, dietplanID = guna2TextBox3.Text, reportID = guna2TextBox4.Text;
            string machines = guna2TextBox5.Text, calories = guna2TextBox6.Text, foodType = guna2TextBox7.Text, Carbs = guna2TextBox8.Text;
            string Allergens = guna2TextBox9.Text, membershipdate = guna2TextBox10.Text;
            SqlConnection connection = new SqlConnection("Data Source=DANIWORKSTATION\\SQLEXPRESS;Initial Catalog=PROJECT_DB;Integrated Security=True");
            connection.Open();
            SqlCommand command;
            string query = "";
            if (reportID == "1")
            {
                query += $@"SELECT m.*
                FROM PROJECT_DB.dbo.Member m
                JOIN PROJECT_DB.dbo.Member_Trainer mt ON m.MemberID = mt.MemberID
                JOIN PROJECT_DB.dbo.Trainer_Gym tg ON mt.TrainerID = tg.TrainerID
                WHERE tg.GymID = {GymID}
                AND mt.TrainerID = {TrainerID}
                ";
            }
            else if (reportID == "2")
            {
                query += $@"SELECT m.*
                FROM PROJECT_DB.dbo.Member m
                JOIN PROJECT_DB.dbo.Member_Diet md ON m.MemberID = md.MemberID
                JOIN PROJECT_DB.dbo.DietPlan d ON md.DietPlanID = d.DietPlanID
                JOIN PROJECT_DB.dbo.Member_Gym mg ON m.MemberID = mg.MemberID
                WHERE mg.GymID = {GymID}
                AND d.DietPlanID = {dietplanID};
                ";
            }
            else if (reportID == "3")
            {
                query += $@"SELECT m.*
                FROM PROJECT_DB.dbo.Member m
                JOIN PROJECT_DB.dbo.Member_Diet md ON m.MemberID = md.MemberID
                JOIN PROJECT_DB.dbo.DietPlan d ON md.DietPlanID = d.DietPlanID
                JOIN PROJECT_DB.dbo.Member_Trainer mt ON m.MemberID = mt.MemberID
                WHERE mt.TrainerID = {TrainerID}
                AND d.DietPlanID = {dietplanID};
                ";
            }
            else if (reportID == "4")
            {
                query += $@"SELECT COUNT(*) AS MachineUsersCount
                FROM PROJECT_DB.dbo.Member_Workout mw
                JOIN PROJECT_DB.dbo.Workout w ON mw.WorkoutID = w.WorkoutID
                JOIN PROJECT_DB.dbo.Exercise e ON w.WorkoutID = e.WorkoutID
                JOIN PROJECT_DB.dbo.Member_Gym mg ON mw.MemberID = mg.MemberID
                WHERE mg.GymID = {GymID}
                AND e.Machine = 'None'
                ";
            }
            else if (reportID == "5")
            {
                query += $@"SELECT *
                FROM PROJECT_DB.dbo.DietPlan a JOIN PROJECT_DB.dbo.food b ON a.DietPlanID = b.DietPlanID
                WHERE b.Calories < {calories} AND b.Time = '{foodType}' 
                ";
            }
            else if (reportID == "6")
            {
                query += $@"SELECT *
                FROM PROJECT_DB.dbo.DietPlan a JOIN PROJECT_DB.dbo.food b ON a.DietPlanID = b.DietPlanID
                WHERE carbs < {Carbs} AND Time = '{foodType}'; 
                ";
            }
            else if (reportID == "7")
            {
                query += $@"SELECT DISTINCT w.*
                    FROM PROJECT_DB.dbo.Workout w
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM PROJECT_DB.dbo.Exercise e
                        WHERE e.WorkoutID = w.WorkoutID
                        AND e.Machine = '{machines}'
                    );
                    ";
            }
            else if (reportID == "8")
            {
                query += $@"SELECT *
                FROM PROJECT_DB.dbo.DietPlan dp
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM food f
                    WHERE f.DietPlanID = dp.DietPlanID
                    AND f.allergens LIKE '%{Allergens}%'
                );
                ";
            }
            else if (reportID == "9")
            {

                query += $@"SELECT *
                    FROM PROJECT_DB.dbo.Member
                    WHERE JOINING_DATE >= DATEADD(month, -3, GETDATE());
                    ";
            }
            else if (reportID == "10")
            {
                query += $@"SELECT mg.GymID, COUNT(m.MemberID) AS TotalMembers
                FROM PROJECT_DB.dbo.Member_Gym mg
                JOIN PROJECT_DB.dbo.Member m ON mg.MemberID = m.MemberID
                WHERE m.JOINING_DATE >= DATEADD(month, -6, GETDATE())
                GROUP BY mg.GymID;
                ";
            }
            else
            {
                return;
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
