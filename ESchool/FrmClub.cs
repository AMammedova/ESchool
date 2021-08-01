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
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_Clubs", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmClub_Load(object sender, EventArgs e)
        {
            list();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmTeacher fr = new FrmTeacher();
            fr.Show();
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Insert into TBL_Clubs (ClubName) values (@p1)", connection);
            komut.Parameters.AddWithValue("@p1", txdclubname.Text);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Club is added", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//e burda datagiridde secilen setri gosterir
        {
            txdclubid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txdclubname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Update Tbl_Clubs set ClubName=@p1 where ClubId=@p2 ", connection);
            komut.Parameters.AddWithValue("@p1", txdclubname.Text);
            komut.Parameters.AddWithValue("@p2",txdclubid.Text);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update is ready", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Delete From TBL_Clubs where ClubId=@p1", connection);
            komut.Parameters.AddWithValue("@p1", txdclubid.Text);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Delete is ready", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
