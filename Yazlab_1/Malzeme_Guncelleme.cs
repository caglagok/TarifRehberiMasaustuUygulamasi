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
    public partial class Malzeme_Guncelleme : Form
    {
        private MalzemeMethodları malzemeYardimcisi;
        private int malzemeID;

        public Malzeme_Guncelleme(int malzemeID)
        {
            InitializeComponent();
            this.malzemeID = malzemeID; // Malzeme ID'sini sakla
            malzemeYardimcisi = new MalzemeMethodları();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Malzeme_Guncelleme_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0; // Minimum değeri ayarla
            numericUpDown1.Maximum = 100000; // Maksimum değeri ayarla

            LoadMalzemeBilgileri();
        }
        private void LoadMalzemeBilgileri()
        {
            // Malzeme ID'sine göre malzemeyi al
            List<Malzemeler> malzemeListesi = malzemeYardimcisi.GetMalzemeler();
            Malzemeler malzeme = malzemeListesi.Find(m => m.MalzemeID == malzemeID);
            comboBox1.Items.Add("gram");
            comboBox1.Items.Add("mililitre");
         
            if (malzeme != null)
            {
                // Alanları doldur
                // Alanları doldur
                textBox1.Text = malzeme.MalzemeAdi; // Malzeme adını textbox'a ata
                comboBox1.SelectedItem = malzeme.MalzemeBirim.ToString(); // Malzeme birimini combobox'a ata

                // Birim fiyatını ve toplam miktarı numericUpDown kontrollerine ata
                numericUpDown2.Value = malzeme.BirimFiyat; // Birim fiyatını ata
             
                numericUpDown1.Value = Convert.ToDecimal(malzeme.ToplamMiktar); // Toplam miktarı decimal'e çevirip ata
                                                                                // Toplam miktarını ata


            }
            else
            {
                MessageBox.Show("Malzeme bulunamadı.");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text;
            string malzemeBirim = comboBox1.SelectedItem.ToString();
            decimal birimFiyat = numericUpDown1.Value;
            int eklenenMiktar = (int)numericUpDown2.Value;

            // Güncelleme işlemi
            malzemeYardimcisi.MalzemeGuncelle(malzemeID, malzemeAdi, eklenenMiktar.ToString(), malzemeBirim, birimFiyat);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
