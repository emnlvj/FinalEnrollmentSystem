using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EnrollmentSystem
{
    public partial class StudentEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mis\Desktop\Enrollment System\Jacaba1.accdb";
        public StudentEntry()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                string query = "SELECT COUNT(*) FROM STUDENTFILE WHERE STFSTUDID = ?";
                using (OleDbCommand thisCommand = new OleDbCommand(query, thisConnection))
                {
                    thisCommand.Parameters.AddWithValue("?", StudIDTextBox.Text.Trim().ToUpper());
                    int count = (int)thisCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("ID NUMBER ALREADY EXISTS");
                        return;
                    }
                }

                string insertQuery = @"INSERT INTO STUDENTFILE (STFSTUDID, STFSTUDLNAME, STFSTUDFNAME, STFSTUDMNAME, STFSTUDCOURSE, STFSTUDYEAR, STFSTUDREMARKS, STFSTUDSTATUS) 
                                       VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, thisConnection))
                {
                    insertCommand.Parameters.AddWithValue("?", StudIDTextBox.Text.Trim());
                    insertCommand.Parameters.AddWithValue("?", LastNameTextBox.Text.Trim());
                    insertCommand.Parameters.AddWithValue("?", FirstNameTextBox.Text.Trim());
                    insertCommand.Parameters.AddWithValue("?", MidNameTextBox.Text.Trim().Substring(0, 1));
                    insertCommand.Parameters.AddWithValue("?", CourseTextBox.Text.Trim());
                    insertCommand.Parameters.AddWithValue("?", Convert.ToInt32(YearTextBox.Text.Trim()));
                    insertCommand.Parameters.AddWithValue("?", RemarksTextBox.Text.Trim());
                    insertCommand.Parameters.AddWithValue("?", StatusTextBox.Text.Trim());

                    insertCommand.ExecuteNonQuery();
                }

                MessageBox.Show("RECORDED");
                ClearFormFields();
            }
        }

        private void ClearFormFields()
        {
            StudIDTextBox.Clear();
            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            MidNameTextBox.Clear();
            CourseTextBox.Clear();
            YearTextBox.Clear();
            RemarksTextBox.Clear();
            StatusTextBox.Clear();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            StudIDTextBox.Clear();
            LastNameTextBox.Clear();
            FirstNameTextBox.Clear();
            MidNameTextBox.Clear();
            CourseTextBox.Clear();
            YearTextBox.Clear();
            RemarksTextBox.Clear();
            StatusTextBox.Clear();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainEntry menu = new MainEntry();
            menu.Show();
            Hide();
        }
    }
}
