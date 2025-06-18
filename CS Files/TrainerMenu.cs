using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Milestone_2
{
    public partial class Trainer : Form
    {
        int Trainer_ID;
        public Trainer(int TrainerID)
        {
            Trainer_ID = TrainerID;
            InitializeComponent();
        }

        private void Trainer_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            TrainerHome t1 = new TrainerHome(Trainer_ID);
            t1.TopLevel = false;
            guna2Panel1.Controls.Add(t1);
            t1.Show();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            TrainerAppointment t1 = new TrainerAppointment(Trainer_ID);
            t1.TopLevel = false;

            guna2Panel1.Controls.Add(t1);
            t1.Show();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            TrainerWorkout t1 = new TrainerWorkout(Trainer_ID);
            t1.TopLevel = false;

            guna2Panel1.Controls.Add(t1);
            t1.Show();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            TrainerDiet t1 = new TrainerDiet(Trainer_ID);
            t1.TopLevel = false;

            guna2Panel1.Controls.Add(t1);
            t1.Show();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            TrainerRating t1 = new TrainerRating(Trainer_ID);
            t1.TopLevel = false;

            guna2Panel1.Controls.Add(t1);
            t1.Show();
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logging out....");
            MainMenu m1 = new MainMenu();
            m1.Show();
        }

        
    }
}
