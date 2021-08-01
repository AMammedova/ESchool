using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ESchool
{
    public partial class FrmTeacher : Form
    {
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClub fr = new FrmClub();
            fr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLessons fr = new FrmLessons();
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmStudent fr = new FrmStudent();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmExamNotes fr = new FrmExamNotes();
            fr.Show();
            this.Hide();
        }
    }
}
