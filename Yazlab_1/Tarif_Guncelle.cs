using System;
using System.Linq;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Tarif_Guncelle : Form
    {
        private int tarif_ID; // Sınıf seviyesinde tanımla

        public Tarif_Guncelle(int Tarif_ID)
        {
            tarif_ID = Tarif_ID; // Constructor'da gelen parametreyi atıyoruz
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Gerekirse buraya kod ekleyebilirsiniz
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Gerekirse buraya kod ekleyebilirsiniz
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // Gerekirse buraya kod ekleyebilirsiniz
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gerekirse buraya kod ekleyebilirsiniz
        }

        /*  private void tarifekle_Click(object sender, EventArgs e)
          {
              // Formdan değerleri al
              string tarifAdi = textBox1.Text;
              string kategori = comboBox1.SelectedItem?.ToString(); // Kategori seçili değilse null döner
              int hazirlamaSuresi = (int)numericUpDown1.Value;
              string talimatlar = richTextBox1.Text;

              // Malzemeleri topla
              List<Kullanilan_Malzeme> malzemeler = new List<Kullanilan_Malzeme>();

              foreach (FlowLayoutPanel malzemePanel in flowLayoutPanel1.Controls)
              {
                  CheckBox malzemeCheckBox = (CheckBox)malzemePanel.Controls[0];
                  NumericUpDown miktarNumericUpDown = (NumericUpDown)malzemePanel.Controls[1];
                  Label malzemeIDLabel = (Label)malzemePanel.Controls[2]; // Malzeme ID'sini al

                  if (malzemeCheckBox.Checked) // Eğer malzeme işaretlenmişse
                  {
                      malzemeler.Add(new Kullanilan_Malzeme
                      {
                          MalzemeID = int.Parse(malzemeIDLabel.Text), // Malzeme ID'sini al
                          Miktar = miktarNumericUpDown.Value // Miktarı al
                      });
                  }
              }

              // Güncelleme işlemini gerçekleştir
              try
              {
                  TarifMethodları.TarifGuncelle(tarif_ID, tarifAdi, kategori, hazirlamaSuresi, talimatlar, malzemeler);
                  MessageBox.Show("Tarif başarıyla güncellendi.");
              }
              catch (Exception ex)
              {
                  MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message);
              }
          }*/
        private void Tarif_Guncelle_Load(object sender, EventArgs e)
        {
            // Tarif bilgilerini ID ile getir
            Tarifler tarif = TarifMethodları.GetTarifById(tarif_ID);

            if (tarif != null)
            {
                // Form alanlarını doldur
                textBox1.Text = tarif.TarifAdi;
                numericUpDown1.Value = tarif.HazirlamaSuresi;
                richTextBox1.Text = tarif.Talimatlar;
                comboBox1.SelectedItem = tarif.Kategori; // Kategoriyi set et

                // FlowLayoutPanel'deki malzemeleri doldur
                flowLayoutPanel1.Controls.Clear(); // Önceki kontrolleri temizle

                // Tüm malzemeleri al
                MalzemeMethodları malzemeMethodları = new MalzemeMethodları(); // Sınıfın bir örneğini oluştur
                var tumMalzemeler = malzemeMethodları.GetMalzemeler(); // Tüm malzemeleri al

                foreach (var malzeme in tumMalzemeler)
                {
                    FlowLayoutPanel malzemePanel = new FlowLayoutPanel();
                    malzemePanel.AutoSize = true;
                    malzemePanel.FlowDirection = FlowDirection.LeftToRight;

                    // CheckBox
                    CheckBox malzemeCheckBox = new CheckBox();
                    malzemeCheckBox.Text = malzeme.MalzemeAdi;
                    malzemeCheckBox.Checked = tarif.Malzemeler.Any(m => m.MalzemeAdi == malzeme.MalzemeAdi); // Mevcut tarifte varsa işaretle
                    malzemeCheckBox.AutoSize = true;

                    // NumericUpDown (Miktar)
                    NumericUpDown miktarNumericUpDown = new NumericUpDown();
                    miktarNumericUpDown.Minimum = 0;
                    miktarNumericUpDown.Maximum = 100000;
                    miktarNumericUpDown.DecimalPlaces = 2;
                    miktarNumericUpDown.Width = 90;

                    // Miktarı set et
                    var mevcutMalzeme = tarif.Malzemeler.FirstOrDefault(m => m.MalzemeAdi == malzeme.MalzemeAdi);
                    if (mevcutMalzeme != null && !string.IsNullOrEmpty(mevcutMalzeme.ToplamMiktar))
                    {
                        if (decimal.TryParse(mevcutMalzeme.ToplamMiktar.Replace(',', '.'), out decimal miktar))
                        {
                            miktarNumericUpDown.Value = miktar; // Dönüşüm başarılı ise değeri ayarla
                        }
                        else
                        {
                            miktarNumericUpDown.Value = 0; // Dönüşüm başarısızsa varsayılan değeri ayarla
                        }
                    }
                    else
                    {
                        miktarNumericUpDown.Value = 0; // Eğer mevcut malzeme yoksa varsayılan değeri ayarla
                    }

                    // Malzeme ID'si Label'ı
                    Label malzemeIDLabel = new Label();
                    malzemeIDLabel.Text = malzeme.MalzemeID.ToString(); // Malzeme ID'sini ayarla
                    malzemeIDLabel.Visible = false; // Görünmez yap

                    // Panel'e ekle
                    malzemePanel.Controls.Add(malzemeCheckBox);
                    malzemePanel.Controls.Add(miktarNumericUpDown);
                    malzemePanel.Controls.Add(malzemeIDLabel); // ID'yi ekle

                    flowLayoutPanel1.Controls.Add(malzemePanel);
                }

                // FlowLayoutPanel boyutlandırma ve scroll özelliği ekleme
                flowLayoutPanel1.AutoScroll = true; // Scroll bar ekle
                flowLayoutPanel1.VerticalScroll.Enabled = true; // Dikey kaydırmayı etkinleştir
                flowLayoutPanel1.Height = 300; // Yüksekliği sabitle
            }
        }

        private void tarifekle_Click(object sender, EventArgs e)
        {
            // Formdan değerleri al
            string tarifAdi = textBox1.Text;
            string kategori = comboBox1.SelectedItem?.ToString(); // Kategori seçili değilse null döner
            int hazirlamaSuresi = (int)numericUpDown1.Value;
            string talimatlar = richTextBox1.Text;

            // Malzemeleri topla
            List<Kullanilan_Malzeme> malzemeler = new List<Kullanilan_Malzeme>();

            foreach (FlowLayoutPanel malzemePanel in flowLayoutPanel1.Controls)
            {
                CheckBox malzemeCheckBox = (CheckBox)malzemePanel.Controls[0];
                NumericUpDown miktarNumericUpDown = (NumericUpDown)malzemePanel.Controls[1];
                Label malzemeIDLabel = (Label)malzemePanel.Controls[2]; // Malzeme ID'sini al

                if (malzemeCheckBox.Checked) // Eğer malzeme işaretlenmişse
                {
                    int malzemeID;
                    if (int.TryParse(malzemeIDLabel.Text, out malzemeID)) // Malzeme ID'sini al
                    {
                        malzemeler.Add(new Kullanilan_Malzeme(malzemeID, (float)miktarNumericUpDown.Value)); // Düzeltme burada
                    }
                    else
                    {
                        MessageBox.Show($"Malzeme ID'si alınırken bir hata oluştu: {malzemeIDLabel.Text}");
                    }
                }
            }

            // Güncelleme işlemini gerçekleştir
            TarifMethodları.TarifGuncelle(tarif_ID, tarifAdi, kategori, hazirlamaSuresi, talimatlar, malzemeler);
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Gerekirse buraya kod ekleyebilirsiniz
        }

        private void MalzemeEkleme_Click(object sender, EventArgs e)
        {
            this.Close();

            Malzeme_Ekleme malzemeEklemeForm = new Malzeme_Ekleme();
            malzemeEklemeForm.Show();
        }

        private void tarifeklemegeri_Click(object sender, EventArgs e)
        {
            
            // Bu formu gizle (kapatmak yerine)
            this.Close();
            
        }
    }
}
