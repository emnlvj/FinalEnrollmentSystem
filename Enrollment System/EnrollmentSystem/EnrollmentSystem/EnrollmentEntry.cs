using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class EnrollmentEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mis\Desktop\Enrollment System\Jacaba1.accdb";
        public EnrollmentEntry()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IDNumberTextBox.Text))
            {
                MessageBox.Show("ID NUMBER IS EMPTY");
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                if (IsStudentAlreadyEnrolled(connection, IDNumberTextBox.Text.Trim().ToUpper()))
                {
                    MessageBox.Show("STUDENT ALREADY ENROLLED");
                    return;
                }

                if (!AreClassesAvailable(connection))
                {
                    MessageBox.Show("ENROLLMENT DECLINED, PLEASE CHECK CORRECT DETAILS");
                    return;
                }

                EnrollStudent(connection);
                MessageBox.Show("ENROLLED");
                ClearForm();
            }
        }

        private bool IsStudentAlreadyEnrolled(OleDbConnection connection, string studentId)
        {
            using (OleDbCommand command = new OleDbCommand("SELECT 1 FROM ENROLLMENTHEADERFILE WHERE ENRHFSTUDID = @StudentId", connection))
            {
                command.Parameters.AddWithValue("@StudentId", studentId);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }

        private bool AreClassesAvailable(OleDbConnection connection)
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string edpCode = row.Cells[0].Value.ToString();

                using (OleDbCommand command = new OleDbCommand("SELECT SSFMAXSIZE, SSFCLASSSIZE FROM SUBJECTSCHEDFILE WHERE SSFEDPCODE = @edpCode", connection))
                {
                    command.Parameters.AddWithValue("@edpCode", edpCode);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int maxSize = Convert.ToInt32(reader["SSFMAXSIZE"]);
                            int classSize = Convert.ToInt32(reader["SSFCLASSSIZE"]);

                            if (classSize >= maxSize)
                            {
                                MessageBox.Show($"CLASS {edpCode} IS FULL");
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private void EnrollStudent(OleDbConnection connection)
        {
            using (OleDbTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    InsertEnrollmentHeader(connection, transaction);
                    InsertEnrollmentDetails(connection, transaction);
                    UpdateSubjectSchedule(connection, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private void InsertEnrollmentHeader(OleDbConnection connection, OleDbTransaction transaction)
        {
            using (OleDbCommand command = new OleDbCommand(
                "INSERT INTO ENROLLMENTHEADERFILE (ENRHFSTUDID, ENRHFSTUDDATEENROLL, ENRHFSTUDSCHLYR, ENRHFSTUDENCODER, ENRHFSTUDTOTALUNITS, ENRHFSTUDSTATUS) " +
                "VALUES (@StudentId, @EnrollDate, @SchoolYear, @Encoder, @TotalUnits, @Status)", connection, transaction))
            {
                command.Parameters.AddWithValue("@StudentId", IDNumberTextBox.Text);
                command.Parameters.AddWithValue("@EnrollDate", DatePicker.Text.Trim());
                command.Parameters.AddWithValue("@SchoolYear", "2023-2024");
                command.Parameters.AddWithValue("@Encoder", NameLabel2.Text);
                command.Parameters.AddWithValue("@TotalUnits", Convert.ToInt16(TotalUnitsLabel.Text));
                command.Parameters.AddWithValue("@Status", "EN");

                command.ExecuteNonQuery();
            }
        }

        private void InsertEnrollmentDetails(OleDbConnection connection, OleDbTransaction transaction)
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                using (OleDbCommand command = new OleDbCommand(
                    "INSERT INTO ENROLLMENTDETAILFILE (ENRDFSTUDID, ENRDFSTUDSUBJCODE, ENRDFSTUDEDPCODE) " +
                    "VALUES (@StudentId, @SubjectCode, @EdpCode)", connection, transaction))
                {
                    command.Parameters.AddWithValue("@StudentId", IDNumberTextBox.Text);
                    command.Parameters.AddWithValue("@SubjectCode", row.Cells[1].Value);
                    command.Parameters.AddWithValue("@EdpCode", row.Cells[0].Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateSubjectSchedule(OleDbConnection connection, OleDbTransaction transaction)
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                string edpCode = row.Cells[0].Value.ToString();

                using (OleDbCommand command = new OleDbCommand(
                    "UPDATE SUBJECTSCHEDFILE SET SSFCLASSSIZE = SSFCLASSSIZE + 1 WHERE SSFEDPCODE = @EdpCode", connection, transaction))
                {
                    command.Parameters.AddWithValue("@EdpCode", edpCode);
                    command.ExecuteNonQuery();
                }

                using (OleDbCommand command = new OleDbCommand(
                    "UPDATE SUBJECTSCHEDFILE SET SSFSTATUS = 'IN' WHERE SSFEDPCODE = @EdpCode AND SSFCLASSSIZE >= SSFMAXSIZE", connection, transaction))
                {
                    command.Parameters.AddWithValue("@EdpCode", edpCode);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ClearForm()
        {
            EDPCodeTextBox.Text = string.Empty;
            NameLabel2.Text = string.Empty;
            CourseLabelTwo.Text = string.Empty;
            YearLabelTwo.Text = string.Empty;
            IDNumberTextBox.Text = string.Empty;
            DataGridView.Rows.Clear();
        }

        private void StudentInfoGroupBox_Paint(object sender, PaintEventArgs e)
        {
            StudentInfoGroupBox.BackColor = Color.FromArgb(150, StudentInfoGroupBox.BackColor);
        }

        private void IDNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                OleDbCommand thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT * FROM STUDENTFILE";
                OleDbDataReader thisDataReader = thisCommand.ExecuteReader();

                bool found = false;

                while (thisDataReader.Read())
                {
                    if (thisDataReader["STFSTUDID"].ToString().Trim() == IDNumberTextBox.Text.Trim())
                    {
                        string name = null;
                        string course = null;
                        string year = null;
                        found = true;
                        name = thisDataReader["STFSTUDLNAME"].ToString() + ", " + thisDataReader["STFSTUDFNAME"].ToString() + " " + thisDataReader["STFSTUDMNAME"].ToString().Substring(0, 1);
                        NameLabel2.Text = name;
                        course = thisDataReader["STFSTUDCOURSE"].ToString();
                        CourseLabelTwo.Text = course;
                        year = thisDataReader["STFSTUDYEAR"].ToString();
                        YearLabelTwo.Text = year;
                        break;
                    }
                }

                if (!found)
                    MessageBox.Show("STUDENT NOT FOUND");
            }
        }


        private bool IsDayConflict(string days, string existingDays)
        {
            Dictionary<string, string[]> conflictDays = new Dictionary<string, string[]>
    {
        { "MWF", new[] { "MON", "WED", "FRI" } },
        { "MW", new[] { "MON", "WED" } },
        { "TTH", new[] { "TUE", "THU" } },
        { "FS", new[] { "FRI", "SAT" } }
    };

            if (conflictDays.TryGetValue(days, out string[] conflictingDays))
            {
                foreach (string day in conflictingDays)
                {
                    if (existingDays.Contains(day))
                    {
                        return true;
                    }
                }
            }

            return existingDays == days;
        }

        private bool IsTimeConflict(string startTime, string endTime, DataGridViewRow row)
        {
            TimeSpan newStart = DateTime.Parse(startTime).TimeOfDay;
            TimeSpan newEnd = DateTime.Parse(endTime).TimeOfDay;
            TimeSpan existingStart = DateTime.Parse(row.Cells[2].Value.ToString()).TimeOfDay;
            TimeSpan existingEnd = DateTime.Parse(row.Cells[3].Value.ToString()).TimeOfDay;

            return !(newStart >= existingEnd || newEnd <= existingStart);
        }

        

        

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            IDNumberTextBox.Clear();
            NameLabel2.Text = null;
            CourseLabelTwo.Text = null;
            YearLabelTwo.Text = null;
            EDPCodeTextBox.Clear();
            TotalUnitsLabel.Text = null;
            DataGridView.Rows.Clear();
        }

        private void EDPCodeTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                

                
                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    string edpCode = EDPCodeTextBox.Text.Trim();
                    if (row.IsNewRow) continue;
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Trim() == edpCode)
                    {
                        MessageBox.Show("EDP code already exists in the schedule.");
                        return;
                    }
                }

                using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
                {
                    thisConnection.Open();

                    OleDbCommand command = new OleDbCommand("SELECT * FROM SUBJECTSCHEDFILE WHERE SSFEDPCODE = @edpCode", thisConnection);
                    command.Parameters.AddWithValue("@edpCode", EDPCodeTextBox.Text.Trim());
                    OleDbDataReader reader = command.ExecuteReader();

                    if (!reader.Read())
                    {
                        MessageBox.Show("SCHEDULE NOT FOUND");
                        reader.Close();
                        return;
                    }

                    string edpCode = reader["SSFEDPCODE"].ToString();
                    string subjCode = reader["SSFSUBJCODE"].ToString();
                    string startTime = reader["SSFSTARTTIME"].ToString();
                    string endTime = reader["SSFENDTIME"].ToString();
                    string days = reader["SSFDAYS"].ToString();
                    string room = reader["SSFROOM"].ToString();
                    reader.Close();

                    command.CommandText = "SELECT SFSUBJUNITS FROM SUBJECTFILE WHERE SFSUBJCODE = @subjCode";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@subjCode", subjCode.Trim().ToUpper());
                    object unitsResult = command.ExecuteScalar();
                    string units = unitsResult != null ? unitsResult.ToString() : "0";

                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string existingDays = row.Cells[4].Value.ToString().ToUpper();
                        if (IsDayConflict(days, existingDays) && IsTimeConflict(startTime, endTime, row))
                        {
                            MessageBox.Show("SCHEDULE IS CONFLICT!");
                            return;
                        }
                    }

                    DataGridViewRow newRow = DataGridView.Rows[DataGridView.Rows.Add()];
                    newRow.Cells[0].Value = edpCode;
                    newRow.Cells[1].Value = subjCode;
                    newRow.Cells[2].Value = DateTime.Parse(startTime).ToString("hh:mm tt");
                    newRow.Cells[3].Value = DateTime.Parse(endTime).ToString("hh:mm tt");
                    newRow.Cells[4].Value = days;
                    newRow.Cells[5].Value = room;
                    newRow.Cells[6].Value = units;

                    int totalUnits = 0;
                    foreach (DataGridViewRow row in DataGridView.Rows)
                    {
                        if (row.IsNewRow) continue;
                        totalUnits += Convert.ToInt32(row.Cells[6].Value);
                    }

                    TotalUnitsLabel.Text = totalUnits.ToString();
                }
            }
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainEntry mainEntry = new MainEntry();
            mainEntry.Show();
            Hide();
        }
    }
}
