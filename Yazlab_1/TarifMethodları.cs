using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
                string query = "SELECT TarifID, TarifAdi, HazirlamaSuresi, Talimatlar FROM Tarifler";

               SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    Tarifler tarif = new Tarifler
                    {
                        TarifID = reader.GetInt32(0), 
                        TarifAdi = reader.GetString(1), 
                        HazirlamaSuresi = reader.GetInt32(2), 
                        Talimatlar = reader.GetString(3) 
                    };

                    tariflerList.Add(tarif);
                }

                connection.Close();
            }

            return tariflerList;
        }

        public static void TarifSil(int tarifID)
        {
            DatabaseHelper dbHelper = new DatabaseHelper(); 
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string deleteMalzemeQuery = "DELETE FROM TarifMalzeme WHERE TarifID = @TarifID";
                    using (SqlCommand deleteMalzemeCommand = new SqlCommand(deleteMalzemeQuery, connection, transaction))
                    {
                        deleteMalzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        deleteMalzemeCommand.ExecuteNonQuery();
                    }

                    string deleteTarifQuery = "DELETE FROM Tarifler WHERE TarifID = @TarifID";
                    using (SqlCommand deleteTarifCommand = new SqlCommand(deleteTarifQuery, connection, transaction))
                    {
                        deleteTarifCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        deleteTarifCommand.ExecuteNonQuery();
                    }

                    transaction.Commit(); 
                    MessageBox.Show("Tarif ve ilgili malzemeler başarıyla silindi.");
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback(); 
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

                if (selectedCategories != null && selectedCategories.Count > 0)
                {
                    string categoriesFilter = string.Join(",", selectedCategories.Select(c => $"'{c}'"));
                    query += $" AND t.Kategori IN ({categoriesFilter})";
                }

                if (!string.IsNullOrEmpty(selectedIngredientRange))
                {
                    string[] ingredientRanges = selectedIngredientRange.Split(',');
                    string rangeConditions = string.Join(" OR ", ingredientRanges.Select(range =>
                    {
                        switch (range)
                        {
                            case "0-5":
                                return "(SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = t.TarifID) BETWEEN 0 AND 5";
                            case "5-10":
                                return "(SELECT COUNT(*) FROM TarifMalzeme WHERE TarifID = t.TarifID) BETWEEN 5 AND 10";
                            default:
                                return "1=1";
                        }
                    }));
                    query += $" AND ({rangeConditions})";
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


                    Malzemeler malzeme = new Malzemeler
                    {
                        MalzemeID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                        MalzemeAdi = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    };


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


                        tarif.Maliyet = maliyetHesaplama.TarifMaliyetiHesapla(tarifID);

                        tariflerList.Add(tarif);
                    }


                    if (malzeme.MalzemeID != 0)
                    {
                        tarif.Malzemeler.Add(malzeme);
                    }
                }

                connection.Close();
            }

            if (!string.IsNullOrEmpty(selectedCostRange))
            {
                string[] costRanges = selectedCostRange.Split(',');
                tariflerList = tariflerList.Where(t =>
                {
                    decimal totalCost = t.Maliyet;
                    return costRanges.Any(range =>
                    {
                        switch (range)
                        {
                            case "0-100 TL":
                                return totalCost >= 0 && totalCost <= 100;
                            case "100-500 TL":
                                return totalCost > 100 && totalCost <= 500;
                            case "500TL ve Üzeri":
                                return totalCost > 500;
                            default:
                                return false;
                        }
                    });
                }).ToList();
            }

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
                    break;
            }

            return tariflerList;
        }

        public string TarifDetaylariniGetir(int tarifID, DataGridView dataGridView1, RichTextBox richTextBox1, TextBox textBox1, PictureBox pictureBox1)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            string tarifAdi = string.Empty; 
            decimal toplamMaliyet = 0;

            using (SqlConnection connection = dbHelper.GetConnection())
            {
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

                    dataGridView1.Rows.Add(malzemeAdi, miktar, birimFiyat);

                    toplamMaliyet += (decimal)miktar * birimFiyat; 
                }

                reader.Close();

                string talimatQuery = "SELECT TarifAdi, Talimatlar, TarifGorseli FROM Tarifler WHERE TarifID = @TarifID";
                SqlCommand talimatCommand = new SqlCommand(talimatQuery, connection);
                talimatCommand.Parameters.AddWithValue("@TarifID", tarifID);

                using (SqlDataReader talimatReader = talimatCommand.ExecuteReader())
                {
                    if (talimatReader.Read())
                    {
                        tarifAdi = talimatReader["TarifAdi"]?.ToString(); 
                        string talimatlar = talimatReader["Talimatlar"]?.ToString();
                        if (!string.IsNullOrEmpty(talimatlar))
                        {
                            richTextBox1.Clear(); 
                            richTextBox1.AppendText(talimatlar); 
                        }

                        string imagePath = talimatReader["TarifGorseli"]?.ToString();
                        if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                        {
                            pictureBox1.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            pictureBox1.Image = null; 
                        }
                    }
                }

                textBox1.Text = toplamMaliyet.ToString("C"); 

                connection.Close();
            }

            return tarifAdi; 
        }


        public static void TarifGuncelle(int tarifID, string tarifAdi, string kategori, int hazirlamaSuresi, string talimatlar, List<Kullanilan_Malzeme> malzemeler, string resimDosyaYolu)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string tarifQuery = "UPDATE Tarifler SET " +
                                        "TarifAdi = @TarifAdi, " +
                                        "Kategori = @Kategori, " +
                                        "HazirlamaSuresi = @HazirlamaSuresi, " +
                                        "Talimatlar = @Talimatlar, " +
                                        "TarifGorseli = @TarifGorseli " + 
                                        "WHERE TarifID = @TarifID";

                    using (SqlCommand tarifCommand = new SqlCommand(tarifQuery, connection, transaction))
                    {
                        tarifCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        tarifCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                        tarifCommand.Parameters.AddWithValue("@Kategori", kategori);
                        tarifCommand.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                        tarifCommand.Parameters.AddWithValue("@Talimatlar", talimatlar);
                        tarifCommand.Parameters.AddWithValue("@TarifGorseli", resimDosyaYolu); 

                        tarifCommand.ExecuteNonQuery();
                    }

                    string deleteMalzemeQuery = "DELETE FROM TarifMalzeme WHERE TarifID = @TarifID";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteMalzemeQuery, connection, transaction))
                    {
                        deleteCommand.Parameters.AddWithValue("@TarifID", tarifID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    foreach (Kullanilan_Malzeme malzeme in malzemeler)
                    {
                        string malzemeQuery = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) " +
                                              "VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";

                        using (SqlCommand malzemeCommand = new SqlCommand(malzemeQuery, connection, transaction))
                        {
                            malzemeCommand.Parameters.AddWithValue("@TarifID", tarifID);
                            malzemeCommand.Parameters.AddWithValue("@MalzemeID", malzeme.MalzemeID);
                            malzemeCommand.Parameters.AddWithValue("@MalzemeMiktar", malzeme.Miktar);

                            malzemeCommand.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Tarif başarıyla güncellendi.");
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        public static Tarifler GetTarifById(int tarifId)
        {
            Tarifler tarif = null;
            DatabaseHelper dbHelper = new DatabaseHelper();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                string query = @"SELECT t.TarifID, t.TarifAdi, t.HazirlamaSuresi, t.Talimatlar, 
                        t.Kategori, t.TarifGorseli, m.MalzemeID, m.MalzemeAdi, m.MalzemeBirim, tm.MalzemeMiktar
                        FROM Tarifler t
                        JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID
                        JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                        WHERE t.TarifID = @TarifID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                tarif = new Tarifler();
                List<Malzemeler> malzemelerListesi = new List<Malzemeler>();

                while (reader.Read())
                {
                    if (tarif.TarifID == 0)
                    {
                        tarif.TarifID = reader.GetInt32(0);
                        tarif.TarifAdi = reader.GetString(1);
                        tarif.HazirlamaSuresi = reader.GetInt32(2);
                        tarif.Talimatlar = reader.GetString(3);
                        tarif.Kategori = reader.GetString(4);
                        tarif.ResimDosyaYolu = reader.GetString(5);
                    }

                    Malzemeler malzeme = new Malzemeler
                    {
                        MalzemeID = reader.GetInt32(6),
                        MalzemeAdi = reader.GetString(7),
                        MalzemeBirim = reader.GetString(8),
                        ToplamMiktar = reader.GetDouble(9).ToString()
                    };

                    malzemelerListesi.Add(malzeme);
                }

                tarif.Malzemeler = malzemelerListesi;
                connection.Close();
            }
            return tarif;
        }
    }
}
