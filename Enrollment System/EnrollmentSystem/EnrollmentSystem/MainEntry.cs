using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrollmentSystem
{
    public partial class MainEntry : Form
    {
        public MainEntry()
        {
            InitializeComponent();
        }

        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, panel1.BackColor);
        }

        private void SubjectEntryDesign_Click(object sender, EventArgs e)
        {

            SubjectEntry subEntry = new SubjectEntry();
            subEntry.Show();
            Hide();
        }

        private void MainEntry_Load(object sender, EventArgs e)
        {

        }

        private void SubjectScheduleEntryDesign_Click(object sender, EventArgs e)
        {
            SubjectScheduleEntry schedEntry = new SubjectScheduleEntry();
            schedEntry.Show();
            Hide();
        }

        private void EnrollmentEntryDesign_Click(object sender, EventArgs e)
        {
            EnrollmentEntry enrollEntry = new EnrollmentEntry();
            enrollEntry.Show();
            Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            StudentEntry studentEntry = new StudentEntry();
            studentEntry.Show();
            Hide();
        }
    }
}
