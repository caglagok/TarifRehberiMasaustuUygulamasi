using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yazlab_1.Yazlab_1.Yazlab_1;

namespace Yazlab_1
{
    public class TarifMethodları
    {
        public static List<Tarifler> GetTarifler()
        {
            List<Tarifler> tariflerList = new List<Tarifler>();
            DatabaseHelper dbHelper = new DatabaseHelper();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                // Sorguya Talimatlar sütununu ekledik
                string query = "SELECT TarifID, TarifAdi, HazirlamaSuresi, Talimatlar FROM Tarifler";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // TarifID, TarifAdi, HazirlamaSuresi ve Talimatlar'ı okuyarak tarif nesnesini oluşturuyoruz
                    Tarifler tarif = new Tarifler
                    {
                        TarifID = reader.GetInt32(0), // İlk sütun TarifID
                        TarifAdi = reader.GetString(1), // İkinci sütun TarifAdi
                        HazirlamaSuresi = reader.GetInt32(2), // Üçüncü sütun HazirlamaSuresi
                        Talimatlar = reader.GetString(3) // Dördüncü sütun Talimatlar
                    };

                    tariflerList.Add(tarif);
                }

                connection.Close();
            }

            return tariflerList;
        }

        public static void TarifSil(int tarifID)
        {
            DatabaseHelper dbHelper = new DatabaseHelper(); // DatabaseHelper'dan bağlantı al
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                // Transaction kullanarak iki tabloyu da silme işlemi gerçekleştireceğiz
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Önce TarifMalzeme tablosundan sil
                    string deleteMalzemeQuery = "DELETE FROM TarifMalzeme WHERE TarifID = @TarifID";
                    using (SqlCommand deleteMalzemeCommand = new SqlCommand(deleteMalzemeQuery, connection, transaction))
                    {
                        deleteMalzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        deleteMalzemeCommand.ExecuteNonQuery();
                    }

                    // Ardından Tarifler tablosundan sil
                    string deleteTarifQuery = "DELETE FROM Tarifler WHERE TarifID = @TarifID";
                    using (SqlCommand deleteTarifCommand = new SqlCommand(deleteTarifQuery, connection, transaction))
                    {
                        deleteTarifCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        deleteTarifCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Her iki işlem de başarılıysa işlemi onayla
                    MessageBox.Show("Tarif ve ilgili malzemeler başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback(); // Hata durumunda işlemi geri al
                    }
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }
        public static List<Tarifler> SearchTarifler(string searchTerm, List<string> selectedCategories, string selectedCostRange, string selectedIngredientRange, string sortOrder)
        {
            List<Tarifler> tariflerList = new List<Tarifler>();
            DatabaseHelper dbHelper = new DatabaseHelper();
            MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                string query = @"SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi, m.MalzemeID, m.MalzemeAdi, tm.MalzemeMiktar, t.Kategori
                                 FROM Tarifler t
                                 LEFT JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID
                                 LEFT JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                                 WHERE (t.TarifAdi LIKE @SearchTerm OR m.MalzemeAdi LIKE @SearchTerm)";

                // Kategori filtresi ekleme
                if (selectedCategories != null && selectedCategories.Count > 0)
                {
                    string categoriesFilter = string.Join(",", selectedCategories.Select(c => $"'{c}'"));
                    query += $" AND t.Kategori IN ({categoriesFilter})";
                }

                // Malzeme sayısı filtresi ekleme
                if (!string.IsNullOrEmpty(selectedIngredientRange))
                {
                    switch (selectedIngredientRange)
                    {
                        case "0-5":
                            query += " AND (SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = t.TarifID) BETWEEN 0 AND 5";
                            break;
                        case "5-10":
                            query += " AND (SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = t.TarifID) BETWEEN 5 AND 10";
                            break;
                    }
                }

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int tarifID = reader.GetInt32(0);
                    string tarifAdi = reader.GetString(1);
                    int hazirlamaSuresi = reader.GetInt32(2);

                    // Malzeme nesnesi oluştur
                    Malzemeler malzeme = new Malzemeler
                    {
                        MalzemeID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        MalzemeAdi = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    };

                    // Tarif nesnesini kontrol et
                    var tarif = tariflerList.FirstOrDefault(t => t.TarifID == tarifID);
                    if (tarif == null)
                    {
                        // Yeni tarif nesnesi oluştur
                        tarif = new Tarifler
                        {
                            TarifID = tarifID,
                            TarifAdi = tarifAdi,
                            HazirlamaSuresi = hazirlamaSuresi,
                            Malzemeler = new List<Malzemeler>() // Malzemeler listesini başlat
                        };

                        // Maliyet hesapla ve tarif nesnesine ekle
                        tarif.Maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                        tariflerList.Add(tarif);
                    }

                    // Eğer malzeme mevcutsa, tarifin malzemeler listesine ekle
                    if (malzeme.MalzemeID != 0)
                    {
                        tarif.Malzemeler.Add(malzeme);
                    }
                }

                connection.Close();
            }

            // Maliyet aralığı filtresi
            if (!string.IsNullOrEmpty(selectedCostRange))
            {
                tariflerList = tariflerList.Where(t =>
                {
                    decimal totalCost = t.Maliyet;
                    switch (selectedCostRange)
                    {
                        case "0-100 TL":
                            return totalCost >= 0 && totalCost <= 100;
                        case "100-200 TL":
                            return totalCost > 100 && totalCost <= 200;
                        case "200-300 TL":
                            return totalCost > 200 && totalCost <= 300;
                        default:
                            return true;
                    }
                }).ToList();
            }

            // Sıralama işlemi
            switch (sortOrder)
            {
                case "Süreye göre Artan":
                    tariflerList = tariflerList.OrderBy(t => t.HazirlamaSuresi).ToList();
                    break;
                case "Süreye göre Azalan":
                    tariflerList = tariflerList.OrderByDescending(t => t.HazirlamaSuresi).ToList();
                    break;
                case "Maliyete göre Artan":
                    tariflerList = tariflerList.OrderBy(t => t.Maliyet).ToList();
                    break;
                case "Maliyete göre Azalan":
                    tariflerList = tariflerList.OrderByDescending(t => t.Maliyet).ToList();
                    break;
                default:
                    tariflerList = tariflerList.OrderBy(t => t.TarifAdi).ToList(); // Varsayılan olarak tarif adına göre sırala
                    break;
            }

            return tariflerList;
        }
        public string TarifDetaylariniGetir(int tarifID, DataGridView dataGridView1, RichTextBox richTextBox1, TextBox textBox1, PictureBox pictureBox1)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            string tarifAdi = string.Empty; // Tarif adını tutacak değişken

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                // Malzemeleri ve miktarları getir
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

                // Talimatları ve tarif adını getir
                string talimatQuery = "SELECT TarifAdi, Talimatlar, TarifGorseli FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand talimatCommand = new SqlCommand(talimatQuery, connection);
                talimatCommand.Parameters.AddWithValue("@TarifID", tarifID);

                using (SqlDataReader talimatReader = talimatCommand.ExecuteReader())
                {
                    if (talimatReader.Read())
                    {
                        // Tarif adını al
                        tarifAdi = talimatReader["TarifAdi"]?.ToString(); // Tarif adını al
                        string talimatlar = talimatReader["Talimatlar"]?.ToString();
                        if (!string.IsNullOrEmpty(talimatlar))
                        {
                            richTextBox1.Clear(); // Mevcut metni temizle
                            richTextBox1.AppendText(talimatlar); // Yeni talimatları ekle
                        }

                        // Görsel yolunu al ve PictureBox'a yükle
                        string imagePath = talimatReader["TarifGorseli"]?.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            pictureBox1.Image = null; // Varsayılan resim
                        }
                    }
                }

                // Toplam maliyeti hesapla ve göster
                MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();
                decimal toplamMaliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Toplam maliyeti TextBox'a ekle
                textBox1.Text = toplamMaliyet.ToString("C"); // Para birimi formatında göster

                connection.Close();
            }

            return tarifAdi; // Tarif adını döndür
        }

        /*
        public void TarifDetaylariniGetir(int tarifID, DataGridView dataGridView1, RichTextBox richTextBox1, TextBox textBox1, PictureBox pictureBox1)
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
                string talimatQuery = "SELECT Talimatlar, TarifGorseli FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand talimatCommand = new SqlCommand(talimatQuery, connection);
                talimatCommand.Parameters.AddWithValue("@TarifID", tarifID);

                //string talimatlar = talimatCommand.ExecuteScalar()?.ToString();

                using (SqlDataReader talimatReader = talimatCommand.ExecuteReader())
                {
                    if (talimatReader.Read())
                    {
                        // Talimatları RichTextBox'a ekle
                        string talimatlar = talimatReader["Talimatlar"]?.ToString();
                        if (!string.IsNullOrEmpty(talimatlar))
                        {
                            richTextBox1.Clear(); // Mevcut metni temizle
                            richTextBox1.AppendText(talimatlar); // Yeni talimatları ekle
                        }

                        // 3. Görsel yolunu al ve PictureBox'a yükle
                        string imagePath = talimatReader["TarifGorseli"]?.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            pictureBox1.Image = null; // Varsayılan resim
                        }
                    }
                }
                // 3. Toplam maliyeti hesapla ve göster
                MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();
                decimal toplamMaliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                // Toplam maliyeti TextBox'a ekle
                textBox1.Text = toplamMaliyet.ToString("C"); // Para birimi formatında göster

                connection.Close();
            }
        }
        */
    }
}