
namespace DB_Milestone_2
{
    partial class DisplayExercises
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayExercises));
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.exerciseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pROJECT_DB = new DB_Milestone_2.PROJECT_DB();
            this.exerciseTableAdapter = new DB_Milestone_2.PROJECT_DBTableAdapters.ExerciseTableAdapter();
            this.sets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetMuscleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exerciseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pROJECT_DB)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 15;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.exerciseIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.targetMuscleDataGridViewTextBoxColumn,
            this.machineDataGridViewTextBoxColumn,
            this.restDataGridViewTextBoxColumn,
            this.reps,
            this.sets});
            this.guna2DataGridView1.DataSource = this.exerciseBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(55, 50);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.ShowCellErrors = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(695, 328);
            this.guna2DataGridView1.TabIndex = 0;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 15;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            // 
            // exerciseBindingSource
            // 
            this.exerciseBindingSource.DataMember = "Exercise";
            this.exerciseBindingSource.DataSource = this.pROJECT_DB;
            // 
            // pROJECT_DB
            // 
            this.pROJECT_DB.DataSetName = "PROJECT_DB";
            this.pROJECT_DB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // exerciseTableAdapter
            // 
            this.exerciseTableAdapter.ClearBeforeFill = true;
            // 
            // sets
            // 
            this.sets.DataPropertyName = "sets";
            this.sets.HeaderText = "Sets";
            this.sets.Name = "sets";
            this.sets.ReadOnly = true;
            // 
            // reps
            // 
            this.reps.DataPropertyName = "reps";
            this.reps.HeaderText = "Reps";
            this.reps.Name = "reps";
            this.reps.ReadOnly = true;
            // 
            // restDataGridViewTextBoxColumn
            // 
            this.restDataGridViewTextBoxColumn.DataPropertyName = "Rest";
            this.restDataGridViewTextBoxColumn.HeaderText = "Rest";
            this.restDataGridViewTextBoxColumn.Name = "restDataGridViewTextBoxColumn";
            this.restDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // machineDataGridViewTextBoxColumn
            // 
            this.machineDataGridViewTextBoxColumn.DataPropertyName = "Machine";
            this.machineDataGridViewTextBoxColumn.HeaderText = "Machine";
            this.machineDataGridViewTextBoxColumn.Name = "machineDataGridViewTextBoxColumn";
            this.machineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // targetMuscleDataGridViewTextBoxColumn
            // 
            this.targetMuscleDataGridViewTextBoxColumn.DataPropertyName = "TargetMuscle";
            this.targetMuscleDataGridViewTextBoxColumn.HeaderText = "TargetMuscle";
            this.targetMuscleDataGridViewTextBoxColumn.Name = "targetMuscleDataGridViewTextBoxColumn";
            this.targetMuscleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // exerciseIDDataGridViewTextBoxColumn
            // 
            this.exerciseIDDataGridViewTextBoxColumn.DataPropertyName = "ExerciseID";
            this.exerciseIDDataGridViewTextBoxColumn.HeaderText = "ExerciseID";
            this.exerciseIDDataGridViewTextBoxColumn.Name = "exerciseIDDataGridViewTextBoxColumn";
            this.exerciseIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DisplayExercises
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2DataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayExercises";
            this.Text = "DisplayExercises";
            this.Load += new System.EventHandler(this.DisplayExercises_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exerciseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pROJECT_DB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private PROJECT_DB pROJECT_DB;
        private System.Windows.Forms.BindingSource exerciseBindingSource;
        private PROJECT_DBTableAdapters.ExerciseTableAdapter exerciseTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn setsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exerciseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetMuscleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reps;
        private System.Windows.Forms.DataGridViewTextBoxColumn sets;
    }
}