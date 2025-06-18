
namespace DB_Milestone_2
{
    partial class TrainerRating
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2RatingStar1 = new Guna.UI2.WinForms.Guna2RatingStar();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::DB_Milestone_2.Properties.Resources.rating;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-34, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(1599, 1080);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(695, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Rating";
            // 
            // guna2RatingStar1
            // 
            this.guna2RatingStar1.Location = new System.Drawing.Point(548, 301);
            this.guna2RatingStar1.Name = "guna2RatingStar1";
            this.guna2RatingStar1.Size = new System.Drawing.Size(476, 103);
            this.guna2RatingStar1.TabIndex = 2;
            this.guna2RatingStar1.ValueChanged += new System.EventHandler(this.guna2RatingStar1_ValueChanged);
            // 
            // TrainerRating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1554, 1041);
            this.Controls.Add(this.guna2RatingStar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "TrainerRating";
            this.Text = "TrainerRating";
            this.Load += new System.EventHandler(this.TrainerRating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2RatingStar guna2RatingStar1;
    }
}