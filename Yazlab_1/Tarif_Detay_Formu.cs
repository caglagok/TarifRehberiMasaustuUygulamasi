using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yazlab_1.Yazlab_1.Yazlab_1;

namespace Yazlab_1
{
    public partial class Tarif_Detay_Formu : Form
    {
        private int _tarifID;

        public Tarif_Detay_Formu(int tarifID)
        {
            InitializeComponent();
            _tarifID = tarifID;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Tarif_Detay_Formu_Load(object sender, EventArgs e)
        {
            TarifDetaylariniGetir(_tarifID);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // Tarif_Ekleme_Formu tarifEklemeFormu = new Tarif_Ekleme_Formu(this); // 'this' ile mevcut Ana_Sayfa formunu geçiyoruz
            //tarifEklemeFormu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TarifMethodları.TarifSil(_tarifID);
        }
        public void TarifDetaylariniGetir(int tarifID)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                // 1. Malzemeleri ve miktarları getir
                string malzemeQuery = @"
            SELECT m.MalzemeAdi, tm.MalzemeMiktar, m.BirimFiyat 
            FROM TarifMalzeme tm
            JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = @TarifID";

                SqlCommand malzemeCommand = new SqlCommand(malzemeQuery, connection);
                malzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);

                connection.Open();
                SqlDataReader reader = malzemeCommand.ExecuteReader();

                while (reader.Read())
                {
                    string malzemeAdi = reader.GetString(0);
                    double miktar = reader.GetDouble(1);
                    decimal birimFiyat = reader.GetDecimal(2);

                    // Malzemeleri ve maliyetlerini DataGridView'e ekle
                    dataGridView1.Rows.Add(malzemeAdi, miktar, birimFiyat);
                }

                reader.Close();

                // 2. Talimatları getir
                string talimatQuery = "SELECT Talimatlar FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand talimatCommand = new SqlCommand(talimatQuery, connection);
                talimatCommand.Parameters.AddWithValue("@TarifID", tarifID);

                string talimatlar = talimatCommand.ExecuteScalar()?.ToString();

                // Talimatları RichTextBox'a ekle
                if (!string.IsNullOrEmpty(talimatlar))
                {
                    richTextBox1.Clear(); // Öncelikle mevcut metni temizle
                    richTextBox1.AppendText(talimatlar); // Talimatları RichTextBox'a ekle
                }

                // 3. Toplam maliyeti hesapla ve göster
                MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();
                decimal toplamMaliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Toplam maliyeti TextBox'a ekle
                textBox1.Text = toplamMaliyet.ToString("C"); // C formatı ile para birimi formatında göster

                connection.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
