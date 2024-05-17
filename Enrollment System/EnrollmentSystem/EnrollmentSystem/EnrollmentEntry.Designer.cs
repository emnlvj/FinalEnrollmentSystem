namespace EnrollmentSystem
{
    partial class EnrollmentEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollmentEntry));
            this.StudentInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.YearLabelTwo = new System.Windows.Forms.Label();
            this.CourseLabelTwo = new System.Windows.Forms.Label();
            this.NameLabel2 = new System.Windows.Forms.Label();
            this.IDNumberTextBox = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CourseLabel = new System.Windows.Forms.Label();
            this.IdNumberLabel = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.EDPCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDPCodeTextBox = new System.Windows.Forms.TextBox();
            this.EdpCodeLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TotalUnitsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.StudentInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentInfoGroupBox
            // 
            this.StudentInfoGroupBox.BackColor = System.Drawing.Color.White;
            this.StudentInfoGroupBox.Controls.Add(this.YearLabelTwo);
            this.StudentInfoGroupBox.Controls.Add(this.CourseLabelTwo);
            this.StudentInfoGroupBox.Controls.Add(this.NameLabel2);
            this.StudentInfoGroupBox.Controls.Add(this.IDNumberTextBox);
            this.StudentInfoGroupBox.Controls.Add(this.YearLabel);
            this.StudentInfoGroupBox.Controls.Add(this.NameLabel);
            this.StudentInfoGroupBox.Controls.Add(this.CourseLabel);
            this.StudentInfoGroupBox.Controls.Add(this.IdNumberLabel);
            this.StudentInfoGroupBox.Location = new System.Drawing.Point(35, 12);
            this.StudentInfoGroupBox.Name = "StudentInfoGroupBox";
            this.StudentInfoGroupBox.Size = new System.Drawing.Size(270, 183);
            this.StudentInfoGroupBox.TabIndex = 3;
            this.StudentInfoGroupBox.TabStop = false;
            this.StudentInfoGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.StudentInfoGroupBox_Paint);
            // 
            // YearLabelTwo
            // 
            this.YearLabelTwo.BackColor = System.Drawing.Color.White;
            this.YearLabelTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.YearLabelTwo.Location = new System.Drawing.Point(96, 143);
            this.YearLabelTwo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.YearLabelTwo.Name = "YearLabelTwo";
            this.YearLabelTwo.Size = new System.Drawing.Size(150, 24);
            this.YearLabelTwo.TabIndex = 12;
            // 
            // CourseLabelTwo
            // 
            this.CourseLabelTwo.BackColor = System.Drawing.Color.White;
            this.CourseLabelTwo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CourseLabelTwo.Location = new System.Drawing.Point(96, 113);
            this.CourseLabelTwo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CourseLabelTwo.Name = "CourseLabelTwo";
            this.CourseLabelTwo.Size = new System.Drawing.Size(150, 24);
            this.CourseLabelTwo.TabIndex = 11;
            // 
            // NameLabel2
            // 
            this.NameLabel2.BackColor = System.Drawing.Color.White;
            this.NameLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameLabel2.Location = new System.Drawing.Point(96, 85);
            this.NameLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel2.Name = "NameLabel2";
            this.NameLabel2.Size = new System.Drawing.Size(150, 24);
            this.NameLabel2.TabIndex = 10;
            // 
            // IDNumberTextBox
            // 
            this.IDNumberTextBox.Location = new System.Drawing.Point(96, 60);
            this.IDNumberTextBox.Name = "IDNumberTextBox";
            this.IDNumberTextBox.Size = new System.Drawing.Size(150, 20);
            this.IDNumberTextBox.TabIndex = 6;
            this.IDNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDNumberTextBox_KeyPress);
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearLabel.ForeColor = System.Drawing.Color.White;
            this.YearLabel.Location = new System.Drawing.Point(11, 143);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(40, 13);
            this.YearLabel.TabIndex = 5;
            this.YearLabel.Text = "YEAR";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(11, 85);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(42, 13);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "NAME";
            // 
            // CourseLabel
            // 
            this.CourseLabel.AutoSize = true;
            this.CourseLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.CourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseLabel.ForeColor = System.Drawing.Color.White;
            this.CourseLabel.Location = new System.Drawing.Point(11, 113);
            this.CourseLabel.Name = "CourseLabel";
            this.CourseLabel.Size = new System.Drawing.Size(58, 13);
            this.CourseLabel.TabIndex = 2;
            this.CourseLabel.Text = "COURSE";
            // 
            // IdNumberLabel
            // 
            this.IdNumberLabel.AutoSize = true;
            this.IdNumberLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.IdNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdNumberLabel.ForeColor = System.Drawing.Color.White;
            this.IdNumberLabel.Location = new System.Drawing.Point(11, 60);
            this.IdNumberLabel.Name = "IdNumberLabel";
            this.IdNumberLabel.Size = new System.Drawing.Size(77, 13);
            this.IdNumberLabel.TabIndex = 1;
            this.IdNumberLabel.Text = "ID NUMBER";
            // 
            // DataGridView
            // 
            this.DataGridView.BackgroundColor = System.Drawing.Color.Orchid;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EDPCodeColumn,
            this.SubjectCodeColumn,
            this.StartTimeColumn,
            this.EndTimeColumn,
            this.DaysColumn,
            this.RoomColumn,
            this.UnitsColumn});
            this.DataGridView.Location = new System.Drawing.Point(24, 227);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.RowHeadersWidth = 62;
            this.DataGridView.Size = new System.Drawing.Size(746, 150);
            this.DataGridView.TabIndex = 13;
            // 
            // EDPCodeColumn
            // 
            this.EDPCodeColumn.HeaderText = "EDP Code";
            this.EDPCodeColumn.MinimumWidth = 8;
            this.EDPCodeColumn.Name = "EDPCodeColumn";
            this.EDPCodeColumn.Width = 150;
            // 
            // SubjectCodeColumn
            // 
            this.SubjectCodeColumn.HeaderText = "Subject Code";
            this.SubjectCodeColumn.MinimumWidth = 8;
            this.SubjectCodeColumn.Name = "SubjectCodeColumn";
            this.SubjectCodeColumn.Width = 150;
            // 
            // StartTimeColumn
            // 
            this.StartTimeColumn.HeaderText = "Start Time";
            this.StartTimeColumn.MinimumWidth = 8;
            this.StartTimeColumn.Name = "StartTimeColumn";
            this.StartTimeColumn.Width = 150;
            // 
            // EndTimeColumn
            // 
            this.EndTimeColumn.HeaderText = "End Time";
            this.EndTimeColumn.MinimumWidth = 8;
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.Width = 150;
            // 
            // DaysColumn
            // 
            this.DaysColumn.HeaderText = "Days";
            this.DaysColumn.MinimumWidth = 8;
            this.DaysColumn.Name = "DaysColumn";
            this.DaysColumn.Width = 150;
            // 
            // RoomColumn
            // 
            this.RoomColumn.HeaderText = "Room";
            this.RoomColumn.MinimumWidth = 8;
            this.RoomColumn.Name = "RoomColumn";
            this.RoomColumn.Width = 150;
            // 
            // UnitsColumn
            // 
            this.UnitsColumn.HeaderText = "Units";
            this.UnitsColumn.MinimumWidth = 8;
            this.UnitsColumn.Name = "UnitsColumn";
            this.UnitsColumn.Width = 150;
            // 
            // EDPCodeTextBox
            // 
            this.EDPCodeTextBox.Location = new System.Drawing.Point(120, 201);
            this.EDPCodeTextBox.Name = "EDPCodeTextBox";
            this.EDPCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.EDPCodeTextBox.TabIndex = 12;
            this.EDPCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EDPCodeTextBox_KeyPress_1);
            // 
            // EdpCodeLabel
            // 
            this.EdpCodeLabel.AutoSize = true;
            this.EdpCodeLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.EdpCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EdpCodeLabel.ForeColor = System.Drawing.Color.White;
            this.EdpCodeLabel.Location = new System.Drawing.Point(25, 204);
            this.EdpCodeLabel.Name = "EdpCodeLabel";
            this.EdpCodeLabel.Size = new System.Drawing.Size(70, 13);
            this.EdpCodeLabel.TabIndex = 11;
            this.EdpCodeLabel.Text = "EDP CODE";
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.DarkViolet;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(312, 394);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(70, 28);
            this.CancelButton.TabIndex = 57;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DarkViolet;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(235, 394);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(61, 28);
            this.SaveButton.TabIndex = 56;
            this.SaveButton.Text = "SAVE";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TotalUnitsLabel
            // 
            this.TotalUnitsLabel.BackColor = System.Drawing.Color.White;
            this.TotalUnitsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalUnitsLabel.Location = new System.Drawing.Point(639, 201);
            this.TotalUnitsLabel.Name = "TotalUnitsLabel";
            this.TotalUnitsLabel.Size = new System.Drawing.Size(79, 20);
            this.TotalUnitsLabel.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkViolet;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(544, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "TOTAL UNITS";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.DarkViolet;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(401, 394);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(93, 28);
            this.BackButton.TabIndex = 58;
            this.BackButton.Text = "MAIN MENU";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.MainMenu_Click);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.BackColor = System.Drawing.Color.DarkViolet;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.ForeColor = System.Drawing.Color.White;
            this.DateLabel.Location = new System.Drawing.Point(251, 201);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(42, 15);
            this.DateLabel.TabIndex = 53;
            this.DateLabel.Text = "DATE";
            // 
            // DatePicker
            // 
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatePicker.Location = new System.Drawing.Point(312, 201);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(200, 20);
            this.DatePicker.TabIndex = 52;
            // 
            // EnrollmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TotalUnitsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.EDPCodeTextBox);
            this.Controls.Add(this.EdpCodeLabel);
            this.Controls.Add(this.StudentInfoGroupBox);
            this.MaximizeBox = false;
            this.Name = "EnrollmentEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnrollmentEntry";
            this.StudentInfoGroupBox.ResumeLayout(false);
            this.StudentInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox StudentInfoGroupBox;
        private System.Windows.Forms.Label YearLabelTwo;
        private System.Windows.Forms.Label CourseLabelTwo;
        private System.Windows.Forms.Label NameLabel2;
        private System.Windows.Forms.TextBox IDNumberTextBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label CourseLabel;
        private System.Windows.Forms.Label IdNumberLabel;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDPCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitsColumn;
        private System.Windows.Forms.TextBox EDPCodeTextBox;
        private System.Windows.Forms.Label EdpCodeLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label TotalUnitsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.DateTimePicker DatePicker;
    }
}