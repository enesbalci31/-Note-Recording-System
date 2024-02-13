using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Kayıt_Sistemi
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Öğrenci Numarasını  çekmek için
            Ogrenci_Detay frm =new Ogrenci_Detay();
            frm.numara=maskedTextBox1.Text;
            frm.Show();
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Öğrenci girişinden Öğretmen detay a direkt geçiş sağlamak için
            if (maskedTextBox1.Text == "1111") 
            
            {
                Öğretmen_Detay frm = new Öğretmen_Detay();
                frm.Show();


            }


        }
    }
}
