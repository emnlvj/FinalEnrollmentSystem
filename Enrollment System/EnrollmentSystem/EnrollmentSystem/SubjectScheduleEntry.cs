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

namespace EnrollmentSystem
{
    public partial class SubjectScheduleEntry : Form
    {
         string connectionString =   @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mis\Desktop\Enrollment System\Jacaba1.accdb";
        public SubjectScheduleEntry()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, panel1.BackColor);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, panel1.BackColor);
        }

       

        private void SaveButton_Click(object sender, EventArgs e)
        {
            bool exist = false;
            string edpCode = EDPCodeTextBox.Text.Trim().ToUpper();

            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();

                string query = "SELECT COUNT(*) FROM SUBJECTSCHEDFILE WHERE SSFEDPCODE = ?";
                using (OleDbCommand thisCommand = new OleDbCommand(query, thisConnection))
                {
                    thisCommand.Parameters.AddWithValue("?", EDPCodeTextBox.Text.Trim().ToUpper());
                    int count = (int)thisCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("EDP CODE ALREADY EXISTS");
                        exist = true;
                    }
                }
            }

            if (!exist)
            {
                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();
                    using (OleDbDataAdapter thisAdapter = new OleDbDataAdapter("SELECT * FROM SUBJECTSCHEDFILE", thisConnection))
                    {
                        OleDbCommandBuilder thisBuilder = new OleDbCommandBuilder(thisAdapter);
                        DataSet thisDataSet = new DataSet();
                        thisAdapter.Fill(thisDataSet, "SUBJECTSCHEDFILE");
                        DataRow thisRow = thisDataSet.Tables["SUBJECTSCHEDFILE"].NewRow();

                        thisRow["SSFEDPCODE"] = EDPCodeTextBox.Text.Trim();
                        thisRow["SSFSUBJCODE"] = SubjectCodeTextBoxThree.Text.Trim();
                        thisRow["SSFSTARTTIME"] = StartTime.Text.Trim();
                        thisRow["SSFENDTIME"] = EndTime.Text.Trim();
                        thisRow["SSFDAYS"] = DaysTextBox.Text.Trim();
                        thisRow["SSFROOM"] = RoomTextBox.Text.Trim();
                        thisRow["SSFMAXSIZE"] = 15;
                        thisRow["SSFCLASSSIZE"] = 0;
                        thisRow["SSFSTATUS"] = "AC";
                        thisRow["SSFXM"] = AMComboBox.Text.Trim();
                        thisRow["SSFSECTION"] = SectionTextBox.Text.Trim();
                        thisRow["SSFSCHOOLYEAR"] = SchoolYearTextBox.Text.Trim();
                        thisDataSet.Tables["SUBJECTSCHEDFILE"].Rows.Add(thisRow);
                        thisAdapter.Update(thisDataSet, "SUBJECTSCHEDFILE");
                    }
                }

                MessageBox.Show("RECORDED");

                ClearFormFields();
            }
        }

        private void ClearFormFields()
        {
            EDPCodeTextBox.Clear();
            SubjectCodeTextBoxThree.Clear();
            DescLabel2.Text = string.Empty;
            DaysTextBox.Clear();
            AMComboBox.SelectedIndex = -1;
            RoomTextBox.Clear();
            SectionTextBox.Clear();
            SchoolYearTextBox.Clear();
        }

        
        private void MainMenu_Click_1(object sender, EventArgs e)
        {
          
                MainEntry menu = new MainEntry();
                menu.Show();
                Hide();
            
        }


        private void SubjectCodeTextBoxThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT * FROM SUBJECTFILE";
                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;

                while (thisDataReader.Read())
                {
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTextBoxThree.Text.Trim())
                    {
                        string description = null;
                        found = true;
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        DescLabel2.Text = description;
                        break;
                    }
                }

                if (!found)
                    MessageBox.Show("SUBJECT CODE NOT FOUND");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EDPCodeTextBox.Text = null;
            SubjectCodeTextBoxThree.Text = null;
            DescLabel2.Text = null;
            SectionTextBox.Text = null;
            RoomTextBox.Text = null;
            SchoolYearTextBox = null;
            StartTime.ResetText();
            EndTime.ResetText();
            AMComboBox.Text = null;
            DaysTextBox.Text = null;
            
        }
    }
}
