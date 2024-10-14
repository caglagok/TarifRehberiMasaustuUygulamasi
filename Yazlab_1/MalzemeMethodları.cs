using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
    public class MalzemeMethodları
    {
        private DatabaseHelper dbHelper;
        public MalzemeMethodları()
        {
            dbHelper = new DatabaseHelper(); // DatabaseHelper nesnesini oluşturuyoruz.
        }
        private bool MalzemeVarMi(string malzemeAdi, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);

                int count = (int)command.ExecuteScalar(); // Eşleşen kayıt sayısını al
                return count > 0; // Eğer 0'dan büyükse malzeme zaten var
            }
        }
        public void MalzemeGuncelle(int malzemeId, string yeniMalzemeAdi, string yeniToplamMiktar, string yeniMalzemeBirim, decimal yeniBirimFiyat)
        {
            using (SqlConnection connection = new SqlConnection(dbHelper.connectionString))
            {
                try
                {
                    connection.Open(); // Veritabanına bağlan
                    MessageBox.Show("Veritabanına başarıyla bağlandı."); // Bağlantı kontrolü

                    // Malzeme güncelleme sorgusu
                    string updateQuery = "UPDATE Malzemeler SET " +
                                          "MalzemeAdi = @YeniMalzemeAdi, " +
                                          "ToplamMiktar = @YeniToplamMiktar, " +
                                          "MalzemeBirim = @YeniMalzemeBirim, " +
                                          "BirimFiyat = @YeniBirimFiyat " +
                                          "WHERE MalzemeId = @MalzemeId"; // Malzeme adı yerine malzeme ID'sini kullan

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MalzemeId", malzemeId); // Malzeme ID'si için parametre
                        command.Parameters.AddWithValue("@YeniMalzemeAdi", yeniMalzemeAdi);
                        command.Parameters.AddWithValue("@YeniToplamMiktar", yeniToplamMiktar);
                        command.Parameters.AddWithValue("@YeniMalzemeBirim", yeniMalzemeBirim);
                        command.Parameters.AddWithValue("@YeniBirimFiyat", yeniBirimFiyat);

                        int result = command.ExecuteNonQuery(); // Komutu çalıştır

                        if (result > 0)
                        {
                            MessageBox.Show("Malzeme başarıyla güncellendi."); // Başarılı güncelleme
                        }
                        else
                        {
                            MessageBox.Show("Malzeme güncellenemedi. Malzeme ID'si bulunamadı."); // Hata durumu
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message); // Hata mesajı
                }
            }
        }

        public void MalzemeEkle(string malzemeAdi, string toplamMiktar, string malzemeBirim, decimal birimFiyat)
        {
            using (SqlConnection connection = new SqlConnection(dbHelper.connectionString))
            {
                try
                {
                    connection.Open(); // Veritabanına bağlan
                    MessageBox.Show("Veritabanına başarıyla bağlandı."); // Bağlantı kontrolü

                    // Duplicate kontrolü: Aynı isimde malzeme var mı?
                    if (MalzemeVarMi(malzemeAdi, connection))
                    {
                        MessageBox.Show("Bu malzeme zaten mevcut! Lütfen farklı bir malzeme adı girin.");
                        return; // Ekleme işlemini iptal et
                    }

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

        public List<Malzemeler> GetMalzemeler()
        {
            List<Malzemeler> malzemeListesi = new List<Malzemeler>();
            using (SqlConnection connection = new SqlConnection(dbHelper.connectionString))
            {
                connection.Open();
                // SQL sorgusunu güncelleyin
                string query = "SELECT MalzemeID, MalzemeAdi, MalzemeBirim, ToplamMiktar, BirimFiyat FROM Malzemeler ORDER BY MalzemeAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Malzemeler malzeme = new Malzemeler
                        {
                            MalzemeID = Convert.ToInt32(reader["MalzemeID"]), // MalzemeID'yi al
                            MalzemeAdi = reader["MalzemeAdi"].ToString(),
                            MalzemeBirim = reader["MalzemeBirim"].ToString(),
                            ToplamMiktar = reader["ToplamMiktar"].ToString(), // ToplamMiktar'ı al
                            BirimFiyat = Convert.ToDecimal(reader["BirimFiyat"]) // BirimFiyat'ı al
                        };
                        malzemeListesi.Add(malzeme);
                    }
                }
            }
            return malzemeListesi;
        }


        public int GetMalzemeID(string malzemeAdi)
        {
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                string query = "SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                    connection.Open();

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Malzeme bulunamadı: " + malzemeAdi);
                    }
                }
            }
        }
        public void MalzemeSil(string malzemeAdi)
        {
            using (SqlConnection connection = new SqlConnection(dbHelper.connectionString))
            {
                try
                {
                    connection.Open(); // Veritabanına bağlan
                    MessageBox.Show("Veritabanına başarıyla bağlandı."); // Bağlantı kontrolü

                    // Önce TarifMalzeme tablosundan malzemeyi sil
                    string deleteTarifMalzemeQuery = "DELETE FROM TarifMalzeme WHERE MalzemeID = (SELECT MalzemeID FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi)";
                    using (SqlCommand command = new SqlCommand(deleteTarifMalzemeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        command.ExecuteNonQuery(); // Komutu çalıştır
                    }

                    // Ardından Malzeme tablosundan malzemeyi sil
                    string deleteMalzemeQuery = "DELETE FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                    using (SqlCommand command = new SqlCommand(deleteMalzemeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        int result = command.ExecuteNonQuery(); // Komutu çalıştır

                        if (result > 0)
                        {
                            MessageBox.Show("Malzeme başarıyla silindi."); // Başarılı silme
                        }
                        else
                        {
                            MessageBox.Show("Malzeme silinemedi. Malzeme adı bulunamadı."); // Hata durumu
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
