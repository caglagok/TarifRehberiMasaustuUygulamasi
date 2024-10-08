using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Yazlab_1
{
    public class Malzemeler
    {
        private DatabaseHelper dbHelper;

        public Malzemeler()
        {
            dbHelper = new DatabaseHelper(); // DatabaseHelper nesnesini oluşturuyoruz.
        }
        public int MalzemeID { get; set; }
        public string MalzemeAdi { get; set; }
        public string ToplamMiktar { get; set; }
        public string MalzemeBirim { get; set; }
        public decimal BirimFiyat { get; set; }

        public void MalzemeEkle(string malzemeAdi, string toplamMiktar, string malzemeBirim, decimal birimFiyat)
        {
            using (SqlConnection connection = new SqlConnection(dbHelper.connectionString))
            {
                try
                {
                    connection.Open(); // Veritabanına bağlan
                    MessageBox.Show("Veritabanına başarıyla bağlandı."); // Bağlantı kontrolü

                    // Malzeme ekleme sorgusu
                    string query = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        command.Parameters.AddWithValue("@ToplamMiktar", toplamMiktar);
                        command.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                        command.Parameters.AddWithValue("@BirimFiyat", birimFiyat);

                        int result = command.ExecuteNonQuery(); // Komutu çalıştır
                        if (result > 0)
                        {
                            MessageBox.Show("Malzeme başarıyla eklendi."); // Başarılı ekleme
                        }
                        else
                        {
                            MessageBox.Show("Malzeme eklenemedi."); // Hata durumu
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message); // Hata mesajı
                }
            }
        }
    }

}
