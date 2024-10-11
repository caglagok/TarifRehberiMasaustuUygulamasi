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
    public static List<Tarifler> SearchTarifler(string searchTerm, List<string> selectedCategories, string selectedCostRange, string selectedIngredientRange)
{
    List<Tarifler> tariflerList = new List<Tarifler>();
    DatabaseHelper dbHelper = new DatabaseHelper();
    MaliyetHesaplama maliyetHesaplama = new MaliyetHesaplama();

    using (SqlConnection connection = dbHelper.GetConnection())
    {
        // Tarifler ve Malzemeler arasında ilişki kuran sorgu
        string query = @"
        SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi, 
               m.MalzemeID, m.MalzemeAdi, tm.MalzemeMiktar,
               t.Kategori, 
               (SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = t.TarifID) AS MalzemeSayisi
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

        // Sıralama: Önce tarif adı, ardından malzeme adı
        query += " ORDER BY m.MalzemeAdi ASC , t.TarifAdi ASC";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            // Tarif bilgilerini al
            int tarifID = reader.GetInt32(0);
            string tarifAdi = reader.GetString(1);
            int hazirlamaSuresi = reader.GetInt32(2);

            // Malzeme bilgilerini al
            Malzemeler malzeme = new Malzemeler
            {
                MalzemeID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                MalzemeAdi = reader.IsDBNull(4) ? "" : reader.GetString(4),
            };

            // Eğer tarif daha önce listede yoksa ekle
            var tarif = tariflerList.FirstOrDefault(t => t.TarifID == tarifID);
            if (tarif == null)
            {
                tarif = new Tarifler
                {
                    TarifID = tarifID,
                    TarifAdi = tarifAdi,
                    HazirlamaSuresi = hazirlamaSuresi,
                    Malzemeler = new List<Malzemeler>()
                };
                tariflerList.Add(tarif);
            }

            // Malzemeyi tarifin malzeme listesine ekle
            if (malzeme.MalzemeID != 0)
            {
                tarif.Malzemeler.Add(malzeme);
            }
        }

        connection.Close();
    }

    // Maliyet hesaplaması yap
    foreach (var tarif in tariflerList)
    {
        decimal maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarif.TarifID);
        tarif.Maliyet = maliyet; // Tarifler sınıfına Maliyet özelliğini eklediğinizi varsayıyorum.
    }

    // Maliyet aralığına göre filtreleme
    if (!string.IsNullOrEmpty(selectedCostRange))
    {
        tariflerList = tariflerList.Where(t =>
        {
            decimal totalCost = t.Maliyet; // Tarifin maliyetini al
            switch (selectedCostRange)
            {
                case "0-100 TL":
                    return totalCost >= 0 && totalCost <= 100;
                case "100-200 TL":
                    return totalCost > 100 && totalCost <= 200;
                case "200-300 TL":
                    return totalCost > 200 && totalCost <= 300;
                default:
                    return true; // Varsayılan durumda tüm tarifler döner
            }
        }).ToList();
    }

    return tariflerList;
}



    }
}