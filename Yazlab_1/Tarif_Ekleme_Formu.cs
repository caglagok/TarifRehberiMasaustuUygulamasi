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
        public MalzemeMethodları malzeme; 
        private Ana_Sayfa anaSayfaForm;
        private string resimDosyaYolu; 

        public Tarif_Ekleme_Formu(Ana_Sayfa anaSayfa)
        {
            InitializeComponent();
            malzeme = new MalzemeMethodları(); 
            anaSayfaForm = anaSayfa; 

        }

        public void Tarif_Ekleme_Formu_Load(object sender, EventArgs e)
        {
            List<Malzemeler> malzemeListesi = malzeme.GetMalzemeler(); 

            flowLayoutPanel1.AutoScroll = true;

            flowLayoutPanel1.Controls.Clear(); 

            foreach (var malzemeItem in malzemeListesi)
            {
                FlowLayoutPanel malzemePanel = new FlowLayoutPanel();
                malzemePanel.AutoSize = true; 
                malzemePanel.FlowDirection = FlowDirection.LeftToRight; 
                malzemePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink; 

                CheckBox malzemeCheckBox = new CheckBox();
                malzemeCheckBox.Text = malzemeItem.MalzemeAdi; 
                malzemeCheckBox.AutoSize = true;

                NumericUpDown miktarNumericUpDown = new NumericUpDown();
                miktarNumericUpDown.Minimum = 0;
                miktarNumericUpDown.Maximum = 100000; 
                miktarNumericUpDown.DecimalPlaces = 2; 
                miktarNumericUpDown.Width = 90; 

                Label birimLabel = new Label();
                birimLabel.Text = malzemeItem.MalzemeBirim; 
                birimLabel.AutoSize = true;

                malzemePanel.Controls.Add(malzemeCheckBox);
                malzemePanel.Controls.Add(miktarNumericUpDown);
                malzemePanel.Controls.Add(birimLabel);

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

            foreach (Panel malzemePanel in flowLayoutPanel1.Controls)
            {
                CheckBox malzemeCheckBox = (CheckBox)malzemePanel.Controls[0];
                NumericUpDown miktarNumericUpDown = (NumericUpDown)malzemePanel.Controls[1];

                if (malzemeCheckBox.Checked)
                {
                    string malzemeAdi = malzemeCheckBox.Text;
                    float miktar = (float)miktarNumericUpDown.Value;
                    int malzemeID = malzeme.GetMalzemeID(malzemeAdi);

                    if (miktar > 0)
                    {
                        kullanilanMalzemeler.Add(new Kullanilan_Malzeme(malzemeID, miktar));
                    }
                }
            }

            string tarifAdi = textBox1.Text;
            string kategori = comboBox1.SelectedItem?.ToString() ?? "";
            int hazirlamaSuresi = (int)numericUpDown1.Value;
            string talimatlar = richTextBox1.Text;

            Tarif_Ekleme tarifEkleme = new Tarif_Ekleme();
            tarifEkleme.TarifVeMalzemeleriEkle(tarifAdi, kategori, hazirlamaSuresi, talimatlar, kullanilanMalzemeler,resimDosyaYolu);

            this.Close();

            anaSayfaForm.LoadTarifler();
            anaSayfaForm.LoadMalzemeler();

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
        public void MalzemeleriGuncelle()
        {
            Tarif_Ekleme_Formu_Load(this, EventArgs.Empty);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Malzeme_Ekleme malzemeEklemeForm = new Malzeme_Ekleme(anaSayfaForm, this);
            malzemeEklemeForm.ShowDialog();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                resimDosyaYolu = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(resimDosyaYolu); 
            }
        }

        private byte[] ResmiByteArrayOlarakAl(string dosyaYolu)
        {
            using (FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    return br.ReadBytes((int)fs.Length);
                }
            }
        }
    }
}
