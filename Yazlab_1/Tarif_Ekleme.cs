using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
    public class Tarif_Ekleme
    {
        private DatabaseHelper dbHelper;

        public Tarif_Ekleme()
        {
            dbHelper = new DatabaseHelper(); // DatabaseHelper nesnesi
        }

        // Tarif ve Malzemeleri Ekleme Metodu
        public void TarifVeMalzemeleriEkle(string tarifAdi, string kategori, int hazirlamaSuresi, string talimatlar, List<Kullanilan_Malzeme> malzemeler)
        {
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Tarif ekleme sorgusu
                    string tarifQuery = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) " +
                                        "OUTPUT INSERTED.TarifID " +
                                        "VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar)";

                    int tarifID;

                    using (SqlCommand tarifCommand = new SqlCommand(tarifQuery, connection, transaction))
                    {
                        tarifCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                        tarifCommand.Parameters.AddWithValue("@Kategori", kategori);
                        tarifCommand.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                        tarifCommand.Parameters.AddWithValue("@Talimatlar", talimatlar);

                        // Yeni eklenen tarifin ID'sini al
                        tarifID = (int)tarifCommand.ExecuteScalar();
                    }

                    // Malzemeleri ekleme sorgusu
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

                    // İşlemi onayla
                    transaction.Commit();
                    MessageBox.Show("Tarif ve malzemeler başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    // Hata durumunda işlemi geri al
                    transaction?.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
    
}
