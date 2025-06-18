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
    public partial class OwnerMenu : Form
    {
        int Owner_ID,  Gym_ID;
        public OwnerMenu(int OwnerID, int GymID)
        {
            Owner_ID = OwnerID;
            Gym_ID = GymID;
            InitializeComponent();
        }

        private void OwnerMenu_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OwnerHome m1 = new OwnerHome(Owner_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OwnerMember m1 = new OwnerMember(Owner_ID, Gym_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OwnerTrainer m1 = new OwnerTrainer(Owner_ID, Gym_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OwnerAddTrainer m1 = new OwnerAddTrainer(Owner_ID, Gym_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            OwnerAdmin m1 = new OwnerAdmin(Owner_ID, Gym_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logging Out ..... ");
            MainMenu m1 = new MainMenu();
            m1.Show();
        }
    }
}
