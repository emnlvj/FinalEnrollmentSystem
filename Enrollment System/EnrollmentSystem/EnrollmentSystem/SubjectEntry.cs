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
    public partial class SubjectEntry : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\mis\Desktop\Enrollment System\Jacaba1.accdb";
        public SubjectEntry()
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
            using (OleDbConnection thisConnection = new OleDbConnection(connectionString))
            {
                thisConnection.Open();
                string query = "SELECT COUNT(*) FROM SUBJECTFILE WHERE SFSUBJCODE = ?";
                using (OleDbCommand thisCommand = new OleDbCommand(query, thisConnection))
                {
                    thisCommand.Parameters.AddWithValue("?", SubjectCodeTextBox.Text.Trim().ToUpper());
                    int count = (int)thisCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("SUBJECT CODE ALREADY EXISTS");
                        return;
                    }
                }

                string insertQuery = @"INSERT INTO SUBJECTFILE (SFSUBJCODE, SFSUBJDESC, SFSUBJUNITS, SFSUBJREGOFRNG, SFSUBJCATEGORY, SFSUBJSTATUS, SFSUBJCOURSECODE, SFSUBJCURRCODE) 
                                       VALUES (?, ?, ?, ?, ?, 'AC', ?, ?)";

                using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, thisConnection))
                {
                    insertCommand.Parameters.AddWithValue("?", SubjectCodeTextBox.Text);
                    insertCommand.Parameters.AddWithValue("?", DescTextBox.Text);
                    insertCommand.Parameters.AddWithValue("?", Convert.ToInt16(UnitsTextBox.Text));
                    insertCommand.Parameters.AddWithValue("?", OfferingComboBox.Text.Substring(0, 1));
                    insertCommand.Parameters.AddWithValue("?", CategoryComboBox.Text.Substring(0, 3).ToUpper());
                    insertCommand.Parameters.AddWithValue("?", CourseCodeComboBox.Text);
                    insertCommand.Parameters.AddWithValue("?", YearTextBox.Text);

                    insertCommand.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(SubjectCodeTwoTextBox.Text) && (PreRequisiteRadioButton.Checked || CoRequisiteRadioButton.Checked))
                {
                    string category = PreRequisiteRadioButton.Checked ? "PR" : "CR";
                    
                    string insertPreqQuery = "INSERT INTO SUBJECTPREQFILE (SUBJCODE, SUBJPRECODE, SUBJCATEGORY) VALUES (?, ?, ?)";

                    using (OleDbCommand preqCommand = new OleDbCommand(insertPreqQuery, thisConnection))
                    {
                        preqCommand.Parameters.AddWithValue("?", SubjectCodeTextBox.Text);
                        preqCommand.Parameters.AddWithValue("?", SubjectCodeTwoTextBox.Text);
                        preqCommand.Parameters.AddWithValue("?", category);

                        preqCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("RECORDED");
                ClearFormFields();
            }
        }

        private void ClearFormFields()
        {
            SubjectCodeTextBox.Text = null;
            DescTextBox.Text = null;
            UnitsTextBox.Text = null;
            OfferingComboBox.SelectedIndex = -1;
            CategoryComboBox.SelectedIndex = -1;
            CourseCodeComboBox.SelectedIndex = -1;
            YearTextBox.Text = null;
            SubjectCodeTwoTextBox.Text = null;
            PreRequisiteRadioButton.Checked = false;
            CoRequisiteRadioButton.Checked = false;
            DataGridView.Rows.Clear();
        }

        private void SubjectCodeTwoTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (thisDataReader["SFSUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTwoTextBox.Text.Trim())
                    {
                        string subjectcode = null;
                        string description = null;
                        string units = null;
                        found = true;
                        subjectcode = thisDataReader["SFSUBJCODE"].ToString();
                        description = thisDataReader["SFSUBJDESC"].ToString();
                        units = thisDataReader["SFSUBJUNITS"].ToString();
                        DataGridView.Rows[0].Cells[0].Value = subjectcode;
                        DataGridView.Rows[0].Cells[1].Value = description;
                        DataGridView.Rows[0].Cells[2].Value = units;
                        break;
                    }
                }

                if (found == false)
                    MessageBox.Show("SUBJECT CODE NOT FOUND");

                thisConnection = new OleDbConnection(connectionString);
                thisConnection.Open();
                thisCommand = thisConnection.CreateCommand();
                thisCommand.CommandText = "SELECT * FROM SUBJECTPREQFILE";
                thisDataReader = thisCommand.ExecuteReader();

                found = false;

                while (thisDataReader.Read())
                {
                    if (thisDataReader["SUBJCODE"].ToString().Trim().ToUpper() == SubjectCodeTwoTextBox.Text.Trim().ToUpper())
                    {
                        string requisite = null;
                        found = true;
                        requisite = thisDataReader["SUBJPRECODE"].ToString();
                        DataGridView.Rows[0].Cells[3].Value = requisite;
                        break;
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SubjectCodeTextBox.Text = null;
            DescTextBox.Text = null;
            UnitsTextBox.Text = null;
            OfferingComboBox.SelectedIndex = -1;
            CategoryComboBox.SelectedIndex = -1;
            CourseCodeComboBox.SelectedIndex = -1;
            YearTextBox.Text = null;
            SubjectCodeTwoTextBox.Text = null;
            PreRequisiteRadioButton.Checked = false;
            CoRequisiteRadioButton.Checked = false;
            DataGridView.Rows.Clear();
        }

        private void MainMenu_Click(object sender, EventArgs e)
        {
            MainEntry menu = new MainEntry();
            menu.Show();
            Hide();
        }
    }
}
