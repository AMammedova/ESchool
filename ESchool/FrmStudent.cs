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
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From TBL_Clubs",connection );
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbclub.DisplayMember = "ClubName";
            cmbclub.ValueMember = "ClubId";
            cmbclub.DataSource = dt;
            connection.Close();


          

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmTeacher fr = new FrmTeacher();
            fr.Show();
            this.Hide();
        }
        string c = "";
           
private void btnadd_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                c = "Female";
            }
            if (radioButton2.Checked == true)
            {
                c = "Male";
            }

            ds.AddStudent(txdname.Text, txdsurname.Text, byte.Parse(cmbclub.Text),c);
            MessageBox.Show("Add is ready", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();
        }

        private void cmbclub_SelectedIndexChanged(object sender, EventArgs e)
        {
            txdid.Text = cmbclub.SelectedValue.ToString();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            ds.RemoveStudent(int.Parse(txdid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txdid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txdname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txdsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            //connection.Open();
            //SqlCommand komut = new SqlCommand("Select * From TBL_Clubs where ClubId=@p1", connection);
            //komut.Parameters.AddWithValue("@p1", txdid.Text);
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
                cmbclub.Text=dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //
            //SqlDataAdapter da = new SqlDataAdapter(komut);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            ////cmbclub.DisplayMember = "ClubName";
            ////cmbclub.ValueMember = "ClubId";
            //cmbclub.DataSource = dt;
            //connection.Close();
     c= dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (c=="Female")
            {
                radioButton1.Checked=true;
            }
            else
            {
                radioButton2.Checked = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.UpdateStudent(txdname.Text, txdsurname.Text, byte.Parse(cmbclub.SelectedValue.ToString()), c, int.Parse(txdid.Text));
        }

        private void label6_Click(object sender, EventArgs e)

        {
            
            dataGridView1.DataSource = ds.StudentCome(txdsearch.Text);
            txdsearch.Clear();
        }

        private void txdsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
