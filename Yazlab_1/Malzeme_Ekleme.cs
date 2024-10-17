using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Malzeme_Ekleme : Form
    {
        private MalzemeMethodları malzeme;
        
        public Malzeme_Ekleme()
        {
            InitializeComponent();
            malzeme = new MalzemeMethodları();
           
        }

        private void Malzeme_Ekleme_Load_1(object sender, EventArgs e)
        {

            comboBox1.Items.Add("gram");
            comboBox1.Items.Add("mililitre");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text; // Malzeme adı textbox'ından
            string toplamMiktar = numericUpDown1.Value.ToString(); // Toplam miktar numericUpDown'dan
            string malzemeBirim = comboBox1.SelectedItem?.ToString(); // Seçilen birim
            decimal birimFiyat = numericUpDown2.Value; // Birim fiyat numericUpDown'dan

            // Malzeme ekle
            if (!string.IsNullOrWhiteSpace(malzemeAdi) && malzemeBirim != null)
            {
                malzeme.MalzemeEkle(malzemeAdi, toplamMiktar, malzemeBirim, birimFiyat);
            }
            else
            {
                MessageBox.Show("Lütfen malzeme adı ve birim seçin."); // Hata mesajı
            }

            // Bu formu kapat
            this.Close();

         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bu formu kapat
            this.Close();

        }
    }
}