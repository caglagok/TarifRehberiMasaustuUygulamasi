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
    public partial class MalzemeEkleme2 : Form
    {
        private MalzemeMethodları malzeme;
        private Ana_Sayfa anaSayfaForm;
        private Tarif_Guncelle tarifEklemeFormu;

        public MalzemeEkleme2(Ana_Sayfa anaSayfa, Tarif_Guncelle tarifEkleme)
        {
            InitializeComponent();
            malzeme = new MalzemeMethodları();
            anaSayfaForm = anaSayfa;
            tarifEklemeFormu = tarifEkleme;
        }

        private void MalzemeEkleme2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("gram");
            comboBox1.Items.Add("mililitre");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string malzemeAdi = textBox1.Text;
            string toplamMiktar = numericUpDown1.Value.ToString();
            string malzemeBirim = comboBox1.SelectedItem?.ToString();
            decimal birimFiyat = numericUpDown2.Value;

            if (!string.IsNullOrWhiteSpace(malzemeAdi) && malzemeBirim != null)
            {
                malzeme.MalzemeEkle(malzemeAdi, toplamMiktar, malzemeBirim, birimFiyat);

                tarifEklemeFormu.MalzemeleriGuncelle();

                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen malzeme adı ve birim seçin.");
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
