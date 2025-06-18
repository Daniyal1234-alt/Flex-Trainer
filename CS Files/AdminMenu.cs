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
    public partial class Admin : Form
    {
        int Admin_id;
        public Admin(int AdminID)
        {

            InitializeComponent();
            Admin_id = AdminID;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logging Out ... ");
            MainMenu m1 = new MainMenu();
            m1.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            AdminHome m1 = new AdminHome(Admin_id);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            AdminPerformace m1 = new AdminPerformace(Admin_id);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            AdminRequest m1 = new AdminRequest(Admin_id);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            AdminRemoval m1 = new AdminRemoval(Admin_id);
            m1.TopLevel = false;
            guna2Panel1.Controls.Add(m1);
            m1.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Panel1.Controls.Clear();
            Reports reports = new Reports();
            reports.TopLevel = false;
            guna2Panel1.Controls.Add(reports);
            reports.Show();
        }
    }
}
