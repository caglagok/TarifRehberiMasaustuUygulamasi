using System;
using System.Linq;
using System.Windows.Forms;

namespace Yazlab_1
{
    public partial class Tarif_Guncelle : Form
    {
        private int tarif_ID; 
        private string resimDosyaYolu; 
        private Ana_Sayfa anaSayfaForm;

        public Tarif_Guncelle(int Tarif_ID, Ana_Sayfa anaSayfaForm)
        {
            tarif_ID = Tarif_ID; 
            InitializeComponent();
          
            this.anaSayfaForm = anaSayfaForm;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

      
        private void Tarif_Guncelle_Load(object sender, EventArgs e)
        {
            Tarifler tarif = TarifMethodları.GetTarifById(tarif_ID);
            flowLayoutPanel1.AutoScroll = true;

            if (tarif != null)
            {
                textBox1.Text = tarif.TarifAdi;
                numericUpDown1.Value = tarif.HazirlamaSuresi;
                richTextBox1.Text = tarif.Talimatlar;
                comboBox1.SelectedItem = tarif.Kategori;

                if (!string.IsNullOrEmpty(tarif.ResimDosyaYolu))
                {
                    resimDosyaYolu = tarif.ResimDosyaYolu; 
                    pictureBox1.Image = Image.FromFile(resimDosyaYolu);
                }

                flowLayoutPanel1.Controls.Clear();

                MalzemeMethodları malzemeMethodları = new MalzemeMethodları();
                var tumMalzemeler = malzemeMethodları.GetMalzemeler();

                foreach (var malzeme in tumMalzemeler)
                {
                    FlowLayoutPanel malzemePanel = new FlowLayoutPanel();
                    malzemePanel.AutoSize = true;
                    malzemePanel.FlowDirection = FlowDirection.LeftToRight;

                    CheckBox malzemeCheckBox = new CheckBox();
                    malzemeCheckBox.Text = malzeme.MalzemeAdi;
                    malzemeCheckBox.Checked = tarif.Malzemeler.Any(m => m.MalzemeAdi == malzeme.MalzemeAdi);
                    malzemeCheckBox.AutoSize = true;

                    NumericUpDown miktarNumericUpDown = new NumericUpDown();
                    miktarNumericUpDown.Minimum = 0;
                    miktarNumericUpDown.Maximum = 100000;
                    miktarNumericUpDown.DecimalPlaces = 2;
                    miktarNumericUpDown.Width = 90;

                    var mevcutMalzeme = tarif.Malzemeler.FirstOrDefault(m => m.MalzemeAdi == malzeme.MalzemeAdi);
                    if (mevcutMalzeme != null && !string.IsNullOrEmpty(mevcutMalzeme.ToplamMiktar))
                    {
                        if (decimal.TryParse(mevcutMalzeme.ToplamMiktar.Replace(',', '.'), out decimal miktar))
                        {
                            miktarNumericUpDown.Value = miktar;
                        }
                        else
                        {
                            miktarNumericUpDown.Value = 0;
                        }
                    }
                    else
                    {
                        miktarNumericUpDown.Value = 0;
                    }

                    Label malzemeIDLabel = new Label();
                    malzemeIDLabel.Text = malzeme.MalzemeID.ToString();
                    malzemeIDLabel.Visible = false;

                    malzemePanel.Controls.Add(malzemeCheckBox);
                    malzemePanel.Controls.Add(miktarNumericUpDown);
                    malzemePanel.Controls.Add(malzemeIDLabel);

                    flowLayoutPanel1.Controls.Add(malzemePanel);
                }

             
            }
        }
        private void tarifekle_Click(object sender, EventArgs e)
        {
            string tarifAdi = textBox1.Text;
            string kategori = comboBox1.SelectedItem?.ToString();
            int hazirlamaSuresi = (int)numericUpDown1.Value;
            string talimatlar = richTextBox1.Text;

            List<Kullanilan_Malzeme> malzemeler = new List<Kullanilan_Malzeme>();

            foreach (FlowLayoutPanel malzemePanel in flowLayoutPanel1.Controls)
            {
                CheckBox malzemeCheckBox = (CheckBox)malzemePanel.Controls[0];
                NumericUpDown miktarNumericUpDown = (NumericUpDown)malzemePanel.Controls[1];
                Label malzemeIDLabel = (Label)malzemePanel.Controls[2];

                if (malzemeCheckBox.Checked)
                {
                    if (int.TryParse(malzemeIDLabel.Text, out int malzemeID))
                    {
                        malzemeler.Add(new Kullanilan_Malzeme(malzemeID, (float)miktarNumericUpDown.Value));
                    }
                    else
                    {
                        MessageBox.Show($"Malzeme ID'si alınırken bir hata oluştu: {malzemeIDLabel.Text}");
                    }
                }
            }

            TarifMethodları.TarifGuncelle(tarif_ID, tarifAdi, kategori, hazirlamaSuresi, talimatlar, malzemeler, resimDosyaYolu);

            anaSayfaForm.LoadTarifler();
            anaSayfaForm.LoadMalzemeler();
            
            if (Application.OpenForms.OfType<Tarif_Detay_Formu>().FirstOrDefault() is Tarif_Detay_Formu detayFormu)
            {
                detayFormu.LoadData(); 
            }

            this.Close();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MalzemeEkleme_Click(object sender, EventArgs e)
        {
            this.Close();

            MalzemeEkleme2 malzemeEklemeForm = new MalzemeEkleme2(anaSayfaForm);
            malzemeEklemeForm.Show();
        }

        private void tarifeklemegeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                resimDosyaYolu = openFileDialog.FileName; 
                pictureBox1.Image = Image.FromFile(resimDosyaYolu);
            }
        }
    }
}
