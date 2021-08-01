using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESchool
{
    public partial class FrmExamNotes : Form
    {
        public FrmExamNotes()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        DataSet1TableAdapters.TBL_NotesTableAdapter ds = new DataSet1TableAdapters.TBL_NotesTableAdapter();
        private void FrmExamNotes_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_Lessons", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "LessonName";
            comboBox1.ValueMember = "LessonId";
            comboBox1.DataSource = dt;
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmTeacher fr = new FrmTeacher();
            fr.Show();
            this.Hide();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NoteList(int.Parse(txdid.Text));
        }
        int notid;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txdid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txd1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txd2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txd3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
      txdproject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
      txdgpa.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
       txdposition.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int ex1, ex2, ex3, project;

        private void btnclear_Click(object sender, EventArgs e)
        {
            txd1.Clear();
            txd2.Clear();
            txd3.Clear();
            txdgpa.Clear();
            txdproject.Clear();
            txdid.Clear();
        }

        double gpa;
        private void btncalculate_Click(object sender, EventArgs e)
        {
           
            
            //ring position;
            ex1 = Convert.ToInt32(txd1.Text);
            ex2 = Convert.ToInt32(txd2.Text);
            ex3 = Convert.ToInt32(txd3.Text);
        project = Convert.ToInt32(txd2.Text);
            gpa = (double)(ex1 + ex2 + ex3 + project) / 4;
            txdgpa.Text = $"{gpa.ToString("0.00")}";
            if (gpa >= 50)
            {
                txdposition.Text = "True";
            }
            else
            {
                txdposition.Text = "False";
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            ds.UpdateNote(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txdid.Text), byte.Parse(txd1.Text), byte.Parse(txd2.Text), byte.Parse(txd3.Text), byte.Parse(txdproject.Text), decimal.Parse(txdgpa.Text), bool.Parse(txdposition.Text),notid);
            MessageBox.Show("Update is ready");
        }
    }
}
