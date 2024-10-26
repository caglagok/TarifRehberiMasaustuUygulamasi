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
            dbHelper = new DatabaseHelper(); 
        }

        private bool TarifVarMi(string tarifAdi, SqlConnection connection, SqlTransaction transaction)
        {
            string query = "SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @TarifAdi";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@TarifAdi", tarifAdi);

                int count = (int)command.ExecuteScalar(); 
                return count > 0; 
            }
        }

        public void TarifVeMalzemeleriEkle(string tarifAdi, string kategori, int hazirlamaSuresi, string talimatlar, List<Kullanilan_Malzeme> malzemeler, string resimDosyaYolu)
        {
            using (SqlConnection connection = dbHelper.GetConnection())
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    //Duplicate kontrolü
                    if (TarifVarMi(tarifAdi, connection, transaction))
                    {
                        MessageBox.Show("Bu tarif zaten mevcut! Lütfen farklı bir tarif adı girin.");
                        transaction.Rollback(); 
                        return;
                    }

                    string tarifQuery = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar,TarifGorseli) " +
                                        "OUTPUT INSERTED.TarifID " +
                                        "VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar,@TarifGorseli)";

                    int tarifID;

                    using (SqlCommand tarifCommand = new SqlCommand(tarifQuery, connection, transaction))
                    {
                        tarifCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                        tarifCommand.Parameters.AddWithValue("@Kategori", kategori);
                        tarifCommand.Parameters.AddWithValue("@HazirlamaSuresi", hazirlamaSuresi);
                        tarifCommand.Parameters.AddWithValue("@Talimatlar", talimatlar);
                        tarifCommand.Parameters.AddWithValue("@TarifGorseli", resimDosyaYolu); 

                        tarifID = (int)tarifCommand.ExecuteScalar();
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
                    MessageBox.Show("Tarif ve malzemeler başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}