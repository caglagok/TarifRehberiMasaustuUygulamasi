using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazlab_1
{
    using System;
    using System.Data.SqlClient;

    namespace Yazlab_1
    {
        using System;
        using System.Data.SqlClient;

        namespace Yazlab_1
        {
            public class MaliyetHesaplama
            {
                private DatabaseHelper dbHelper;

                public MaliyetHesaplama()
                {
                    dbHelper = new DatabaseHelper();
                }

                // Tarif için maliyet hesaplama metodu
                public decimal TarifMaliyetiHesapla(int tarifID)
                {
                    decimal toplamMaliyet = 0;

                    using (SqlConnection connection = dbHelper.GetConnection())
                    {
                        string query = @"
            SELECT tm.MalzemeID, tm.MalzemeMiktar, m.BirimFiyat, m.ToplamMiktar 
            FROM TarifMalzeme tm
            INNER JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = @TarifID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TarifID", tarifID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int malzemeID = reader.GetInt32(0);
                                double kullanilanMiktar = reader.GetDouble(1); // Bu satırı güncelledim.

                                decimal birimFiyat = reader.GetDecimal(2);
                                float depodakiMiktar = float.Parse(reader.GetString(3)); // ToplamMiktar varchar olduğu için float'a çevriliyor

                                // Malzeme için eksik miktar var mı kontrol et
                                if (depodakiMiktar < kullanilanMiktar)
                                {
                                    double eksikMiktar = kullanilanMiktar - depodakiMiktar;
                                    decimal eksikMiktarDecimal = (decimal)eksikMiktar;

                                    // Eksik miktarın maliyetini toplam maliyete ekle
                                    toplamMaliyet += eksikMiktarDecimal * birimFiyat;
                                }
                             
                            }
                        }
                    }

                    return toplamMaliyet;
                }
            }


        }
    }
}
