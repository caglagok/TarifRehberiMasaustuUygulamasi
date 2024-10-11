using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                string query = "SELECT TarifAdi, HazirlamaSuresi FROM Tarifler";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Tarifler tarif = new Tarifler
                    {
                        TarifAdi = reader.GetString(0),
                        HazirlamaSuresi = reader.GetInt32(1),
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
        public static List<Tarifler> SearchTarifler(string searchTerm)
        {
            List<Tarifler> tariflerList = new List<Tarifler>();
            DatabaseHelper dbHelper = new DatabaseHelper();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                // Tarifler ve Malzemeler arasında ilişki kuran sorgu
                string query = @"
            SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi, 
                   m.MalzemeID, m.MalzemeAdi, tm.MalzemeMiktar,
                   CASE 
                     WHEN t.TarifAdi LIKE @SearchTerm THEN 1 
                     ELSE 2 
                   END AS SortOrder
            FROM Tarifler t
            LEFT JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID
            LEFT JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE t.TarifAdi LIKE @SearchTerm OR m.MalzemeAdi LIKE @SearchTerm
            ORDER BY SortOrder ASC, t.TarifAdi ASC";

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
                        MalzemeID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3), // MalzemeID
                        MalzemeAdi = reader.IsDBNull(4) ? "" : reader.GetString(4), // MalzemeAdi
                       
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
                    if (malzeme.MalzemeID != 0) // Eğer malzeme mevcutsa
                    {
                        tarif.Malzemeler.Add(malzeme);
                    }
                }

                connection.Close();
            }

            return tariflerList;
        }

    }
}