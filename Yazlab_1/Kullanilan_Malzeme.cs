using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
    public class Kullanilan_Malzeme
    {
        public int MalzemeID { get; set; }
        public float Miktar { get; set; }
        private DatabaseHelper dbHelper;
        public Kullanilan_Malzeme(int malzemeID, float miktar)
        {
            MalzemeID = malzemeID;
            Miktar = miktar;
            dbHelper = new DatabaseHelper();
        }
        public Dictionary<int, int> TarifMalzemeSayilariGetir(List<int> tarifIDs)
        {
            Dictionary<int, int> malzemeSayilariDict = new Dictionary<int, int>();

            using (SqlConnection connection = dbHelper.GetConnection())
            {
                connection.Open();

                foreach (int tarifID in tarifIDs)
                {
                    string query = @"
                                SELECT COUNT(*) 
                                FROM TarifMalzeme 
                                WHERE TarifID = @TarifID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TarifID", tarifID);

                    int malzemeSayisi = (int)command.ExecuteScalar();
                    malzemeSayilariDict[tarifID] = malzemeSayisi;
                }
            }

            return malzemeSayilariDict;
        }

    }
}

