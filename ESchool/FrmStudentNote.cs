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
    public partial class FrmStudentNote : Form
    {
        public FrmStudentNote()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-2VFLNLS\\SQLEXPRESS;Initial Catalog=Okul;Integrated Security=True");
        private void FrmStudentNote_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select LessonName,Exam1,Exam2,Exam3,Project,GPA,Position From TBL_Notes INNER JOIN TBL_Lessons ON TBL_Notes.LessonId = TBL_Lessons.LessonId where StudentId =@p1", connection);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            connection.Open();
            SqlCommand komut1 = new SqlCommand("Select ( StudentName + ' ' + StudentSurname) from TBL_Students where StudentId=@k1", connection);
            komut1.Parameters.AddWithValue("@k1", numara);
            SqlDataReader dt1 = komut1.ExecuteReader();
            while (dt1.Read())
            {
                this.Text = dt1[0].ToString();
            }

            connection.Close();
            



        }
    }
}
