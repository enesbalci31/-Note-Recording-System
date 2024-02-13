using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Not_Kayıt_Sistemi
{
    public partial class Öğretmen_Detay : Form
    {
        public Öğretmen_Detay()
        {
            InitializeComponent();
        }
        //İlgili veritabanına bağlantı sağlamak için 
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-M8U6A74;Initial Catalog=DBNotKayıtSistemi;Integrated Security=True;");
        private void Ogretmen_Detay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNotKayıtSistemiDataSet.Tbl_Ders' table. You can move, or remove it, as needed.
            this.tbl_DersTableAdapter.Fill(this.dBNotKayıtSistemiDataSet.Tbl_Ders);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Öğretmen_Detay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNotKayıtSistemiDataSet1.Tbl_Ders' table. You can move, or remove it, as needed.
            this.tbl_DersTableAdapter1.Fill(this.dBNotKayıtSistemiDataSet1.Tbl_Ders);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Yeni öğrenci kaydetmek için
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Ders (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)", baglanti);
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox1.Text);
            cmd.Parameters.AddWithValue("@p3",textBox2.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi ");
            this.tbl_DersTableAdapter1.Fill(this.dBNotKayıtSistemiDataSet1.Tbl_Ders);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // ilgili veritabanından verileri datagridwiew de göstermek için
            int secilen = dataGridView1.SelectedCells[0].RowIndex;


            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Öğrencilerin ortalamalarını hesaplar
            double ortalama, s1, s2, s3;
            string Durum;  
            s1=Convert.ToDouble(textBox5.Text);
            s2=Convert.ToDouble(textBox4.Text);
            s3=Convert.ToDouble(textBox3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            label12.Text=ortalama.ToString();

            if (ortalama >= 50)
            {

                Durum = "True";

            }
            else 
            {

                Durum = "False";
            
            }

            //Öğrenci Sınav notlarını girmek ve güncellemek için
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Update Tbl_Ders set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,ORTALAMA=@p4,DURUM=@p5 Where OGRNUMARA=@p6 ",baglanti);
            cmd.Parameters.AddWithValue("@p1", textBox5.Text);
            cmd.Parameters.AddWithValue("@p2", textBox4.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", decimal.Parse(label12.Text));
            cmd.Parameters.AddWithValue("@p5", Durum);
            cmd.Parameters.AddWithValue("@p6", maskedTextBox1.Text);
            
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");

            this.tbl_DersTableAdapter1.Fill(this.dBNotKayıtSistemiDataSet1.Tbl_Ders);


        }

    }
}
