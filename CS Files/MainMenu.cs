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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void makebuttontransparent(Button b1)
        {
            b1.FlatStyle = FlatStyle.Flat;
            b1.ForeColor = Color.Transparent;
            b1.BackColor = Color.Transparent;
            b1.Parent = this.pictureBox1;
            b1.FlatAppearance.BorderSize = 0;
            b1.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
            b1.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MemberSignup m1 = new MemberSignup();
            this.Hide();
            m1.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrainerSignUp t1 = new TrainerSignUp();
            t1.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OwnerSignUp t1 = new OwnerSignUp();
            t1.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminSignUp a1 = new AdminSignUp();
            a1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
