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
    public partial class Ogrenci_Detay : Form
    {
        public Ogrenci_Detay()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-M8U6A74;Initial Catalog=DBNotKayıtSistemi;Integrated Security=True;");
       
        private void Öğrenci_Detay_Load(object sender, EventArgs e)
        {
            //ilgili veritabanından öğrenci bilgilerini çekmek için
            label2.Text = numara;
            

            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Ders where  OGRNUMARA=@p1",baglanti);
            cmd.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                label3.Text = dr[2].ToString() + " " + dr[3].ToString();
                label13.Text = dr[4].ToString();
                label12.Text = dr[5].ToString();
                label11.Text = dr[6].ToString();
                label10.Text = dr[7].ToString();
                label14.Text = dr[8].ToString();

            }
            baglanti.Close();



        }
    }
}
