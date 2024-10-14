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
    public partial class Tarif_Ekleme_Formu : Form
    {
        public MalzemeMethodları malzeme; // Malzemeler sınıfı için bir nesne
        private Ana_Sayfa anaSayfaForm; // Ana Sayfa formuna referans

        public Tarif_Ekleme_Formu(Ana_Sayfa anaSayfa)
        {
            InitializeComponent();
            malzeme = new MalzemeMethodları(); // Malzemeler nesnesini oluştur
            anaSayfaForm = anaSayfa; // Ana Sayfa formunu sakla
        }


        public void Tarif_Ekleme_Formu_Load(object sender, EventArgs e)
        {
            List<Malzemeler> malzemeListesi = malzeme.GetMalzemeler(); // Malzemeleri getir
                                                                       // flowLayoutPanel1, formunuzda tanımlı FlowLayoutPanel nesnesi
            flowLayoutPanel1.AutoScroll = true;

            // Malzemeleri FlowLayoutPanel'e ekle
            flowLayoutPanel1.Controls.Clear(); // Önce mevcut kontrolleri temizle

            foreach (var malzemeItem in malzemeListesi)
            {
                // Yeni bir Panel oluştur
                FlowLayoutPanel malzemePanel = new FlowLayoutPanel();
                malzemePanel.AutoSize = true; // Panelin otomatik boyutlandırılmasını sağla
                malzemePanel.FlowDirection = FlowDirection.LeftToRight; // Kontrolleri yatay sırala
                malzemePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Boyut değişimine izin ver

                // Seçim için CheckBox
                CheckBox malzemeCheckBox = new CheckBox();
                malzemeCheckBox.Text = malzemeItem.MalzemeAdi; // Malzeme adı
                malzemeCheckBox.AutoSize = true;

                // Miktar giriş alanı
                NumericUpDown miktarNumericUpDown = new NumericUpDown();
                miktarNumericUpDown.Minimum = 0;
                miktarNumericUpDown.Maximum = 100000; // Maksimum değer
                miktarNumericUpDown.DecimalPlaces = 2; // İstenirse ondalık basamak sayısını ayarlayın
                miktarNumericUpDown.Width = 90; // Genişliği ayarlayın

                // Birim yazısı
                Label birimLabel = new Label();
                birimLabel.Text = malzemeItem.MalzemeBirim; // Örneğin "g" veya "ml" veritabanından alınacak
                birimLabel.AutoSize = true;

                // Kontrolleri Panel'e ekle
                malzemePanel.Controls.Add(malzemeCheckBox);
                malzemePanel.Controls.Add(miktarNumericUpDown);
                malzemePanel.Controls.Add(birimLabel);

                // Panel'i FlowLayoutPanel'e ekle
                flowLayoutPanel1.Controls.Add(malzemePanel);


            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<Kullanilan_Malzeme> kullanilanMalzemeler = new List<Kullanilan_Malzeme>();

            // Seçilen malzemeleri ve miktarları al
            foreach (Panel malzemePanel in flowLayoutPanel1.Controls)
            {
                CheckBox malzemeCheckBox = (CheckBox)malzemePanel.Controls[0];
                NumericUpDown miktarNumericUpDown = (NumericUpDown)malzemePanel.Controls[1];

                // Eğer malzeme seçildiyse
                if (malzemeCheckBox.Checked)
                {
                    string malzemeAdi = malzemeCheckBox.Text;
                    float miktar = (float)miktarNumericUpDown.Value; // Miktarı al
                    int malzemeID = malzeme.GetMalzemeID(malzemeAdi); // Malzeme ID'sini al

                    if (miktar > 0)
                    {
                        kullanilanMalzemeler.Add(new Kullanilan_Malzeme(malzemeID, miktar));
                    }
                }
            }

            // Tarif bilgilerini al
            string tarifAdi = textBox1.Text;
            string kategori = comboBox1.SelectedItem?.ToString() ?? "";
            int hazirlamaSuresi = (int)numericUpDown1.Value;
            string talimatlar = richTextBox1.Text;

            // Tarif ekleme işlemini yap
            Tarif_Ekleme tarifEkleme = new Tarif_Ekleme();
            tarifEkleme.TarifVeMalzemeleriEkle(tarifAdi, kategori, hazirlamaSuresi, talimatlar, kullanilanMalzemeler);

            // Tarif eklendikten sonra formu kapat
            this.Close();

            // Ana Sayfa'daki tarifleri güncelle
            anaSayfaForm.LoadTarifler();
        }
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Malzeme_Ekleme malzemeEklemeForm = new Malzeme_Ekleme();
            malzemeEklemeForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tarifeklemegeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
