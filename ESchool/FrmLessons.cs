using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ESchool
{
    public partial class FrmLessons : Form
    {
        public FrmLessons()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBL_LessonsTableAdapter ds = new DataSet1TableAdapters.TBL_LessonsTableAdapter();

        private void button5_Click(object sender, EventArgs e)
        {
            FrmTeacher fr = new FrmTeacher();
            fr.Show();
            this.Hide();
        }

        private void FrmLessons_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.LessonList();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ds.AddLesson(txdclubname.Text);
            MessageBox.Show("Addin lesson is done");
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.LessonList();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            ds.DeleteQuery(byte.Parse(txdclubid.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.LessonUpdate(byte.Parse(txdclubname.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txdclubid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txdclubname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
