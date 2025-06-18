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
    public partial class MemberMenu : Form
    {
        int Member_ID;
        public MemberMenu(int MemberID)
        {
            Member_ID = MemberID;
            InitializeComponent();
            guna2Panel1.BorderColor = Color.White;
            guna2Panel1.Controls.Clear();
            MemberHome m1 = new MemberHome(Member_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            MemberHome m1 = new MemberHome(Member_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            MemberDiet m1 = new MemberDiet(Member_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            MemberWorkout m1 = new MemberWorkout(Member_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging Out....");
            this.Hide();
            MainMenu m1 = new MainMenu();
            m1.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            MemberSession m1 = new MemberSession(Member_ID);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void MemberMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
